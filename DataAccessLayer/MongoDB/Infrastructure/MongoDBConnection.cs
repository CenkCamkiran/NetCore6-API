using Configurations;
using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Infrastructure
{
	public class MongoDBConnection
	{

		private MongoClient mongoClient;
		protected MongoClient MongoClient { get { return mongoClient; } }

		private AppConfiguration appConfiguration;

		public MongoDBConnection(string DatabaseName, string CollectionName)
		{
			try
			{
				appConfiguration = new AppConfiguration();
				Dictionary<string, string> MongoDBConfig = appConfiguration.GetMongoDBConfig();

				mongoClient = new MongoClient(MongoDBConfig["MongoDBConnectionString"]);

			}
			catch (Exception exception)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = exception.Message.ToString();
				errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

				throw new MongoDBConnectionException(JsonConvert.SerializeObject(errorModel));
			}

		}

	}
}
