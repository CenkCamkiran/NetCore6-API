using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public class Tomatoes
	{
        [BsonElement]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime lastUpdated { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int? fresh { get; set; }

        [BsonElement]
        public Critic critic { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int? rotten { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? dvd { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string website { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string production { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string consensus { get; set; }
    }
}
