using LiteDB;

namespace InitechAPI.Models
{
    public class Agent
    {
        [BsonField("_id")]
        public int Id { get; set; }

        [BsonField("name")]
        public string Name { get; set; }

        [BsonField("address")]
        public string Address { get; set; }

        [BsonField("city")]
        public string City { get; set; }


        [BsonField("state")]
        public string State { get; set; }


        [BsonField("zipCode")]
        public string ZipCode { get; set; }

        [BsonField("tier")]
        public int Tier { get; set; }

        [BsonField("phone")]
        public PhoneNumbers PhoneNumbers { get; set; }
    }
}