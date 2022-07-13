using Helpers.AppExceptionHelpers;
using Helpers.ValidationHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Models.HelpersModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MiddlewareLayer
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class RequestParamsValidationMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestParamsValidationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{

			var requestBody = httpContext.Request.Body;

			using (StreamReader reader = new StreamReader(requestBody))
			{
				string JSONBody = await reader.ReadToEndAsync();

				var cenk = JsonConvert.DeserializeObject<object>(JSONBody);
				var jObject = JObject.Parse(JSONBody); //Must use JToken

				JToken? token = null;
				bool isEmailPropertyExists = jObject.TryGetValue("email", out token);

				if (isEmailPropertyExists)
				{
					EmailValidation emailValidation = new EmailValidation();

					string? emailValue = token.ToString();	

					if (!emailValidation.IsEmailValid(emailValue))
					{
						CustomAppError errorResponse = new CustomAppError();
						errorResponse.ErrorMessage = "Email is not valid";
						errorResponse.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

						throw new EmailFormatException(JsonConvert.SerializeObject(errorResponse));
					}
					
				}

				//foreach (JProperty property in jObject.Properties())
				//{
				//	Console.WriteLine(property.Name + " - " + property.Value.ToString());
				//}

				//foreach (KeyValuePair<string, JToken> item in jObject)
				//{
				//	Console.WriteLine(item.Key + " : " + item.Value.ToString());
				//}

			}

			await _next(httpContext);

		}
		
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class RequestParamsValidationMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestParamsValidationMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestParamsValidationMiddleware>();
		}
	}
}
