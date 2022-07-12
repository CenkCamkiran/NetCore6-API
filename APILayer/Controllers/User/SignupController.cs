using Helpers.AppExceptionHelpers;
using Helpers.ValidationHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{

	[ApiController]
    [Route("rest/api/v1/user/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SignupController : ControllerBase
    {

        [HttpPost]
        public UserSignupResponse UserSignUp([FromBody] UserSignupRequest requestBody)
        {

			EmailValidation validator = new EmailValidation();
			if (!validator.IsEmailValid(requestBody.email))
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Email Format is not correct";
				errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

				throw new EmailFormatException(JsonConvert.SerializeObject(errorModel));
			}

            BusinessLayer.KeycloakService keycloakService = new BusinessLayer.KeycloakService();
            TokenResponse? AuthToken = keycloakService.AdminAuth();

            CreateUserRequest createUser = new CreateUserRequest();
			Models.HelpersModels.Attributes attributes = new Models.HelpersModels.Attributes();
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
            credential.createdDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            credentialList.Add(credential);

            createUser.attributes = attributes;
            createUser.credentials = credentialList;

            UserSignupResponse? createUserResult = keycloakService.CreateUser(createUser, AuthToken);

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

            UserSignupResponse? result = createUserResult;

            HttpContext.Response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

            UserSignupResponse response = new UserSignupResponse();
            response.ResponseMessage = "User Created!";
            response.ResponseCode = ((int)HttpStatusCode.Created).ToString();

            return response;

        }
    }
}
