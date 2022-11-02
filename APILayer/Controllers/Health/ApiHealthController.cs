using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using ServiceLayer.Interfaces;
using System.Net;
using System.Net.NetworkInformation;

//
namespace APILayer.Controllers.Health
{
	[Route("rest/api/v1/status/[controller]")]
	[ApiController]
	public class ApiHealthController : ControllerBase
	{

		private IPingService _pingService;

		public ApiHealthController(IPingService pingService)
		{
			_pingService = pingService;
		}

		[HttpGet]
		public APIHealthResponse GetHealth()
		{

			APIHealthResponse apiHealthResponseModel = new APIHealthResponse();
			Models.ControllerModels.Health health = new Models.ControllerModels.Health();

			PingReply elasticStatus = _pingService.PingElasticSearch();
			PingReply keycloakStatus = _pingService.PingKeycloak();
			PingReply mongoDbStatus = _pingService.PingMongoDB();
			//PingReply redisStatus = _pingService.PingRedis();
			PingReply rabbitmqStatus = _pingService.PingRabbitMQ();

			health.ElasticSearch = elasticStatus.Status.ToString();
			health.Keycloak = keycloakStatus.Status.ToString();
			health.MongoDB = mongoDbStatus.Status.ToString();
			//health.Redis = redisStatus.Status.ToString();
			health.RabbitMQ = rabbitmqStatus.Status.ToString();

			apiHealthResponseModel.HealthStatus = health;

			return apiHealthResponseModel;

			//if (elasticStatus.Status == IPStatus.Success && keycloakStatus.Status == IPStatus.Success &&
			//	mongoDbStatus.Status == IPStatus.Success && redisStatus.Status == IPStatus.Success &&
			//	rabbitmqStatus.Status == IPStatus.Success)
			//{

			//	health.ElasticSearch = elasticStatus.Status.ToString();
			//	health.Keycloak = keycloakStatus.Status.ToString();
			//	health.MongoDB = mongoDbStatus.Status.ToString();
			//	health.Redis = redisStatus.Status.ToString();
			//	health.RabbitMQ = rabbitmqStatus.Status.ToString();

			//	apiHealthResponseModel.HealthStatus = health;

			//	return apiHealthResponseModel;

			//}
			//else
			//{

			//}

			//apiHealthResponseModel.HealthStatus = ((int)HttpStatusCode.InternalServerError).ToString();
			//apiHealthResponseModel.HealthStatusDescription = "API is not healthy! Try again later";

		}
	}
}
