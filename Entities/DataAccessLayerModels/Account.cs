using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayerModels
{
	public class Account
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }

		[BsonElement("account_id")]
		[BsonRepresentation(BsonType.Int32)]
		public int accountId { get; set; }

		[BsonElement("limit")]
		[BsonRepresentation(BsonType.Int32)]
		public int limit { get; set; }

		[BsonElement("products")]
		public string products { get; set; }
	}
}
