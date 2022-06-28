using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Net;

namespace DotNetCoreFirstproject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenControlMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var request = httpContext.Request;

            StringValues AccessToken = "";
            StringValues RefreshToken = "";

            bool IsAccessTokenHeaderExists = request.Headers.TryGetValue("AccessToken", out AccessToken);
            bool IsRefreshTokenHeaderExists = request.Headers.TryGetValue("RefreshToken", out RefreshToken);

            if (!IsAccessTokenHeaderExists || !IsRefreshTokenHeaderExists)
            {

                if (string.IsNullOrEmpty(AccessToken.ToString()) || string.IsNullOrEmpty(RefreshToken.ToString()))
                {
                    CustomAppErrorModel errorModel = new CustomAppErrorModel();
                    errorModel.ErrorMessage = "AccessToken or RefreshToken not found in request headers.";
                    errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    throw new RequestTokenHeadersException(JsonConvert.SerializeObject(errorModel));
                }

            }

            //else, execute the process
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenControlMiddleware>();
        }
    }
}
