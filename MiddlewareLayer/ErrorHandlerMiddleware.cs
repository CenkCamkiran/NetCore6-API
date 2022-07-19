using BusinessLayer;
using Helpers.AppExceptionHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.SecurityTokenService;
using Models.ControllerModels;
using Models.HelpersModels;
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
			catch (AggregateException error)
			{

				KeycloakService keycloakService = new KeycloakService();

				var response = httpContext.Response;
				response.ContentType = MediaTypeNames.Application.Json; // HttpResponseHeader.ContentType.ToString();

				//var cenk = error is KeycloakException;
				//var cengo = error.InnerException is KeycloakException;

				CustomErrorResponse errorResponse = new CustomErrorResponse();

				switch (error.InnerException)
				{
					case KeycloakException:

						CustomKeycloakError AdminTokenModel = JsonConvert.DeserializeObject<CustomKeycloakError>(error.InnerException.Message);

						response.StatusCode = Convert.ToInt32(AdminTokenModel.ErrorCode);

						errorResponse.ErrorMessage = AdminTokenModel?.ErrorMessage;
						errorResponse.ErrorCode = AdminTokenModel?.ErrorCode;

						if (AdminTokenModel.KeycloakToken != null)
							keycloakService.RemoveSession(true, AdminTokenModel.KeycloakToken);

						break;

					case BadRequestException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorCode;

						break;

					case AppException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorCode;

						break;

					case KeyNotFoundException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorCode;

						break;

					case MandatoryRequestTokenHeadersException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.InnerException.Message)?.ErrorCode;

						break;

					case ArgumentException or ArgumentNullException or FormatException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case EmailFormatException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MandatoryRequestBodyParametersException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case HashFailedException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case ElasticSearchException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MandatoryRequestQueryParamsException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case DataNotFoundException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MongoDBConnectionException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case TokenNotActiveException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					default:

						response.StatusCode = ((int)HttpStatusCode.InternalServerError);

						errorResponse.ErrorMessage = error.Message.ToString();
						errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

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

				CustomErrorResponse errorResponse = new CustomErrorResponse();

				switch (error)
				{

					case KeycloakException:

						CustomKeycloakError AdminTokenModel = JsonConvert.DeserializeObject<CustomKeycloakError>(error.Message);

						response.StatusCode = Convert.ToInt32(AdminTokenModel.ErrorCode);

						errorResponse.ErrorMessage = AdminTokenModel?.ErrorMessage;
						errorResponse.ErrorCode = AdminTokenModel?.ErrorCode;

						if (AdminTokenModel.KeycloakToken != null)
							keycloakService.RemoveSession(true, AdminTokenModel.KeycloakToken);

						break;

					case BadRequestException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case AppException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case KeyNotFoundException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MandatoryRequestTokenHeadersException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case ArgumentException or ArgumentNullException or FormatException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case EmailFormatException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MandatoryRequestBodyParametersException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case HashFailedException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MandatoryRequestQueryParamsException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case ElasticSearchException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case DataNotFoundException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case MongoDBConnectionException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					case TokenNotActiveException:

						response.StatusCode = Convert.ToInt32(JsonConvert.DeserializeObject<CustomAppError>(error.Message).ErrorCode);

						errorResponse.ErrorMessage = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorMessage;
						errorResponse.ErrorCode = JsonConvert.DeserializeObject<CustomAppError>(error.Message)?.ErrorCode;

						break;

					default:

						response.StatusCode = ((int)HttpStatusCode.InternalServerError);

						errorResponse.ErrorMessage = "General error occurred!";
						errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

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
