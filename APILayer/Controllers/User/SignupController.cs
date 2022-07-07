using Entities.ControllerEntities;
using Entities.HelpersEntities;
using Helpers.AppExceptionHelpers;
using Helpers.ValidationHelpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{

	[ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SignupController : ControllerBase
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

            BusinessLayer.KeycloakService keycloakService = new BusinessLayer.KeycloakService();
            TokenResponseModel? AuthToken = keycloakService.AdminAuth();

            CreateUserRequestModel createUser = new CreateUserRequestModel();
			Entities.HelpersEntities.Attributes attributes = new Entities.HelpersEntities.Attributes();
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

            UserSignupResponseModel? createUserResult = keycloakService.CreateUser(createUser, AuthToken);

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

            UserSignupResponseModel? result = createUserResult;

            HttpContext.Response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

            UserSignupResponseModel response = new UserSignupResponseModel();
            response.ResponseMessage = "User Created!";
            response.ResponseCode = ((int)HttpStatusCode.Created).ToString();

            return response;

        }
    }
}
