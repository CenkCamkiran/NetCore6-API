using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareLayer
{
	public class LoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public LoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext, ILoggingService loggingService)
		{
			await _next(httpContext);

			await loggingService.InsertControllerRequestResponseLog(httpContext.Request, httpContext.Response);

		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class LoggingMiddlewareExtensions
	{
		public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<LoggingMiddleware>();
		}
	}
}
