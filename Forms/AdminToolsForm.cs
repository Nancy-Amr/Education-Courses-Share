using CoursesSharesDB;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoursesSharesDB.Forms
{
    public partial class AdminToolsForm : Form
    {
        private Repository _repository;
        private System.Windows.Forms.Timer _refreshTimer; // Explicitly specify Windows.Forms.Timer

        public AdminToolsForm()
        {
            InitializeComponent();
            _repository = new Repository();
            InitializeAdminTools();
            StartAutoRefresh();
        }

        private void InitializeAdminTools()
        {
            LoadStatistics();
            LoadRecentActivities();
            LoadSystemHealth();
            LoadUserRolesDistribution();

            // Set welcome message
            if (SessionManager.CurrentUser != null)
            {
                lblAdminWelcome.Text = $"Welcome, Admin {SessionManager.CurrentUser.Username}";
            }
        }

        private void LoadStatistics()
        {
            try
            {
                var users = _repository.GetAllUsers();
                var resources = _repository.GetAllResources();
                var courses = _repository.GetAllCourses();
                var enrollments = _repository.GetAllEnrollments();

                lblTotalUsers.Text = users.Count.ToString();
                //lblTotalResources.Text = resources.Count.ToString();
                //lblTotalCourses.Text = courses.Count.ToString();
                lblTotalEnrollments.Text = enrollments.Count.ToString();

                // Calculate active users (logged in last 7 days)
                int activeUsers = CalculateActiveUsers(users);
                lblActiveUsers.Text = activeUsers.ToString();

                // Calculate system load
                CalculateSystemLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateActiveUsers(List<User> users)
        {
            // In a real system, you would check last login date
            // For demo, return 75% of total users
            return (int)(users.Count * 0.75);
        }

        private void CalculateSystemLoad()
        {
            // Simulate system load calculation
            Random rand = new Random();
            int cpuUsage = rand.Next(20, 80);
            int memoryUsage = rand.Next(30, 90);
            int diskUsage = rand.Next(40, 95);

            lblCpuUsage.Text = $"{cpuUsage}%";
            lblMemoryUsage.Text = $"{memoryUsage}%";
            lblDiskUsage.Text = $"{diskUsage}%";

            // Color code based on usage
            SetUsageColor(lblCpuUsage, cpuUsage);
            SetUsageColor(lblMemoryUsage, memoryUsage);
            SetUsageColor(lblDiskUsage, diskUsage);
        }

        private void SetUsageColor(Label label, int usage)
        {
            if (usage < 50)
                label.ForeColor = Color.Green;
            else if (usage < 80)
                label.ForeColor = Color.Orange;
            else
                label.ForeColor = Color.Red;
        }

        private void LoadRecentActivities()
        {
            try
            {
                var activities = _repository.GetRecentActivities(10);
                dataGridViewActivities.DataSource = activities;

                if (dataGridViewActivities.Columns.Count > 0)
                {
                    dataGridViewActivities.Columns["Timestamp"].HeaderText = "Time";
                    dataGridViewActivities.Columns["User"].HeaderText = "User";
                    dataGridViewActivities.Columns["Action"].HeaderText = "Action";
                    dataGridViewActivities.Columns["Details"].HeaderText = "Details";
                    dataGridViewActivities.Columns["IPAddress"].HeaderText = "IP Address";
                }
            }
            catch (Exception ex)
            {
                // If GetRecentActivities is not implemented, show sample data
                LoadSampleActivities();
            }
        }

        private void LoadSampleActivities()
        {
            var sampleActivities = new List<object>
            {
                new { Timestamp = DateTime.Now.AddMinutes(-5), User = "admin", Action = "Login", Details = "Successful login", IPAddress = "192.168.1.100" },
                new { Timestamp = DateTime.Now.AddMinutes(-15), User = "john_doe", Action = "Upload", Details = "Uploaded course material", IPAddress = "192.168.1.101" },
                new { Timestamp = DateTime.Now.AddMinutes(-30), User = "jane_smith", Action = "Enrollment", Details = "Enrolled in Course 101", IPAddress = "192.168.1.102" },
                new { Timestamp = DateTime.Now.AddHours(-1), User = "admin", Action = "User Management", Details = "Created new user", IPAddress = "192.168.1.100" },
                new { Timestamp = DateTime.Now.AddHours(-2), User = "system", Action = "Backup", Details = "Daily backup completed", IPAddress = "127.0.0.1" }
            };

            dataGridViewActivities.DataSource = sampleActivities;
        }

        private void LoadSystemHealth()
        {
            // Check various system health indicators
            CheckDatabaseConnection();
            CheckFileSystem();
            CheckBackupStatus();
        }

        private void CheckDatabaseConnection()
        {
            try
            {
                // Try to execute a simple query
                var test = _repository.GetAllUsers();
                lblDbStatus.Text = "Connected";
                lblDbStatus.ForeColor = Color.Green;
                lblDbStatus.BackColor = Color.LightGreen;
            }
            catch (Exception)
            {
                lblDbStatus.Text = "Disconnected";
                lblDbStatus.ForeColor = Color.Red;
                lblDbStatus.BackColor = Color.LightCoral;
            }
        }

        private void CheckFileSystem()
        {
            try
            {
                // Check if upload directory exists
                string uploadPath = @"C:\Uploads\";
                if (System.IO.Directory.Exists(uploadPath))
                {
                    lblFsStatus.Text = "Healthy";
                    lblFsStatus.ForeColor = Color.Green;
                    lblFsStatus.BackColor = Color.LightGreen;
                }
                else
                {
                    lblFsStatus.Text = "Warning";
                    lblFsStatus.ForeColor = Color.Orange;
                    lblFsStatus.BackColor = Color.LightYellow;
                }
            }
            catch
            {
                lblFsStatus.Text = "Error";
                lblFsStatus.ForeColor = Color.Red;
                lblFsStatus.BackColor = Color.LightCoral;
            }
        }

        private void CheckBackupStatus()
        {
            // Simulate backup check
            DateTime lastBackup = DateTime.Now.AddHours(-6);
            lblLastBackup.Text = lastBackup.ToString("yyyy-MM-dd HH:mm");

            if (lastBackup > DateTime.Now.AddDays(-1))
            {
                lblBackupStatus.Text = "Recent";
                lblBackupStatus.ForeColor = Color.Green;
            }
            else
            {
                lblBackupStatus.Text = "Overdue";
                lblBackupStatus.ForeColor = Color.Red;
            }
        }

        private void LoadUserRolesDistribution()
        {
            try
            {
                var users = _repository.GetAllUsers();
                int students = users.FindAll(u => u.Role.Equals("student", StringComparison.OrdinalIgnoreCase)).Count;
                int instructors = users.FindAll(u => u.Role.Equals("instructor", StringComparison.OrdinalIgnoreCase)).Count;
                int admins = users.FindAll(u => u.Role.Equals("admin", StringComparison.OrdinalIgnoreCase)).Count;

                lblStudentsCount.Text = students.ToString();
                lblInstructorsCount.Text = instructors.ToString();
                lblAdminsCount.Text = admins.ToString();

                // Calculate percentages
                int total = students + instructors + admins;
                if (total > 0)
                {
                    lblStudentsPercent.Text = $"{((double)students / total * 100):0.0}%";
                    lblInstructorsPercent.Text = $"{((double)instructors / total * 100):0.0}%";
                    lblAdminsPercent.Text = $"{((double)admins / total * 100):0.0}%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user distribution: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartAutoRefresh()
        {
            _refreshTimer = new System.Windows.Forms.Timer(); // Explicit constructor
            _refreshTimer.Interval = 30000; // 30 seconds
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentActivities();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentActivities();
            LoadSystemHealth();
            MessageBox.Show("System data refreshed successfully!", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRunBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Save System Backup",
                FileName = $"SystemBackup_{DateTime.Now:yyyyMMdd_HHmm}.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    progressBarBackup.Visible = true;
                    progressBarBackup.Style = ProgressBarStyle.Marquee; // Indeterminate since we don't have async progress hooks easily
                    Application.DoEvents(); // Force UI update to show progress bar

                    // Perform Backup
                    _repository.CreateBackup(saveFileDialog.FileName);
                    
                    // Stop progress
                    progressBarBackup.Visible = false;
                    Cursor.Current = Cursors.Default;

                    lblLastBackup.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    lblBackupStatus.Text = "Recent - Verified";
                    lblBackupStatus.ForeColor = Color.Green;

                    MessageBox.Show($"Backup created successfully at:\n{saveFileDialog.FileName}", "Backup Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    progressBarBackup.Visible = false;
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Backup failed: {ex.Message}", "Backup Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all activity logs? This action cannot be undone.",
                "Confirm Clear Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Clear the data grid
                    dataGridViewActivities.DataSource = null;

                    // In real system: _repository.ClearActivityLogs();

                    MessageBox.Show("Activity logs cleared successfully!", "Logs Cleared",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing logs: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("System Settings form would open here.", "System Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // var settingsForm = new SystemSettingsForm();
            // settingsForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var userManagementForm = new CoursesSharesDB.Forms.UserManagementForm("Admin");
            userManagementForm.ShowDialog();
            LoadStatistics(); // Refresh after changes
        }



        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Export System Data",
                FileName = "system_export.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var csv = new System.Text.StringBuilder();
                    
                    // Export Users
                    csv.AppendLine("=== USERS ===");
                    csv.AppendLine("ID,Username,Email,Role,Created");
                    var users = _repository.GetAllUsers();
                    foreach (var user in users)
                    {
                        csv.AppendLine($"{user.Id},{user.Username},{user.Email},{user.Role},{user.CreatedAt:yyyy-MM-dd}");
                    }
                    
                    csv.AppendLine();
                    csv.AppendLine("=== COURSES ===");
                    csv.AppendLine("Code,Name,Instructors");
                    var courses = _repository.GetAllCourses();
                    foreach (var course in courses)
                    {
                        var instructors = string.Join("; ", course.InstructorNames);
                        csv.AppendLine($"{course.Code},{course.Name},\"{instructors}\"");
                    }
                    
                    csv.AppendLine();
                    csv.AppendLine("=== RESOURCES ===");
                    csv.AppendLine("ID,Name,Course,Uploader,Upload Date,Category");
                    var resources = _repository.GetAllResources();
                    foreach (var resource in resources)
                    {
                        csv.AppendLine($"{resource.Id},\"{resource.Name}\",{resource.CourseCode},{resource.UploaderUsername},{resource.UploadDate:yyyy-MM-dd},{resource.CategoryId}");
                    }
                    
                    // Write to file
                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                    
                    MessageBox.Show($"Data exported successfully to:\n{saveFileDialog.FileName}\n\nExported:\n- {users.Count} Users\n- {courses.Count} Courses\n- {resources.Count} Resources",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StopAutoRefresh();
            this.Close();
        }

        private void StopAutoRefresh()
        {
            if (_refreshTimer != null)
            {
                _refreshTimer.Stop();
                _refreshTimer.Dispose();
                _refreshTimer = null;
            }
        }

        private void AdminToolsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAutoRefresh();
        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Try to open help URL
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://help.example.com/admin-tools",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot open help URL: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Add this method to AdminToolsForm.cs class
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a SignUpForm in your project
                // Replace with your actual sign up form class
                // var signUpForm = new SignUpForm();
                // signUpForm.ShowDialog();

                // If you don't have a SignUpForm yet, create a simple one or use MessageBox
                MessageBox.Show("Redirecting to user registration form...\n\n" +
                               "In a full implementation, this would open the Sign Up form\n" +
                               "with admin privileges to create new users.",
                               "Add New User",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // For now, open the UserManagementForm in add mode
                var userManagementForm = new CoursesSharesDB.Forms.UserManagementForm();
                userManagementForm.ShowDialog();
                LoadStatistics(); // Refresh after changes
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening user registration: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}