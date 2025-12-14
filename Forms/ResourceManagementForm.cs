using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace CoursesSharesDB.Forms
{
    public partial class ResourceManagementForm : Form
    {
        private Repository _repository;
        private BindingSource _bindingSource;

        public ResourceManagementForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _bindingSource = new BindingSource();

            ApplyModernStyle();

            LoadComboBoxes();
            LoadResources();

            // Anchoring
            this.Load += (s, e) => ApplyAnchoring();

            CheckPermissions();
        }

        private void ApplyModernStyle()
        {
            dataGridViewResources.EnableHeadersVisualStyles = false;
            dataGridViewResources.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69); // Green theme for resources
            dataGridViewResources.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewResources.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewResources.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Disable manual ID entry
            txtId.ReadOnly = true;
            txtId.BackColor = SystemColors.ControlLight;
            txtId.BackColor = SystemColors.ControlLight;
            txtId.BackColor = SystemColors.ControlLight;
            txtId.Text = "Auto-Generated";

            // Disable Reactions (Read-only)
            txtReactions.ReadOnly = true;
            txtReactions.BackColor = SystemColors.ControlLight;
        }

        private void ApplyAnchoring()
        {
            dataGridViewResources.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Expand name/desc fields
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContentUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void LoadResources()
        {
            try
            {
                var resources = GetAllowedResources();
                _bindingSource.DataSource = resources;
                dataGridViewResources.DataSource = _bindingSource;
                lblTotalResources.Text = $"Total Resources: {resources.Count}";
                SetupDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading resources: " + ex.Message);
            }
        }

        private List<Resource> GetAllowedResources()
        {
            var allResources = _repository.GetAllResources();

            // If Admin, see everything
            if (SessionManager.IsAdmin || SessionManager.CurrentUser == null)
                return allResources;

            // If Instructor, see only resources for their courses
            if (SessionManager.IsInstructor)
            {
                string username = SessionManager.CurrentUser.Username;
                var allCourses = _repository.GetAllCourses();

                // Find course codes where this user is an instructor
                var myCourseCodes = allCourses
                    .Where(c => IsInstructorForCourse(c, username))
                    .Select(c => c.Code)
                    .ToList();

                return allResources.Where(r => myCourseCodes.Contains(r.CourseCode)).ToList();
            }

            // Students or others see all (read-only view)
            return allResources;
        }

        private bool IsInstructorForCourse(Course course, string username)
        {
            if (course.InstructorNames == null) return false;

            return course.InstructorNames.Any(name =>
            {
                // Remove titles and extra spaces
                string cleanedName = name.Replace("Dr. ", "").Replace("Prof. ", "").Replace("Eng. ", "")
                                         .Replace("  ", " ").Trim();
                // Convert to username style
                string nameAsUsername = cleanedName.ToLower().Replace(" ", "_");

                return nameAsUsername.Equals(username, StringComparison.OrdinalIgnoreCase);
            });
        }

        private void SetupDataGridViewColumns()
        {
            dataGridViewResources.AutoGenerateColumns = false;
            // Ensure columns exist (usually done in Designer, but safety check here)
            if (dataGridViewResources.Columns.Count == 0)
            {
                // Add columns programmatically if Designer didn't
                dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 50 });
                dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Width = 200 });
                dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CourseCode", HeaderText = "Course", Width = 80 });
                dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UploaderUsername", HeaderText = "Uploader", Width = 100 });
                dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UploadDate", HeaderText = "Date", Width = 100 });
            }
        }

        private void LoadComboBoxes()
        {
            // Course Codes
            var courses = _repository.GetAllCourses();
            cmbCourseCode.DataSource = courses;
            cmbCourseCode.DisplayMember = "Code";
            cmbCourseCode.ValueMember = "Code";

            // Categories
            var categories = _repository.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            // Uploaders (Users)
            var users = _repository.GetAllUsers();
            cmbUploader.DataSource = users;
            cmbUploader.DisplayMember = "Username";
            cmbUploader.ValueMember = "Username";

            // If not admin, lock uploader to current user
            if (!SessionManager.IsAdmin && SessionManager.CurrentUser != null)
            {
                cmbUploader.SelectedValue = SessionManager.CurrentUser.Username;
                cmbUploader.Enabled = false;
            }

            // Static Types
            cmbContentType.Items.Clear();
            cmbContentType.Items.AddRange(new string[] { "File", "Link", "Video", "Document" });

            cmbFileType.Items.Clear();
            cmbFileType.Items.AddRange(new string[] { "PDF", "DOCX", "PPTX", "TXT", "ZIP", "None" });
        }

        private void CheckPermissions()
        {
            if (SessionManager.IsStudent)
            {
                // Students can only view
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnBrowse.Enabled = false; // Disable upload for students

                // Visual cues
                btnAdd.BackColor = Color.LightGray;
                btnUpdate.BackColor = Color.LightGray;
                btnDelete.BackColor = Color.LightGray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var resource = new Resource
                {
                    Id = _repository.GetNextResourceId(), // Auto-generate ID
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CourseCode = cmbCourseCode.SelectedValue.ToString(),

                    UploaderUsername = (!SessionManager.IsAdmin && SessionManager.CurrentUser != null)
                        ? SessionManager.CurrentUser.Username
                        : cmbUploader.SelectedValue.ToString(),
                    CategoryId = (int)cmbCategory.SelectedValue,
                    UploadDate = dtpUploadDate.Value,
                    Content = new Content
                    {
                        Type = cmbContentType.Text,
                        Url = txtContentUrl.Text.Trim(),
                        FileType = cmbFileType.Text
                    },
                    Topics = cmbTopics.SelectedValue != null ? new List<int> { (int)cmbTopics.SelectedValue } : new List<int>(),
                    Reactions = ParseReactions(txtReactions.Text)
                };

                _repository.InsertResource(resource);
                MessageBox.Show("Resource added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadResources();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding resource: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null) return;
            if (!ValidateInputs()) return;

            try
            {
                var currentRes = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;

                // Permission Check
                if (!SessionManager.IsAdmin && SessionManager.CurrentUser != null)
                {
                    if (currentRes.UploaderUsername != SessionManager.CurrentUser.Username)
                    {
                        MessageBox.Show("You can only modify resources you uploaded.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Update properties
                currentRes.Name = txtName.Text.Trim();
                currentRes.Description = txtDescription.Text.Trim();
                currentRes.CourseCode = cmbCourseCode.SelectedValue.ToString();
                currentRes.UploaderUsername = cmbUploader.SelectedValue.ToString();
                currentRes.CategoryId = (int)cmbCategory.SelectedValue;
                currentRes.UploadDate = dtpUploadDate.Value;
                currentRes.Content.Type = cmbContentType.Text;
                currentRes.Content.Url = txtContentUrl.Text.Trim();
                currentRes.Content.FileType = cmbFileType.Text;
                currentRes.Topics = cmbTopics.SelectedValue != null ? new List<int> { (int)cmbTopics.SelectedValue } : new List<int>();
                currentRes.Reactions = ParseReactions(txtReactions.Text);

                if (_repository.UpdateResource(currentRes))
                {
                    MessageBox.Show("Resource updated successfully!");
                    LoadResources();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating: {ex.Message}");
            }
        }

        // Helper to parse comma-separated strings
        private List<string> ParseReactions(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new List<string>();
            return input.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        private void cmbCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourseCode.SelectedValue == null)
            {
                cmbTopics.DataSource = null;
                return;
            }

            string courseCode = cmbCourseCode.SelectedValue.ToString();
            var course = _repository.GetCourseByCode(courseCode);

            if (course != null && course.Topics != null)
            {
                cmbTopics.DataSource = course.Topics;
                cmbTopics.DisplayMember = "Name";
                cmbTopics.ValueMember = "TopicId";
            }
            else
            {
                cmbTopics.DataSource = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null) return;
            var res = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;

            // Permission Check
            if (!SessionManager.IsAdmin && SessionManager.CurrentUser != null)
            {
                if (res.UploaderUsername != SessionManager.CurrentUser.Username)
                {
                    MessageBox.Show("You can only delete resources you uploaded.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show($"Delete resource '{res.Name}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repository.DeleteResource(res.Id);
                LoadResources();
                ClearForm();
            }
        }

        private void dataGridViewResources_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null) return;

            var res = dataGridViewResources.CurrentRow.DataBoundItem as Resource;
            if (res == null) return;

            txtId.Text = res.Id.ToString();
            txtName.Text = res.Name ?? "";
            txtDescription.Text = res.Description ?? "";

            if (res.CourseCode != null) cmbCourseCode.SelectedValue = res.CourseCode;
            if (res.UploaderUsername != null) cmbUploader.SelectedValue = res.UploaderUsername;

            // Handle CategoryId safely if it's 0 or invalid
            try { cmbCategory.SelectedValue = res.CategoryId; } catch { }

            dtpUploadDate.Value = res.UploadDate > DateTime.MinValue ? res.UploadDate : DateTime.Now;

            if (res.Content != null)
            {
                cmbContentType.Text = res.Content.Type ?? "File";
                txtContentUrl.Text = res.Content.Url ?? "";
                cmbFileType.Text = res.Content.FileType ?? "None";
            }
            else
            {
                cmbContentType.SelectedIndex = -1;
                txtContentUrl.Clear();
                cmbFileType.SelectedIndex = -1;
            }

            if (res.Topics != null && res.Topics.Count > 0)
                cmbTopics.SelectedValue = res.Topics[0];
            else
                cmbTopics.SelectedIndex = -1;

            txtReactions.Text = res.Reactions != null ? string.Join(", ", res.Reactions) : "";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                return false;
            }
            if (cmbCourseCode.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Course.");
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Category.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtId.Text = "Auto-Generated";
            txtName.Clear();
            txtDescription.Clear();
            cmbCourseCode.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;

            // Set Uploader
            if (!SessionManager.IsAdmin && SessionManager.CurrentUser != null)
            {
                cmbUploader.SelectedValue = SessionManager.CurrentUser.Username;
                cmbUploader.Enabled = false;
            }
            else
            {
                cmbUploader.SelectedIndex = -1;
                cmbUploader.Enabled = true;
            }

            txtContentUrl.Clear();
            cmbTopics.SelectedIndex = -1;
            txtReactions.Clear();
            dtpUploadDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
        private void btnClose_Click(object sender, EventArgs e) => Close();

        // Search Handlers
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = GetAllowedResources();

            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                list = list.Where(r => r.Name.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(txtSearchCourseCode.Text))
                list = list.Where(r => r.CourseCode.ToLower().Contains(txtSearchCourseCode.Text.ToLower())).ToList();

            _bindingSource.DataSource = list;
            dataGridViewResources.DataSource = _bindingSource;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            txtSearchCourseCode.Clear();
            LoadResources();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Resource File";
                ofd.Filter = "All Files|*.*|PDF Documents|*.pdf|Word Documents|*.docx|PowerPoint Presentations|*.pptx|Videos|*.mp4";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourcePath = ofd.FileName;
                        string filename = Path.GetFileName(sourcePath);
                        string uploadsDir = Path.Combine(Application.StartupPath, "Uploads");

                        if (!Directory.Exists(uploadsDir))
                            Directory.CreateDirectory(uploadsDir);

                        // Create unique filename
                        string uniqueName = $"{Path.GetFileNameWithoutExtension(filename)}_{DateTime.Now.Ticks}{Path.GetExtension(filename)}";
                        string destPath = Path.Combine(uploadsDir, uniqueName);

                        File.Copy(sourcePath, destPath);

                        // Set relative path in URL box
                        txtContentUrl.Text = $"Uploads/{uniqueName}";

                        // Auto-detect types
                        string ext = Path.GetExtension(filename).Trim('.').ToUpper();
                        cmbContentType.Text = (ext == "MP4" || ext == "AVI") ? "Video" : "File";

                        if (ext == "PDF") cmbFileType.Text = "PDF";
                        else if (ext == "DOCX") cmbFileType.Text = "DOCX";
                        else if (ext == "PPTX") cmbFileType.Text = "PPTX";
                        else if (ext == "TXT") cmbFileType.Text = "TXT";
                        else if (ext == "ZIP") cmbFileType.Text = "ZIP";
                        else cmbFileType.Text = "None";

                        MessageBox.Show("File uploaded successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Upload failed: {ex.Message}", "Error");
                    }
                }
            }
        }

        private void lblSearchCourse_Click(object sender, EventArgs e)
        {

        }
    }
}