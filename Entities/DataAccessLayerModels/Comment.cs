using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
    public class Comment
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string name { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string email { get; set; }

        [BsonElement("text")]
        [BsonRepresentation(BsonType.String)]
        public string text { get; set; }

        [BsonElement("date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime date { get; set; }
    }
}
