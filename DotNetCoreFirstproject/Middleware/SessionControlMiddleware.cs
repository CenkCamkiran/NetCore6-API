using DotNetCoreFirstproject.ServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DotNetCoreFirstproject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SessionControlMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var request = httpContext.Request;

            KeycloakService keycloakService = new KeycloakService();

            try
            {
                //keycloakService.RefreshSession();
                await _next(httpContext);
            }
            catch (Exception)
            {

            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SessionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionControlMiddleware>();
        }
    }
}
