using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Resource
{
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    [BsonElement("name")] // Maps C# Name property to MongoDB "name" field
    public string Name { get; set; }

    [BsonElement("upload_date")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime UploadDate { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("content")]
    public Content Content { get; set; }

    [BsonElement("course_code")]
    public string CourseCode { get; set; }

    [BsonElement("topics")]
    public List<int> Topics { get; set; } = new List<int>();

    [BsonElement("uploader_username")]
    public string UploaderUsername { get; set; }

    [BsonElement("category_id")]
    [BsonRepresentation(BsonType.Int32)]
    public int CategoryId { get; set; }

    [BsonElement("reactions")]
    public List<string> Reactions { get; set; } = new List<string>();
}

public class Content
{
    [BsonElement("type")]
    public string Type { get; set; }

    [BsonElement("url")]
    public string Url { get; set; }

    [BsonElement("fileType")]
    public string FileType { get; set; }
}