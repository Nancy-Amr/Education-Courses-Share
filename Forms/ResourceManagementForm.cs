using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            txtId.Text = "Auto-Generated";
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
                var resources = _repository.GetAllResources();
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

            // Static Types
            cmbContentType.Items.Clear();
            cmbContentType.Items.AddRange(new string[] { "File", "Link", "Video", "Document" });
            
            cmbFileType.Items.Clear();
            cmbFileType.Items.AddRange(new string[] { "PDF", "DOCX", "PPTX", "TXT", "ZIP", "None" });
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
                    UploaderUsername = cmbUploader.SelectedValue.ToString(),
                    CategoryId = (int)cmbCategory.SelectedValue,
                    UploadDate = dtpUploadDate.Value,
                    Content = new Content
                    {
                        Type = cmbContentType.Text,
                        Url = txtContentUrl.Text.Trim(),
                        FileType = cmbFileType.Text
                    },
                    Topics = ParseTopics(txtTopics.Text),
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
                currentRes.Topics = ParseTopics(txtTopics.Text);
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

        // Helper to parse comma-separated integers safely
        private List<int> ParseTopics(string input)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(input)) return list;
            
            var parts = input.Split(',');
            foreach(var part in parts)
            {
                if(int.TryParse(part.Trim(), out int id)) list.Add(id);
            }
            return list;
        }

        // Helper to parse comma-separated strings
        private List<string> ParseReactions(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new List<string>();
            return input.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null) return;
            var res = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;
            
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
            var res = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;

            txtId.Text = res.Id.ToString();
            txtName.Text = res.Name;
            txtDescription.Text = res.Description;
            cmbCourseCode.SelectedValue = res.CourseCode;
            cmbUploader.SelectedValue = res.UploaderUsername;
            cmbCategory.SelectedValue = res.CategoryId;
            dtpUploadDate.Value = res.UploadDate;
            
            if (res.Content != null)
            {
                cmbContentType.Text = res.Content.Type;
                txtContentUrl.Text = res.Content.Url;
                cmbFileType.Text = res.Content.FileType;
            }

            txtTopics.Text = string.Join(", ", res.Topics);
            txtReactions.Text = string.Join(", ", res.Reactions);
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
            cmbUploader.SelectedIndex = -1;
            txtContentUrl.Clear();
            txtTopics.Clear();
            txtReactions.Clear();
            dtpUploadDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
        private void btnClose_Click(object sender, EventArgs e) => Close();

        // Search Handlers
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = _repository.GetAllResources();
            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                list = list.Where(r => r.Name.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();
            
            _bindingSource.DataSource = list;
            dataGridViewResources.DataSource = _bindingSource;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            LoadResources();
        }
    }
}