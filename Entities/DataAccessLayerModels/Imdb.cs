using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	//[BsonIgnoreExtraElements]
	[BsonNoId]
	public class Imdb
	{
		[BsonElement("rating")]
		[BsonRepresentation(BsonType.Double)]
		public double rating { get; set; }

		[BsonElement("votes")]
		[BsonRepresentation(BsonType.Int32)]
		public int votes { get; set; }

		[BsonElement("id")]
		[BsonRepresentation(BsonType.Int32)]
		public int id { get; set; }
	}
}
