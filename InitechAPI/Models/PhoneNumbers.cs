using LiteDB;

namespace InitechAPI.Models
{
    public class PhoneNumbers
    {
        [BsonField("priary")]
        public string Primary { get; set; }

        [BsonField("mobile")]
        public string Mobile { get; set; }
    }
}