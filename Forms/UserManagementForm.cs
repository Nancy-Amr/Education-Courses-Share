
using System;
using System.Windows.Forms;
using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using System.Collections.Generic;
using Education_Courses.Helpers;
using System.Linq;
using System.ComponentModel;

namespace CoursesSharesDB.Forms
{
    public partial class UserManagementForm : Form
    {
        private Repository _repository;
        private BindingSource _bindingSource;
        private string _currentUserRole; // Track current user's role
        private List<User> _usersList; // Store users in a list

        public UserManagementForm(string currentUserRole = "Admin")
        {
            InitializeComponent();
            _repository = new Repository();
            _bindingSource = new BindingSource();
            _currentUserRole = currentUserRole;
            _usersList = new List<User>();
            LoadUsers();
            ConfigureUIForRole();
        }

        private void ConfigureUIForRole()
        {
            // Hide editing controls for non-admin users
            bool isAdmin = _currentUserRole == "Admin";

            // Show/hide buttons
            btnAdd.Visible = isAdmin;
            btnUpdate.Visible = isAdmin;
            btnDelete.Visible = isAdmin;
            btnReset.Visible = isAdmin; // Hide reset button for non-admin

            // Show/hide form fields
            label1.Visible = isAdmin;
            txtId.Visible = isAdmin;
            label2.Visible = isAdmin;
            txtUsername.Visible = isAdmin;
            label3.Visible = isAdmin;
            txtEmail.Visible = isAdmin;
            label4.Visible = isAdmin;
            txtPassword.Visible = isAdmin;
            label5.Visible = isAdmin;
            cmbRole.Visible = isAdmin;
            label6.Visible = isAdmin;
            txtProfilePic.Visible = isAdmin;

            // Adjust form size
            if (!isAdmin)
            {
                this.Height = 450;
                dataGridViewUsers.Height = 380;
            }
        }

