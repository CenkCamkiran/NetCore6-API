using BusinessLayer;
using Entities.ControllerEntities;
using Entities.HelpersEntities;
using Helpers.AppExceptionHelpers;
using Helpers.CryptoHelpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{
	[ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("rest/api/v1/user/[controller]")]
        public UserLoginResponseModel UserLogin([FromBody] UserLoginRequestModel requestBody)
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

            UserLoginResponseModel? tokenResult = new UserLoginResponseModel()
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
