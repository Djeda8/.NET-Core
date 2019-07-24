using Microsoft.AspNetCore.Builder;

namespace Caching.Middlewares
{
    public static class RequestCounterMiddlewareExtensions
    {
        public static IApplicationBuilder UseCounterMiddleware(
                    this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CounterMiddleware>();
        }
    }
}
