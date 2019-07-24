using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Middlewares
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public MyCustomMiddleware(RequestDelegate next, ILogger<MyCustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            var path = context.Request.Path;
            var statusCode = context.Response.StatusCode;
            _logger.LogDebug($"Path='{path}', status={statusCode}, time={watch.Elapsed}");
        }
    }
}
