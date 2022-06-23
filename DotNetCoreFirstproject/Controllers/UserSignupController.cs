using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.Controllers
{

    [ApiController]
    public class UserSignupController : Controller
    {

        [HttpPost]
        [Route("/company/api/v1/[controller]")]
        [Consumes(MediaTypeNames.Application.Json)]
        public UserSignupResponseModel UserSignUp([FromBody] UserSignupRequestModel requestBody)
        {

            KeycloakService keycloakService = new KeycloakService();
            Token AuthToken = keycloakService.AdminAuth().Result;

            CreateUser createUser = new CreateUser();
            createUser.FirstName = requestBody.firstName;
            createUser.LastName = requestBody.lastName;
            createUser.Username = requestBody.username;
            createUser.Email = requestBody.email;
            createUser.Attributes.Gender = requestBody.attributes.gender;
            createUser.Attributes.PhoneNumber = requestBody.attributes.phoneNumber;
            createUser.Attributes.Age = Convert.ToInt64(requestBody.attributes.age);
            createUser.Attributes.Country = requestBody.attributes.country;

            UserSignupResponseModel response = keycloakService.UserSignUp(createUser, AuthToken);

            HttpContext.Response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            HttpContext.Response.StatusCode = (int) HttpStatusCode.Created;

            return response;

        }
    }
}
