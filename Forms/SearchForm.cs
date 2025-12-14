using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using MongoDB.Driver;

namespace CoursesSharesDB.Forms
{
    public partial class SearchForm : Form
    {
        private Repository _repository;
        private MongoDBContext _context;
        private List<ResourceCategory> _categories;

        public SearchForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _context = new MongoDBContext();
            LoadComboBoxes();
            SetupDataGridView();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load courses
                var courses = _repository.GetAllCourses();
                cmbSearchCourse.DataSource = new List<Course>(courses);
                cmbSearchCourse.DisplayMember = "Name";
                cmbSearchCourse.ValueMember = "Code";
                cmbSearchCourse.SelectedIndex = -1;

                // Load categories
                _categories = _repository.GetAllCategories();
                cmbSearchCategory.DataSource = new List<ResourceCategory>(_categories);
                cmbSearchCategory.DisplayMember = "Name";
                cmbSearchCategory.ValueMember = "Id";
                cmbSearchCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading search criteria: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewSearchResults.AutoGenerateColumns = false;
            dataGridViewSearchResults.Columns.Clear();

            // Configure columns
            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Resource Name",
                Width = 200
            });

            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 250
            });

            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseCode",
                HeaderText = "Course",
                Width = 100
            });

            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UploaderUsername",
                HeaderText = "Uploader",
                Width = 120
            });

            dataGridViewSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UploadDate",
                HeaderText = "Upload Date",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            // Add button column for viewing details
            var detailsColumn = new DataGridViewButtonColumn
            {
                Name = "Actions", // Fix: Set the Name so we can find it later
                HeaderText = "Actions",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dataGridViewSearchResults.Columns.Add(detailsColumn);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = Builders<Resource>.Filter.Empty;

                // Filter by name (case-insensitive)
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                {
                    filter &= Builders<Resource>.Filter.Regex(r => r.Name,
                        new MongoDB.Bson.BsonRegularExpression(txtSearchName.Text, "i"));
                }

                // Filter by description (case-insensitive)
                if (!string.IsNullOrWhiteSpace(txtSearchDescription.Text))
                {
                    filter &= Builders<Resource>.Filter.Regex(r => r.Description,
                        new MongoDB.Bson.BsonRegularExpression(txtSearchDescription.Text, "i"));
                }

                // Filter by course
                if (cmbSearchCourse.SelectedItem != null)
                {
                    var selectedCourse = (Course)cmbSearchCourse.SelectedItem;
                    filter &= Builders<Resource>.Filter.Eq(r => r.CourseCode, selectedCourse.Code);
                }

                // Filter by category
                if (cmbSearchCategory.SelectedItem != null)
                {
                    var selectedCategory = (ResourceCategory)cmbSearchCategory.SelectedItem;
                    filter &= Builders<Resource>.Filter.Eq(r => r.CategoryId, selectedCategory.Id);
                }

                // Execute search
                var results = _context.Resources.Find(filter)
                    .SortByDescending(r => r.UploadDate)
                    .ToList();

                // Display results
                dataGridViewSearchResults.DataSource = results;
                lblResultsCount.Text = $"{results.Count} resource(s) found";

                if (results.Count == 0)
                {
                    MessageBox.Show("No resources found matching your criteria.", "Search Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearchCriteria();
            dataGridViewSearchResults.DataSource = null;
            lblResultsCount.Text = "0 resource(s)";
        }

        private void ClearSearchCriteria()
        {
            txtSearchName.Clear();
            txtSearchDescription.Clear();
            cmbSearchCourse.SelectedIndex = -1;
            cmbSearchCategory.SelectedIndex = -1;
            txtSearchName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewSearchResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle "View Details" button click
            if (e.ColumnIndex == dataGridViewSearchResults.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var selectedResource = (Resource)dataGridViewSearchResults.Rows[e.RowIndex].DataBoundItem;
                ShowResourceDetails(selectedResource);
            }
        }

        private void ShowResourceDetails(Resource resource)
        {
            try
            {
                var detailsForm = new ResourceDetailsForm(resource);
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow searching by pressing Enter in name field
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }

        private void txtSearchDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow searching by pressing Enter in description field
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            // Optional: Show advanced search dialog
            MessageBox.Show("Advanced search features would be implemented here.",
                "Advanced Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}