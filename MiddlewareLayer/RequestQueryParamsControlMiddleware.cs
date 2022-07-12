using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareLayer
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class RequestQueryParamsControlMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestQueryParamsControlMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{

			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class RequestQueryParamsControlMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestQueryParamsControlMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestQueryParamsControlMiddleware>();
		}
	}
}
