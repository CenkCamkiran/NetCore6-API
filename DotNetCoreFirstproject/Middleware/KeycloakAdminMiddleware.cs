using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DotNetCoreFirstproject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class KeycloakAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public KeycloakAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class KeycloakAdminMiddlewareExtensions
    {
        public static IApplicationBuilder UseKeycloakAdminMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<KeycloakAdminMiddleware>();
        }
    }
}
