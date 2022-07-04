using DotNetCoreFirstproject.Helpers.AppConfigurationHelpers;
using Nest;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Infrastructure
{
	public partial class ElasticSearchConnection
	{
		private AppConfigurationHelper appConfigurationHelper;
		private readonly ConnectionSettings connection;

		private ElasticClient client;
		public ElasticClient ElasticSearchClient { get => client; }
	}
}
