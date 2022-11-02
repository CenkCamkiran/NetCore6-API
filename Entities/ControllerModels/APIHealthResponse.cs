using System.Net.NetworkInformation;

namespace Models.ControllerModels
{
	[Serializable]
	public class APIHealthResponse
	{
		public Health HealthStatus { get; set; }
	}

	[Serializable]
	public class Health
	{
		public string ElasticSearch { get; set; }
		public string Keycloak { get; set; }
		public string MongoDB { get; set; }
		public string Redis { get; set; }
		public string RabbitMQ { get; set; }

	}
}
