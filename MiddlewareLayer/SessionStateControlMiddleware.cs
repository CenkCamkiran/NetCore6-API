using BusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Models.HelpersModels;
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

            KeycloakService keycloakService = new KeycloakService();

            StringValues AccessToken = "";
            StringValues RefreshToken = "";

            request.Headers.TryGetValue(HttpRequestHeader.Authorization.ToString(), out AccessToken);
            request.Headers.TryGetValue("RefreshToken", out RefreshToken);

            TokenResponse token = new TokenResponse();
            token.access_token = AccessToken;
            token.refresh_token = RefreshToken;

            keycloakService.RefreshSession(false, token); //This middleware used for normal users, not admins

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
