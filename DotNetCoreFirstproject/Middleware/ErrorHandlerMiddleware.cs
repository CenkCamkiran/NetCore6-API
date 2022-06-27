using DotNetCoreFirstproject.Controllers.Entities;
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
            catch (Exception error)
            {

                var response = httpContext.Response;
                response.ContentType = "application/json"; // HttpResponseHeader.ContentType.ToString();

                var cenk = error is KeycloakException;
                var cengo = error.InnerException is KeycloakException;

                switch (error.InnerException)
                {
                    case KeycloakException:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        KeycloakService keycloakService = new KeycloakService();
                        string? AdminTokenModel = error.InnerException.InnerException.Message;

                        CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                        errorResponse.ErrorMessage = error.InnerException.InnerException.Message;
                        errorResponse.ErrorCode = error.InnerException.InnerException.Message;

                        if (!string.IsNullOrEmpty(AdminTokenModel))
                            await keycloakService.RemoveSession(true, JsonConvert.DeserializeObject<TokenResponseModel>(AdminTokenModel));

                        break;

                    case BadRequestException:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        await response.WriteAsync(error.Message);

                        break;

                    case AppException:

                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        await response.WriteAsync(error.Message);

                        break;

                    case KeyNotFoundException:

                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        await response.WriteAsync(error.Message);

                        break;

                    default:

                        break;
                }

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
