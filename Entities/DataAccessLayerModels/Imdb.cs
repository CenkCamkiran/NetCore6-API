using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
    public class Imdb
    {
        [BsonElement]
        [BsonRepresentation(BsonType.Double)]
        public double rating { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int votes { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int id { get; set; }
    }
}
