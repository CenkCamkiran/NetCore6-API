using BusinessLayer;
using Helpers.AppExceptionHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{
	[ApiController]
	[Consumes(MediaTypeNames.Application.Json)]
	[Route("rest/api/v1/user/[controller]")]
	public class LogoutController : ControllerBase
	{

		[HttpPost]
		public NoContentResult UserLogout([FromBody] LogoutRequest token)
		{

			if (string.IsNullOrEmpty(token.accessToken) || string.IsNullOrEmpty(token.refreshToken))
			{

				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "AccessToken and RefreshToken must not be null or empty";
				errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

				throw new MandatoryRequestBodyParametersException(JsonConvert.SerializeObject(errorModel));
			}

			JwtSecurityToken? decodedAccessToken = new JwtSecurityToken(token.accessToken);
			JwtPayload? accessTokenPayload = decodedAccessToken.Payload;

			object? sessionState;
			bool isSessionStateExists = accessTokenPayload.TryGetValue("session_state", out sessionState);

			if (!isSessionStateExists)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "AccessToken or RefreshToken is malformed";
				errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

				throw new MalformedTokenException(JsonConvert.SerializeObject(errorModel));
			}

			KeycloakService keycloakService = new KeycloakService();

			TokenResponse adminToken = keycloakService.AdminAuth();

			TokenResponse tokenResponse = new TokenResponse()
			{
				access_token = token.accessToken,
				refresh_token = token.refreshToken,
				session_state = accessTokenPayload["session_state"].ToString()
			};


			keycloakService.RemoveSession(false, tokenResponse);

			return NoContent();
		}
	}
}
