namespace CoursesSharesDB.Forms
{
    partial class ResourceManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        // DataGridView
        private System.Windows.Forms.DataGridView dataGridViewResources;

        // Labels
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalResources;

        // Search Controls
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSearchCourse;
        private System.Windows.Forms.TextBox txtSearchCourseCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        // Details Controls
        private System.Windows.Forms.GroupBox grpDetails;
        
        // Col 1
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.ComboBox cmbCourseCode;
        private System.Windows.Forms.Label lblUploader;
        private System.Windows.Forms.ComboBox cmbUploader;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;

        // Col 2
        private System.Windows.Forms.Label lblUploadDate;
        private System.Windows.Forms.DateTimePicker dtpUploadDate;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.ComboBox cmbContentType;
        private System.Windows.Forms.Label lblContentUrl;
        private System.Windows.Forms.TextBox txtContentUrl;
        private System.Windows.Forms.Button btnBrowse; // Added
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Label lblTopics;
        private System.Windows.Forms.ComboBox cmbTopics; // Changed
        private System.Windows.Forms.Label lblReactions;
        private System.Windows.Forms.TextBox txtReactions;

        // Button Panel
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewResources = new System.Windows.Forms.DataGridView();
            lblTitle = new System.Windows.Forms.Label();
            lblTotalResources = new System.Windows.Forms.Label();
            
            // Search
            grpSearch = new System.Windows.Forms.GroupBox();
            btnRefresh = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            txtSearchCourseCode = new System.Windows.Forms.TextBox();
            lblSearchCourse = new System.Windows.Forms.Label();
            txtSearchName = new System.Windows.Forms.TextBox();
            lblSearchName = new System.Windows.Forms.Label();

            // Details
            grpDetails = new System.Windows.Forms.GroupBox();
            txtReactions = new System.Windows.Forms.TextBox();
            lblReactions = new System.Windows.Forms.Label();
            cmbTopics = new System.Windows.Forms.ComboBox();
            lblTopics = new System.Windows.Forms.Label();
            cmbFileType = new System.Windows.Forms.ComboBox();
            lblFileType = new System.Windows.Forms.Label();
            btnBrowse = new System.Windows.Forms.Button();
            txtContentUrl = new System.Windows.Forms.TextBox();
            lblContentUrl = new System.Windows.Forms.Label();
            cmbContentType = new System.Windows.Forms.ComboBox();
            lblContentType = new System.Windows.Forms.Label();
            dtpUploadDate = new System.Windows.Forms.DateTimePicker();
            lblUploadDate = new System.Windows.Forms.Label();
            cmbCategory = new System.Windows.Forms.ComboBox();
            lblCategory = new System.Windows.Forms.Label();
            cmbUploader = new System.Windows.Forms.ComboBox();
            lblUploader = new System.Windows.Forms.Label();
            cmbCourseCode = new System.Windows.Forms.ComboBox();
            lblCourseCode = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            lblDescription = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            txtId = new System.Windows.Forms.TextBox();
            lblId = new System.Windows.Forms.Label();

