namespace Education_Courses.Forms
{
    partial class AdminToolsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header Section
        private Label lblAdminWelcome;
        private Label lblTitle;
        private PictureBox pictureBox1;

        // Statistics Panel
        private GroupBox grpStatistics;
        private Label lblStatUsers;
        private Label lblTotalUsers;
        private Label lblStatResources;
        private Label lblTotalResources;
        private Label lblStatCourses;
        private Label lblTotalCourses;
        private Label lblStatEnrollments;
        private Label lblTotalEnrollments;
        private Label lblStatActiveUsers;
        private Label lblActiveUsers;

        // System Health Panel
        private GroupBox grpSystemHealth;
        private Label lblDbStatusLabel;
        private Label lblDbStatus;
        private Label lblFsStatusLabel;
        private Label lblFsStatus;
        private Label lblBackupStatusLabel;
        private Label lblBackupStatus;
        private Label lblLastBackupLabel;
        private Label lblLastBackup;
        private Label lblCpuLabel;
        private Label lblCpuUsage;
        private Label lblMemoryLabel;
        private Label lblMemoryUsage;
        private Label lblDiskLabel;
        private Label lblDiskUsage;
        private ProgressBar progressBarBackup;

        // Activity Log Panel
        private GroupBox grpActivityLog;
        private DataGridView dataGridViewActivities;
        private Button btnClearLogs;

        // User Distribution Panel
        private GroupBox grpUserDistribution;
        private Label lblStudentsLabel;
        private Label lblStudentsCount;
        private Label lblStudentsPercent;
        private Label lblInstructorsLabel;
        private Label lblInstructorsCount;
        private Label lblInstructorsPercent;
        private Label lblAdminsLabel;
        private Label lblAdminsCount;
        private Label lblAdminsPercent;

        // Control Buttons
        private Button btnRefresh;
        private Button btnRunBackup;
        private Button btnSystemSettings;
        private Button btnUserManagement;
        private Button btnDatabaseTools;
        private Button btnExportData;
        private Button btnEmergencyLockdown;
        private Button btnClose;

