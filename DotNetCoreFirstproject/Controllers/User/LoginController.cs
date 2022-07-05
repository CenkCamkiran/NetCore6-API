using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.CryptoHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.Controllers.User
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class LoginController : Controller
    {

        [HttpPost]
        [Route("rest/api/v1/user/[controller]")]
        public TokenResponseModel UserLogin([FromBody] UserLoginRequestModel requestBody)
        {

            if (string.IsNullOrEmpty(requestBody.username) || string.IsNullOrEmpty(requestBody.password))
            {
                CustomAppErrorModel errorModel = new CustomAppErrorModel();
                errorModel.ErrorMessage = "Username and password cannot be empty or null";
                errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

                throw new MandatoryRequestParametersException(JsonConvert.SerializeObject(errorModel));
            }

            CryptoHelper cryptoHelper = new CryptoHelper();
            string hash = cryptoHelper.ComputeSha256Hash(String.Concat(requestBody.username, requestBody.password));
            if (requestBody.hash != hash)
            {
                CustomAppErrorModel errorModel = new CustomAppErrorModel();
                errorModel.ErrorMessage = "Hash failed";
                errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

                throw new HashFailedException(JsonConvert.SerializeObject(errorModel));
            }

            KeycloakService keycloakService = new KeycloakService();
            TokenResponseModel? token = keycloakService.UserAuth(requestBody);

            TokenResponseModel? tokenResult = token;

            return tokenResult;
        }
    }
}
