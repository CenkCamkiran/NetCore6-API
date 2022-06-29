using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

            var emailValidator = new EmailAddressAttribute();

            emailValidator.IsValid();
            KeycloakService keycloakService = new KeycloakService();

            return null;
        }
    }
}
