using Nest;

namespace Helpers.AppConfigurationHelpers
{
	public partial class ElasticSearchConnection
	{
		private AppConfigurationHelper appConfigurationHelper;
		private readonly ConnectionSettings connection;

		private ElasticClient client;
		public ElasticClient ElasticSearchClient { get => client; }
	}
}
