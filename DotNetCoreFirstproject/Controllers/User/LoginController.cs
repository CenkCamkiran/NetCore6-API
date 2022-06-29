using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.Helpers.ValidationHelpers;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.Controllers.User
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class LoginController : Controller
    {

        [Route("rest/api/v1/user/[controller]")]
        public TokenResponseModel UserLogin([FromBody] UserLoginRequestModel requestBody)
        {

            KeycloakService keycloakService = new KeycloakService();
            Task<TokenResponseModel> token = keycloakService.UserAuth(requestBody);

            return token.Result;
        }
    }
}
