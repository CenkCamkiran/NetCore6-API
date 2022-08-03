using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	public class Tomatoes
	{
		[BsonElement("lastUpdated")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime lastUpdated { get; set; }

		[BsonElement("fresh")]
		[BsonRepresentation(BsonType.Int32)]
		public int? fresh { get; set; }

		[BsonElement("critic")]
		public Critic critic { get; set; }

		[BsonElement("rotten")]
		[BsonRepresentation(BsonType.Int32)]
		public int? rotten { get; set; }

		[BsonElement("dvd")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime? dvd { get; set; }

		[BsonElement("website")]
		[BsonRepresentation(BsonType.String)]
		public string website { get; set; }

		[BsonElement("production")]
		[BsonRepresentation(BsonType.String)]
		public string production { get; set; }

		[BsonElement("consensus")]
		[BsonRepresentation(BsonType.String)]
		public string consensus { get; set; }
	}
}
