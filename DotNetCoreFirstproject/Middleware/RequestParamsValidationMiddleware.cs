using DotNetCoreFirstproject.Controllers.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Threading.Tasks;

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

				var dsa = jObject.Properties();

				var result = (JObject)jObject["username"];

				var cenkkk = result.Properties();

				//var nameOfProperty = "username";
				//var propertyInfo = cenk.GetType().GetProperty(nameOfProperty);
				//var value = propertyInfo.GetValue(cenk, null);

				//var type = cenk.GetType();

				//var nameProperty = type.GetProperty("username", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				//var fieldProperty = type.GetField("username", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

				//var name = nameProperty.GetValue(JSONBody, null);
				//nameProperty.SetValue(user, "ahmeTT", null);
				//name = nameProperty.GetValue(user, null);
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
