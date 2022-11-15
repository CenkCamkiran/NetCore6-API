using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Interfaces;

namespace MiddlewareLayer
{
	public class TestingMiddleware
	{
		private readonly RequestDelegate _next;

		public TestingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext, ITesting _testing)
		{
			await _next(httpContext);
			_testing.DoSomethingSync();
			//await _testing.DoSomethingAsync();
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class TestingMiddlewareExtensions
	{
		public static IApplicationBuilder UseTestingMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<TestingMiddleware>();
		}
	}
}
