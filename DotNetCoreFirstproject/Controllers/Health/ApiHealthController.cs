using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.NetworkInformation;

namespace DotNetCoreFirstproject.Controllers.Health
{
    [ApiController]
    public class ApiHealthController : Controller
    {

        [HttpGet]
        [Route("rest/api/v1/status/[controller]")]
        public APIHealthResponseModel GetHealth()
        {

            APIHealthResponseModel apiHealthResponseModel = new APIHealthResponseModel();   

            PingService pingService = new PingService();
            Task<PingReply> elasticStatus = pingService.PingElasticSearch();
            Task<PingReply> keycloakStatus = pingService.PingKeycloak();

            if (elasticStatus.Result.Status == IPStatus.Success && keycloakStatus.Result.Status == IPStatus.Success)
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
