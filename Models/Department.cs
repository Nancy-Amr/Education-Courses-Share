using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesSharesDB.Models
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("name")]  // Add this
        public string Name { get; set; }

        [BsonElement("description")]  // Add this if you use description
        public string Description { get; set; }
    }
}