// DAL/MongoDBContext.cs
using MongoDB.Driver;
using CoursesSharesDB.Models;

namespace CoursesSharesDB.DAL
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString = "mongodb://localhost:27017", string databaseName = "CoursesSharesDB")
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Collections
        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("courses");
        public IMongoCollection<Resource> Resources => _database.GetCollection<Resource>("resources");
        public IMongoCollection<SavedResource> SavedResources => _database.GetCollection<SavedResource>("saved_resources");
        public IMongoCollection<Department> Departments => _database.GetCollection<Department>("departments");
        public IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("comments");
        public IMongoCollection<ResourceCategory> ResourceCategories => _database.GetCollection<ResourceCategory>("resource_categories");
    }
}

