using BusinessLayer;
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

		[HttpGet]
		public APIHealthResponse GetHealth()
		{

			APIHealthResponse apiHealthResponseModel = new APIHealthResponse();

			PingService pingService = new PingService();
			PingReply elasticStatus = pingService.PingElasticSearch();
			PingReply keycloakStatus = pingService.PingKeycloak();
			PingReply mongoDbStatus = pingService.PingMongoDB();

			if (elasticStatus.Status == IPStatus.Success && keycloakStatus.Status == IPStatus.Success && mongoDbStatus.Status == IPStatus.Success)
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
