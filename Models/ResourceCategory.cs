using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesSharesDB.Models
{
    public class ResourceCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("name")]  // Add this attribute to map to lowercase field
        public string Name { get; set; }
    }
}