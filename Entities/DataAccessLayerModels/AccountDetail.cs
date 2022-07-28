using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	public class AccountDetail
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }

		[BsonElement("account_id")]
		[BsonRepresentation(BsonType.Int32)]
		public long accountId { get; set; }

		[BsonElement("limit")]
		[BsonRepresentation(BsonType.Int32)]
		public long limit { get; set; }

		[BsonElement("products")]
		public string[] products { get; set; }

		[BsonElement("transaction_details")]
		public TransactionDetails TransactionDetails { get; set; }
	}
}
