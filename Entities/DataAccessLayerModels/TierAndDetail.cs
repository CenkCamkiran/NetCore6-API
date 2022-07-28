using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	public class TierAndDetail
	{
		[BsonElement("tier")]
		[BsonRepresentation(BsonType.String)]
		public string tier { get; set; }

		[BsonElement("id")]
		[BsonRepresentation(BsonType.String)]
		public string id { get; set; }

		[BsonElement("active")]
		[BsonRepresentation(BsonType.Boolean)]
		public bool active { get; set; }

		[BsonElement("benefits")]
		public string[] benefits { get; set; }
	}
}
