

namespace CoursesSharesDB.Forms
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewUsers;
        private Label label1, label2, label3, label4, label5, label6;
        private TextBox txtId, txtUsername, txtEmail, txtPassword, txtProfilePic;
        private ComboBox cmbRole;
        private Button btnAdd, btnUpdate, btnDelete, btnClose, btnReset; // ADD btnReset
        private DataGridViewButtonColumn colEdit, colDelete;

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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtProfilePic = new TextBox();
            cmbRole = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            btnReset = new Button(); // ADD THIS
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.ColumnHeadersHeight = 29;
            dataGridViewUsers.Location = new Point(12, 12);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(900, 400);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.SelectionChanged += dataGridViewUsers_SelectionChanged;
            dataGridViewUsers.CellContentClick += dataGridViewUsers_CellContentClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(120, 430);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 470);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 510);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(450, 430);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 4;
            txtPassword.PasswordChar = '*'; // ADD THIS LINE
            txtPassword.Enter += txtPassword_Enter; // ADD THIS EVENT
            txtPassword.Leave += txtPassword_Leave; // ADD THIS EVENT
            // 
            // txtProfilePic
            // 
            txtProfilePic.Location = new Point(450, 510);
            txtProfilePic.Name = "txtProfilePic";
            txtProfilePic.Size = new Size(250, 27);
            txtProfilePic.TabIndex = 6;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Instructor", "Student" });
            cmbRole.Location = new Point(450, 470);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(150, 28);
            cmbRole.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 123, 255);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(720, 425);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(720, 470);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 35);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(720, 515);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 35);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(820, 515);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(255, 193, 7);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(820, 425);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 35);
            btnReset.TabIndex = 10;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 433);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 11;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 473);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 12;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 513);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 13;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(360, 433);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 14;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(360, 473);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 15;
            label5.Text = "Role:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(360, 513);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 16;
            label6.Text = "Profile Pic:";
            // 
            // UserManagementForm
            // 
            ClientSize = new Size(924, 563);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReset); // ADD THIS
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbRole);
            Controls.Add(txtProfilePic);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(txtId);
            Controls.Add(dataGridViewUsers);
            Name = "UserManagementForm";
            Text = "User Management";
            Load += UserManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
