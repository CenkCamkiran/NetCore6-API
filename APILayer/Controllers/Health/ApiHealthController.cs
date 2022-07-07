using BusinessLayer;
using Entities.ControllerEntities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.NetworkInformation;

namespace APILayer.Controllers.Health
{
	[ApiController]
    public class ApiHealthController : ControllerBase
	{

        [HttpGet]
        [Route("rest/api/v1/status/[controller]")]
        public APIHealthResponseModel GetHealth()
        {

            APIHealthResponseModel apiHealthResponseModel = new APIHealthResponseModel();   

            PingService pingService = new PingService();
            PingReply elasticStatus = pingService.PingElasticSearch();
            PingReply keycloakStatus = pingService.PingKeycloak();

            if (elasticStatus.Status == IPStatus.Success && keycloakStatus.Status == IPStatus.Success)
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
