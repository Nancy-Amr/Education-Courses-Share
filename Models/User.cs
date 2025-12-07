// User.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesSharesDB.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("role")]
        public string Role { get; set; } // "student", "instructor", or "admin"

        [BsonElement("profilePicture")]
        public string? ProfilePicture { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}