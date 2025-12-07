// SignUpForm.Designer.cs
namespace Education_Courses.Forms
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblProfilePic;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtProfilePic;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.GroupBox grpUserInfo;

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
            lblTitle = new Label();
            lblUsername = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblRole = new Label();
            lblProfilePic = new Label();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtProfilePic = new TextBox();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            btnCancel = new Button();
            btnBrowseImage = new Button();
            chkShowPassword = new CheckBox();
            grpUserInfo = new GroupBox();
            grpUserInfo.SuspendLayout();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 70, 120);
            lblTitle.Location = new Point(120, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(240, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New User";
            // 
            // grpUserInfo
            // 
            grpUserInfo.Controls.Add(lblUsername);
            grpUserInfo.Controls.Add(lblEmail);
            grpUserInfo.Controls.Add(lblPassword);
            grpUserInfo.Controls.Add(lblConfirmPassword);
            grpUserInfo.Controls.Add(lblRole);
            grpUserInfo.Controls.Add(lblProfilePic);
            grpUserInfo.Controls.Add(txtUsername);
            grpUserInfo.Controls.Add(txtEmail);
            grpUserInfo.Controls.Add(txtPassword);
            grpUserInfo.Controls.Add(txtConfirmPassword);
            grpUserInfo.Controls.Add(txtProfilePic);
            grpUserInfo.Controls.Add(cmbRole);
            grpUserInfo.Controls.Add(btnBrowseImage);
            grpUserInfo.Controls.Add(chkShowPassword);
            grpUserInfo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpUserInfo.Location = new Point(30, 120);
            grpUserInfo.Name = "grpUserInfo";
            grpUserInfo.Size = new Size(410, 320);
            grpUserInfo.TabIndex = 2;
            grpUserInfo.TabStop = false;
            grpUserInfo.Text = "User Information";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(89, 18);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 18);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 120);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 18);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(20, 160);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(148, 18);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 200);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(47, 18);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role:";
            // 
            // lblProfilePic
            // 
            lblProfilePic.AutoSize = true;
            lblProfilePic.Location = new Point(20, 240);
            lblProfilePic.Name = "lblProfilePic";
            lblProfilePic.Size = new Size(145, 18);
            lblProfilePic.TabIndex = 5;
            lblProfilePic.Text = "Profile Picture:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(180, 37);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 24);
            txtUsername.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(180, 77);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 24);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 117);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 24);
            txtPassword.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(180, 157);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(220, 24);
            txtConfirmPassword.TabIndex = 5;
            // 
            // txtProfilePic
            // 
            txtProfilePic.Location = new Point(180, 237);
            txtProfilePic.Name = "txtProfilePic";
            txtProfilePic.Size = new Size(140, 24);
            txtProfilePic.TabIndex = 7;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(180, 197);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(220, 26);
            cmbRole.TabIndex = 6;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(325, 235);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(75, 28);
            btnBrowseImage.TabIndex = 8;
            btnBrowseImage.Text = "Browse";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(180, 270);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(141, 22);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(40, 167, 69);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(100, 460);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 45);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "&Register User";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(260, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // SignUpForm
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(470, 520);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(grpUserInfo);
            Controls.Add(txtAdminPassword);
            Controls.Add(lblAdminPassword);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Register New User";
            grpUserInfo.ResumeLayout(false);
            grpUserInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}