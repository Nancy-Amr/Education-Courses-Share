
namespace CoursesSharesDB.Forms
{
    partial class ResourceDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUploader;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDescription;
        
        // Interaction controls
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpComments;
        private System.Windows.Forms.ListBox lstComments;
        private System.Windows.Forms.TextBox txtNewComment;
        private System.Windows.Forms.Button btnPostComment;

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
            this.lblResourceName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUploader = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpComments = new System.Windows.Forms.GroupBox();
            this.lstComments = new System.Windows.Forms.ListBox();
            this.txtNewComment = new System.Windows.Forms.TextBox();
            this.btnPostComment = new System.Windows.Forms.Button();

            this.grpComments.SuspendLayout();
            this.SuspendLayout();

            // lblResourceName
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblResourceName.Location = new System.Drawing.Point(20, 20);
            this.lblResourceName.Size = new System.Drawing.Size(200, 24);
            this.lblResourceName.Text = "Resource Name";

            // lblCourse
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(24, 60);
            this.lblCourse.Text = "Course: ";

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(300, 60);
            this.lblCategory.Text = "Category: ";

            // lblUploader
            this.lblUploader.AutoSize = true;
            this.lblUploader.Location = new System.Drawing.Point(24, 90);
            this.lblUploader.Text = "Uploaded by: ";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(300, 90);
            this.lblDate.Text = "Date: ";

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 120);
            this.lblDescription.Text = "Description:";

            // txtDescription (Read Only)
            this.txtDescription.Location = new System.Drawing.Point(27, 140);
            this.txtDescription.Multiline = true;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(540, 60);
            this.txtDescription.BackColor = System.Drawing.Color.White;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(600, 20);
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.Text = "Save Resource";
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // grpComments
            this.grpComments.Location = new System.Drawing.Point(27, 220);
            this.grpComments.Size = new System.Drawing.Size(673, 300);
            this.grpComments.Text = "Comments";
            this.grpComments.Controls.Add(this.lstComments);
            this.grpComments.Controls.Add(this.txtNewComment);
            this.grpComments.Controls.Add(this.btnPostComment);

            // lstComments
            this.lstComments.Location = new System.Drawing.Point(15, 25);
            this.lstComments.Size = new System.Drawing.Size(640, 200);

            // txtNewComment
            this.txtNewComment.Location = new System.Drawing.Point(15, 240);
            this.txtNewComment.Multiline = true;
            this.txtNewComment.Size = new System.Drawing.Size(540, 40);

            // btnPostComment
            this.btnPostComment.Location = new System.Drawing.Point(565, 240);
            this.btnPostComment.Size = new System.Drawing.Size(90, 40);
            this.btnPostComment.Text = "Post";
            this.btnPostComment.Click += new System.EventHandler(this.btnPostComment_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(610, 540);
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            // Form
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.lblResourceName);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblUploader);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpComments);
            this.Controls.Add(this.btnClose);
            this.Name = "ResourceDetailsForm";
            this.Text = "Resource Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ResourceDetailsForm_Load);

            this.grpComments.ResumeLayout(false);
            this.grpComments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
