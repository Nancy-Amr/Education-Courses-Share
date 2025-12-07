// LoginForm.cs
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Windows.Forms;

namespace CoursesSharesDB.Forms
{
    public partial class LoginForm : Form
    {
        private readonly Repository _repository;
        public User CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _repository = new Repository();

            // Hide error label initially
            lblError.Visible = false;

            // For demo purposes, set default credentials
            txtUsername.Text = "admin"; // or "malak_mohamed" if that's your admin username
            txtPassword.Text = "admin123"; // Default password
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Please enter both username and password.");
                return;
            }

            try
            {
                var user = _repository.GetUserByUsername(username);

                if (user == null)
                {
                    ShowError("Invalid username or password.");
                    return;
                }

                // For demo: Compare plain text. In production, use proper password hashing
                if (user.Password != password)
                {
                    ShowError("Invalid username or password.");
                    return;
                }

                // Set current user
                CurrentUser = user;

                // Store user in session manager
                SessionManager.Login(user);

                // Set DialogResult to OK to indicate successful login
                this.DialogResult = DialogResult.OK;

                // The calling code will handle opening the MainForm
                // For example, in Program.cs:
                // LoginForm loginForm = new LoginForm();
                // if (loginForm.ShowDialog() == DialogResult.OK)
                // {
                //     Application.Run(new MainForm());
                // }

                this.Close(); // Close the login form
            }
            catch (Exception ex)
            {
                ShowError($"Login error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            txtPassword.Focus();
            txtPassword.SelectAll();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Ask for admin password
            string adminPassword = PromptForAdminPassword();

            if (string.IsNullOrEmpty(adminPassword))
                return; // User cancelled

            // Validate admin password
            if (ValidateAdminPassword(adminPassword))
            {
                // Admin password verified - open signup form
                var signupForm = new Education_Courses.Forms.SignUpForm();
                if (signupForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("User registered successfully!",
                        "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid admin password! Only administrators can create new users.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForAdminPassword()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 200;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "🔒 Admin Authentication Required";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;
                prompt.BackColor = Color.White;

                Label titleLabel = new Label()
                {
                    Text = "Administrator Access Required",
                    Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 70, 120),
                    Location = new Point(20, 20),
                    Size = new Size(350, 25)
                };

                Label instructionLabel = new Label()
                {
                    Text = "Enter admin password to create new users:",
                    Font = new Font("Microsoft Sans Serif", 9F),
                    Location = new Point(20, 60),
                    Size = new Size(350, 20)
                };

                TextBox passwordBox = new TextBox()
                {
                    Location = new Point(20, 85),
                    Size = new Size(340, 25),
                    PasswordChar = '*',
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                Button okButton = new Button()
                {
                    Text = "✓ Continue",
                    Location = new Point(220, 125),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(0, 123, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                Button cancelButton = new Button()
                {
                    Text = "✗ Cancel",
                    Location = new Point(310, 125),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                okButton.Click += (sender, e) => { prompt.Close(); };
                cancelButton.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(titleLabel);
                prompt.Controls.Add(instructionLabel);
                prompt.Controls.Add(passwordBox);
                prompt.Controls.Add(okButton);
                prompt.Controls.Add(cancelButton);

                prompt.AcceptButton = okButton;
                prompt.CancelButton = cancelButton;

                // Focus password field
                prompt.Shown += (sender, e) => passwordBox.Focus();

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    return passwordBox.Text.Trim();
                }

                return null;
            }
        }

        private bool ValidateAdminPassword(string password)
        {
            try
            {
                // Try to get admin user from database
                var adminUser = _repository.GetUserByUsername("admin");

                if (adminUser != null)
                {
                    // Compare with database password (case-sensitive)
                    return adminUser.Password == password;
                }

                // Fallback: Hardcoded admin passwords
                string[] validPasswords = { "admin123", "Admin123", "Admin123!" };
                return validPasswords.Contains(password);
            }
            catch (Exception ex)
            {
                // Log error but don't show to user
                Console.WriteLine($"Password validation error: {ex.Message}");

                // Fallback to hardcoded password
                return password == "admin123";
            }
        }
    }
}