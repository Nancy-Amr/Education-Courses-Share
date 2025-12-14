namespace CoursesSharesDB.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalResources;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.GroupBox grpNavigation;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageResources;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdminTools;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblWelcome = new Label();
            lblTotalUsers = new Label();
            lblTotalResources = new Label();
            lblTotalCourses = new Label();
            grpStatistics = new GroupBox();
            grpNavigation = new GroupBox();
            btnManageUsers = new Button();
            btnManageResources = new Button();
            btnManageCourses = new Button();
            btnViewReports = new Button();
            btnSearch = new Button();
            btnExit = new Button();
            pictureBox1 = new PictureBox();
            btnLogout = new Button();
            btnAdminTools = new Button();
            grpStatistics.SuspendLayout();
            grpNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 70, 120);
            lblTitle.Location = new Point(188, 19);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(690, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Courses Shares Management";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(188, 69);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(424, 29);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Advanced Database Project - Team 16";
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUsers.Location = new Point(25, 40);
            lblTotalUsers.Margin = new Padding(4, 0, 4, 0);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(160, 25);
            lblTotalUsers.TabIndex = 2;
            lblTotalUsers.Text = "Total Users: 0";
            // 
            // lblTotalResources
            // 
            lblTotalResources.AutoSize = true;
            lblTotalResources.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalResources.Location = new Point(25, 80);
            lblTotalResources.Margin = new Padding(4, 0, 4, 0);
            lblTotalResources.Name = "lblTotalResources";
            lblTotalResources.Size = new Size(211, 25);
            lblTotalResources.TabIndex = 3;
            lblTotalResources.Text = "Total Resources: 0";
            // 
            // lblTotalCourses
            // 
            lblTotalCourses.AutoSize = true;
            lblTotalCourses.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCourses.Location = new Point(25, 120);
            lblTotalCourses.Margin = new Padding(4, 0, 4, 0);
            lblTotalCourses.Name = "lblTotalCourses";
            lblTotalCourses.Size = new Size(186, 25);
            lblTotalCourses.TabIndex = 4;
            lblTotalCourses.Text = "Total Courses: 0";
            // 
            // grpStatistics
            // 
            grpStatistics.Controls.Add(lblTotalUsers);
            grpStatistics.Controls.Add(lblTotalCourses);
            grpStatistics.Controls.Add(lblTotalResources);
            grpStatistics.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpStatistics.Location = new Point(188, 112);
            grpStatistics.Margin = new Padding(4, 5, 4, 5);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Padding = new Padding(4, 5, 4, 5);
            grpStatistics.Size = new Size(438, 160);
            grpStatistics.TabIndex = 5;
            grpStatistics.TabStop = false;
            grpStatistics.Text = "System Statistics";
            // 
            // grpNavigation
            // 
            grpNavigation.Controls.Add(btnManageUsers);
            grpNavigation.Controls.Add(btnManageResources);
            grpNavigation.Controls.Add(btnManageCourses);
            grpNavigation.Controls.Add(btnViewReports);
            grpNavigation.Controls.Add(btnSearch);
            grpNavigation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpNavigation.Location = new Point(188, 280);
            grpNavigation.Margin = new Padding(4, 5, 4, 5);
            grpNavigation.Name = "grpNavigation";
            grpNavigation.Padding = new Padding(4, 5, 4, 5);
            grpNavigation.Size = new Size(438, 369);
            grpNavigation.TabIndex = 6;
            grpNavigation.TabStop = false;
            grpNavigation.Text = "Navigation";
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.FromArgb(0, 123, 255);
            btnManageUsers.FlatStyle = FlatStyle.Flat;
            btnManageUsers.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Location = new Point(31, 44);
            btnManageUsers.Margin = new Padding(4, 5, 4, 5);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(375, 52);
            btnManageUsers.TabIndex = 0;
            btnManageUsers.Text = "&View Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnManageResources
            // 
            btnManageResources.BackColor = Color.FromArgb(40, 167, 69);
            btnManageResources.FlatStyle = FlatStyle.Flat;
            btnManageResources.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageResources.ForeColor = Color.White;
            btnManageResources.Location = new Point(31, 109);
            btnManageResources.Margin = new Padding(4, 5, 4, 5);
            btnManageResources.Name = "btnManageResources";
            btnManageResources.Size = new Size(375, 52);
            btnManageResources.TabIndex = 1;
            btnManageResources.Text = "&Manage Resources";
            btnManageResources.UseVisualStyleBackColor = false;
            btnManageResources.Click += btnManageResources_Click;
            // 
            // btnManageCourses
            // 
            btnManageCourses.BackColor = Color.FromArgb(220, 53, 69);
            btnManageCourses.FlatStyle = FlatStyle.Flat;
            btnManageCourses.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageCourses.ForeColor = Color.White;
            btnManageCourses.Location = new Point(31, 171);
            btnManageCourses.Margin = new Padding(4, 5, 4, 5);
            btnManageCourses.Name = "btnManageCourses";
            btnManageCourses.Size = new Size(375, 52);
            btnManageCourses.TabIndex = 2;
            btnManageCourses.Text = "&Manage Courses";
            btnManageCourses.UseVisualStyleBackColor = false;
            btnManageCourses.Click += btnManageCourses_Click;
            // 
            // btnViewReports
            // 
            btnViewReports.BackColor = Color.FromArgb(255, 193, 7);
            btnViewReports.FlatStyle = FlatStyle.Flat;
            btnViewReports.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReports.ForeColor = Color.White;
            btnViewReports.Location = new Point(31, 233);
            btnViewReports.Margin = new Padding(4, 5, 4, 5);
            btnViewReports.Name = "btnViewReports";
            btnViewReports.Size = new Size(375, 52);
            btnViewReports.TabIndex = 3;
            btnViewReports.Text = "&View Reports";
            btnViewReports.UseVisualStyleBackColor = false;
            btnViewReports.Click += btnViewReports_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(23, 162, 184);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(31, 295);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(375, 52);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "&Search Resources";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(108, 117, 125);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(688, 280);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(188, 56);
            btnExit.TabIndex = 7;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(62, 19);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 125);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(688, 450);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(188, 56);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "&Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAdminTools
            // 
            btnAdminTools.BackColor = Color.FromArgb(111, 66, 193);
            btnAdminTools.FlatStyle = FlatStyle.Flat;
            btnAdminTools.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminTools.ForeColor = Color.White;
            btnAdminTools.Location = new Point(688, 380);
            btnAdminTools.Margin = new Padding(4, 5, 4, 5);
            btnAdminTools.Name = "btnAdminTools";
            btnAdminTools.Size = new Size(188, 56);
            btnAdminTools.TabIndex = 11;
            btnAdminTools.Text = "&Admin Tools";
            btnAdminTools.UseVisualStyleBackColor = false;
            btnAdminTools.Visible = false;
            btnAdminTools.Click += btnAdminTools_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(938, 750);
            Controls.Add(pictureBox1);
            Controls.Add(btnExit);
            Controls.Add(grpNavigation);
            Controls.Add(grpStatistics);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Controls.Add(btnLogout);
            Controls.Add(btnAdminTools);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Courses Shares Management System";
            Load += MainForm_Load;
            grpStatistics.ResumeLayout(false);
            grpStatistics.PerformLayout();
            grpNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}