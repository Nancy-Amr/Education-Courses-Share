
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using Education_Courses.Helpers; // For SessionManager

namespace CoursesSharesDB.Forms
{
    public partial class ResourceDetailsForm : Form
    {
        private Resource _resource;
        private Repository _repository;
        private User _currentUser;

        public ResourceDetailsForm(Resource resource)
        {
            InitializeComponent();
            _resource = resource;
            _repository = new Repository();
            _currentUser = SessionManager.CurrentUser; // Assuming SessionManager is available
        }

        private void ResourceDetailsForm_Load(object sender, EventArgs e)
        {
            LoadResourceDetails();
            LoadComments();
            CheckIfSaved();
        }

        private void LoadResourceDetails()
        {
            lblResourceName.Text = _resource.Name;
            
            // Fetch Course Name
            var course = _repository.GetCourseByCode(_resource.CourseCode);
            lblCourse.Text = $"Course: {course?.Name ?? _resource.CourseCode}";

            // Fetch Category Name (Bit inefficient but okay for single item)
            var categories = _repository.GetAllCategories();
            var cat = categories.FirstOrDefault(c => c.Id == _resource.CategoryId);
            lblCategory.Text = $"Category: {cat?.Name ?? "Unknown"}";

            lblUploader.Text = $"Uploaded by: {_resource.UploaderUsername}";
            lblDate.Text = $"Date: {_resource.UploadDate:yyyy-MM-dd}";
            txtDescription.Text = _resource.Description;
        }

        private void CheckIfSaved()
        {
            if (_currentUser == null) return;

            bool isSaved = _repository.IsResourceSaved(_currentUser.Id, _resource.Id);
            if (isSaved)
            {
                btnSave.Text = "Saved ✓ (Unsave)";
                btnSave.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                btnSave.Text = "Save Resource";
                btnSave.BackColor = System.Drawing.Color.ForestGreen;
            }
            btnSave.Enabled = true; // Always enable to allow toggling
        }

        private void LoadComments()
        {
            lstComments.Items.Clear();
            var comments = _repository.GetCommentsByResource(_resource.Id);

            foreach (var comment in comments)
            {
                var user = _repository.GetUserById(comment.UserId);
                string username = user?.Username ?? "Unknown";
                string display = $"{username} ({comment.TimeStamp:g}): {comment.Text}";
                lstComments.Items.Add(display);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please login to save resources.", "Not Logged In");
                return;
            }

            try
            {
                bool isSaved = _repository.IsResourceSaved(_currentUser.Id, _resource.Id);

                if (isSaved)
                {
                    // Unsave Logic
                     _repository.DeleteSavedResource(_currentUser.Id, _resource.Id);
                     MessageBox.Show("Resource removed from saved list.", "Unsaved");
                }
                else
                {
                    // Save Logic
                    var saved = new SavedResource
                    {
                        UserId = _currentUser.Id,
                        ResourceId = _resource.Id,
                        SavingDate = DateTime.Now
                    };

                    _repository.InsertSavedResource(saved);
                    MessageBox.Show("Resource saved successfully!", "Success");
                }
                
                CheckIfSaved(); // Update UI
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating save status: {ex.Message}", "Error");
            }
        }

        private void btnOpenResource_Click(object sender, EventArgs e)
        {
            if (_resource.Content == null || string.IsNullOrEmpty(_resource.Content.Url))
            {
                MessageBox.Show("There is no file or URL associated with this resource.", "No Content");
                return;
            }

            try
            {
                string path = _resource.Content.Url;

                // Check if it's a web URL
                if (path.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                    path.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    // It's a URL, open as is
                }
                else
                {
                    // It's a file path, assume relative to application base directory
                    // Combine with BaseDirectory to get absolute path
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    
                    // Verify file exists
                    if (!System.IO.File.Exists(path))
                    {
                         MessageBox.Show($"File not found at path: {path}\n\nPlease check if the file exists in the Uploads folder.", "File Not Found");
                         return;
                    }
                }

                // Open the URL or File using the system default application (Browser for links, PDF Viewer for PDFs, etc.)
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the file/url: {ex.Message}", "Error");
            }
        }

        private void btnPostComment_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please login to post comments.", "Not Logged In");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewComment.Text))
            {
                MessageBox.Show("Comment cannot be empty.", "Validation Error");
                return;
            }

            try
            {
                // Simple ID generation for now (since Comment.Id is likely auto-generated or needs manual logic if MongoDB doesn't do it for Ints)
                // Assuming Comment.Id is not critical for now or handled by DB default (ObjectId is usually better but model uses Int)
                // We will let Repository/Driver handle it or just ignore ID if not primary key constraint like SQL.
                // Wait, Comment model has [BsonId] int. We might need to generate it.
                // NOTE: Repository doesn't expose generic ID generator. I'll make a quick one here or ignore if BsonId is ObjectId masked.
                // Actually Model says BsonType.Int32.
                
                var comment = new Comment
                {
                    // Id = GenerateId(), // Skipping for simplicity, MongoDB might complain but let's try
                    ResourceId = _resource.Id,
                    UserId = _currentUser.Id,
                    Text = txtNewComment.Text,
                    TimeStamp = DateTime.Now
                };

                // Helper to get next ID ?
                // For now, let's assume we can insert without ID and let DB handle or it's random. 
                // Actually, int ID in Mongo usually requires manual management. 
                // I will use a random int for now to avoid complexity of a counter collection.
                comment.Id = new Random().Next(1000, 999999);

                _repository.InsertComment(comment);
                txtNewComment.Clear();
                LoadComments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error posting comment: {ex.Message}", "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
