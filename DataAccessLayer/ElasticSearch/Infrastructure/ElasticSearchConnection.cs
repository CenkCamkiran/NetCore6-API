using Nest;
using Elasticsearch.Net;
using Configurations;

namespace DataAccessLayer.ElasticSearch.Infrastructure
{
	public partial class ElasticSearchConnection
	{

		public ElasticSearchConnection()
		{

			AppConfiguration appConfiguration = new AppConfiguration();
			Dictionary<string, string> elasticConfig = appConfiguration.GetElasticSearchConfig();

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
