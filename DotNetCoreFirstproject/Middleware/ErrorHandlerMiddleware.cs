using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using System.Net.Mime;

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

                        var appError = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(appError.ErrorCode);

                        errorResponse.ErrorMessage = appError?.ErrorMessage;
                        errorResponse.ErrorCode = appError?.ErrorCode;

                        break;

                    case AppException:

                        var applicationError = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(applicationError.ErrorCode);

                        errorResponse.ErrorMessage = applicationError?.ErrorMessage;
                        errorResponse.ErrorCode = applicationError?.ErrorCode;

                        break;

                    case KeyNotFoundException:

                        var applicationError_ = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(applicationError_.ErrorCode);

                        errorResponse.ErrorMessage = applicationError_?.ErrorMessage;
                        errorResponse.ErrorCode = applicationError_?.ErrorCode;

                        break;

                    default:

                        var applicationError__ = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(applicationError__.ErrorCode);

                        errorResponse.ErrorMessage = applicationError__?.ErrorMessage;
                        errorResponse.ErrorCode = applicationError__?.ErrorCode;

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
