using System;
using System.Collections.Generic;

using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models.DataAccessLayerModels
{
    public class CustomerAccounts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("username")]
        [BsonRepresentation(BsonType.String)]
        public string username { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string name { get; set; }

        [BsonElement("address")]
        [BsonRepresentation(BsonType.String)]
        public string address { get; set; }

        [BsonElement("birthdate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime birthdate { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string email { get; set; }

        [BsonElement("active")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool active { get; set; }

        [BsonElement("tier_and_details")]
        public Dictionary<string, TierAndDetail>? tierAndDetails { get; set; }

        [BsonElement("account_details")]
        public AccountDetail[][] accountDetails { get; set; }
    }
}
