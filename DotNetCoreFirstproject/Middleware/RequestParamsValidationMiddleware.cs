﻿using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.Helpers.ValidationHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace DotNetCoreFirstproject.Middleware
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
				var jObject = JObject.Parse(JSONBody);

				JToken? token = null;
				bool isEmailPropertyExists = jObject.TryGetValue("email", out token);

				if (isEmailPropertyExists)
				{
					EmailValidation emailValidation = new EmailValidation();

					string? emailValue = token.ToString();	

					if (!emailValidation.IsEmailValid(emailValue))
					{
						CustomAppErrorModel errorResponse = new CustomAppErrorModel();
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
