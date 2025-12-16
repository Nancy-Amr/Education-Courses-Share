
namespace CoursesSharesDB.Forms
{
    partial class UserProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblProfilePic;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtProfilePic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private System.Windows.Forms.CheckBox chkShowPassword;

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
            lblTitle = new System.Windows.Forms.Label();
            lblUsername = new System.Windows.Forms.Label();
            lblEmail = new System.Windows.Forms.Label();
            lblRole = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            lblProfilePic = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            txtEmail = new System.Windows.Forms.TextBox();
            txtRole = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            txtProfilePic = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnBrowse = new System.Windows.Forms.Button();
            pbProfilePic = new System.Windows.Forms.PictureBox();
            chkShowPassword = new System.Windows.Forms.CheckBox();

            ((System.ComponentModel.ISupportInitialize)(pbProfilePic)).BeginInit();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 120);
            lblTitle.Location = new System.Drawing.Point(120, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(119, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Profile";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(30, 70);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(58, 13);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(120, 67);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new System.Drawing.Size(200, 20);
            txtUsername.TabIndex = 2;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(30, 100);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(32, 13);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role:";
            // 
            // txtRole
            // 
            txtRole.Location = new System.Drawing.Point(120, 97);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new System.Drawing.Size(200, 20);
            txtRole.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(30, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(35, 13);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(120, 127);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(200, 20);
            txtEmail.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(30, 160);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(81, 13);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "New Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(120, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(200, 20);
            txtPassword.TabIndex = 8;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new System.Drawing.Point(326, 160);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new System.Drawing.Size(102, 17);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += new System.EventHandler(chkShowPassword_CheckedChanged);
            // 
            // lblProfilePic
            // 
            lblProfilePic.AutoSize = true;
            lblProfilePic.Location = new System.Drawing.Point(30, 190);
            lblProfilePic.Name = "lblProfilePic";
            lblProfilePic.Size = new System.Drawing.Size(75, 13);
            lblProfilePic.TabIndex = 10;
            lblProfilePic.Text = "Profile Picture:";
            // 
            // txtProfilePic
            // 
            txtProfilePic.Location = new System.Drawing.Point(120, 187);
            txtProfilePic.Name = "txtProfilePic";
            txtProfilePic.Size = new System.Drawing.Size(200, 20);
            txtProfilePic.TabIndex = 11;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new System.Drawing.Point(326, 185);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(75, 23);
            btnBrowse.TabIndex = 12;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
            // 
            // pbProfilePic
            // 
            pbProfilePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbProfilePic.Location = new System.Drawing.Point(120, 220);
            pbProfilePic.Name = "pbProfilePic";
            pbProfilePic.Size = new System.Drawing.Size(100, 100);
            pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbProfilePic.TabIndex = 13;
            pbProfilePic.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(120, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(90, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += new System.EventHandler(btnSave_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(230, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(btnCancel_Click);
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 400);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pbProfilePic);
            Controls.Add(btnBrowse);
            Controls.Add(txtProfilePic);
            Controls.Add(lblProfilePic);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtRole);
            Controls.Add(lblRole);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UserProfileForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "My Profile";
            Load += new System.EventHandler(UserProfileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(pbProfilePic)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
