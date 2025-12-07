using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoursesSharesDB.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly Repository _repository;
        private List<Department> _departments;
        private readonly BindingSource _bindingSource;

        // Constructor
        public CourseManagementForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _bindingSource = new BindingSource();

            // Initial data load setup
            LoadFormData();

            // Link DataGridView events to methods that load data into controls
            this.dataGridViewCourses.SelectionChanged += new System.EventHandler(this.dataGridViewCourses_SelectionChanged);
            this.dataGridViewCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCourses_CellClick);

            if (SessionManager.IsStudent)
            {
                // Disable add/update/delete buttons for students
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnManageTopics.Enabled = false;

                // Change button colors to indicate disabled state
                btnAdd.BackColor = System.Drawing.Color.Gray;
                btnUpdate.BackColor = System.Drawing.Color.Gray;
                btnDelete.BackColor = System.Drawing.Color.Gray;
                btnManageTopics.BackColor = System.Drawing.Color.Gray;

                // Show message
                MessageBox.Show("Note: Students can only view courses. Management functions are disabled.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- Core Data Loading and Setup ---

        private void LoadFormData()
        {
            try
            {
                _departments = _repository.GetAllDepartments();

                // Setup Department ComboBoxes (assuming Department has a suitable ToString() or you set DisplayMember/ValueMember)
                cmbDepartments.DataSource = new List<Department>(_departments);
                cmbDepartments.DisplayMember = "Name";
                cmbDepartments.ValueMember = "Id";

                cmbSearchDepartment.DataSource = new List<Department>(_departments);
                cmbSearchDepartment.DisplayMember = "Name";
                cmbSearchDepartment.ValueMember = "Id";

                // Pre-populate Instructors ListBox (assuming a list of instructors is available)
                // If instructors aren't stored in the DB separately, this is a placeholder.
                lstInstructors.Items.Clear();
                lstInstructors.Items.AddRange(new object[] { "Dr. Smith", "Prof. Johnson", "Ms. Davis", "Mr. Brown" });

                btnSearch_Click(null, null); // Run an initial search to populate the grid
                UpdateTotalCourseCount();

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during initial load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalCourseCount()
        {
            var courses = _repository.GetAllCourses();
            lblTotalCourses.Text = $"Total Courses: {courses.Count}";
        }

        // --- Validation and Input Methods ---

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbDepartments.SelectedItem == null ||
                lstInstructors.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please fill in Code, Name, select a Department, and at least one Instructor.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ❌ FIXED: Method required by btnClear event handler
        private void ClearInputs()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            cmbDepartments.SelectedIndex = -1;
            for (int i = 0; i < lstInstructors.Items.Count; i++)
            {
                lstInstructors.SetItemChecked(i, false);
            }
        }

        // --- CRUD Operations ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                var selectedDepts = new List<object>();
                if (cmbDepartments.SelectedItem != null)
                {
                    var dept = (Department)cmbDepartments.SelectedItem;
                    selectedDepts.Add(dept.Id.ToString());
                }

                var selectedInstructors = new List<string>();
                foreach (string item in lstInstructors.CheckedItems)
                {
                    selectedInstructors.Add(item);
                }

                var course = new Course
                {
                    Code = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Departments = selectedDepts,
                    InstructorNames = selectedInstructors,
                    Topics = new List<Course.Topic>()
                };

                _repository.AddCourse(course);

                btnSearch_Click(sender, e);
                ClearInputs();

                MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
                return;

            try
            {
                var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;

                var selectedDepts = new List<object>();
                if (cmbDepartments.SelectedItem != null)
                {
                    var dept = (Department)cmbDepartments.SelectedItem;
                    selectedDepts.Add(dept.Id.ToString());
                }

                var selectedInstructors = new List<string>();
                foreach (string item in lstInstructors.CheckedItems)
                {
                    selectedInstructors.Add(item);
                }

                selectedCourse.Name = txtName.Text.Trim();
                selectedCourse.Description = txtDescription.Text.Trim();
                selectedCourse.Departments = selectedDepts;
                selectedCourse.InstructorNames = selectedInstructors;

                _repository.UpdateCourse(selectedCourse);

                btnSearch_Click(sender, e);
                ClearInputs();

                MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ❌ FIXED: Method required by btnDelete event handler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;

            var result = MessageBox.Show($"Are you sure you want to delete course '{selectedCourse.Name}' ({selectedCourse.Code})? This action cannot be undone.", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.DeleteCourse(selectedCourse.Code);

                    btnSearch_Click(sender, e);
                    ClearInputs();
                    UpdateTotalCourseCount();

                    MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Search and Refresh ---

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var allCourses = _repository.GetAllCourses();
                var filteredCourses = allCourses;

                // Filter by code
                if (!string.IsNullOrWhiteSpace(txtSearchCode.Text))
                {
                    filteredCourses = filteredCourses
                        .Where(c => c.Code.Contains(txtSearchCode.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Filter by name
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                {
                    filteredCourses = filteredCourses
                        .Where(c => c.Name.Contains(txtSearchName.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Filter by department
                if (cmbSearchDepartment.SelectedItem != null && cmbSearchDepartment.SelectedIndex != -1)
                {
                    var selectedDept = (Department)cmbSearchDepartment.SelectedItem;
                    filteredCourses = filteredCourses
                        .Where(c => c.Departments?.Any(d =>
                            d?.ToString() == selectedDept.Id.ToString() ||  // Use ToString()
                            d?.ToString() == selectedDept.Name) == true)
                        .ToList();
                }

                _bindingSource.DataSource = filteredCourses;
                dataGridViewCourses.DataSource = _bindingSource;
                dataGridViewCourses.Refresh();

                lblSearchResults.Text = $"Found {filteredCourses.Count} course(s)";
                UpdateTotalCourseCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ❌ FIXED: Method required by btnRefresh event handler
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchCode.Clear();
            txtSearchName.Clear();
            cmbSearchDepartment.SelectedIndex = -1;
            btnSearch_Click(sender, e);
        }

        // --- DataGridView Events (Load data into details section) ---

        private void LoadCourseDetails(Course course)
        {
            txtCode.Text = course.Code;
            txtName.Text = course.Name;
            txtDescription.Text = course.Description;
            txtCode.ReadOnly = true; // Prevent editing the unique code on update

            // Select department
            if (course.Departments != null && course.Departments.Count > 0)
            {
                var deptKey = course.Departments[0]?.ToString();

                Department dept = _departments
                    .FirstOrDefault(d => d.Id.ToString() == deptKey || d.Name == deptKey);

                cmbDepartments.SelectedItem = dept;
            }
            else
            {
                cmbDepartments.SelectedIndex = -1;
            }

            // Check instructors
            for (int i = 0; i < lstInstructors.Items.Count; i++)
            {
                string instructor = lstInstructors.Items[i].ToString();
                bool isChecked = course.InstructorNames?.Contains(instructor) ?? false;
                lstInstructors.SetItemChecked(i, isChecked);
            }
        }

        // ❌ FIXED: Method required by dataGridViewCourses_SelectionChanged event handler
        private void dataGridViewCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow != null && dataGridViewCourses.CurrentRow.DataBoundItem is Course selectedCourse)
            {
                LoadCourseDetails(selectedCourse);
            }
        }

        // ❌ FIXED: Method required by dataGridViewCourses_CellClick event handler
        private void dataGridViewCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewCourses.Rows[e.RowIndex].DataBoundItem is Course selectedCourse)
            {
                LoadCourseDetails(selectedCourse);
            }
        }

        // --- Other Button Handlers ---

        // ❌ FIXED: Method required by btnClear event handler
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtCode.ReadOnly = false; // Allow editing code for new entries
        }

        // ❌ FIXED: Method required by btnManageTopics event handler
        private void btnManageTopics_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to manage topics for.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;

            // Assuming CourseTopicsForm exists and takes a Course object
            using (var topicsForm = new CourseTopicsForm(selectedCourse))
            {
                topicsForm.ShowDialog();

                // If topics were modified, refresh the data in the grid
                if (topicsForm.TopicsModified)
                {
                    btnSearch_Click(sender, e);
                }
            }
        }

        // ❌ FIXED: Method required by btnClose event handler
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}