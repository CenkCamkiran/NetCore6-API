using DotNetCoreFirstproject.Helpers.AppConfigurationHelpers;
using DotNetCoreFirstproject.Helpers.HttpClientHelpers;
using System.Net.NetworkInformation;

namespace DotNetCoreFirstproject.ServiceLayer
{
	public class PingService
	{
		private AppConfigurationHelper configHelper;
		private PingHelper pingHelper;

		public PingService()
		{
			configHelper = new AppConfigurationHelper();
			pingHelper = new PingHelper();
		}

		public PingReply PingKeycloak()
		{

			Dictionary<string, string> config = configHelper.GetKeycloakConfig();
			return pingHelper.PingKeycloak(new Uri(config["Host"]).Host);

		}

		public PingReply PingElasticSearch()
		{

			Dictionary<string, string> config = configHelper.GetElasticSearchConfig();
			return pingHelper.PingElasticsearch(new Uri(config["ElasticHost"]).Host);

		}

		//public async Task<bool> PingMongoDB()
		//{
		//	Dictionary<string, string> servers = configHelper.GetKeycloakConfig();

		//	return true;

		//}

	}
}
