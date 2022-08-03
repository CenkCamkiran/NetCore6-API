using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public class MovieComments
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }

		[BsonElement("plot")]
		[BsonRepresentation(BsonType.String)]
		public string plot { get; set; }

		[BsonElement("genres")]
		public List<string> genres { get; set; }

		[BsonElement("runtime")]
		[BsonRepresentation(BsonType.Int32)]
		public int runtime { get; set; }

		[BsonElement("cast")]
		public List<string> cast { get; set; }

		[BsonElement("num_mflix_comments")]
		[BsonRepresentation(BsonType.Int32)]
		public int num_mflix_comments { get; set; }

		[BsonElement("title")]
		[BsonRepresentation(BsonType.String)]
		public string title { get; set; }

		[BsonElement("fullplot")]
		[BsonRepresentation(BsonType.String)]
		public string fullplot { get; set; }

		[BsonElement("countries")]
		public List<string> countries { get; set; }

		[BsonElement("released")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime released { get; set; }

		[BsonElement("directors")]
		public List<string> directors { get; set; }

		[BsonElement("rated")]
		[BsonRepresentation(BsonType.String)]
		public string rated { get; set; }

		[BsonElement("awards")]
		public Awards awards { get; set; }

		[BsonElement("lastupdated")]
		[BsonRepresentation(BsonType.String)]
		public string lastupdated { get; set; }

		[BsonElement("year")]
		[BsonRepresentation(BsonType.Int32)]
		public int year { get; set; }

		[BsonElement("imdb")]
		public Imdb imdb { get; set; }

		[BsonElement("type")]
		[BsonRepresentation(BsonType.String)]
		public string type { get; set; }

		[BsonElement("tomatoes")]
		public Tomatoes tomatoes { get; set; }

		[BsonElement("poster")]
		[BsonRepresentation(BsonType.String)]
		public string poster { get; set; }

		[BsonElement("languages")]
		public List<string> languages { get; set; }

		[BsonElement("writers")]
		public List<string> writers { get; set; }

		[BsonElement("comments")]
		public List<Comment>? comments { get; set; }
	}
}
