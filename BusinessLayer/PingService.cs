using Configurations;
using Helpers.HttpClientHelpers;
using ServiceLayer.Interfaces;
using System.Net.NetworkInformation;

namespace ServiceLayer
{
	public class PingService : IPingService
	{
		private AppConfiguration appConfiguration;
		private PingHelper pingHelper;

		public PingService()
		{
			appConfiguration = new AppConfiguration();
			pingHelper = new PingHelper();
		}

		public PingReply PingKeycloak()
		{

			Dictionary<string, string> config = appConfiguration.GetKeycloakConfig();
			return pingHelper.PingKeycloak(new Uri(config["KeycloakHost"]).Host);

		}

		public PingReply PingElasticSearch()
		{

			Dictionary<string, string> config = appConfiguration.GetElasticSearchConfig();
			return pingHelper.PingElasticsearch(new Uri(config["ElasticHost"]).Host);

		}

		public PingReply PingMongoDB()
		{
			Dictionary<string, string> config = appConfiguration.GetMongoDBConfig();
			return pingHelper.PingElasticsearch(new Uri(config["MongoDBHost"]).Host);
		}


		public PingReply PingRedis()
		{
			Dictionary<string, string> config = appConfiguration.GetRedisConfig();
			return pingHelper.PingRedis(new Uri(config["RedisHost"]).Host);
		}

	}
}
