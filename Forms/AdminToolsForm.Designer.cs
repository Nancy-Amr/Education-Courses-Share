namespace CoursesSharesDB.Forms
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
        private Button btnAddUser;

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
            lblAdminWelcome = new Label();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            grpStatistics = new GroupBox();
            lblStatUsers = new Label();
            lblTotalUsers = new Label();
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
            // 
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
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(120, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(385, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "System Administration Tools";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // grpStatistics
            // 
            grpStatistics.Controls.Add(lblStatUsers);
            grpStatistics.Controls.Add(lblTotalUsers);
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
            // 
            // lblStatUsers
            // 
            lblStatUsers.AutoSize = true;
            lblStatUsers.Location = new Point(20, 40);
            lblStatUsers.Name = "lblStatUsers";
            lblStatUsers.Size = new Size(101, 18);
            lblStatUsers.TabIndex = 0;
            lblStatUsers.Text = "Total Users:";
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUsers.ForeColor = Color.Blue;
            lblTotalUsers.Location = new Point(150, 40);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(19, 20);
            lblTotalUsers.TabIndex = 1;
            lblTotalUsers.Text = "0";
            // 
            // lblStatEnrollments
            // 
            lblStatEnrollments.Location = new Point(0, 0);
            lblStatEnrollments.Name = "lblStatEnrollments";
            lblStatEnrollments.Size = new Size(100, 23);
            lblStatEnrollments.TabIndex = 6;
            // 
            // lblTotalEnrollments
            // 
            lblTotalEnrollments.Location = new Point(0, 0);
            lblTotalEnrollments.Name = "lblTotalEnrollments";
            lblTotalEnrollments.Size = new Size(100, 23);
            lblTotalEnrollments.TabIndex = 7;
            // 
            // lblStatActiveUsers
            // 
            lblStatActiveUsers.Location = new Point(0, 0);
            lblStatActiveUsers.Name = "lblStatActiveUsers";
            lblStatActiveUsers.Size = new Size(100, 23);
            lblStatActiveUsers.TabIndex = 8;
            // 
            // lblActiveUsers
            // 
            lblActiveUsers.Location = new Point(0, 0);
            lblActiveUsers.Name = "lblActiveUsers";
            lblActiveUsers.Size = new Size(100, 23);
            lblActiveUsers.TabIndex = 9;
            // 
            // grpSystemHealth
            // 
            grpSystemHealth.Controls.Add(lblDbStatusLabel);
            grpSystemHealth.Controls.Add(lblDbStatus);
            grpSystemHealth.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSystemHealth.Location = new Point(340, 120);
            grpSystemHealth.Name = "grpSystemHealth";
            grpSystemHealth.Size = new Size(300, 200);
            grpSystemHealth.TabIndex = 4;
            grpSystemHealth.TabStop = false;
            grpSystemHealth.Text = "System Health";
            // 
            // lblDbStatusLabel
            // 
            lblDbStatusLabel.Location = new Point(0, 0);
            lblDbStatusLabel.Name = "lblDbStatusLabel";
            lblDbStatusLabel.Size = new Size(100, 23);
            lblDbStatusLabel.TabIndex = 0;
            // 
            // lblDbStatus
            // 
            lblDbStatus.Location = new Point(0, 0);
            lblDbStatus.Name = "lblDbStatus";
            lblDbStatus.Size = new Size(100, 23);
            lblDbStatus.TabIndex = 1;
            // 
            // lblFsStatusLabel
            // 
            lblFsStatusLabel.Location = new Point(0, 0);
            lblFsStatusLabel.Name = "lblFsStatusLabel";
            lblFsStatusLabel.Size = new Size(100, 23);
            lblFsStatusLabel.TabIndex = 0;
            // 
            // lblFsStatus
            // 
            lblFsStatus.Location = new Point(0, 0);
            lblFsStatus.Name = "lblFsStatus";
            lblFsStatus.Size = new Size(100, 23);
            lblFsStatus.TabIndex = 0;
            // 
            // lblBackupStatusLabel
            // 
            lblBackupStatusLabel.Location = new Point(0, 0);
            lblBackupStatusLabel.Name = "lblBackupStatusLabel";
            lblBackupStatusLabel.Size = new Size(100, 23);
            lblBackupStatusLabel.TabIndex = 0;
            // 
            // lblBackupStatus
            // 
            lblBackupStatus.Location = new Point(0, 0);
            lblBackupStatus.Name = "lblBackupStatus";
            lblBackupStatus.Size = new Size(100, 23);
            lblBackupStatus.TabIndex = 0;
            // 
            // lblLastBackupLabel
            // 
            lblLastBackupLabel.Location = new Point(0, 0);
            lblLastBackupLabel.Name = "lblLastBackupLabel";
            lblLastBackupLabel.Size = new Size(100, 23);
            lblLastBackupLabel.TabIndex = 0;
            // 
            // lblLastBackup
            // 
            lblLastBackup.Location = new Point(0, 0);
            lblLastBackup.Name = "lblLastBackup";
            lblLastBackup.Size = new Size(100, 23);
            lblLastBackup.TabIndex = 0;
            // 
            // lblCpuLabel
            // 
            lblCpuLabel.Location = new Point(0, 0);
            lblCpuLabel.Name = "lblCpuLabel";
            lblCpuLabel.Size = new Size(100, 23);
            lblCpuLabel.TabIndex = 0;
            // 
            // lblCpuUsage
            // 
            lblCpuUsage.Location = new Point(0, 0);
            lblCpuUsage.Name = "lblCpuUsage";
            lblCpuUsage.Size = new Size(100, 23);
            lblCpuUsage.TabIndex = 0;
            // 
            // lblMemoryLabel
            // 
            lblMemoryLabel.Location = new Point(0, 0);
            lblMemoryLabel.Name = "lblMemoryLabel";
            lblMemoryLabel.Size = new Size(100, 23);
            lblMemoryLabel.TabIndex = 0;
            // 
            // lblMemoryUsage
            // 
            lblMemoryUsage.Location = new Point(0, 0);
            lblMemoryUsage.Name = "lblMemoryUsage";
            lblMemoryUsage.Size = new Size(100, 23);
            lblMemoryUsage.TabIndex = 0;
            // 
            // lblDiskLabel
            // 
            lblDiskLabel.Location = new Point(0, 0);
            lblDiskLabel.Name = "lblDiskLabel";
            lblDiskLabel.Size = new Size(100, 23);
            lblDiskLabel.TabIndex = 0;
            // 
            // lblDiskUsage
            // 
            lblDiskUsage.Location = new Point(0, 0);
            lblDiskUsage.Name = "lblDiskUsage";
            lblDiskUsage.Size = new Size(100, 23);
            lblDiskUsage.TabIndex = 0;
            // 
            // progressBarBackup
            // 
            progressBarBackup.Location = new Point(0, 0);
            progressBarBackup.Name = "progressBarBackup";
            progressBarBackup.Size = new Size(100, 23);
            progressBarBackup.TabIndex = 0;
            // 
            // grpActivityLog
            // 
            grpActivityLog.Controls.Add(dataGridViewActivities);
            grpActivityLog.Controls.Add(btnClearLogs);
            grpActivityLog.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpActivityLog.Location = new Point(20, 340);
            grpActivityLog.Name = "grpActivityLog";
            grpActivityLog.Size = new Size(764, 250);
            grpActivityLog.TabIndex = 5;
            grpActivityLog.TabStop = false;
            grpActivityLog.Text = "Recent Activity Log";
            // 
            // dataGridViewActivities
            // 
            dataGridViewActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActivities.Location = new Point(20, 30);
            dataGridViewActivities.Name = "dataGridViewActivities";
            dataGridViewActivities.RowHeadersWidth = 51;
            dataGridViewActivities.Size = new Size(720, 180);
            dataGridViewActivities.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            btnClearLogs.BackColor = Color.FromArgb(220, 53, 69);
            btnClearLogs.FlatStyle = FlatStyle.Flat;
            btnClearLogs.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearLogs.ForeColor = Color.White;
            btnClearLogs.Location = new Point(640, 214);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(100, 30);
            btnClearLogs.TabIndex = 1;
            btnClearLogs.Text = "Clear Logs";
            btnClearLogs.UseVisualStyleBackColor = false;
            btnClearLogs.Click += btnClearLogs_Click;
            // 
            // grpUserDistribution
            // 
            grpUserDistribution.Controls.Add(lblStudentsLabel);
            grpUserDistribution.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpUserDistribution.Location = new Point(660, 120);
            grpUserDistribution.Name = "grpUserDistribution";
            grpUserDistribution.Size = new Size(300, 200);
            grpUserDistribution.TabIndex = 6;
            grpUserDistribution.TabStop = false;
            grpUserDistribution.Text = "User Roles Distribution";
            // 
            // lblStudentsLabel
            // 
            lblStudentsLabel.Location = new Point(0, 0);
            lblStudentsLabel.Name = "lblStudentsLabel";
            lblStudentsLabel.Size = new Size(100, 23);
            lblStudentsLabel.TabIndex = 0;
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.Location = new Point(0, 0);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(100, 23);
            lblStudentsCount.TabIndex = 0;
            // 
            // lblStudentsPercent
            // 
            lblStudentsPercent.Location = new Point(0, 0);
            lblStudentsPercent.Name = "lblStudentsPercent";
            lblStudentsPercent.Size = new Size(100, 23);
            lblStudentsPercent.TabIndex = 0;
            // 
            // lblInstructorsLabel
            // 
            lblInstructorsLabel.Location = new Point(0, 0);
            lblInstructorsLabel.Name = "lblInstructorsLabel";
            lblInstructorsLabel.Size = new Size(100, 23);
            lblInstructorsLabel.TabIndex = 0;
            // 
            // lblInstructorsCount
            // 
            lblInstructorsCount.Location = new Point(0, 0);
            lblInstructorsCount.Name = "lblInstructorsCount";
            lblInstructorsCount.Size = new Size(100, 23);
            lblInstructorsCount.TabIndex = 0;
            // 
            // lblInstructorsPercent
            // 
            lblInstructorsPercent.Location = new Point(0, 0);
            lblInstructorsPercent.Name = "lblInstructorsPercent";
            lblInstructorsPercent.Size = new Size(100, 23);
            lblInstructorsPercent.TabIndex = 0;
            // 
            // lblAdminsLabel
            // 
            lblAdminsLabel.Location = new Point(0, 0);
            lblAdminsLabel.Name = "lblAdminsLabel";
            lblAdminsLabel.Size = new Size(100, 23);
            lblAdminsLabel.TabIndex = 0;
            // 
            // lblAdminsCount
            // 
            lblAdminsCount.Location = new Point(0, 0);
            lblAdminsCount.Name = "lblAdminsCount";
            lblAdminsCount.Size = new Size(100, 23);
            lblAdminsCount.TabIndex = 0;
            // 
            // lblAdminsPercent
            // 
            lblAdminsPercent.Location = new Point(0, 0);
            lblAdminsPercent.Name = "lblAdminsPercent";
            lblAdminsPercent.Size = new Size(100, 23);
            lblAdminsPercent.TabIndex = 0;
            // 
            // btnRefresh
            // 
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
            // 
            // btnRunBackup
            // 
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
            // 
            // btnSystemSettings
            // 
            btnSystemSettings.Location = new Point(0, 0);
            btnSystemSettings.Name = "btnSystemSettings";
            btnSystemSettings.Size = new Size(75, 23);
            btnSystemSettings.TabIndex = 0;
            // 
            // btnUserManagement
            // 
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
            // 
            // btnDatabaseTools
            // 
            btnDatabaseTools.Location = new Point(0, 0);
            btnDatabaseTools.Name = "btnDatabaseTools";
            btnDatabaseTools.Size = new Size(75, 23);
            btnDatabaseTools.TabIndex = 0;
            // 
            // btnExportData
            // 
            btnExportData.Location = new Point(0, 0);
            btnExportData.Name = "btnExportData";
            btnExportData.Size = new Size(75, 23);
            btnExportData.TabIndex = 0;
            // 
            // btnEmergencyLockdown
            // 
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
            // 
            // btnClose
            // 
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
            // 
            // linkLabelHelp
            // 
            linkLabelHelp.AutoSize = true;
            linkLabelHelp.Location = new Point(850, 30);
            linkLabelHelp.Name = "linkLabelHelp";
            linkLabelHelp.Size = new Size(126, 20);
            linkLabelHelp.TabIndex = 12;
            linkLabelHelp.TabStop = true;
            linkLabelHelp.Text = "Admin Help Docs";
            linkLabelHelp.LinkClicked += linkLabelHelp_LinkClicked;
            // 
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
            Controls.Add(btnAddUser);
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
            grpActivityLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).EndInit();
            grpUserDistribution.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

            // 
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
            Controls.Add(btnAddUser); // ADD THIS LINE
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
            grpActivityLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).EndInit();
            grpUserDistribution.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}