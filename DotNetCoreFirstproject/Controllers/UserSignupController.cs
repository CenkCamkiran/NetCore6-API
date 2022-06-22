using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFirstproject.Controllers
{

    [ApiController]
    public class UserSignupController : Controller
    {

        [HttpPost]
        [Route("/company/api/v1/[controller]")]
        public IEnumerable<object> UserSignUp([FromBody] UsersignupModel requestBody)
        {

            KeycloakService keycloakService = new KeycloakService();

            var token = keycloakService.AdminAuth();
            Console.WriteLine(token);

            return null;

        }
    }
}
