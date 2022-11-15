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
			var middleware = _next(httpContext);
			var asyncMethod = _testing.DoSomethingAsync(); //Maybe logging?

			List<Task> tasks = new List<Task>()
			{
				middleware, asyncMethod
			};

			while (tasks.Count > 0)
			{
				var finishedTask = await Task.WhenAny(tasks);

				if (finishedTask == middleware)
				{
					Console.WriteLine("middleware");
				}
				else if (finishedTask == asyncMethod)
				{
					Console.WriteLine("asyncMethod");
				}

				tasks.Remove(finishedTask);
			}

			//await _next(httpContext);
			//var result = await Task.Run(() => _testing.DoSomethingSync());
			//_testing.DoSomethingSync();
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
