using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public class Movie
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

		[BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string plot { get; set; }

        [BsonElement]
        public List<string> genres { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int runtime { get; set; }

        [BsonElement]
        public List<string> cast { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int num_mflix_comments { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string title { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string fullplot { get; set; }

        [BsonElement]
        public List<string> countries { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime released { get; set; }

        [BsonElement]
        public List<string> directors { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string rated { get; set; }

        [BsonElement]
        public Awards awards { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string lastupdated { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int year { get; set; }

        [BsonElement]
        public Imdb imdb { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string type { get; set; }

        [BsonElement]
        public Tomatoes tomatoes { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.String)]
        public string poster { get; set; }

        [BsonElement]
        public List<string> languages { get; set; }

        [BsonElement]
        public List<string> writers { get; set; }
    }
}
