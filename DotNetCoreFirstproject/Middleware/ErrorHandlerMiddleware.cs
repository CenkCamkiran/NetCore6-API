using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace DotNetCoreFirstproject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (KeycloakException error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json"; // HttpResponseHeader.ContentType.ToString();
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                KeycloakService keycloakService = new KeycloakService();
                string? AdminTokenModel = error.InnerException.InnerException.Message;

                if (!string.IsNullOrEmpty(AdminTokenModel))
                    await keycloakService.RemoveSession(true, JsonConvert.DeserializeObject<TokenResponseModel>(AdminTokenModel));

                await response.WriteAsync(error.InnerException.Message);

            }
            catch (KeyNotFoundException error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json"; // HttpResponseHeader.ContentType.ToString();
                response.StatusCode = (int)HttpStatusCode.NotFound;

                await response.WriteAsync(error.Message);

            }
            catch (AppException error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.NotFound;

                await response.WriteAsync(error.Message);

            }
            catch (BadRequestException error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                await response.WriteAsync(error.Message);

            }
            catch (Exception error)
            {

                var response = httpContext.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await response.WriteAsync(error.Message);

            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
