// DAL/Repository.cs
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using CoursesSharesDB.Models;

namespace CoursesSharesDB.DAL
{
    public class Repository
    {
        private readonly MongoDBContext _context;

        public Repository()
        {
            _context = new MongoDBContext();
        }

        // User Operations
        public List<User> GetAllUsers() => _context.Users.Find(_ => true).ToList();
        public User GetUserById(int id) => _context.Users.Find(u => u.Id == id).FirstOrDefault();
        public void InsertUser(User user) => _context.Users.InsertOne(user);
        public bool UpdateUser(User user)
        {
            var result = _context.Users.ReplaceOne(u => u.Id == user.Id, user);
            return result.ModifiedCount > 0;
        }
        public bool DeleteUser(int id)
        {
            var result = _context.Users.DeleteOne(u => u.Id == id);
            return result.DeletedCount > 0;
        }

        // Resource Operations
        public List<Resource> GetAllResources() => _context.Resources.Find(_ => true).ToList();
        public Resource GetResourceById(int id) => _context.Resources.Find(r => r.Id == id).FirstOrDefault();
        public List<Resource> GetResourcesByCourse(string courseCode) =>
            _context.Resources.Find(r => r.CourseCode == courseCode).ToList();
        public void InsertResource(Resource resource) => _context.Resources.InsertOne(resource);
        public bool UpdateResource(Resource resource)
        {
            var result = _context.Resources.ReplaceOne(r => r.Id == resource.Id, resource);
            return result.ModifiedCount > 0;
        }
        public bool DeleteResource(int id)
        {
            var result = _context.Resources.DeleteOne(r => r.Id == id);
            return result.DeletedCount > 0;
        }
        // IDs Generator
        public int GetNextResourceId()
        {
            var resources = GetAllResources();
            return resources.Count > 0 ? resources.Max(r => r.Id) + 1 : 1;
        }
        // Course Operations
        public List<Course> GetAllCourses() => _context.Courses.Find(_ => true).ToList();
        public Course GetCourseByCode(string code) => _context.Courses.Find(c => c.Code == code).FirstOrDefault();
        public void AddCourse(Course course) => _context.Courses.InsertOne(course);
        public bool UpdateCourse(Course course)
        {
            var result = _context.Courses.ReplaceOne(c => c.Code == course.Code, course);
            return result.ModifiedCount > 0;
        }
        public bool DeleteCourse(string code)
        {
            var result = _context.Courses.DeleteOne(c => c.Code == code);
            return result.DeletedCount > 0;
        }

        // Saved Resources Operations
        public List<SavedResource> GetSavedResourcesByUser(int userId) =>
            _context.SavedResources.Find(sr => sr.UserId == userId).ToList();

        // Comment Operations
        public List<Comment> GetCommentsByResource(int resourceId) =>
            _context.Comments.Find(c => c.ResourceId == resourceId).ToList();

        // Department Operations
        public List<Department> GetAllDepartments() => _context.Departments.Find(_ => true).ToList();

        // Category Operations
        public List<ResourceCategory> GetAllCategories() => _context.ResourceCategories.Find(_ => true).ToList();

        // User Authentication Operations
        public User GetUserByUsername(string username)
        {
            return _context.Users.Find(u => u.Username == username).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Find(u => u.Email == email).FirstOrDefault();
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = GetUserByUsername(username);
            if (user != null && user.Password == password) // In real app, use proper hashing
            {
                return user;
            }
            return null;
        }

        // Admin Operations
        public User GetAdminUser()
        {
            return _context.Users.Find(u => u.Role.ToLower() == "admin").FirstOrDefault();
        }

        public bool VerifyAdminPassword(string password)
        {
            var admin = GetAdminUser();
            return admin != null && admin.Password == password; // In production, use proper hashing
        }

        // Since you don't have ActivityLogs collection, we'll simulate recent activities
        public List<object> GetRecentActivities(int count)
        {
            // Create sample activities since you don't have the collection
            var activities = new List<object>();

            // Get recent resources as "activities"
            var recentResources = _context.Resources
                .Find(_ => true)
                .SortByDescending(r => r.UploadDate)
                .Limit(count)
                .ToList();

            foreach (var resource in recentResources)
            {
                activities.Add(new
                {
                    Timestamp = resource.UploadDate,
                    User = resource.UploaderUsername,
                    Action = "Upload",
                    Details = $"Uploaded '{resource.Name}'",
                    IPAddress = "127.0.0.1"
                });
            }

            return activities;
        }

        // Since you don't have Enrollments collection, return empty list
        public List<object> GetAllEnrollments()
        {
            // Return empty list since you don't have enrollments
            return new List<object>();
        }

        // Statistics Methods - Adjusted for your actual database
        public int GetActiveUserCount(int days = 7)
        {
            // Since you don't have LastLogin field, just return count of users
            return GetAllUsers().Count;
        }

        public Dictionary<string, int> GetUserRoleDistribution()
        {
            var users = GetAllUsers();
            return users
                .GroupBy(u => u.Role.ToLower())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // ID Generation Methods
        public int GetNextUserId()
        {
            var users = GetAllUsers();
            return users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
        }

        // Search Operations
        public List<User> SearchUsers(string searchTerm)
        {
            return _context.Users.Find(u =>
                u.Username.Contains(searchTerm) ||
                u.Email.Contains(searchTerm))
                .ToList();
        }

        public List<Resource> SearchResources(string searchTerm)
        {
            return _context.Resources.Find(r =>
                r.Name.Contains(searchTerm) ||
                r.Description.Contains(searchTerm) ||
                r.CourseCode.Contains(searchTerm))
                .ToList();
        }

        // Simulate logging activity (would store in a real system)
        public void LogActivity(string user, string action, string details, string ipAddress = null)
        {
            // In a real system, you would insert into ActivityLogs collection
            // For now, just write to console or log file
            Console.WriteLine($"[Activity] {DateTime.Now}: {user} - {action} - {details}");
        }
    }
    
}