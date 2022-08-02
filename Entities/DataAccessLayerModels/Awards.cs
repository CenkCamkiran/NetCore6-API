using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
    public class Awards
    {
        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int wins { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int nominations { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string text { get; set; }
    }
}
