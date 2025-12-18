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
            lblCourseInfo = new Label();
            dataGridViewTopics = new DataGridView();
            lblTopicCount = new Label();
            txtTopicName = new TextBox();
            btnAddTopic = new Button();
            btnDeleteTopic = new Button();
            btnClose = new Button();
            lblNewTopic = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopics).BeginInit();
            SuspendLayout();
            // 
            // lblCourseInfo
            // 
            lblCourseInfo.AutoSize = true;
            lblCourseInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourseInfo.Location = new Point(15, 14);
            lblCourseInfo.Margin = new Padding(4, 0, 4, 0);
            lblCourseInfo.Name = "lblCourseInfo";
            lblCourseInfo.Size = new Size(147, 32);
            lblCourseInfo.TabIndex = 0;
            lblCourseInfo.Text = "Course Info";
            // 
            // dataGridViewTopics
            // 
            dataGridViewTopics.AllowUserToAddRows = false;
            dataGridViewTopics.AllowUserToDeleteRows = false;
            dataGridViewTopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTopics.Location = new Point(20, 62);
            dataGridViewTopics.Margin = new Padding(4, 5, 4, 5);
            dataGridViewTopics.MultiSelect = false;
            dataGridViewTopics.Name = "dataGridViewTopics";
            dataGridViewTopics.ReadOnly = true;
            dataGridViewTopics.RowHeadersWidth = 51;
            dataGridViewTopics.RowTemplate.Height = 24;
            dataGridViewTopics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTopics.Size = new Size(575, 391);
            dataGridViewTopics.TabIndex = 1;
            // 
            // lblTopicCount
            // 
            lblTopicCount.AutoSize = true;
            lblTopicCount.Location = new Point(16, 473);
            lblTopicCount.Margin = new Padding(4, 0, 4, 0);
            lblTopicCount.Name = "lblTopicCount";
            lblTopicCount.Size = new Size(122, 25);
            lblTopicCount.TabIndex = 2;
            lblTopicCount.Text = "Total Topics: 0";
            // 
            // txtTopicName
            // 
            txtTopicName.Location = new Point(125, 523);
            txtTopicName.Margin = new Padding(4, 5, 4, 5);
            txtTopicName.Name = "txtTopicName";
            txtTopicName.Size = new Size(334, 31);
            txtTopicName.TabIndex = 3;
            // 
            // btnAddTopic
            // 
            btnAddTopic.Location = new Point(468, 517);
            btnAddTopic.Margin = new Padding(4, 5, 4, 5);
            btnAddTopic.Name = "btnAddTopic";
            btnAddTopic.Size = new Size(128, 47);
            btnAddTopic.TabIndex = 4;
            btnAddTopic.Text = "Add Topic";
            btnAddTopic.UseVisualStyleBackColor = true;
            btnAddTopic.Click += btnAddTopic_Click;
            // 
            // btnDeleteTopic
            // 
            btnDeleteTopic.Location = new Point(20, 586);
            btnDeleteTopic.Margin = new Padding(4, 5, 4, 5);
            btnDeleteTopic.Name = "btnDeleteTopic";
            btnDeleteTopic.Size = new Size(128, 47);
            btnDeleteTopic.TabIndex = 5;
            btnDeleteTopic.Text = "Delete Topic";
            btnDeleteTopic.UseVisualStyleBackColor = true;
            btnDeleteTopic.Click += btnDeleteTopic_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(468, 586);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 47);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblNewTopic
            // 
            lblNewTopic.AutoSize = true;
            lblNewTopic.Location = new Point(16, 528);
            lblNewTopic.Margin = new Padding(4, 0, 4, 0);
            lblNewTopic.Name = "lblNewTopic";
            lblNewTopic.Size = new Size(109, 25);
            lblNewTopic.TabIndex = 7;
            lblNewTopic.Text = "Topic Name:";
            // 
            // CourseTopicsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 656);
            Controls.Add(lblNewTopic);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteTopic);
            Controls.Add(btnAddTopic);
            Controls.Add(txtTopicName);
            Controls.Add(lblTopicCount);
            Controls.Add(dataGridViewTopics);
            Controls.Add(lblCourseInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CourseTopicsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Course Topics Management";
            Load += CourseTopicsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopics).EndInit();
            ResumeLayout(false);
            PerformLayout();
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