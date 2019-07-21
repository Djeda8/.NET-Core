using Microsoft.AspNetCore.Builder;

namespace Caching.Middlewares
{
    public static class RequestOptionsCacheMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptionsCacheMiddleware(
                    this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsCacheMiddleware>();
        }
    }
}
