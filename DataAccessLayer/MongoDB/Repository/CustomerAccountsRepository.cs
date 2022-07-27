using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public object GetCustomerAccountById(string Id)
		{
			MongoDBCommand<Customer, Account> mongoDBCommand = new MongoDBCommand<Customer, Account>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, ACCOUNTS_COLLECTION_NAME, _mongoClient);

			var cenk = new BsonDocument()

			return mongoDBCommand.LookupClassicWithUnwind(customer => customer.id == Id, "accounts", "account_id", "result");

		}
	}
}
