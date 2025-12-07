namespace CoursesSharesDB.Forms
{
    partial class ResourceManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        // DataGridView
        private System.Windows.Forms.DataGridView dataGridViewResources;

        // Labels
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.Label lblUploader;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUploadDate;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.Label lblContentUrl;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label lblTopics;
        private System.Windows.Forms.Label lblReactions;
        private System.Windows.Forms.Label lblTotalResources;
        private System.Windows.Forms.Label lblSearchResults;

        // TextBoxes
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtContentUrl;
        private System.Windows.Forms.TextBox txtTopics;
        private System.Windows.Forms.TextBox txtReactions;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtSearchCourseCode;
        private System.Windows.Forms.TextBox txtSearchUploader;

        // ComboBoxes
        private System.Windows.Forms.ComboBox cmbCourseCode;
        private System.Windows.Forms.ComboBox cmbUploader;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbContentType;
        private System.Windows.Forms.ComboBox cmbFileType;

        // DateTimePicker
        private System.Windows.Forms.DateTimePicker dtpUploadDate;

        // Buttons
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        // GroupBoxes/Panels
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Panel pnlControls;

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
            this.dataGridViewResources = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalResources = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearchUploader = new System.Windows.Forms.TextBox();
            this.txtSearchCourseCode = new System.Windows.Forms.TextBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.dtpUploadDate = new System.Windows.Forms.DateTimePicker();
            this.txtReactions = new System.Windows.Forms.TextBox();
            this.txtTopics = new System.Windows.Forms.TextBox();
            this.txtContentUrl = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.cmbContentType = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbUploader = new System.Windows.Forms.ComboBox();
            this.cmbCourseCode = new System.Windows.Forms.ComboBox();
            this.lblReactions = new System.Windows.Forms.Label();
            this.lblTopics = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblContentUrl = new System.Windows.Forms.Label();
            this.lblContentType = new System.Windows.Forms.Label();
            this.lblUploadDate = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUploader = new System.Windows.Forms.Label();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();

            // DataGridView
            this.dataGridViewResources.AllowUserToAddRows = false;
            this.dataGridViewResources.AllowUserToDeleteRows = false;
            this.dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResources.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewResources.Name = "dataGridViewResources";
            this.dataGridViewResources.ReadOnly = true;
            this.dataGridViewResources.RowHeadersWidth = 51;
            this.dataGridViewResources.RowTemplate.Height = 24;
            this.dataGridViewResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResources.Size = new System.Drawing.Size(960, 250);
            this.dataGridViewResources.TabIndex = 0;
            this.dataGridViewResources.SelectionChanged += new System.EventHandler(this.dataGridViewResources_SelectionChanged);

            // Labels
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Resource Management";

            this.lblTotalResources.AutoSize = true;
            this.lblTotalResources.Location = new System.Drawing.Point(16, 50);
            this.lblTotalResources.Name = "lblTotalResources";
            this.lblTotalResources.Size = new System.Drawing.Size(111, 17);
            this.lblTotalResources.TabIndex = 2;
            this.lblTotalResources.Text = "Total Resources:";

            // Search GroupBox
            this.grpSearch.Controls.Add(this.txtSearchUploader);
            this.grpSearch.Controls.Add(this.txtSearchCourseCode);
            this.grpSearch.Controls.Add(this.txtSearchName);
            this.grpSearch.Controls.Add(this.lblSearchResults);
            this.grpSearch.Controls.Add(this.btnRefresh);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(500, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(472, 62);
            this.grpSearch.TabIndex = 3;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search Resources";

            // Search controls would be added here with proper layout

            // Details GroupBox
            this.grpDetails.Controls.Add(this.dtpUploadDate);
            this.grpDetails.Controls.Add(this.txtReactions);
            this.grpDetails.Controls.Add(this.txtTopics);
            this.grpDetails.Controls.Add(this.txtContentUrl);
            this.grpDetails.Controls.Add(this.txtDescription);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.cmbFileType);
            this.grpDetails.Controls.Add(this.cmbContentType);
            this.grpDetails.Controls.Add(this.cmbCategory);
            this.grpDetails.Controls.Add(this.cmbUploader);
            this.grpDetails.Controls.Add(this.cmbCourseCode);
            this.grpDetails.Controls.Add(this.lblReactions);
            this.grpDetails.Controls.Add(this.lblTopics);
            this.grpDetails.Controls.Add(this.lblFileType);
            this.grpDetails.Controls.Add(this.lblContentUrl);
            this.grpDetails.Controls.Add(this.lblContentType);
            this.grpDetails.Controls.Add(this.lblUploadDate);
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.lblUploader);
            this.grpDetails.Controls.Add(this.lblCourseCode);
            this.grpDetails.Controls.Add(this.lblDescription);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Location = new System.Drawing.Point(12, 340);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(960, 250);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Resource Details";

            // Panel for control buttons
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.btnUpdate);
            this.pnlControls.Controls.Add(this.btnAdd);
            this.pnlControls.Location = new System.Drawing.Point(12, 600);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(960, 60);
            this.pnlControls.TabIndex = 5;

            // Form settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 672);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.lblTotalResources);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridViewResources);
            this.Name = "ResourceManagementForm";
            this.Text = "Resource Management";
            this.Load += new System.EventHandler(this.ResourceManagementForm_Load);

            // Additional initialization for all controls (position, size, etc.)
            // This would be extensive - Visual Studio Designer generates this automatically

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // This method would be generated by VS Designer
        private void ResourceManagementForm_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
    }
}