using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	//https://stackoverflow.com/questions/11557912/element-id-does-not-match-any-field-or-property-of-class
	//[BsonIgnoreExtraElements]
	public class TierAndDetail
	{
		[BsonElement("tier")]
		[BsonRepresentation(BsonType.String)]
		public string tier { get; set; }

		[BsonElement("benefits")]
		public string[] benefits { get; set; }

		[BsonElement("active")]
		[BsonRepresentation(BsonType.Boolean)]
		public bool active { get; set; }

		[BsonElement("_id")]
		[BsonRepresentation(BsonType.String)]
		public string id { get; set; }
	}
}
