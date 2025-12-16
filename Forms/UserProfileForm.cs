using System;
using System.Drawing;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using Education_Courses.Helpers;

namespace CoursesSharesDB.Forms
{
    public partial class UserProfileForm : Form
    {
        private Repository _repository;
        private User _currentUser;

        public UserProfileForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _currentUser = SessionManager.CurrentUser;
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                txtUsername.Text = _currentUser.Username;
                txtRole.Text = _currentUser.Role;
                txtEmail.Text = _currentUser.Email;
                txtProfilePic.Text = _currentUser.ProfilePicture;
                LoadProfilePicture(_currentUser.ProfilePicture);
            }
        }

        private void LoadProfilePicture(string path)
        {
            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                try
                {
                    using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        pbProfilePic.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    pbProfilePic.Image = null;
                }
            }
            else
            {
                pbProfilePic.Image = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtProfilePic.Text = openFileDialog.FileName;
                    LoadProfilePicture(openFileDialog.FileName);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _currentUser.Email = txtEmail.Text;
                _currentUser.ProfilePicture = txtProfilePic.Text;

                // Only update password if user entered something
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    _currentUser.Password = PasswordHelper.HashPassword(txtPassword.Text);
                }

                if (_repository.UpdateUser(_currentUser))
                {
                    SessionManager.Login(_currentUser); // Update session using public method
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
