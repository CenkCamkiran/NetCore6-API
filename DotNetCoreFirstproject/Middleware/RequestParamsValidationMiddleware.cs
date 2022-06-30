using DotNetCoreFirstproject.Controllers.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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

				var nameProperty = JSONBody.GetType().GetProperty("username");

				var name = nameProperty.GetValue(JSONBody, null);
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
