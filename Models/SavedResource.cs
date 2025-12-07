using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CoursesSharesDB.Models
{
    public class SavedResource
    {
        [BsonElement("user_id")]
        public int UserId { get; set; }

        [BsonElement("resource_id")]
        public int ResourceId { get; set; }

        [BsonElement("saving_date")]
        public DateTime SavingDate { get; set; }
    }
}