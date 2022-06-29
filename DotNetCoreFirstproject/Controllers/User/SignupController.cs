using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;
using DotNetCoreFirstproject.Helpers.ValidationHelpers;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.Controllers.User
{

    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SignupController : Controller
    {

        [HttpPost]
        [Route("rest/api/v1/user/[controller]")]
        public UserSignupResponseModel UserSignUp([FromBody] UserSignupRequestModel requestBody)
        {

            EmailValidation validator = new EmailValidation();
            if (!validator.IsEmailValid(requestBody.email))
            {
                CustomAppErrorModel errorModel = new CustomAppErrorModel();
                errorModel.ErrorMessage = "Email Format is not correct";
                errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

                throw new EmailFormatException(JsonConvert.SerializeObject(errorModel));
            } 

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

            Task<UserSignupResponseModel> createUserResult = keycloakService.CreateUser(createUser, AuthToken);

            //AggregateException? exception = createUserResult.Exception;

            ////exception.
            //var cenk = exception.Flatten();
            //var opt1 = exception is KeycloakException;
            //var opt2 = exception is Exception;
            //var opt3 = exception.InnerException is KeycloakException;

            //var cenkkkk = exception.Message;
            //var json = JsonConvert.DeserializeObject(cenkkkk);

            //cenk.Handle(ex =>
            //{
            //    return false;
            //});

            UserSignupResponseModel? result = createUserResult.Result;

            HttpContext.Response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

            UserSignupResponseModel response = new UserSignupResponseModel();
            response.ResponseMessage = "User Created!";
            response.ResponseCode = ((int)HttpStatusCode.Created).ToString();

            return response;

        }
    }
}