            // Controls
            pnlControls = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(dataGridViewResources)).BeginInit();
            grpSearch.SuspendLayout();
            grpDetails.SuspendLayout();
            pnlControls.SuspendLayout();
            SuspendLayout();

            // 
            // dataGridViewResources
            // 
            dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResources.Location = new System.Drawing.Point(12, 75);
            dataGridViewResources.Name = "dataGridViewResources";
            dataGridViewResources.RowHeadersWidth = 51;
            dataGridViewResources.RowTemplate.Height = 24;
            dataGridViewResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResources.Size = new System.Drawing.Size(1240, 200); 
            dataGridViewResources.TabIndex = 3;
            dataGridViewResources.SelectionChanged += dataGridViewResources_SelectionChanged;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            lblTitle.Location = new System.Drawing.Point(12, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(335, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Resource Management";

            // 
            // lblTotalResources
            // 
            lblTotalResources.AutoSize = true;
            lblTotalResources.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalResources.Location = new System.Drawing.Point(20, 50);
            lblTotalResources.Name = "lblTotalResources";
            lblTotalResources.Size = new System.Drawing.Size(136, 20);
            lblTotalResources.TabIndex = 1;
            lblTotalResources.Text = "Total Resources: 0";

            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(btnRefresh);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtSearchCourseCode);
            grpSearch.Controls.Add(lblSearchCourse);
            grpSearch.Controls.Add(txtSearchName);
            grpSearch.Controls.Add(lblSearchName);
            grpSearch.Location = new System.Drawing.Point(400, 5);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new System.Drawing.Size(800, 60);
            grpSearch.TabIndex = 2;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search";

            // 
            // lblSearchName
            // 
            lblSearchName.AutoSize = true;
            lblSearchName.Location = new System.Drawing.Point(15, 25);
            lblSearchName.Name = "lblSearchName";
            lblSearchName.Size = new System.Drawing.Size(49, 17);
            lblSearchName.TabIndex = 0;
            lblSearchName.Text = "Name:";

            // 
            // txtSearchName
            // 
            txtSearchName.Location = new System.Drawing.Point(70, 22);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new System.Drawing.Size(180, 22);
            txtSearchName.TabIndex = 1;

            // 
            // lblSearchCourse
            // 
            lblSearchCourse.AutoSize = true;
            lblSearchCourse.Location = new System.Drawing.Point(270, 25);
            lblSearchCourse.Name = "lblSearchCourse";
            lblSearchCourse.Size = new System.Drawing.Size(57, 17);
            lblSearchCourse.TabIndex = 2;
            lblSearchCourse.Text = "Course:";

            // 
            // txtSearchCourseCode
            // 
            txtSearchCourseCode.Location = new System.Drawing.Point(330, 22);
            txtSearchCourseCode.Name = "txtSearchCourseCode";
            txtSearchCourseCode.Size = new System.Drawing.Size(120, 22);
            txtSearchCourseCode.TabIndex = 3;

            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(480, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(90, 30);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.Gray;
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(580, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(90, 30);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(txtReactions);
            grpDetails.Controls.Add(lblReactions);
            grpDetails.Controls.Add(cmbTopics); // Updated to ComboBox
            grpDetails.Controls.Add(lblTopics);
            grpDetails.Controls.Add(cmbFileType);
            grpDetails.Controls.Add(lblFileType);
            grpDetails.Controls.Add(btnBrowse); // Added Button
            grpDetails.Controls.Add(txtContentUrl);
            grpDetails.Controls.Add(lblContentUrl);
            grpDetails.Controls.Add(cmbContentType);
            grpDetails.Controls.Add(lblContentType);
            grpDetails.Controls.Add(dtpUploadDate);
            grpDetails.Controls.Add(lblUploadDate);
            grpDetails.Controls.Add(cmbCategory);
            grpDetails.Controls.Add(lblCategory);
            grpDetails.Controls.Add(cmbUploader);
            grpDetails.Controls.Add(lblUploader);
            grpDetails.Controls.Add(cmbCourseCode);
            grpDetails.Controls.Add(lblCourseCode);
            grpDetails.Controls.Add(txtDescription);
            grpDetails.Controls.Add(lblDescription);
            grpDetails.Controls.Add(txtName);
            grpDetails.Controls.Add(lblName);
            grpDetails.Controls.Add(txtId);
            grpDetails.Controls.Add(lblId);
            grpDetails.Location = new System.Drawing.Point(12, 285);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new System.Drawing.Size(1240, 260);
            grpDetails.TabIndex = 4;
            grpDetails.TabStop = false;
            grpDetails.Text = "Detailed Information";

            // Left Col Y: 25, 55, 85, 145, 175, 205
            
            // Row 1
            lblId.AutoSize = true; lblId.Location = new System.Drawing.Point(20, 25); lblId.Text = "ID:";
            txtId.Location = new System.Drawing.Point(120, 22); txtId.Size = new System.Drawing.Size(100, 22); txtId.ReadOnly = true; 

            // Row 2
            lblName.AutoSize = true; lblName.Location = new System.Drawing.Point(20, 55); lblName.Text = "Name:";
            txtName.Location = new System.Drawing.Point(120, 52); txtName.Size = new System.Drawing.Size(400, 22);

            // Row 3 (Description - Multiline)
            lblDescription.AutoSize = true; lblDescription.Location = new System.Drawing.Point(20, 85); lblDescription.Text = "Description:";
            txtDescription.Location = new System.Drawing.Point(120, 82); txtDescription.Size = new System.Drawing.Size(400, 50); txtDescription.Multiline = true; txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Row 4
            lblCourseCode.AutoSize = true; lblCourseCode.Location = new System.Drawing.Point(20, 145); lblCourseCode.Text = "Course:";
            cmbCourseCode.Location = new System.Drawing.Point(120, 142); cmbCourseCode.Size = new System.Drawing.Size(200, 24);
            cmbCourseCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCourseCode.SelectedIndexChanged += cmbCourseCode_SelectedIndexChanged;

            // Row 5
            lblUploader.AutoSize = true; lblUploader.Location = new System.Drawing.Point(20, 175); lblUploader.Text = "Uploader:";
            cmbUploader.Location = new System.Drawing.Point(120, 172); cmbUploader.Size = new System.Drawing.Size(200, 24);

            // Row 6
            lblCategory.AutoSize = true; lblCategory.Location = new System.Drawing.Point(20, 205); lblCategory.Text = "Category:";
            cmbCategory.Location = new System.Drawing.Point(120, 202); cmbCategory.Size = new System.Drawing.Size(200, 24);


            // Right Col Y: 25, 55, 85, 115, 145, 175
            // Row 1
            lblUploadDate.AutoSize = true; lblUploadDate.Location = new System.Drawing.Point(650, 25); lblUploadDate.Text = "Date:";
            dtpUploadDate.Location = new System.Drawing.Point(730, 22); dtpUploadDate.Size = new System.Drawing.Size(250, 22);

            // Row 2
            lblContentType.AutoSize = true; lblContentType.Location = new System.Drawing.Point(650, 55); lblContentType.Text = "Type:";
            cmbContentType.Location = new System.Drawing.Point(730, 52); cmbContentType.Size = new System.Drawing.Size(150, 24);

            // Row 3
            lblContentUrl.AutoSize = true; lblContentUrl.Location = new System.Drawing.Point(650, 85); lblContentUrl.Text = "URL:";
            txtContentUrl.Location = new System.Drawing.Point(730, 82); txtContentUrl.Size = new System.Drawing.Size(350, 22);

            // Browse Button
            btnBrowse.Location = new System.Drawing.Point(1090, 81);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(40, 24);
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;

            // Row 4
            lblFileType.AutoSize = true; lblFileType.Location = new System.Drawing.Point(650, 115); lblFileType.Text = "File Ext:";
            cmbFileType.Location = new System.Drawing.Point(730, 112); cmbFileType.Size = new System.Drawing.Size(150, 24);

            // Row 5
            lblTopics.AutoSize = true; lblTopics.Location = new System.Drawing.Point(650, 145); lblTopics.Text = "Topics:";
            cmbTopics.Location = new System.Drawing.Point(730, 142); cmbTopics.Size = new System.Drawing.Size(400, 24);
            cmbTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Row 6
            lblReactions.AutoSize = true; lblReactions.Location = new System.Drawing.Point(650, 175); lblReactions.Text = "Reactions:";
            txtReactions.Location = new System.Drawing.Point(730, 172); txtReactions.Size = new System.Drawing.Size(400, 22);


            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(btnClose);
            pnlControls.Controls.Add(btnClear);
            pnlControls.Controls.Add(btnDelete);
            pnlControls.Controls.Add(btnUpdate);
            pnlControls.Controls.Add(btnAdd);
            pnlControls.Location = new System.Drawing.Point(12, 550);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new System.Drawing.Size(1240, 60);
            pnlControls.TabIndex = 5;

            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(20, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(120, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.Location = new System.Drawing.Point(160, 10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(120, 40);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(300, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.Gray;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClear.ForeColor = System.Drawing.Color.White;
            btnClear.Location = new System.Drawing.Point(440, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(120, 40);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            // 
            // btnClose
            // 
            btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnClose.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1100, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(120, 40);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;

            // 
            // ResourceManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1280, 650);
            Controls.Add(pnlControls);
            Controls.Add(grpDetails);
            Controls.Add(grpSearch);
            Controls.Add(lblTotalResources);
            Controls.Add(lblTitle);
            Controls.Add(dataGridViewResources);
            Name = "ResourceManagementForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Resource Management";

            ((System.ComponentModel.ISupportInitialize)(dataGridViewResources)).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            pnlControls.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}