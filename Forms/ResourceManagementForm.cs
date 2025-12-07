using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
            LoadResources();
            LoadComboBoxes();
            SetupDataGridView();
        }

        private void LoadResources()
        {
            try
            {
                var resources = _repository.GetAllResources();
                _bindingSource.DataSource = resources;
                dataGridViewResources.DataSource = _bindingSource;
                lblTotalResources.Text = $"Total Resources: {resources.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resources: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load courses
                var courses = _repository.GetAllCourses();
                cmbCourseCode.DataSource = new List<Course>(courses);
                cmbCourseCode.DisplayMember = "Code";
                cmbCourseCode.ValueMember = "Code";

                // Load categories
                var categories = _repository.GetAllCategories();
                cmbCategory.DataSource = new List<ResourceCategory>(categories);
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";

                // Load users for uploader
                var users = _repository.GetAllUsers();
                cmbUploader.DataSource = new List<User>(users);
                cmbUploader.DisplayMember = "Username";
                cmbUploader.ValueMember = "Username";

                // Load content types
                cmbContentType.Items.AddRange(new string[] { "file", "link", "video", "document" });

                // Load file types
                cmbFileType.Items.AddRange(new string[] { "pdf", "docx", "pptx", "xlsx", "csv", "txt", "zip" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combobox data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewResources.AutoGenerateColumns = false;
            dataGridViewResources.Columns.Clear();

            // Configure columns
            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Resource Name",
                Width = 200
            });

            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseCode",
                HeaderText = "Course Code",
                Width = 80
            });

            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UploaderUsername",
                HeaderText = "Uploader",
                Width = 100
            });

            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UploadDate",
                HeaderText = "Upload Date",
                Width = 100
            });

            dataGridViewResources.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryId",
                HeaderText = "Category ID",
                Width = 80
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                var topicsList = new List<int>();
                if (!string.IsNullOrEmpty(txtTopics.Text))
                {
                    topicsList = txtTopics.Text.Split(',')
                        .Select(t => int.TryParse(t.Trim(), out int result) ? result : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                var reactionsList = new List<string>();
                if (!string.IsNullOrEmpty(txtReactions.Text))
                {
                    reactionsList = txtReactions.Text.Split(',')
                        .Select(r => r.Trim())
                        .Where(r => !string.IsNullOrEmpty(r))
                        .ToList();
                }

                var resource = new Resource
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    CourseCode = cmbCourseCode.Text,
                    UploaderUsername = cmbUploader.Text,
                    CategoryId = ((ResourceCategory)cmbCategory.SelectedItem).Id,
                    UploadDate = dtpUploadDate.Value,
                    Content = new Content
                    {
                        Type = cmbContentType.Text,
                        Url = txtContentUrl.Text,
                        FileType = cmbFileType.Text
                    },
                    Topics = topicsList,
                    Reactions = reactionsList
                };

                _repository.InsertResource(resource);
                LoadResources();
                ClearForm();
                MessageBox.Show("Resource added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding resource: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null)
            {
                MessageBox.Show("Please select a resource to update.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
                return;

            try
            {
                var selectedResource = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;

                var topicsList = new List<int>();
                if (!string.IsNullOrEmpty(txtTopics.Text))
                {
                    topicsList = txtTopics.Text.Split(',')
                        .Select(t => int.TryParse(t.Trim(), out int result) ? result : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                var reactionsList = new List<string>();
                if (!string.IsNullOrEmpty(txtReactions.Text))
                {
                    reactionsList = txtReactions.Text.Split(',')
                        .Select(r => r.Trim())
                        .Where(r => !string.IsNullOrEmpty(r))
                        .ToList();
                }

                selectedResource.Name = txtName.Text;
                selectedResource.Description = txtDescription.Text;
                selectedResource.CourseCode = cmbCourseCode.Text;
                selectedResource.UploaderUsername = cmbUploader.Text;
                selectedResource.CategoryId = ((ResourceCategory)cmbCategory.SelectedItem).Id;
                selectedResource.UploadDate = dtpUploadDate.Value;
                selectedResource.Content = new Content
                {
                    Type = cmbContentType.Text,
                    Url = txtContentUrl.Text,
                    FileType = cmbFileType.Text
                };
                selectedResource.Topics = topicsList;
                selectedResource.Reactions = reactionsList;

                if (_repository.UpdateResource(selectedResource))
                {
                    LoadResources();
                    MessageBox.Show("Resource updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update resource.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating resource: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow == null)
            {
                MessageBox.Show("Please select a resource to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedResource = (Resource)dataGridViewResources.CurrentRow.DataBoundItem;

            var result = MessageBox.Show($"Are you sure you want to delete resource '{selectedResource.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_repository.DeleteResource(selectedResource.Id))
                    {
                        LoadResources();
                        ClearForm();
                        MessageBox.Show("Resource deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete resource.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting resource: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewResources_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewResources.CurrentRow != null && dataGridViewResources.CurrentRow.DataBoundItem is Resource selectedResource)
            {
                LoadResourceDetails(selectedResource);
            }
        }

        private void LoadResourceDetails(Resource resource)
        {
            txtId.Text = resource.Id.ToString();
            txtName.Text = resource.Name;
            txtDescription.Text = resource.Description;

            // Set course code
            if (cmbCourseCode.Items.Count > 0)
            {
                for (int i = 0; i < cmbCourseCode.Items.Count; i++)
                {
                    var course = (Course)cmbCourseCode.Items[i];
                    if (course.Code == resource.CourseCode)
                    {
                        cmbCourseCode.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set category
            if (cmbCategory.Items.Count > 0)
            {
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    var category = (ResourceCategory)cmbCategory.Items[i];
                    if (category.Id == resource.CategoryId)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set uploader
            if (cmbUploader.Items.Count > 0)
            {
                for (int i = 0; i < cmbUploader.Items.Count; i++)
                {
                    var user = (User)cmbUploader.Items[i];
                    if (user.Username == resource.UploaderUsername)
                    {
                        cmbUploader.SelectedIndex = i;
                        break;
                    }
                }
            }

            dtpUploadDate.Value = resource.UploadDate;

            // Set content details
            if (resource.Content != null)
            {
                cmbContentType.Text = resource.Content.Type;
                txtContentUrl.Text = resource.Content.Url;
                cmbFileType.Text = resource.Content.FileType;
            }

            // Set topics
            if (resource.Topics != null && resource.Topics.Count > 0)
            {
                txtTopics.Text = string.Join(", ", resource.Topics);
            }
            else
            {
                txtTopics.Text = "";
            }

            // Set reactions
            if (resource.Reactions != null && resource.Reactions.Count > 0)
            {
                txtReactions.Text = string.Join(", ", resource.Reactions);
            }
            else
            {
                txtReactions.Text = "";
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please enter a Resource ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Resource ID must be a positive integer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a Resource Name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (cmbCourseCode.SelectedItem == null)
            {
                MessageBox.Show("Please select a Course.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCourseCode.Focus();
                return false;
            }

            if (cmbUploader.SelectedItem == null)
            {
                MessageBox.Show("Please select an Uploader.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUploader.Focus();
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a Category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbContentType.Text))
            {
                MessageBox.Show("Please select a Content Type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbContentType.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtDescription.Clear();
            cmbCourseCode.SelectedIndex = -1;
            cmbUploader.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            dtpUploadDate.Value = DateTime.Now;
            cmbContentType.SelectedIndex = -1;
            txtContentUrl.Clear();
            cmbFileType.SelectedIndex = -1;
            txtTopics.Clear();
            txtReactions.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var allResources = _repository.GetAllResources();
                var filteredResources = allResources;

                // Filter by name
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                {
                    filteredResources = filteredResources
                        .Where(r => r.Name.Contains(txtSearchName.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Filter by course code
                if (!string.IsNullOrWhiteSpace(txtSearchCourseCode.Text))
                {
                    filteredResources = filteredResources
                        .Where(r => r.CourseCode.Equals(txtSearchCourseCode.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Filter by uploader
                if (!string.IsNullOrWhiteSpace(txtSearchUploader.Text))
                {
                    filteredResources = filteredResources
                        .Where(r => r.UploaderUsername.Contains(txtSearchUploader.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                _bindingSource.DataSource = filteredResources;
                dataGridViewResources.DataSource = _bindingSource;

                lblSearchResults.Text = $"Found {filteredResources.Count} resource(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching resources: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadResources();
            txtSearchName.Clear();
            txtSearchCourseCode.Clear();
            txtSearchUploader.Clear();
            lblSearchResults.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}