using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OnlineEdx.Infrastructure.Services;
using System.Threading.Tasks;

namespace OnlineEdx.Web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISeedService _seedService;

        public SeedDataMiddleware(RequestDelegate next, ISeedService seedService)
        {
            _next = next;
            _seedService = seedService;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _seedService.Seeds();
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SeedDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
