using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
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

                switch(error){

                    case KeycloakException exception:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException exception:
 
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case AppException exception:

                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:

                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var cenk = JsonConvert.DeserializeObject<CustomErrorResponseModel>(error.Message);
                var result = JsonConvert.SerializeObject(new CustomErrorResponseModel{ ErrorMessage = JsonConvert.DeserializeObject<CustomErrorResponseModel>(error.Message).ErrorMessage, ErrorCode = JsonConvert.DeserializeObject<CustomErrorResponseModel>(error.Message).ErrorCode });
                await response.WriteAsync(result);

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
