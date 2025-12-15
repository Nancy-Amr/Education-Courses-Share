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
        private Button btnUserManagement;

        private Button btnExportData;

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
            btnUserManagement = new Button();

            btnExportData = new Button();

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
            lblStatEnrollments.AutoSize = true;
            lblStatEnrollments.Location = new Point(20, 80);
            lblStatEnrollments.Name = "lblStatEnrollments";
            lblStatEnrollments.Size = new Size(103, 18);
            lblStatEnrollments.TabIndex = 2;
            lblStatEnrollments.Text = "Enrollments:";
            // 
            // lblTotalEnrollments
            // 
            lblTotalEnrollments.AutoSize = true;
            lblTotalEnrollments.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalEnrollments.ForeColor = Color.Green;
            lblTotalEnrollments.Location = new Point(150, 80);
            lblTotalEnrollments.Name = "lblTotalEnrollments";
            lblTotalEnrollments.Size = new Size(19, 20);
            lblTotalEnrollments.TabIndex = 3;
            lblTotalEnrollments.Text = "0";
            // 
            // lblStatActiveUsers
            // 
            lblStatActiveUsers.AutoSize = true;
            lblStatActiveUsers.Location = new Point(20, 120);
            lblStatActiveUsers.Name = "lblStatActiveUsers";
            lblStatActiveUsers.Size = new Size(108, 18);
            lblStatActiveUsers.TabIndex = 4;
            lblStatActiveUsers.Text = "Active Users:";
            // 
            // lblActiveUsers
            // 
            lblActiveUsers.AutoSize = true;
            lblActiveUsers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveUsers.ForeColor = Color.Orange;
            lblActiveUsers.Location = new Point(150, 120);
            lblActiveUsers.Name = "lblActiveUsers";
            lblActiveUsers.Size = new Size(19, 20);
            lblActiveUsers.TabIndex = 5;
            lblActiveUsers.Text = "0";
            // 
            // grpSystemHealth
            // 
            grpSystemHealth.Controls.Add(lblDbStatusLabel);
            grpSystemHealth.Controls.Add(lblDbStatus);
            grpSystemHealth.Controls.Add(lblFsStatusLabel);
            grpSystemHealth.Controls.Add(lblFsStatus);
            grpSystemHealth.Controls.Add(lblBackupStatusLabel);
            grpSystemHealth.Controls.Add(lblBackupStatus);
            grpSystemHealth.Controls.Add(lblLastBackupLabel);
            grpSystemHealth.Controls.Add(lblLastBackup);
            grpSystemHealth.Controls.Add(lblCpuLabel);
            grpSystemHealth.Controls.Add(lblCpuUsage);
            grpSystemHealth.Controls.Add(lblMemoryLabel);
            grpSystemHealth.Controls.Add(lblMemoryUsage);
            grpSystemHealth.Controls.Add(lblDiskLabel);
            grpSystemHealth.Controls.Add(lblDiskUsage);
            grpSystemHealth.Controls.Add(progressBarBackup);
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
            lblDbStatusLabel.AutoSize = true;
            lblDbStatusLabel.Location = new Point(20, 30);
            lblDbStatusLabel.Name = "lblDbStatusLabel";
            lblDbStatusLabel.Size = new Size(84, 18);
            lblDbStatusLabel.TabIndex = 0;
            lblDbStatusLabel.Text = "Database:";
            // 
            // lblDbStatus
            // 
            lblDbStatus.AutoSize = true;
            lblDbStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDbStatus.Location = new Point(140, 30);
            lblDbStatus.Name = "lblDbStatus";
            lblDbStatus.Size = new Size(93, 18);
            lblDbStatus.TabIndex = 1;
            lblDbStatus.Text = "Checking...";
            // 
            // lblFsStatusLabel
            // 
            lblFsStatusLabel.AutoSize = true;
            lblFsStatusLabel.Location = new Point(20, 60);
            lblFsStatusLabel.Name = "lblFsStatusLabel";
            lblFsStatusLabel.Size = new Size(101, 18);
            lblFsStatusLabel.TabIndex = 2;
            lblFsStatusLabel.Text = "File System:";
            // 
            // lblFsStatus
            // 
            lblFsStatus.AutoSize = true;
            lblFsStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFsStatus.Location = new Point(140, 60);
            lblFsStatus.Name = "lblFsStatus";
            lblFsStatus.Size = new Size(93, 18);
            lblFsStatus.TabIndex = 3;
            lblFsStatus.Text = "Checking...";
            // 
            // lblBackupStatusLabel
            // 
            lblBackupStatusLabel.AutoSize = true;
            lblBackupStatusLabel.Location = new Point(20, 90);
            lblBackupStatusLabel.Name = "lblBackupStatusLabel";
            lblBackupStatusLabel.Size = new Size(122, 18);
            lblBackupStatusLabel.TabIndex = 4;
            lblBackupStatusLabel.Text = "Backup Status:";
            // 
            // lblBackupStatus
            // 
            lblBackupStatus.AutoSize = true;
            lblBackupStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBackupStatus.Location = new Point(140, 90);
            lblBackupStatus.Name = "lblBackupStatus";
            lblBackupStatus.Size = new Size(56, 18);
            lblBackupStatus.TabIndex = 5;
            lblBackupStatus.Text = "Status";
            // 
            // lblLastBackupLabel
            // 
            lblLastBackupLabel.AutoSize = true;
            lblLastBackupLabel.Location = new Point(20, 115);
            lblLastBackupLabel.Name = "lblLastBackupLabel";
            lblLastBackupLabel.Size = new Size(106, 18);
            lblLastBackupLabel.TabIndex = 6;
            lblLastBackupLabel.Text = "Last Backup:";
            // 
            // lblLastBackup
            // 
            lblLastBackup.AutoSize = true;
            lblLastBackup.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastBackup.Location = new Point(140, 115);
            lblLastBackup.Name = "lblLastBackup";
            lblLastBackup.Size = new Size(31, 17);
            lblLastBackup.TabIndex = 7;
            lblLastBackup.Text = "N/A";
            // 
            // lblCpuLabel
            // 
            lblCpuLabel.AutoSize = true;
            lblCpuLabel.Location = new Point(20, 140);
            lblCpuLabel.Name = "lblCpuLabel";
            lblCpuLabel.Size = new Size(48, 18);
            lblCpuLabel.TabIndex = 8;
            lblCpuLabel.Text = "CPU:";
            // 
            // lblCpuUsage
            // 
            lblCpuUsage.AutoSize = true;
            lblCpuUsage.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCpuUsage.Location = new Point(90, 140);
            lblCpuUsage.Name = "lblCpuUsage";
            lblCpuUsage.Size = new Size(31, 18);
            lblCpuUsage.TabIndex = 9;
            lblCpuUsage.Text = "0%";
            // 
            // lblMemoryLabel
            // 
            lblMemoryLabel.AutoSize = true;
            lblMemoryLabel.Location = new Point(140, 140);
            lblMemoryLabel.Name = "lblMemoryLabel";
            lblMemoryLabel.Size = new Size(50, 18);
            lblMemoryLabel.TabIndex = 10;
            lblMemoryLabel.Text = "Mem:";
            // 
            // lblMemoryUsage
            // 
            lblMemoryUsage.AutoSize = true;
            lblMemoryUsage.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemoryUsage.Location = new Point(195, 140);
            lblMemoryUsage.Name = "lblMemoryUsage";
            lblMemoryUsage.Size = new Size(31, 18);
            lblMemoryUsage.TabIndex = 11;
            lblMemoryUsage.Text = "0%";
            // 
            // lblDiskLabel
            // 
            lblDiskLabel.AutoSize = true;
            lblDiskLabel.Location = new Point(20, 165);
            lblDiskLabel.Name = "lblDiskLabel";
            lblDiskLabel.Size = new Size(47, 18);
            lblDiskLabel.TabIndex = 12;
            lblDiskLabel.Text = "Disk:";
            // 
            // lblDiskUsage
            // 
            lblDiskUsage.AutoSize = true;
            lblDiskUsage.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiskUsage.Location = new Point(90, 165);
            lblDiskUsage.Name = "lblDiskUsage";
            lblDiskUsage.Size = new Size(31, 18);
            lblDiskUsage.TabIndex = 13;
            lblDiskUsage.Text = "0%";
            // 
            // progressBarBackup
            // 
            progressBarBackup.Location = new Point(20, 175);
            progressBarBackup.Name = "progressBarBackup";
            progressBarBackup.Size = new Size(260, 15);
            progressBarBackup.TabIndex = 14;
            progressBarBackup.Visible = false;
            // 
            // grpActivityLog
            // 
            grpActivityLog.Controls.Add(dataGridViewActivities);
            grpActivityLog.Controls.Add(btnClearLogs);
            grpActivityLog.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpActivityLog.Location = new Point(20, 340);
            grpActivityLog.Name = "grpActivityLog";
            grpActivityLog.Size = new Size(950, 240);
            grpActivityLog.TabIndex = 5;
            grpActivityLog.TabStop = false;
            grpActivityLog.Text = "Recent Activity Log";
            // 
            // dataGridViewActivities
            // 
            dataGridViewActivities.AllowUserToAddRows = false;
            dataGridViewActivities.AllowUserToDeleteRows = false;
            dataGridViewActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActivities.Location = new Point(20, 30);
            dataGridViewActivities.Name = "dataGridViewActivities";
            dataGridViewActivities.ReadOnly = true;
            dataGridViewActivities.RowHeadersWidth = 51;
            dataGridViewActivities.Size = new Size(910, 165);
            dataGridViewActivities.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            btnClearLogs.BackColor = Color.FromArgb(220, 53, 69);
            btnClearLogs.FlatStyle = FlatStyle.Flat;
            btnClearLogs.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearLogs.ForeColor = Color.White;
            btnClearLogs.Location = new Point(830, 200);
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
            grpUserDistribution.Controls.Add(lblStudentsCount);
            grpUserDistribution.Controls.Add(lblStudentsPercent);
            grpUserDistribution.Controls.Add(lblInstructorsLabel);
            grpUserDistribution.Controls.Add(lblInstructorsCount);
            grpUserDistribution.Controls.Add(lblInstructorsPercent);
            grpUserDistribution.Controls.Add(lblAdminsLabel);
            grpUserDistribution.Controls.Add(lblAdminsCount);
            grpUserDistribution.Controls.Add(lblAdminsPercent);
            grpUserDistribution.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpUserDistribution.Location = new Point(660, 120);
            grpUserDistribution.Name = "grpUserDistribution";
            grpUserDistribution.Size = new Size(310, 200);
            grpUserDistribution.TabIndex = 6;
            grpUserDistribution.TabStop = false;
            grpUserDistribution.Text = "User Roles Distribution";
            // 
            // lblStudentsLabel
            // 
            lblStudentsLabel.AutoSize = true;
            lblStudentsLabel.Location = new Point(20, 40);
            lblStudentsLabel.Name = "lblStudentsLabel";
            lblStudentsLabel.Size = new Size(79, 18);
            lblStudentsLabel.TabIndex = 0;
            lblStudentsLabel.Text = "Students:";
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsCount.ForeColor = Color.Blue;
            lblStudentsCount.Location = new Point(140, 40);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(19, 20);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsPercent
            // 
            lblStudentsPercent.AutoSize = true;
            lblStudentsPercent.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentsPercent.Location = new Point(190, 42);
            lblStudentsPercent.Name = "lblStudentsPercent";
            lblStudentsPercent.Size = new Size(38, 17);
            lblStudentsPercent.TabIndex = 2;
            lblStudentsPercent.Text = "(0%)";
            // 
            // lblInstructorsLabel
            // 
            lblInstructorsLabel.AutoSize = true;
            lblInstructorsLabel.Location = new Point(20, 80);
            lblInstructorsLabel.Name = "lblInstructorsLabel";
            lblInstructorsLabel.Size = new Size(94, 18);
            lblInstructorsLabel.TabIndex = 3;
            lblInstructorsLabel.Text = "Instructors:";
            // 
            // lblInstructorsCount
            // 
            lblInstructorsCount.AutoSize = true;
            lblInstructorsCount.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInstructorsCount.ForeColor = Color.Green;
            lblInstructorsCount.Location = new Point(140, 80);
            lblInstructorsCount.Name = "lblInstructorsCount";
            lblInstructorsCount.Size = new Size(19, 20);
            lblInstructorsCount.TabIndex = 4;
            lblInstructorsCount.Text = "0";
            // 
            // lblInstructorsPercent
            // 
            lblInstructorsPercent.AutoSize = true;
            lblInstructorsPercent.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstructorsPercent.Location = new Point(190, 82);
            lblInstructorsPercent.Name = "lblInstructorsPercent";
            lblInstructorsPercent.Size = new Size(38, 17);
            lblInstructorsPercent.TabIndex = 5;
            lblInstructorsPercent.Text = "(0%)";
            // 
            // lblAdminsLabel
            // 
            lblAdminsLabel.AutoSize = true;
            lblAdminsLabel.Location = new Point(20, 120);
            lblAdminsLabel.Name = "lblAdminsLabel";
            lblAdminsLabel.Size = new Size(68, 18);
            lblAdminsLabel.TabIndex = 6;
            lblAdminsLabel.Text = "Admins:";
            // 
            // lblAdminsCount
            // 
            lblAdminsCount.AutoSize = true;
            lblAdminsCount.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminsCount.ForeColor = Color.Red;
            lblAdminsCount.Location = new Point(140, 120);
            lblAdminsCount.Name = "lblAdminsCount";
            lblAdminsCount.Size = new Size(19, 20);
            lblAdminsCount.TabIndex = 7;
            lblAdminsCount.Text = "0";
            // 
            // lblAdminsPercent
            // 
            lblAdminsPercent.AutoSize = true;
            lblAdminsPercent.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminsPercent.Location = new Point(190, 122);
            lblAdminsPercent.Name = "lblAdminsPercent";
            lblAdminsPercent.Size = new Size(38, 17);
            lblAdminsPercent.TabIndex = 8;
            lblAdminsPercent.Text = "(0%)";
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
            btnRunBackup.Location = new Point(146, 600);
            btnRunBackup.Name = "btnRunBackup";
            btnRunBackup.Size = new Size(130, 40);
            btnRunBackup.TabIndex = 8;
            btnRunBackup.Text = "&Run Backup";
            btnRunBackup.UseVisualStyleBackColor = false;
            btnRunBackup.Click += btnRunBackup_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.BackColor = Color.FromArgb(255, 193, 7);
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Location = new Point(418, 600);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(180, 40);
            btnUserManagement.TabIndex = 10;
            btnUserManagement.Text = "&User Management";
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;

            // 
            // btnExportData
            // 
            btnExportData.BackColor = Color.FromArgb(111, 66, 193);
            btnExportData.FlatStyle = FlatStyle.Flat;
            btnExportData.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportData.ForeColor = Color.White;
            btnExportData.Location = new Point(282, 600);
            btnExportData.Name = "btnExportData";
            btnExportData.Size = new Size(130, 40);
            btnExportData.TabIndex = 12;
            btnExportData.Text = "&Export Data";
            btnExportData.UseVisualStyleBackColor = false;
            btnExportData.Click += btnExportData_Click;

            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(20, 650);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 14;
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
            linkLabelHelp.TabIndex = 16;
            linkLabelHelp.TabStop = true;
            linkLabelHelp.Text = "Admin Help Docs";
            linkLabelHelp.LinkClicked += linkLabelHelp_LinkClicked;
            // 
            // AdminToolsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 710);
            Controls.Add(linkLabelHelp);
            Controls.Add(btnClose);

            Controls.Add(btnExportData);

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