using MongoDB.Bson.Serialization.Attributes;

public class Reaction
{
    [BsonElement("user_id")]
    public int UserId { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }
}
