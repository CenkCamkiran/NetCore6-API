using APILayer.Entities;
using BusinessLayer;
using Entities.HelpersEntities;
using Helpers.AppExceptionHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace MiddlewareLayer
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
            catch(AggregateException error)
            {

                KeycloakService keycloakService = new KeycloakService();

                var response = httpContext.Response;
                response.ContentType = MediaTypeNames.Application.Json; // HttpResponseHeader.ContentType.ToString();

                //var cenk = error is KeycloakException;
                //var cengo = error.InnerException is KeycloakException;

                CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();

                switch (error.InnerException)
                {
                    case KeycloakException:

                        CustomKeycloakErrorModel AdminTokenModel = JsonConvert.DeserializeObject<CustomKeycloakErrorModel>(error.InnerException.Message);

                        response.StatusCode = Convert.ToInt32(AdminTokenModel.ErrorCode);

                        errorResponse.ErrorMessage = AdminTokenModel?.ErrorMessage;
                        errorResponse.ErrorCode = AdminTokenModel?.ErrorCode;
                        
                        if (AdminTokenModel.KeycloakToken != null)
                            keycloakService.RemoveSession(true, AdminTokenModel.KeycloakToken);

                        break;

                    case BadRequestException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorCode;

                        break;

                    case AppException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorCode;

                        break;

                    case KeyNotFoundException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorCode;

                        break;

                    case MandatoryRequestTokenHeadersException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorCode;

                        break;

                    case ArgumentException or ArgumentNullException or FormatException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case EmailFormatException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case MandatoryRequestParametersException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case HashFailedException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    default:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.InnerException.Message)?.ErrorCode;

                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
            catch (Exception error)
            {

                KeycloakService keycloakService = new KeycloakService();

                var response = httpContext.Response;
                response.ContentType = MediaTypeNames.Application.Json; // HttpResponseHeader.ContentType.ToString();

                //var cenk = error is KeycloakException;
                //var cengo = error.InnerException is KeycloakException;

                CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();

                switch (error)
                {

                    case KeycloakException:

                        CustomKeycloakErrorModel AdminTokenModel = JsonConvert.DeserializeObject<CustomKeycloakErrorModel>(error.Message);

                        response.StatusCode = Convert.ToInt32(AdminTokenModel.ErrorCode);

                        errorResponse.ErrorMessage = AdminTokenModel?.ErrorMessage;
                        errorResponse.ErrorCode = AdminTokenModel?.ErrorCode;

                        if (AdminTokenModel.KeycloakToken != null)
                            keycloakService.RemoveSession(true, AdminTokenModel.KeycloakToken);

                        break;

                    case BadRequestException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case AppException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case KeyNotFoundException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case MandatoryRequestTokenHeadersException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case ArgumentException or ArgumentNullException or FormatException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break; 

                    case EmailFormatException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case MandatoryRequestParametersException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    case HashFailedException:

                        response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message).ErrorCode);

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

                        break;

                    default:

                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorMessage;
                        errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppErrorModel>(error.Message)?.ErrorCode;

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
