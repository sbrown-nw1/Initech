using LiteDB;

namespace InitechAPI.Models
{
    public class Customer
    {
        [BsonField("_id")]
        public int Id { get; set; }

        [BsonField("agent_id")]
        public int AgentId { get; set; }

        [BsonField("guid")]
        public string Guid { get; set; }

        [BsonField("isActive")]
        public bool IsActive { get; set; }

        [BsonField("balance")]
        public string Balance { get; set; }

        [BsonField("age")]
        public int Age { get; set; }

        [BsonField("eyeColor")]
        public string EyeColor { get; set; }

        [BsonField("name")]
        public Name Name { get; set; }

        [BsonField("company")]
        public string Company { get; set; }

        [BsonField("email")]
        public string Email { get; set; }

        [BsonField("phone")]
        public string Phone { get; set; }

        [BsonField("address")]
        public string Address { get; set; }

        [BsonField("registered")]
        public string Registered { get; set; }

        [BsonField("latitude")]
        public string Latitude { get; set; }

        [BsonField("longitude")]
        public string Longitude { get; set; }

        [BsonField("tags")]
        public string[] Tags { get; set; }
    }
}