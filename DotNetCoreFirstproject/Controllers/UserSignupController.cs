using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.SecurityTokenService;
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
            TokenResponseModel AuthToken = keycloakService.AdminAuth().Result;

            CreateUserRequestModel createUser = new CreateUserRequestModel();
            Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser.Attributes attributes = new Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser.Attributes();
            Credential credential = new Credential();
            List<Credential> credentialList = new List<Credential>();

            createUser.firstName = requestBody.firstName;
            createUser.lastName = requestBody.lastName;
            createUser.username = requestBody.username;
            createUser.email = requestBody.email;
            createUser.createdTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            createUser.enabled = true;

            attributes.gender = requestBody.attributes.gender;
            attributes.phoneNumber = requestBody.attributes.phoneNumber;
            attributes.age = requestBody.attributes.age;
            attributes.country = requestBody.attributes.country;

            credential.temporary = false;
            credential.type = "password";
            credential.value = requestBody.credentials.password;
            credentialList.Add(credential);

            createUser.attributes = attributes;
            createUser.credentials = credentialList;

            UserSignupResponseModel? userSignUpResponse = keycloakService.CreateUser(createUser, AuthToken).Result;

            HttpContext.Response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

            UserSignupResponseModel response = new UserSignupResponseModel();
            response.ResponseMessage = "User Created!";
            response.ResponseCode = ((int)HttpStatusCode.Created).ToString();

            return response;

        }
    }
}
