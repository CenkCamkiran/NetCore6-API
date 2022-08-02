﻿using Helpers.AppExceptionHelpers;
using Helpers.TokenHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mime;

namespace APILayer.Controllers.User
{
	[Consumes(MediaTypeNames.Application.Json)]
	[Route("rest/api/v1/user/[controller]")]
	[ApiController]
	public class LogoutController : ControllerBase
	{

		private IKeycloakService _keycloakService;

		public LogoutController(IKeycloakService keycloakService)
		{
			_keycloakService = keycloakService;
		}

		[HttpPost]
		public NoContentResult UserLogout([FromBody] LogoutRequest token)
		{

			token.CheckToken(token.accessToken, token.refreshToken);

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

			TokenResponse? adminToken = _keycloakService.AdminAuth();

			TokenResponse tokenResponse = new TokenResponse()
			{
				access_token = token.accessToken,
				refresh_token = token.refreshToken,
				session_state = accessTokenPayload["session_state"].ToString()
			};

			_keycloakService.RemoveSession(false, tokenResponse, adminToken);

			return NoContent();
		}
	}
}
