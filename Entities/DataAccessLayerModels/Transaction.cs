using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public partial class Transaction
	{
		[BsonElement("date")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime date { get; set; }

		[BsonElement("amount")]
		[BsonRepresentation(BsonType.Int32)]
		public long amount { get; set; }

		[BsonElement("transaction_code")]
		public TransactionCode transactionCode { get; set; }

		[BsonElement("symbol")]
		public Symbol symbol { get; set; }

		[BsonElement("price")]
		[BsonRepresentation(BsonType.String)]
		public string price { get; set; }

		[BsonElement("total")]
		[BsonRepresentation(BsonType.String)]
		public string total { get; set; }
	}
}
