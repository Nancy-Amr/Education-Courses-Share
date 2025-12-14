using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Drawing; // for UI colors
using System.Linq;
using System.Windows.Forms;

namespace CoursesSharesDB.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly Repository _repository;
        private List<Department> _departments;
        private readonly BindingSource _bindingSource;

        public CourseManagementForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _bindingSource = new BindingSource();
            
            // UI Styling
            ApplyModernStyle();

            LoadFormData();
            
            // Event Wiring
            this.dataGridViewCourses.SelectionChanged += new EventHandler(this.dataGridViewCourses_SelectionChanged);
            this.dataGridViewCourses.CellClick += new DataGridViewCellEventHandler(this.dataGridViewCourses_CellClick);
            this.dataGridViewCourses.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridViewCourses_ColumnHeaderMouseClick);
            this.Load += (s, e) => ApplyAnchoring(); // Apply resizing logic on load

            CheckPermissions();
        }

        private void ApplyModernStyle()
        {
            // Flat look for DataGridView
            dataGridViewCourses.EnableHeadersVisualStyles = false;
            dataGridViewCourses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewCourses.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewCourses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void ApplyAnchoring()
        {
            // Make grid expand
            dataGridViewCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            // Keep buttons at the bottom
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnManageTopics.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Keep details group at bottom
            grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            // Make text boxes in details expand
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstInstructors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void CheckPermissions()
        {
            if (SessionManager.IsStudent)
            {
                // Students: no editing allowed
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnManageTopics.Enabled = false;
                
                // Visual cue for disabled state
                btnAdd.BackColor = Color.LightGray;
                btnUpdate.BackColor = Color.LightGray;
                btnDelete.BackColor = Color.LightGray;
                btnManageTopics.BackColor = Color.LightGray;
            }
            else if (SessionManager.IsInstructor)
            {
                // Instructors: can only add courses they will instruct
                // Update/Delete will be validated per-course in the button click handlers
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnManageTopics.Enabled = true;
            }
            // Admin has full access (all buttons enabled by default)
        }

        private void LoadFormData()
        {
            try
            {
                _departments = _repository.GetAllDepartments();
                
                // Setup Departments
                cmbDepartments.DataSource = new List<Department>(_departments);
                cmbDepartments.DisplayMember = "Name";
                cmbDepartments.ValueMember = "Id";

                // Setup Search Departments
                var searchDepts = new List<Department>(_departments);
                searchDepts.Insert(0, new Department { Id = -1, Name = "All Departments" }); // Add "All" option
                cmbSearchDepartment.DataSource = searchDepts;
                cmbSearchDepartment.DisplayMember = "Name";
                cmbSearchDepartment.ValueMember = "Id";

                // Mock Instructors (You should ideally fetch these from a Users collection filtered by role)
                lstInstructors.Items.Clear();
                var instructors = _repository.GetAllUsers().Where(u => u.Role == "instructor").ToList();
                if(instructors.Any())
                {
                    foreach(var inst in instructors) lstInstructors.Items.Add(inst.Username);
                }
                else 
                {
                    // Fallback if no instructors in DB
                    lstInstructors.Items.AddRange(new object[] { "Dr. Smith", "Prof. Johnson", "Ms. Davis" });
                }

                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalCourseCount()
        {
            lblTotalCourses.Text = $"Total Courses: {dataGridViewCourses.Rows.Count}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                // Verify uniqueness
                if (_repository.GetCourseByCode(txtCode.Text.Trim()) != null)
                {
                    MessageBox.Show("A course with this code already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var course = CreateCourseFromInput();
                _repository.AddCourse(course);

                MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSearch_Click(sender, e);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null) return;
            if (!ValidateInputs()) return;

            try
            {
                var originalCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
                
                // Check if instructor is authorized to update this course
                if (SessionManager.IsInstructor && SessionManager.CurrentUser != null)
                {
                    string instructorUsername = SessionManager.CurrentUser.Username;
                    bool isAuthorized = originalCourse.InstructorNames.Any(name =>
                    {
                        // Remove "Dr.", "Prof.", "Eng.", etc. and compare
                        string cleanedName = name.Replace("Dr. ", "").Replace("Prof. ", "").Replace("Eng. ", "")
                                                 .Replace("  ", " ").Trim();
                        // Convert to username format (lowercase, spaces to underscores)
                        string nameAsUsername = cleanedName.ToLower().Replace(" ", "_");
                        return nameAsUsername.Equals(instructorUsername, StringComparison.OrdinalIgnoreCase);
                    });
                    
                    if (!isAuthorized)
                    {
                        MessageBox.Show("You can only update courses where you are listed as an instructor.", 
                            "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                var updatedCourse = CreateCourseFromInput();
                
                // Keep the original code and ID
                updatedCourse.Id = originalCourse.Id;
                updatedCourse.Code = originalCourse.Code;
                
                // IMPORTANT: Preserve the original instructor names as they are stored in DB format (e.g., "Dr. Nivin Atef")
                // The form uses usernames in the CheckedListBox, but DB needs display names
                // UPDATED: Use the instructor names from the input (updatedCourse) instead of the original ones
                // updatedCourse.InstructorNames = originalCourse.InstructorNames;
                
                // Preserve topics as they aren't edited here
                updatedCourse.Topics = originalCourse.Topics;

                if(_repository.UpdateCourse(updatedCourse))
                {
                    MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearch_Click(sender, e);
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Course CreateCourseFromInput()
        {
            var selectedDepts = new List<object>();
            if (cmbDepartments.SelectedItem != null)
            {
                // Store the ID as string to be consistent with your existing data structure
                var dept = (Department)cmbDepartments.SelectedItem;
                selectedDepts.Add(dept.Id.ToString());
            }

            var selectedInstructors = new List<string>();
            foreach (string item in lstInstructors.CheckedItems)
            {
                // Convert username to display name format
                // item is like "nivin_atef", need to convert to "Dr. Nivin Atef"
                string displayName = ConvertUsernameToDisplayName(item);
                selectedInstructors.Add(displayName);
            }

            return new Course
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Departments = selectedDepts,
                InstructorNames = selectedInstructors,
                Topics = new List<Course.Topic>()
            };
        }

        private string ConvertUsernameToDisplayName(string username)
        {
            // Convert username format (nivin_atef) to display name format (Dr. Nivin Atef)
            // Split by underscore, capitalize each part, join with space
            var parts = username.Split('_');
            var capitalizedParts = parts.Select(p => char.ToUpper(p[0]) + p.Substring(1));
            var fullName = string.Join(" ", capitalizedParts);
            
            // Add title prefix based on role
            // For instructors, use "Dr." prefix (you can customize this based on your needs)
            return $"Dr. {fullName}";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Course Code is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Course Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null) return;

            var course = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
            
            // Check if instructor is authorized to delete this course
            if (SessionManager.IsInstructor && SessionManager.CurrentUser != null)
            {
                string instructorUsername = SessionManager.CurrentUser.Username;
                bool isAuthorized = course.InstructorNames.Any(name =>
                {
                    // Remove "Dr.", "Prof.", "Eng.", etc. and compare
                    string cleanedName = name.Replace("Dr. ", "").Replace("Prof. ", "").Replace("Eng. ", "")
                                             .Replace("  ", " ").Trim();
                    // Convert to username format (lowercase, spaces to underscores)
                    string nameAsUsername = cleanedName.ToLower().Replace(" ", "_");
                    return nameAsUsername.Equals(instructorUsername, StringComparison.OrdinalIgnoreCase);
                });
                
                if (!isAuthorized)
                {
                    MessageBox.Show("You can only delete courses where you are listed as an instructor.", 
                        "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (MessageBox.Show($"Delete course '{course.Name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _repository.DeleteCourse(course.Code);
                btnSearch_Click(sender, e);
                ClearInputs();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var courses = _repository.GetAllCourses();
            
            // Filter by instructor if current user is an instructor
            if (SessionManager.IsInstructor && SessionManager.CurrentUser != null)
            {
                string instructorUsername = SessionManager.CurrentUser.Username;
                
                // Match username against instructor display names
                // Database stores instructor display names like "Dr. Nivin Atef"
                // We need to match against username "nivin_atef"
                courses = courses.Where(c => c.InstructorNames != null && 
                    c.InstructorNames.Any(name => 
                    {
                        // Remove "Dr.", "Prof.", "Eng.", etc. and compare
                        string cleanedName = name.Replace("Dr. ", "").Replace("Prof. ", "").Replace("Eng. ", "")
                                                 .Replace("  ", " ").Trim();
                        // Convert to username format (lowercase, spaces to underscores)
                        string nameAsUsername = cleanedName.ToLower().Replace(" ", "_");
                        return nameAsUsername.Equals(instructorUsername, StringComparison.OrdinalIgnoreCase);
                    })).ToList();
            }
            
            if (!string.IsNullOrWhiteSpace(txtSearchCode.Text))
                courses = courses.Where(c => c.Code.IndexOf(txtSearchCode.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            
            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                courses = courses.Where(c => c.Name.IndexOf(txtSearchName.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            
            if (cmbSearchDepartment.SelectedIndex > 0) // Index 0 is "All"
            {
                var deptId = cmbSearchDepartment.SelectedValue.ToString();
                courses = courses.Where(c => c.DepartmentStrings.Contains(deptId)).ToList();
            }

            _bindingSource.DataSource = courses;
            dataGridViewCourses.DataSource = _bindingSource;
            UpdateTotalCourseCount();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchCode.Clear();
            txtSearchName.Clear();
            cmbSearchDepartment.SelectedIndex = 0;
            btnSearch_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtCode.ReadOnly = false;
        }

        private void ClearInputs()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            cmbDepartments.SelectedIndex = -1;
            for (int i = 0; i < lstInstructors.Items.Count; i++) lstInstructors.SetItemChecked(i, false);
        }

        private void dataGridViewCourses_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedCourse();
        }

        private void dataGridViewCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedCourse();
        }

        private void LoadSelectedCourse()
        {
            if (dataGridViewCourses.CurrentRow == null) return;
            
            var course = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
            txtCode.Text = course.Code;
            txtCode.ReadOnly = true; // Cannot change code of existing course
            txtName.Text = course.Name;
            txtDescription.Text = course.Description;

            // Load Dept
            if (course.DepartmentStrings.Count > 0)
            {
                // Try to find by ID
                foreach(Department item in cmbDepartments.Items)
                {
                    if(item.Id.ToString() == course.DepartmentStrings[0])
                    {
                        cmbDepartments.SelectedItem = item;
                        break;
                    }
                }
            }

            // Load Instructors
            for (int i = 0; i < lstInstructors.Items.Count; i++)
            {
                string name = lstInstructors.Items[i].ToString();
                string username = lstInstructors.Items[i].ToString();
                string displayName = ConvertUsernameToDisplayName(username);
                // Check if the display name exists in the course's instructor list
                // We use Contains with case-insensitivity just to be safe, though exact match should work if data is clean
                bool isAssigned = course.InstructorNames.Any(n => n.Equals(displayName, StringComparison.OrdinalIgnoreCase));
                lstInstructors.SetItemChecked(i, isAssigned);
            }
        }

        private void btnManageTopics_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null) return;
            
            var course = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
            
            // Check if instructor is authorized to manage topics for this course
            if (SessionManager.IsInstructor && SessionManager.CurrentUser != null)
            {
                string instructorUsername = SessionManager.CurrentUser.Username;
                bool isAuthorized = course.InstructorNames.Any(name =>
                {
                    // Remove "Dr.", "Prof.", "Eng.", etc. and compare
                    string cleanedName = name.Replace("Dr. ", "").Replace("Prof. ", "").Replace("Eng. ", "")
                                             .Replace("  ", " ").Trim();
                    // Convert to username format (lowercase, spaces to underscores)
                    string nameAsUsername = cleanedName.ToLower().Replace(" ", "_");
                    return nameAsUsername.Equals(instructorUsername, StringComparison.OrdinalIgnoreCase);
                });
                
                if (!isAuthorized)
                {
                    MessageBox.Show("You can only manage topics for courses where you are listed as an instructor.", 
                        "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            using (var form = new CourseTopicsForm(course))
            {
                form.ShowDialog();
                if (form.TopicsModified)
                {
                    // Refresh data from DB to get updated topics
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private System.ComponentModel.ListSortDirection _lastSortDirection = System.ComponentModel.ListSortDirection.Ascending;
        private string _lastSortColumn = "";

        private void dataGridViewCourses_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridViewCourses.Columns[e.ColumnIndex].DataPropertyName != null)
            {
                string columnName = dataGridViewCourses.Columns[e.ColumnIndex].DataPropertyName;
                
                // Determine sort direction
                System.ComponentModel.ListSortDirection direction;
                if (_lastSortColumn == columnName)
                {
                    direction = _lastSortDirection == System.ComponentModel.ListSortDirection.Ascending 
                        ? System.ComponentModel.ListSortDirection.Descending 
                        : System.ComponentModel.ListSortDirection.Ascending;
                }
                else
                {
                    direction = System.ComponentModel.ListSortDirection.Ascending;
                }

                // Get current list
                var courses = (List<Course>)_bindingSource.DataSource;
                
                // Sort the list
                if (direction == System.ComponentModel.ListSortDirection.Ascending)
                {
                    courses = courses.OrderBy(c => c.GetType().GetProperty(columnName)?.GetValue(c)).ToList();
                }
                else
                {
                    courses = courses.OrderByDescending(c => c.GetType().GetProperty(columnName)?.GetValue(c)).ToList();
                }

                // Update binding source
                _bindingSource.DataSource = courses;
                _bindingSource.ResetBindings(false);

                // Set sort glyph
                dataGridViewCourses.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = 
                    direction == System.ComponentModel.ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

                // Clear other column glyphs
                for (int i = 0; i < dataGridViewCourses.Columns.Count; i++)
                {
                    if (i != e.ColumnIndex)
                    {
                        dataGridViewCourses.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }

                // Remember last sort
                _lastSortColumn = columnName;
                _lastSortDirection = direction;
            }
        }
    }
}