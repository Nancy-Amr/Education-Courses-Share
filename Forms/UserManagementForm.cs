// Forms/UserManagementForm.cs
using System;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;

namespace CoursesSharesDB.Forms
{
    public partial class UserManagementForm : Form
    {
        private Repository _repository;
        private BindingSource _bindingSource;

        public UserManagementForm()
        {
            InitializeComponent();
            _repository = new Repository();
            _bindingSource = new BindingSource();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _repository.GetAllUsers();
            _bindingSource.DataSource = users;
            dataGridViewUsers.DataSource = _bindingSource;

            // Configure columns
            dataGridViewUsers.Columns["Id"].HeaderText = "User ID";
            dataGridViewUsers.Columns["Username"].HeaderText = "Username";
            dataGridViewUsers.Columns["Email"].HeaderText = "Email";
            dataGridViewUsers.Columns["Role"].HeaderText = "Role";
            dataGridViewUsers.Columns["CreatedAt"].HeaderText = "Created Date";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    Id = int.Parse(txtId.Text),
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Role = cmbRole.Text,
                    ProfilePicture = txtProfilePic.Text,
                    CreatedAt = DateTime.Now
                };

                _repository.InsertUser(user);
                LoadUsers();
                ClearForm();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                var selectedUser = (User)dataGridViewUsers.CurrentRow.DataBoundItem;

                selectedUser.Username = txtUsername.Text;
                selectedUser.Email = txtEmail.Text;
                selectedUser.Password = txtPassword.Text;
                selectedUser.Role = cmbRole.Text;
                selectedUser.ProfilePicture = txtProfilePic.Text;

                if (_repository.UpdateUser(selectedUser))
                {
                    LoadUsers();
                    MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                var selectedUser = (User)dataGridViewUsers.CurrentRow.DataBoundItem;

                if (MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_repository.DeleteUser(selectedUser.Id))
                    {
                        LoadUsers();
                        ClearForm();
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                var selectedUser = (User)dataGridViewUsers.CurrentRow.DataBoundItem;
                txtId.Text = selectedUser.Id.ToString();
                txtUsername.Text = selectedUser.Username;
                txtEmail.Text = selectedUser.Email;
                txtPassword.Text = selectedUser.Password;
                cmbRole.Text = selectedUser.Role;
                txtProfilePic.Text = selectedUser.ProfilePicture;
            }
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            txtProfilePic.Clear();
        }
    }
}