        private void LoadUsers()
        {
            try
            {
                _usersList = _repository.GetAllUsers();
                _bindingSource.DataSource = _usersList;
                dataGridViewUsers.DataSource = _bindingSource;

                // Clear existing columns first
                dataGridViewUsers.AutoGenerateColumns = false;
                dataGridViewUsers.Columns.Clear();

                // Add data columns
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.Name = "Id";
                idColumn.DataPropertyName = "Id";
                idColumn.HeaderText = "User ID";
                idColumn.Width = 80;
                idColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewUsers.Columns.Add(idColumn);

                DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn();
                usernameColumn.Name = "Username";
                usernameColumn.DataPropertyName = "Username";
                usernameColumn.HeaderText = "Username";
                usernameColumn.Width = 150;
                usernameColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewUsers.Columns.Add(usernameColumn);

                DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn();
                emailColumn.Name = "Email";
                emailColumn.DataPropertyName = "Email";
                emailColumn.HeaderText = "Email";
                emailColumn.Width = 200;
                emailColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewUsers.Columns.Add(emailColumn);

                DataGridViewTextBoxColumn roleColumn = new DataGridViewTextBoxColumn();
                roleColumn.Name = "Role";
                roleColumn.DataPropertyName = "Role";
                roleColumn.HeaderText = "Role";
                roleColumn.Width = 100;
                roleColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewUsers.Columns.Add(roleColumn);

                DataGridViewTextBoxColumn createdAtColumn = new DataGridViewTextBoxColumn();
                createdAtColumn.Name = "CreatedAt";
                createdAtColumn.DataPropertyName = "CreatedAt";
                createdAtColumn.HeaderText = "Created Date";
                createdAtColumn.Width = 120;
                createdAtColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewUsers.Columns.Add(createdAtColumn);

                // Add action columns only for admin
                if (_currentUserRole == "Admin")
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                    editColumn.Name = "colEdit";
                    editColumn.HeaderText = "Edit";
                    editColumn.Text = "✏️ Edit";
                    editColumn.UseColumnTextForButtonValue = true;
                    editColumn.Width = 80;

                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                    deleteColumn.Name = "colDelete";
                    deleteColumn.HeaderText = "Delete";
                    deleteColumn.Text = "🗑️ Delete";
                    deleteColumn.UseColumnTextForButtonValue = true;
                    deleteColumn.Width = 80;

                    dataGridViewUsers.Columns.Add(editColumn);
                    dataGridViewUsers.Columns.Add(deleteColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ListSortDirection _lastSortDirection = ListSortDirection.Ascending;
        private string _lastSortColumn = "";

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Don't sort button columns
            if (e.ColumnIndex >= 0 && dataGridViewUsers.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                string columnName = dataGridViewUsers.Columns[e.ColumnIndex].DataPropertyName;
                
                // Determine sort direction
                ListSortDirection direction;
                if (_lastSortColumn == columnName)
                {
                    // Toggle direction if same column
                    direction = _lastSortDirection == ListSortDirection.Ascending 
                        ? ListSortDirection.Descending 
                        : ListSortDirection.Ascending;
                }
                else
                {
                    // Default to ascending for new column
                    direction = ListSortDirection.Ascending;
                }

                // Sort the list
                if (direction == ListSortDirection.Ascending)
                {
                    _usersList = _usersList.OrderBy(u => u.GetType().GetProperty(columnName)?.GetValue(u)).ToList();
                }
                else
                {
                    _usersList = _usersList.OrderByDescending(u => u.GetType().GetProperty(columnName)?.GetValue(u)).ToList();
                }

                // Update binding source
                _bindingSource.DataSource = _usersList;
                _bindingSource.ResetBindings(false);

                // Set sort glyph
                dataGridViewUsers.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = 
                    direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

                // Clear other column glyphs
                for (int i = 0; i < dataGridViewUsers.Columns.Count; i++)
                {
                    if (i != e.ColumnIndex)
                    {
                        dataGridViewUsers.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }

                // Remember last sort
                _lastSortColumn = columnName;
                _lastSortDirection = direction;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Username and Email are required!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if password is provided for new user
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Password is required for new user!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    Id = string.IsNullOrWhiteSpace(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = PasswordHelper.HashPassword(txtPassword.Text), // Hash password before storing
                    Role = cmbRole.Text,
                    ProfilePicture = txtProfilePic.Text,
                    CreatedAt = DateTime.Now
                };

                _repository.InsertUser(user);
                LoadUsers();
                ClearForm();
                MessageBox.Show("User added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                try
                {
                    // Get existing user to preserve password if not changed
                    int userId = int.Parse(txtId.Text);
                    var existingUser = _repository.GetUserById(userId);

                    // Determine if password should be updated
                    string passwordToUse;
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != "******")
                    {
                        // New password provided - Hash it!
                        passwordToUse = PasswordHelper.HashPassword(txtPassword.Text);
                    }
                    else if (existingUser != null)
                    {
                        // Keep existing password
                        passwordToUse = existingUser.Password;
                    }
                    else
                    {
                        // Default fallback
                        passwordToUse = "";
                    }

                    var user = new User
                    {
                        Id = userId,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        Password = passwordToUse,
                        Role = cmbRole.Text,
                        ProfilePicture = txtProfilePic.Text
                    };

                    if (_repository.UpdateUser(user))
                    {
                        LoadUsers();
                        MessageBox.Show("User updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                if (MessageBox.Show($"Are you sure you want to delete user with ID: {txtId.Text}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        if (_repository.DeleteUser(int.Parse(txtId.Text)))
                        {
                            LoadUsers();
                            ClearForm();
                            MessageBox.Show("User deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (dataGridViewUsers.CurrentRow != null)
            {
                dataGridViewUsers.ClearSelection();
            }
            txtId.Focus();
            MessageBox.Show("Form has been reset. All fields cleared.", "Reset Form",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow != null && dataGridViewUsers.CurrentRow.DataBoundItem is User selectedUser)
            {
                txtId.Text = selectedUser.Id.ToString();
                txtUsername.Text = selectedUser.Username;
                txtEmail.Text = selectedUser.Email;

                // Don't show actual password hash - show placeholder
                txtPassword.Text = "******";
                txtPassword.PasswordChar = '*';

                cmbRole.Text = selectedUser.Role;
                txtProfilePic.Text = selectedUser.ProfilePicture;
                
                // Load profile picture
                LoadProfilePicture(selectedUser.ProfilePicture);
            }
        }

        private void LoadProfilePicture(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !System.IO.File.Exists(imagePath))
            {
                pbProfilePic.Image = null; // Clear image if path is invalid
                return;
            }

            try
            {
                // Load image from file (using FromStream to avoid locking the file)
                using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    pbProfilePic.Image = Image.FromStream(stream);
                }
            }
            catch
            {
                pbProfilePic.Image = null; // Clear on error
            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _currentUserRole == "Admin")
            {
                var row = dataGridViewUsers.Rows[e.RowIndex];

                if (row.DataBoundItem is User selectedUser)
                {
                    if (e.ColumnIndex == dataGridViewUsers.Columns["colEdit"].Index)
                    {
                        // Load user data into form for editing
                        txtId.Text = selectedUser.Id.ToString();
                        txtUsername.Text = selectedUser.Username;
                        txtEmail.Text = selectedUser.Email;
                        txtPassword.Text = "******"; // Show placeholder instead of hash
                        txtPassword.PasswordChar = '*';
                        cmbRole.Text = selectedUser.Role;
                        txtProfilePic.Text = selectedUser.ProfilePicture;
                        LoadProfilePicture(selectedUser.ProfilePicture); // Load image
                    }
                    else if (e.ColumnIndex == dataGridViewUsers.Columns["colDelete"].Index)
                    {
                        if (MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                if (_repository.DeleteUser(selectedUser.Id))
                                {
                                    LoadUsers();
                                    ClearForm();
                                    MessageBox.Show("User deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
            cmbRole.SelectedIndex = -1;
            txtProfilePic.Clear();
            pbProfilePic.Image = null; // Clear image
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // Set password field to show asterisks by default
            txtPassword.PasswordChar = '*';
        }

        // Add this method to handle password field behavior
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            // When user focuses on password field, clear the placeholder
            if (txtPassword.Text == "******")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        // Add this method to handle when user leaves password field
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            // If password field is empty after editing, restore placeholder
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "******";
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    txtProfilePic.Text = openFileDialog.FileName;
                    LoadProfilePicture(openFileDialog.FileName); // Preview selected image
                }
            }
        }
    }
}
