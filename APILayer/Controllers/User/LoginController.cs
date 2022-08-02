using Helpers.CryptoHelpers;
using Helpers.LoginHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.HelpersModels;
using ServiceLayer.Interfaces;
using System.Net.Mime;

namespace APILayer.Controllers.User
{
	[Consumes(MediaTypeNames.Application.Json)]
	[Route("rest/api/v1/user/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{

		private IKeycloakService _keycloakService;

		public LoginController(IKeycloakService keycloakService)
		{
			_keycloakService = keycloakService;
		}

		[HttpPost]
		public UserLoginResponse UserLogin([FromBody] UserLoginRequest requestBody)
		{

			LoginHelper.CheckLoginFields(requestBody.username, requestBody.password);

			CryptoHelper cryptoHelper = new CryptoHelper();
			string hash = cryptoHelper.ComputeSha256Hash(String.Concat(requestBody.username, requestBody.password));
			cryptoHelper.CheckHash(requestBody.hash, hash);

			TokenResponse? token = _keycloakService.UserAuth(requestBody);

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
