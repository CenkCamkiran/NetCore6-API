using Nest;
using Elasticsearch.Net;

namespace DataAccessLayer.ElasticSearch.Infrastructure
{
	public partial class ElasticSearchConnection
	{

		public ElasticSearchConnection()
		{

			appConfigurationHelper = new AppConfigurationHelper();
			Dictionary<string, string> elasticConfig = appConfigurationHelper.GetElasticSearchConfig();

			connection = new ConnectionSettings(new Uri(elasticConfig["ElasticHost"])).
			   DefaultIndex(elasticConfig["DefaultIndexName"]).
			   ServerCertificateValidationCallback(CertificateValidations.AllowAll).
			   ThrowExceptions(true).
			   PrettyJson().
			   RequestTimeout(TimeSpan.FromSeconds(300)).
			   BasicAuthentication(elasticConfig["ElasticRootUsername"], elasticConfig["ElasticRootPassword"]); //.ApiKeyAuthentication("<id>", "<api key>"); 

			client = new ElasticClient(connection);

		}

	}
}
