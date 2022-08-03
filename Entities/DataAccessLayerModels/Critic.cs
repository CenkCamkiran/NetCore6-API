using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	public class Critic
	{
		[BsonElement("rating")]
		[BsonRepresentation(BsonType.Double)]
		public double rating { get; set; }

		[BsonElement("numReviews")]
		[BsonRepresentation(BsonType.Int32)]
		public int numReviews { get; set; }

		[BsonElement("meter")]
		[BsonRepresentation(BsonType.Int32)]
		public int meter { get; set; }
	}
}
