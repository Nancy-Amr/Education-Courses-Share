// SessionManager.cs
using CoursesSharesDB.Models;

namespace CoursesSharesDB
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsStudent =>
            CurrentUser != null &&
            CurrentUser.Role != null &&
            CurrentUser.Role.Equals("student", StringComparison.OrdinalIgnoreCase);

        public static bool IsInstructor =>
            CurrentUser != null &&
            CurrentUser.Role != null &&
            CurrentUser.Role.Equals("instructor", StringComparison.OrdinalIgnoreCase);

        public static bool IsAdmin =>
            CurrentUser != null &&
            CurrentUser.Role != null &&
            CurrentUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

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