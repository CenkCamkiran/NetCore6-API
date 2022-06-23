using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNetCoreFirstproject.Controllers
{

    [ApiController]
    public class UserSignupController : Controller
    {

        [HttpPost]
        [Route("/company/api/v1/[controller]")]
        public Token UserSignUp([FromBody] UsersignupModel requestBody)
        {

            KeycloakService keycloakService = new KeycloakService();
            var AuthToken = keycloakService.AdminAuth();

            //HttpContext.Response.Headers.Add();
            HttpContext.Response.StatusCode = (int) HttpStatusCode.OK;

            return AuthToken.Result;

        }
    }
}
