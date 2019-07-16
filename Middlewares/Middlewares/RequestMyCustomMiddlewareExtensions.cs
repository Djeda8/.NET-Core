using Microsoft.AspNetCore.Builder;

namespace Middlewares
{
    public static class RequestMyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMyCustomMiddleware(
                    this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
