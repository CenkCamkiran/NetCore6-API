using BusinessLayer.Interfaces;
using Configurations;
using Helpers.HttpClientHelpers;
using System.Net.NetworkInformation;

namespace BusinessLayer
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
			return pingHelper.PingKeycloak(new Uri(config["Host"]).Host);

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


		//public async Task<bool> PingMongoDB()
		//{
		//	Dictionary<string, string> servers = configHelper.GetKeycloakConfig();

		//	return true;

		//}

	}
}
