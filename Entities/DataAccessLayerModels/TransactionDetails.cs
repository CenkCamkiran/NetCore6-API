using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public class TransactionDetails
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }

		[BsonElement("transaction_count")]
		[BsonRepresentation(BsonType.Int32)]
		public long transactionCount { get; set; }

		[BsonElement("bucket_start_date")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime bucketStartDate { get; set; }

		[BsonElement("bucket_end_date")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime bucketEndDate { get; set; }

		[BsonElement("transactions")]
		public Transaction[] transactions { get; set; }

	}
}
