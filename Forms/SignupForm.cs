// SignUpForm.cs
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using Education_Courses.Helpers;
using System;
using System.Windows.Forms;

namespace Education_Courses.Forms
{
    public partial class SignUpForm : Form
    {
        private Repository _repository;
        

        public SignUpForm()
        {
            InitializeComponent();
            _repository = new Repository();
            

            // Hide admin password field if not accessed via admin
            

            // Populate role combo box
            PopulateRoles();
        }

        private void PopulateRoles()
        {
            cmbRole.Items.AddRange(new string[] { "student", "instructor", "admin" });
            cmbRole.SelectedIndex = 0; // Default to Student
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

            // Validate user input
            if (!ValidateUserInput())
                return;

            try
            {
                // Check if username already exists
                var existingUser = _repository.GetUserByUsername(txtUsername.Text);
                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.",
                        "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if email already exists
                var existingEmail = _repository.GetUserByEmail(txtEmail.Text);
                if (existingEmail != null)
                {
                    MessageBox.Show("Email already registered. Please use a different email.",
                        "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create new user
                var user = new User
                {
                    Username = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = PasswordHelper.HashPassword(txtPassword.Text), // ✅ Hash here
                    Role = cmbRole.SelectedItem.ToString(),
                    ProfilePicture = txtProfilePic.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                // Save user to database
                _repository.InsertUser(user);

                MessageBox.Show($"User '{user.Username}' registered successfully!\nRole: {user.Role}",
                    "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}",
                    "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private bool ValidateUserInput()
        {
            // Validate username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validate email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Valid email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Confirm password
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Select Profile Picture"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtProfilePic.Text = openFileDialog.FileName;
                // Optionally display preview
                // pictureBoxProfile.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}