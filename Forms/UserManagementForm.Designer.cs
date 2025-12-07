namespace CoursesSharesDB.Forms
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewUsers;
        private Label label1, label2, label3, label4, label5, label6;
        private TextBox txtId, txtUsername, txtEmail, txtPassword, txtProfilePic;
        private ComboBox cmbRole;
        private Button btnAdd, btnUpdate, btnDelete, btnClose;

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
            dataGridViewUsers = new DataGridView();
            txtId = new TextBox();
            txtUsername = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeight = 29;
            dataGridViewUsers.Location = new Point(0, 0);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(791, 563);
            dataGridViewUsers.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(0, 0);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(0, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 27);
            txtUsername.TabIndex = 0;
            // 
            // UserManagementForm
            // 
            ClientSize = new Size(782, 553);
            Controls.Add(dataGridViewUsers);
            Controls.Add(txtId);
            Name = "UserManagementForm";
            Text = "User Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
            // ... set other properties
        }
    }
}