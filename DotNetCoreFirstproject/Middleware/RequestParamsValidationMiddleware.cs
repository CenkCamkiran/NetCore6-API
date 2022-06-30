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

		//	var request = httpContext.Request;
		//cenk.oguz != null || 
		//Signup x =		(signup)cenk
		//	if (request.Body is UserLoginRequestModel)
		//	{
		//		Console.WriteLine("UserLoginRequestModel");
		//	}
		//	else if (request is UserSignupResponseModel)
		//	{
		//		Console.WriteLine("UserSignupResponseModel");
		//	}

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