        // Help Link
        private LinkLabel linkLabelHelp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminToolsForm));
            lblAdminWelcome = new Label();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            grpStatistics = new GroupBox();
            lblStatUsers = new Label();
            lblTotalUsers = new Label();
            lblStatResources = new Label();
            lblTotalResources = new Label();
            lblStatCourses = new Label();
            lblTotalCourses = new Label();
            lblStatEnrollments = new Label();
            lblTotalEnrollments = new Label();
            lblStatActiveUsers = new Label();
            lblActiveUsers = new Label();
            grpSystemHealth = new GroupBox();
            lblDbStatusLabel = new Label();
            lblDbStatus = new Label();
            lblFsStatusLabel = new Label();
            lblFsStatus = new Label();
            lblBackupStatusLabel = new Label();
            lblBackupStatus = new Label();
            lblLastBackupLabel = new Label();
            lblLastBackup = new Label();
            lblCpuLabel = new Label();
            lblCpuUsage = new Label();
            lblMemoryLabel = new Label();
            lblMemoryUsage = new Label();
            lblDiskLabel = new Label();
            lblDiskUsage = new Label();
            progressBarBackup = new ProgressBar();
            grpActivityLog = new GroupBox();
            dataGridViewActivities = new DataGridView();
            btnClearLogs = new Button();
            grpUserDistribution = new GroupBox();
            lblStudentsLabel = new Label();
            lblStudentsCount = new Label();
            lblStudentsPercent = new Label();
            lblInstructorsLabel = new Label();
            lblInstructorsCount = new Label();
            lblInstructorsPercent = new Label();
            lblAdminsLabel = new Label();
            lblAdminsCount = new Label();
            lblAdminsPercent = new Label();
            btnRefresh = new Button();
            btnRunBackup = new Button();
            btnSystemSettings = new Button();
            btnUserManagement = new Button();
            btnDatabaseTools = new Button();
            btnExportData = new Button();
            btnEmergencyLockdown = new Button();
            btnClose = new Button();
            linkLabelHelp = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpStatistics.SuspendLayout();
            grpSystemHealth.SuspendLayout();
            grpActivityLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).BeginInit();
            grpUserDistribution.SuspendLayout();
            SuspendLayout();

            // lblAdminWelcome
            // 
            lblAdminWelcome.AutoSize = true;
            lblAdminWelcome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminWelcome.ForeColor = Color.FromArgb(0, 70, 120);
            lblAdminWelcome.Location = new Point(120, 20);
            lblAdminWelcome.Name = "lblAdminWelcome";
            lblAdminWelcome.Size = new Size(250, 25);
            lblAdminWelcome.TabIndex = 0;
            lblAdminWelcome.Text = "Administrator Dashboard";

            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(120, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "System Administration Tools";

            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;

            // grpStatistics
            // 
            grpStatistics.Controls.Add(lblStatUsers);
            grpStatistics.Controls.Add(lblTotalUsers);
            grpStatistics.Controls.Add(lblStatResources);
            grpStatistics.Controls.Add(lblTotalResources);
            grpStatistics.Controls.Add(lblStatCourses);
            grpStatistics.Controls.Add(lblTotalCourses);
            grpStatistics.Controls.Add(lblStatEnrollments);
            grpStatistics.Controls.Add(lblTotalEnrollments);
            grpStatistics.Controls.Add(lblStatActiveUsers);
            grpStatistics.Controls.Add(lblActiveUsers);
            grpStatistics.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpStatistics.Location = new Point(20, 120);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Size = new Size(300, 200);
            grpStatistics.TabIndex = 3;
            grpStatistics.TabStop = false;
            grpStatistics.Text = "System Statistics";

            // Statistics labels setup (similar pattern for all)
            lblStatUsers.AutoSize = true;
            lblStatUsers.Location = new Point(20, 40);
            lblStatUsers.Name = "lblStatUsers";
            lblStatUsers.Size = new Size(120, 18);
            lblStatUsers.TabIndex = 0;
            lblStatUsers.Text = "Total Users:";

            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUsers.ForeColor = Color.Blue;
            lblTotalUsers.Location = new Point(150, 40);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(20, 20);
            lblTotalUsers.TabIndex = 1;
            lblTotalUsers.Text = "0";

            // ... (Setup all statistics labels with similar pattern)

            // grpSystemHealth
            // 
            grpSystemHealth.Controls.Add(lblDbStatusLabel);
            grpSystemHealth.Controls.Add(lblDbStatus);
            // ... Add all system health controls
            grpSystemHealth.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSystemHealth.Location = new Point(340, 120);
            grpSystemHealth.Name = "grpSystemHealth";
            grpSystemHealth.Size = new Size(300, 200);
            grpSystemHealth.TabIndex = 4;
            grpSystemHealth.TabStop = false;
            grpSystemHealth.Text = "System Health";

            // ... Setup all system health labels

            // grpActivityLog
            // 
            grpActivityLog.Controls.Add(dataGridViewActivities);
            grpActivityLog.Controls.Add(btnClearLogs);
            grpActivityLog.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpActivityLog.Location = new Point(20, 340);
            grpActivityLog.Name = "grpActivityLog";
            grpActivityLog.Size = new Size(620, 250);
            grpActivityLog.TabIndex = 5;
            grpActivityLog.TabStop = false;
            grpActivityLog.Text = "Recent Activity Log";

            // dataGridViewActivities
            // 
            dataGridViewActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActivities.Location = new Point(20, 30);
            dataGridViewActivities.Name = "dataGridViewActivities";
            dataGridViewActivities.RowHeadersWidth = 51;
            dataGridViewActivities.Size = new Size(580, 180);
            dataGridViewActivities.TabIndex = 0;

            // btnClearLogs
            // 
            btnClearLogs.BackColor = Color.FromArgb(220, 53, 69);
            btnClearLogs.FlatStyle = FlatStyle.Flat;
            btnClearLogs.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearLogs.ForeColor = Color.White;
            btnClearLogs.Location = new Point(500, 215);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(100, 30);
            btnClearLogs.TabIndex = 1;
            btnClearLogs.Text = "Clear Logs";
            btnClearLogs.UseVisualStyleBackColor = false;
            btnClearLogs.Click += btnClearLogs_Click;

            // grpUserDistribution
            // 
            grpUserDistribution.Controls.Add(lblStudentsLabel);
            // ... Add all user distribution controls
            grpUserDistribution.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpUserDistribution.Location = new Point(660, 120);
            grpUserDistribution.Name = "grpUserDistribution";
            grpUserDistribution.Size = new Size(300, 200);
            grpUserDistribution.TabIndex = 6;
            grpUserDistribution.TabStop = false;
            grpUserDistribution.Text = "User Roles Distribution";

            // Control Buttons
            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(0, 123, 255);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(20, 600);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // btnRunBackup
            btnRunBackup.BackColor = Color.FromArgb(40, 167, 69);
            btnRunBackup.FlatStyle = FlatStyle.Flat;
            btnRunBackup.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRunBackup.ForeColor = Color.White;
            btnRunBackup.Location = new Point(150, 600);
            btnRunBackup.Name = "btnRunBackup";
            btnRunBackup.Size = new Size(120, 40);
            btnRunBackup.TabIndex = 8;
            btnRunBackup.Text = "&Run Backup";
            btnRunBackup.UseVisualStyleBackColor = false;
            btnRunBackup.Click += btnRunBackup_Click;

            // btnUserManagement
            btnUserManagement.BackColor = Color.FromArgb(255, 193, 7);
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Location = new Point(280, 600);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(180, 40);
            btnUserManagement.TabIndex = 9;
            btnUserManagement.Text = "&User Management";
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;

            // btnEmergencyLockdown
            btnEmergencyLockdown.BackColor = Color.Red;
            btnEmergencyLockdown.FlatStyle = FlatStyle.Flat;
            btnEmergencyLockdown.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmergencyLockdown.ForeColor = Color.White;
            btnEmergencyLockdown.Location = new Point(660, 600);
            btnEmergencyLockdown.Name = "btnEmergencyLockdown";
            btnEmergencyLockdown.Size = new Size(180, 40);
            btnEmergencyLockdown.TabIndex = 10;
            btnEmergencyLockdown.Text = "🚨 Emergency";
            btnEmergencyLockdown.UseVisualStyleBackColor = false;
            btnEmergencyLockdown.Click += btnEmergencyLockdown_Click;

            // btnClose
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(850, 600);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 40);
            btnClose.TabIndex = 11;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;

            // linkLabelHelp
            linkLabelHelp.AutoSize = true;
            linkLabelHelp.Location = new Point(850, 30);
            linkLabelHelp.Name = "linkLabelHelp";
            linkLabelHelp.Size = new Size(120, 20);
            linkLabelHelp.TabIndex = 12;
            linkLabelHelp.TabStop = true;
            linkLabelHelp.Text = "Admin Help Docs";
            linkLabelHelp.LinkClicked += linkLabelHelp_LinkClicked;

            // AdminToolsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 660);
            Controls.Add(linkLabelHelp);
            Controls.Add(btnClose);
            Controls.Add(btnEmergencyLockdown);
            Controls.Add(btnUserManagement);
            Controls.Add(btnRunBackup);
            Controls.Add(btnRefresh);
            Controls.Add(grpUserDistribution);
            Controls.Add(grpActivityLog);
            Controls.Add(grpSystemHealth);
            Controls.Add(grpStatistics);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitle);
            Controls.Add(lblAdminWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminToolsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrator Tools - System Dashboard";
            FormClosing += AdminToolsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpStatistics.ResumeLayout(false);
            grpStatistics.PerformLayout();
            grpSystemHealth.ResumeLayout(false);
            grpSystemHealth.PerformLayout();
            grpActivityLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).EndInit();
            grpUserDistribution.ResumeLayout(false);
            grpUserDistribution.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}