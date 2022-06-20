using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFirstproject.Controllers
{

    [ApiController]
    public class UserSignupController : Controller
    {

        [HttpPost]
        [Route("/company/api/v1/[controller]")]
        public IEnumerable<string> UserSignUp()
        {

            //Console.WriteLine(Configuration["ExternalTools:Keycloak:Host"]);
            //Console.WriteLine(Configuration["ExternalTools:Keycloak:Admin:Username"]);
            //Console.WriteLine(Configuration["ExternalTools:Keycloak:Admin:Password"]);

            //string cengo1 = Configuration["ExternalTools:Keycloak:Host"];
            //string cengo2 = Configuration["ExternalTools:Keycloak:Admin:Username"];
            //string cengo3 = Configuration["ExternalTools:Keycloak:Admin:Password"];

            return null;
        }
    }
}
