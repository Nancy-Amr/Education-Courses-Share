using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CoursesSharesDB.Models
{
    public class Course
    {
        public class Topic
        {
            [BsonElement("topic_id")]
            public int TopicId { get; set; }

            [BsonElement("name")]
            public string Name { get; set; }

            [BsonElement("course_code")]
            public string CourseCode { get; set; }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        // Change to List<object> to handle both strings and ints
        [BsonElement("departments")]
        public List<object> Departments { get; set; } = new List<object>();

        [BsonElement("instructor_names")]
        public List<string> InstructorNames { get; set; } = new List<string>();

        [BsonElement("topics")]
        public List<Topic> Topics { get; set; } = new List<Topic>();

        // Helper property to get department as strings
        [BsonIgnore]
        public List<string> DepartmentStrings
        {
            get
            {
                var result = new List<string>();
                foreach (var dept in Departments)
                {
                    result.Add(dept?.ToString() ?? string.Empty);
                }
                return result;
            }
        }
    }
}