using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB.Repository
{
	public class CustomerAccountTransactionsRepository : ICustomerAccountTransactionsRepository
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "customers";
		private const string ACCOUNTS_COLLECTION_NAME = "accounts";

		private readonly IMongoClient _mongoClient;

		public CustomerAccountTransactionsRepository(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public List<CustomerAccountTransactions> GetCustomerAccountTransactionsByAccountId(string id)
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

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
        }),
    new BsonDocument("$unwind",
    new BsonDocument("path", "$account_details")),
    new BsonDocument("$lookup",
    new BsonDocument
        {
            { "from", "transactions" },
            { "localField", "account_details.account_id" },
            { "foreignField", "account_id" },
            { "as", "transaction_details" }
        }),
    new BsonDocument("$set",
    new BsonDocument("account_details",
    new BsonDocument("transaction_details",
    new BsonDocument("$arrayElemAt",
    new BsonArray
                    {
                        "$transaction_details",
                        0
                    })))),
    new BsonDocument("$group",
    new BsonDocument
        {
            { "_id", "$_id" },
            { "root",
    new BsonDocument("$mergeObjects", "$$ROOT") }
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
            { "transaction_details", 0 },
            { "account_details",
    new BsonDocument("transaction_details",
    new BsonDocument("account_id", 0)) }
        })
            };

            var result = mongoDBCommand.AggregationPipeline(customer => customer.id == id, stages);
            List<CustomerAccountTransactions> customerAccountTransactions = BsonSerializer.Deserialize<List<CustomerAccountTransactions>>(result);

            return customerAccountTransactions;
        }
	}
}
