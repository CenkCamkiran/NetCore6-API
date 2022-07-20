using BusinessLayer;
using Helpers.AppExceptionHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;

namespace MiddlewareLayer
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class SessionStateControlMiddleware
	{
		private readonly RequestDelegate _next;

		public SessionStateControlMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{

			var request = httpContext.Request;
			var response = httpContext.Response;

			KeycloakService keycloakService = new KeycloakService();

			StringValues AccessToken = "";
			StringValues RefreshToken = "";

			request.Headers.TryGetValue(HttpRequestHeader.Authorization.ToString(), out AccessToken);
			request.Headers.TryGetValue("RefreshToken", out RefreshToken);

			string AccessToken_ = AccessToken.ToString().Substring(0, 7).Trim();

			TokenResponse token = new TokenResponse();
			token.access_token = AccessToken_;
			token.refresh_token = RefreshToken;

			DecodedToken DecodedAccessToken = keycloakService.CheckTokenStatus(token.access_token);

			//active: true or false
			if (!DecodedAccessToken.active)
			{

				DecodedToken DecodedRefreshToken = keycloakService.CheckTokenStatus(token.refresh_token);

				if (!DecodedRefreshToken.active)
				{

					CustomAppError errorModel = new CustomAppError();
					errorModel.ErrorMessage = "Access Token and Refresh Token not active. Try again login";
					errorModel.ErrorCode = ((int)HttpStatusCode.Unauthorized).ToString();

					throw new TokenNotActiveException(JsonConvert.SerializeObject(errorModel));
				}
				else
				{
					TokenResponse? tokenResponse = keycloakService.RefreshSession(false, token); //This middleware used for normal users, not admins

					//This 2 lines of code added because of user and developer experience
					response.Headers.Add(HttpRequestHeader.Authorization.ToString(), tokenResponse.access_token);
					response.Headers.Add("RefreshToken", tokenResponse.refresh_token);

				}
			}

			await _next(httpContext);

		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class SessionControlMiddlewareExtensions
	{
		public static IApplicationBuilder UseSessionControlMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<SessionStateControlMiddleware>();
		}
	}
}
