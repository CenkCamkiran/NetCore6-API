using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB.Repository
{
	public class CustomerAccountsRepository : ICustomerAccountsRepository
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "customers";
		private const string ACCOUNTS_COLLECTION_NAME = "accounts";

		private readonly IMongoClient _mongoClient;

		public CustomerAccountsRepository(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public List<CustomerAccounts> GetCustomerAccountById(string id)
		{
			MongoDBCommand<Customer, Account> mongoDBCommand = new MongoDBCommand<Customer, Account>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, ACCOUNTS_COLLECTION_NAME, _mongoClient);

			var stages = new BsonDocument[]
			{
				new BsonDocument("$match",
				new BsonDocument("_id",
				new ObjectId(id))),
				new BsonDocument("$unwind",
				new BsonDocument("path", "$accounts")),
				new BsonDocument("$lookup",
				new BsonDocument
					{
						{ "from", "accounts" },
						{ "localField", "accounts" },
						{ "foreignField", "account_id" },
						{ "as", "lookupresult" }
					}),
				new BsonDocument("$group",
				new BsonDocument
					{
						{ "_id", "$_id" },
						{ "root",
				new BsonDocument("$mergeObjects", "$$ROOT") },
						{ "account_details",
				new BsonDocument("$push", "$lookupresult") }
					}),
				new BsonDocument("$replaceRoot",
				new BsonDocument("newRoot",
				new BsonDocument("$mergeObjects",
				new BsonArray
							{
								"$root",
								"$$ROOT"
							}))),
				new BsonDocument("$project",
				new BsonDocument
					{
						{ "root", 0 },
						{ "lookupresult", 0 },
						{ "accounts", 0 }
					})
			};

			string jsonData = mongoDBCommand.AggregationPipeline(customer => customer.id == id, stages);
			List<CustomerAccounts>? customerAccounts = BsonSerializer.Deserialize<List<CustomerAccounts>>(jsonData);

			return customerAccounts;

		}
	}
}
