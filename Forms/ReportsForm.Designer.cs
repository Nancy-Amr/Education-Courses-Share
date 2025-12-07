namespace CoursesSharesDB.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Button btnPopularResources;
        private System.Windows.Forms.Button btnResourceEngagement;
        private System.Windows.Forms.Button btnCourseResourceSummary;
        private System.Windows.Forms.Button btnMonthlyUploads;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label lblReportDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpReportResults;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpReports = new System.Windows.Forms.GroupBox();
            this.btnMonthlyUploads = new System.Windows.Forms.Button();
            this.btnCourseResourceSummary = new System.Windows.Forms.Button();
            this.btnResourceEngagement = new System.Windows.Forms.Button();
            this.btnPopularResources = new System.Windows.Forms.Button();
            this.grpReportResults = new System.Windows.Forms.GroupBox();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpReports.SuspendLayout();
            this.grpReportResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Analytics Reports";
            // 
            // grpReports
            // 
            this.grpReports.Controls.Add(this.btnMonthlyUploads);
            this.grpReports.Controls.Add(this.btnCourseResourceSummary);
            this.grpReports.Controls.Add(this.btnResourceEngagement);
            this.grpReports.Controls.Add(this.btnPopularResources);
            this.grpReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReports.Location = new System.Drawing.Point(12, 60);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(350, 250);
            this.grpReports.TabIndex = 1;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Available Reports";
            // 
            // btnMonthlyUploads
            // 
            this.btnMonthlyUploads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnMonthlyUploads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthlyUploads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthlyUploads.ForeColor = System.Drawing.Color.White;
            this.btnMonthlyUploads.Location = new System.Drawing.Point(25, 195);
            this.btnMonthlyUploads.Name = "btnMonthlyUploads";
            this.btnMonthlyUploads.Size = new System.Drawing.Size(300, 40);
            this.btnMonthlyUploads.TabIndex = 3;
            this.btnMonthlyUploads.Text = "4. Monthly Resource Uploads Trend";
            this.btnMonthlyUploads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonthlyUploads.UseVisualStyleBackColor = false;
            this.btnMonthlyUploads.Click += new System.EventHandler(this.btnMonthlyUploads_Click);
            // 
            // btnCourseResourceSummary
            // 
            this.btnCourseResourceSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCourseResourceSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourseResourceSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseResourceSummary.ForeColor = System.Drawing.Color.White;
            this.btnCourseResourceSummary.Location = new System.Drawing.Point(25, 145);
            this.btnCourseResourceSummary.Name = "btnCourseResourceSummary";
            this.btnCourseResourceSummary.Size = new System.Drawing.Size(300, 40);
            this.btnCourseResourceSummary.TabIndex = 2;
            this.btnCourseResourceSummary.Text = "3. Course Resource Summary";
            this.btnCourseResourceSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourseResourceSummary.UseVisualStyleBackColor = false;
            this.btnCourseResourceSummary.Click += new System.EventHandler(this.btnCourseResourceSummary_Click);
            // 
            // btnResourceEngagement
            // 
            this.btnResourceEngagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnResourceEngagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResourceEngagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResourceEngagement.ForeColor = System.Drawing.Color.White;
            this.btnResourceEngagement.Location = new System.Drawing.Point(25, 95);
            this.btnResourceEngagement.Name = "btnResourceEngagement";
            this.btnResourceEngagement.Size = new System.Drawing.Size(300, 40);
            this.btnResourceEngagement.TabIndex = 1;
            this.btnResourceEngagement.Text = "2. Resource Engagement Analysis";
            this.btnResourceEngagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResourceEngagement.UseVisualStyleBackColor = false;
            this.btnResourceEngagement.Click += new System.EventHandler(this.btnResourceEngagement_Click);
            // 
            // btnPopularResources
            // 
            this.btnPopularResources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnPopularResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopularResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopularResources.ForeColor = System.Drawing.Color.White;
            this.btnPopularResources.Location = new System.Drawing.Point(25, 45);
            this.btnPopularResources.Name = "btnPopularResources";
            this.btnPopularResources.Size = new System.Drawing.Size(300, 40);
            this.btnPopularResources.TabIndex = 0;
            this.btnPopularResources.Text = "1. Most Popular Resources (by Saves)";
            this.btnPopularResources.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPopularResources.UseVisualStyleBackColor = false;
            this.btnPopularResources.Click += new System.EventHandler(this.btnPopularResources_Click);
            // 
            // grpReportResults
            // 
            this.grpReportResults.Controls.Add(this.dataGridViewReports);
            this.grpReportResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportResults.Location = new System.Drawing.Point(380, 60);
            this.grpReportResults.Name = "grpReportResults";
            this.grpReportResults.Size = new System.Drawing.Size(550, 400);
            this.grpReportResults.TabIndex = 2;
            this.grpReportResults.TabStop = false;
            this.grpReportResults.Text = "Report Results";
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            this.dataGridViewReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new System.Drawing.Point(15, 30);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersWidth = 51;
            this.dataGridViewReports.RowTemplate.Height = 24;
            this.dataGridViewReports.Size = new System.Drawing.Size(520, 350);
            this.dataGridViewReports.TabIndex = 0;
            // 
            // lblReportDescription
            // 
            this.lblReportDescription.AutoSize = true;
            this.lblReportDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDescription.Location = new System.Drawing.Point(380, 470);
            this.lblReportDescription.Name = "lblReportDescription";
            this.lblReportDescription.Size = new System.Drawing.Size(400, 18);
            this.lblReportDescription.TabIndex = 3;
            this.lblReportDescription.Text = "Select a report from the left to view analytics and statistics.";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(810, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblReportDescription);
            this.Controls.Add(this.grpReportResults);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analytics Reports";
            this.grpReports.ResumeLayout(false);
            this.grpReportResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}