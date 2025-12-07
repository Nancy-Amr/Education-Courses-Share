// Forms/MainForm.cs
using System;
using System.Windows.Forms;
using CoursesSharesDB.DAL;

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
        private void UpdateUserInfo()
        {
            lblWelcome.Text = SessionManager.GetWelcomeMessage();

            // Disable/instructor-only features for students
            if (SessionManager.IsStudent)
            {
                btnManageCourses.Enabled = false;
                btnManageCourses.Text = "Manage Courses (Instructor Only)";
                btnManageCourses.BackColor = System.Drawing.Color.Gray;
            }

            // Show admin-specific welcome
            if (SessionManager.IsAdmin)
            {
                lblWelcome.Text += " - Full System Access";
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
            var userForm = new UserManagementForm();
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
        
        // Hide the current form
        this.Hide();
        
        // Create and show login form
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        
        // When login form closes, close this form too
        loginForm.FormClosed += (s, args) => this.Close();
    }
}
        private void btnAdminRegister_Click(object sender, EventArgs e)
        {
            // Only allow access if current user is admin
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Only administrators can access this feature.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt for admin password
            string adminPassword = PromptForAdminPassword();

            if (adminPassword == "Admin123!") // Change this to match your validation
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
            // Check if user is admin
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Administrator access required!",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for admin password confirmation
            string password = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter admin password:",
                "Admin Verification",
                "",
                -1,
                -1);

            // Validate password (use your secure validation method)
            if (password == "Admin123!") // Replace with secure validation
            {
                var adminTools = new Education_Courses.Forms.AdminToolsForm();
                adminTools.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid admin password!",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}