using CoursesSharesDB.Forms;
using System;
using System.Windows.Forms;

namespace CoursesSharesDB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run database migration (hash passwords, update validation)
            Services.DatabaseMigration.RunMigration();

            bool isRunning = true;

            while (isRunning)
            {
                // Show login form first
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK && loginForm.CurrentUser != null)
                    {
                        // Store user in session
                        SessionManager.Login(loginForm.CurrentUser);

                        // Show main form
                        Application.Run(new MainForm());

                        // If we are here, MainForm has closed.
                        // Check if user is logged out (meaning they clicked Logout button)
                        if (SessionManager.CurrentUser == null)
                        {
                            // User logged out explicitly, so loop continues to show Login form again
                            isRunning = true;
                        }
                        else
                        {
                            // User closed the app without logging out (e.g., clicked X)
                            isRunning = false; 
                        }
                    }
                    else
                    {
                        // User canceled login or failed
                        isRunning = false;
                    }
                }
            }
        }
    }
}