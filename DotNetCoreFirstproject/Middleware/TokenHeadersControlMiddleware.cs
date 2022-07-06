using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Net;

namespace DotNetCoreFirstproject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenHeadersControlMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenHeadersControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var request = httpContext.Request;

            StringValues AuthorizationBearerToken = "";
            StringValues RefreshToken = "";

            bool IsAuthorizationHeaderExists = request.Headers.TryGetValue(HttpRequestHeader.Authorization.ToString(), out AuthorizationBearerToken);
            string AccessToken = AuthorizationBearerToken.ToString().Replace("Bearer", "", StringComparison.OrdinalIgnoreCase).Trim();
            //bool IsAccessTokenHeaderExists = request.Headers.TryGetValue("AccessToken", out AccessToken);
            bool IsRefreshTokenHeaderExists = request.Headers.TryGetValue("RefreshToken", out RefreshToken);

            if (!IsAuthorizationHeaderExists || !IsRefreshTokenHeaderExists)
            {
                CustomAppErrorModel errorModel = new CustomAppErrorModel();
                errorModel.ErrorMessage = "AccessToken or RefreshToken not found in request headers.";
                errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                throw new MandatoryRequestTokenHeadersException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {
                if (string.IsNullOrEmpty(AccessToken.ToString()) || string.IsNullOrEmpty(RefreshToken.ToString()))
                {
                    CustomAppErrorModel errorModel = new CustomAppErrorModel();
                    errorModel.ErrorMessage = "AccessToken or RefreshToken not found in request headers.";
                    errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    throw new MandatoryRequestTokenHeadersException(JsonConvert.SerializeObject(errorModel));
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
            return builder.UseMiddleware<TokenHeadersControlMiddleware>();
        }
    }
}
