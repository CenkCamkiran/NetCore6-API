using BusinessLayer;
using Helpers.AppExceptionHelpers;
using Helpers.CryptoHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{
	[ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("rest/api/v1/user/[controller]")]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public UserLoginResponse UserLogin([FromBody] UserLoginRequest requestBody)
        {

            if (string.IsNullOrEmpty(requestBody.username) || string.IsNullOrEmpty(requestBody.password))
            {
                CustomAppError errorModel = new CustomAppError();
                errorModel.ErrorMessage = "Username and password cannot be empty or null";
                errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

                throw new MandatoryRequestBodyParametersException(JsonConvert.SerializeObject(errorModel));
            }

            CryptoHelper cryptoHelper = new CryptoHelper();
            string hash = cryptoHelper.ComputeSha256Hash(String.Concat(requestBody.username, requestBody.password));
            if (requestBody.hash != hash)
            {
                CustomAppError errorModel = new CustomAppError();
                errorModel.ErrorMessage = "Hash failed";
                errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

                throw new HashFailedException(JsonConvert.SerializeObject(errorModel));
            }

            KeycloakService keycloakService = new KeycloakService();
            TokenResponse? token = keycloakService.UserAuth(requestBody);

            UserLoginResponse? tokenResult = new UserLoginResponse()
            {
                accessToken = token.access_token,
                refreshToken = token.refresh_token,
                expiresIn = token.expires_in,
                refreshExpiresIn = token.refresh_expires_in, 
                sessionState = token.session_state,
                tokenType = token.token_type
            };

            return tokenResult;
        }
    }
}
