using LiteDB;

namespace InitechAPI.Models
{
    public class Name
    {
        [BsonField("first")]
        public string First { get; set; }

        [BsonField("last")]
        public string Last { get; set; }
    }
}