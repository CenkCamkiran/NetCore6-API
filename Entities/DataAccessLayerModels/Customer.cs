using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{

    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

		[BsonElement("username")]
        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Fullname { get; set; }

        [BsonElement("address")]
        [BsonRepresentation(BsonType.String)]
        public string Address { get; set; }
        
        [BsonElement("birthdate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Birthdate { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("active")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Active { get; set; }

        [BsonElement("accounts")]
        public int[] Accounts { get; set; }

        [BsonElement("tier_and_details")]
        public object TierAndDetails { get; set; }
    }

}
