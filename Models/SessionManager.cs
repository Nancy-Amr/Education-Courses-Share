// SessionManager.cs
using CoursesSharesDB.Models;

namespace CoursesSharesDB
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsStudent => CurrentUser?.Role == "Student";
        public static bool IsInstructor => CurrentUser?.Role == "Instructor";
        public static bool IsAdmin => CurrentUser?.Role == "Admin";

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static string GetWelcomeMessage()
        {
            if (CurrentUser == null)
                return "Welcome Guest";

            return $"Welcome, {CurrentUser.Username} ({CurrentUser.Role})";
        }
    }
}