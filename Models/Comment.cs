using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CoursesSharesDB.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("resource_id")]
        public int ResourceId { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; }

        public string Text { get; set; }

        [BsonElement("time_stamp")]
        public DateTime TimeStamp { get; set; }
    }
}