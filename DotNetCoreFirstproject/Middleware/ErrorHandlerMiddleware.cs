using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;
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
                response.ContentType = MediaTypeNames.Application.Json; // HttpResponseHeader.ContentType.ToString();

                //var cenk = error is KeycloakException;
                //var cengo = error.InnerException is KeycloakException;

                CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();

                switch (error.InnerException)
                {
                    case KeycloakException:

                        KeycloakService keycloakService = new KeycloakService();
                        CustomKeycloakErrorModel AdminTokenModel = JsonConvert.DeserializeObject<CustomKeycloakErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(AdminTokenModel.ErrorCode);

                        errorResponse.ErrorMessage = AdminTokenModel?.ErrorMessage;
                        errorResponse.ErrorCode = AdminTokenModel?.ErrorCode;

                        await keycloakService.RemoveSession(true, AdminTokenModel.KeycloakToken);

                        break;

                    case BadRequestException:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        break;

                    case AppException:

                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;

                    case KeyNotFoundException:

                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;

                    default:

                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(errorResponse));

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
