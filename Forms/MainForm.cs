
using System;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using System.Drawing;
using Education_Courses.Helpers;

namespace CoursesSharesDB.Forms
{
    public partial class MainForm : Form
    {
        private Repository _repository;

        public MainForm()
        {
            InitializeComponent();
            _repository = new Repository();
            UpdateUserInfo();
        }

        // In MainForm.cs constructor or UpdateUserInfo method
        private void UpdateUserInfo()
        {
            lblWelcome.Text = SessionManager.GetWelcomeMessage();

            // Disable instructor-only features for students
            bool isStudent = SessionManager.CurrentUser != null &&
                            SessionManager.CurrentUser.Role != null &&
                            SessionManager.CurrentUser.Role.Equals("student", StringComparison.OrdinalIgnoreCase);

            if (isStudent)
            {
                btnManageCourses.Enabled = false;
                btnManageCourses.BackColor = Color.Gray;
            }
            else
            {
                btnManageCourses.Enabled = true;
                btnManageCourses.Text = "&Manage Courses";
                btnManageCourses.BackColor = Color.FromArgb(220, 53, 69);
            }

            // Show admin-specific welcome and tools
            bool isAdmin = SessionManager.CurrentUser != null &&
                          SessionManager.CurrentUser.Role != null &&
                          SessionManager.CurrentUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

            if (isAdmin)
            {
                lblWelcome.Text += " - Full System Access";
                if (btnAdminTools != null)
                {
                    btnAdminTools.Visible = true;
                    btnAdminTools.BringToFront();
                }
            }
            else
            {
                if (btnAdminTools != null)
                    btnAdminTools.Visible = false;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var users = _repository.GetAllUsers();
            var resources = _repository.GetAllResources();
            var courses = _repository.GetAllCourses();

            lblTotalUsers.Text = $"Total Users: {users.Count}";
            lblTotalResources.Text = $"Total Resources: {resources.Count}";
            lblTotalCourses.Text = $"Total Courses: {courses.Count}";
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Get current user role
            string userRole = "Student"; // Default

            if (SessionManager.CurrentUser != null && SessionManager.CurrentUser.Role != null)
            {
                userRole = SessionManager.CurrentUser.Role;
            }

            // Open UserManagementForm with current user role
            // Only Admin will see edit/delete buttons, others see read-only view
            var userForm = new UserManagementForm(userRole);
            userForm.ShowDialog();
        }

        private void btnManageResources_Click(object sender, EventArgs e)
        {
            var resourceForm = new ResourceManagementForm();
            resourceForm.ShowDialog();
        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            // Check if user has permission
            if (SessionManager.IsStudent)
            {
                MessageBox.Show("Only instructors can manage courses and departments.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var courseForm = new CourseManagementForm();
            courseForm.ShowDialog();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportsForm();
            reportForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            searchForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?",
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Logout the user
                SessionManager.Logout();

                // Close the main form (this will return control to Program.cs)
                this.Close();
            }
        }

        private void btnAdminRegister_Click(object sender, EventArgs e)
        {
            // Only allow access if current user is admin
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.Role != "admin")
            {
                MessageBox.Show("Only administrators can access this feature.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt for admin password
            string adminPassword = PromptForAdminPassword();

            if (adminPassword == "admin123!") // Change this to match your validation
            {
                var signUpForm = new Education_Courses.Forms.SignUpForm();
                signUpForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid admin password!", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForAdminPassword()
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Admin Authentication",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Enter admin password:" };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240, PasswordChar = '*' };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        // In MainForm.cs, add to your navigation
        private void btnAdminTools_Click(object sender, EventArgs e)
        {
            // Check if user is admin (Case-insensitive)
            if (SessionManager.CurrentUser == null || 
                !SessionManager.CurrentUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Administrator access required!",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verify admin password with max 3 attempts
            int attempts = 0;
            const int maxAttempts = 3;
            bool isAuthenticated = false;

            while (attempts < maxAttempts)
            {
                // Ask for admin password confirmation
                // Use a custom dialog or InputBox. Note: InputBox does not mask password characters.
                // Reusing PromptForAdminPassword method for better UX (masked characters)
                string password = PromptForAdminPassword();

                // If user cancels (returns empty or null), break
                if (string.IsNullOrEmpty(password))
                {
                    return;
                }

                // Increase attempt counter
                attempts++;

                // Validate password against the current logged-in admin's password
                // Note: SessionManager.CurrentUser.Password contains the HASHED password.
                // We need to hash the input password and compare, or use a Verify method if available.
                // Assuming PasswordHelper.VerifyPassword handles (plain, hash) comparison.
                if (PasswordHelper.VerifyPassword(password, SessionManager.CurrentUser.Password))
                {
                    isAuthenticated = true;
                    break;
                }
                else
                {
                    int remaining = maxAttempts - attempts;
                    if (remaining > 0)
                    {
                        MessageBox.Show($"Invalid password! You have {remaining} attempt(s) remaining.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (isAuthenticated)
            {
                var adminTools = new AdminToolsForm();
                adminTools.ShowDialog();
            }
            else
            {
                MessageBox.Show("Maximum attempts exceeded. You will be logged out.",
                    "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Logout logic
                SessionManager.Logout();
                this.Close(); // Close MainForm to return to Login logic in Program.cs
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var profileForm = new UserProfileForm();
            profileForm.ShowDialog();
            // Refresh welcome message in case profile updated
            UpdateUserInfo();
        }
    }
}
