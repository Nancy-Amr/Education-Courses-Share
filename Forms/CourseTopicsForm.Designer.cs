namespace CoursesSharesDB.Forms
{
    partial class CourseTopicsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCourseInfo = new System.Windows.Forms.Label();
            this.dataGridViewTopics = new System.Windows.Forms.DataGridView();
            this.lblTopicCount = new System.Windows.Forms.Label();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.btnAddTopic = new System.Windows.Forms.Button();
            this.btnDeleteTopic = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNewTopic = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopics)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCourseInfo
            // 
            this.lblCourseInfo.AutoSize = true;
            this.lblCourseInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseInfo.Location = new System.Drawing.Point(12, 9);
            this.lblCourseInfo.Name = "lblCourseInfo";
            this.lblCourseInfo.Size = new System.Drawing.Size(107, 28);
            this.lblCourseInfo.TabIndex = 0;
            this.lblCourseInfo.Text = "Course Info";
            // 
            // dataGridViewTopics
            // 
            this.dataGridViewTopics.AllowUserToAddRows = false;
            this.dataGridViewTopics.AllowUserToDeleteRows = false;
            this.dataGridViewTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTopics.Location = new System.Drawing.Point(16, 40);
            this.dataGridViewTopics.MultiSelect = false;
            this.dataGridViewTopics.Name = "dataGridViewTopics";
            this.dataGridViewTopics.ReadOnly = true;
            this.dataGridViewTopics.RowHeadersWidth = 51;
            this.dataGridViewTopics.RowTemplate.Height = 24;
            this.dataGridViewTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTopics.Size = new System.Drawing.Size(460, 250);
            this.dataGridViewTopics.TabIndex = 1;
            // 
            // lblTopicCount
            // 
            this.lblTopicCount.AutoSize = true;
            this.lblTopicCount.Location = new System.Drawing.Point(13, 303);
            this.lblTopicCount.Name = "lblTopicCount";
            this.lblTopicCount.Size = new System.Drawing.Size(84, 17);
            this.lblTopicCount.TabIndex = 2;
            this.lblTopicCount.Text = "Total Topics: 0";
            // 
            // txtTopicName
            // 
            this.txtTopicName.Location = new System.Drawing.Point(100, 335);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(268, 22);
            this.txtTopicName.TabIndex = 3;
            // 
            // btnAddTopic
            // 
            this.btnAddTopic.Location = new System.Drawing.Point(374, 331);
            // ⭐ FIX APPLIED HERE: Using System.Drawing.Size type, not the control name
            this.btnAddTopic.Size = new System.Drawing.Size(102, 30);
            this.btnAddTopic.Name = "btnAddTopic";
            this.btnAddTopic.TabIndex = 4;
            this.btnAddTopic.Text = "Add Topic";
            this.btnAddTopic.UseVisualStyleBackColor = true;
            this.btnAddTopic.Click += new System.EventHandler(this.btnAddTopic_Click);
            // 
            // btnDeleteTopic
            // 
            this.btnDeleteTopic.Location = new System.Drawing.Point(16, 375);
            // ⭐ FIX APPLIED HERE: Using System.Drawing.Size type, not the control name
            this.btnDeleteTopic.Size = new System.Drawing.Size(102, 30);
            this.btnDeleteTopic.Name = "btnDeleteTopic";
            this.btnDeleteTopic.TabIndex = 5;
            this.btnDeleteTopic.Text = "Delete Topic";
            this.btnDeleteTopic.UseVisualStyleBackColor = true;
            this.btnDeleteTopic.Click += new System.EventHandler(this.btnDeleteTopic_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(374, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNewTopic
            // 
            this.lblNewTopic.AutoSize = true;
            this.lblNewTopic.Location = new System.Drawing.Point(13, 338);
            this.lblNewTopic.Name = "lblNewTopic";
            this.lblNewTopic.Size = new System.Drawing.Size(81, 17);
            this.lblNewTopic.TabIndex = 7;
            this.lblNewTopic.Text = "Topic Name:";
            // 
            // CourseTopicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 420);
            this.Controls.Add(this.lblNewTopic);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteTopic);
            this.Controls.Add(this.btnAddTopic);
            this.Controls.Add(this.txtTopicName);
            this.Controls.Add(this.lblTopicCount);
            this.Controls.Add(this.dataGridViewTopics);
            this.Controls.Add(this.lblCourseInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseTopicsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Course Topics Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Declare all controls referenced in CourseTopicsForm.cs
        // Using 'protected' for accessibility in the partial class
        protected System.Windows.Forms.Label lblCourseInfo;
        protected System.Windows.Forms.DataGridView dataGridViewTopics;
        protected System.Windows.Forms.Label lblTopicCount;
        protected System.Windows.Forms.TextBox txtTopicName;
        protected System.Windows.Forms.Button btnAddTopic;
        protected System.Windows.Forms.Button btnDeleteTopic;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Label lblNewTopic;
    }
}