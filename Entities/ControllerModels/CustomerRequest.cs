using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.ControllerModels
{
	public class CustomerRequest
	{

		[BsonElement("username")]
		[BsonRepresentation(BsonType.String)]
		public string username { get; set; }

		[BsonElement("name")]
		[BsonRepresentation(BsonType.String)]
		public string fullname { get; set; }

		[BsonElement("address")]
		[BsonRepresentation(BsonType.String)]
		public string address { get; set; }

		[BsonElement("birthdate")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime birthdate { get; set; }

		[BsonElement("email")]
		[BsonRepresentation(BsonType.String)]
		public string email { get; set; }

		[BsonElement("active")]
		[BsonRepresentation(BsonType.Boolean)]
		public bool active { get; set; }

		[BsonElement("accounts")]
		public int[] accounts { get; set; }

		[BsonElement("tier_and_details")]
		public Dictionary<string, TierAndDetail>? tierAndDetails { get; set; }
	}
}
