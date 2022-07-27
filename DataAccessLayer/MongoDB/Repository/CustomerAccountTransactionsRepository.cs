using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public object GetCustomerAccountTransactionsByAccountId(string id)
		{
			MongoDBCommand<object, object> mongoDBCommand = new MongoDBCommand<object, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.LookupLinqExample();

			throw new NotImplementedException();
		}
	}
}
