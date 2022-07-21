using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using System.Net;
using System.Net.NetworkInformation;

namespace APILayer.Controllers.Health
{
	[ApiController]
	[Route("rest/api/v1/status/[controller]")]
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

			PingReply elasticStatus = _pingService.PingElasticSearch();
			PingReply keycloakStatus = _pingService.PingKeycloak();
			PingReply mongoDbStatus = _pingService.PingMongoDB();
			PingReply redisStatus = _pingService.PingRedis();

			if (elasticStatus.Status == IPStatus.Success && keycloakStatus.Status == IPStatus.Success &&
				mongoDbStatus.Status == IPStatus.Success && redisStatus.Status == IPStatus.Success)
			{
				apiHealthResponseModel.HealthStatus = ((int)HttpStatusCode.OK).ToString();
				apiHealthResponseModel.HealthStatusDescription = "API is OK!";

				return apiHealthResponseModel;

			}

			apiHealthResponseModel.HealthStatus = ((int)HttpStatusCode.InternalServerError).ToString();
			apiHealthResponseModel.HealthStatusDescription = "API is not healthy! Try again later";

			return apiHealthResponseModel;

		}
	}
}
