using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caching.Middlewares
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        public CounterMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context); // Pasamos el control al siguiente middleware

            var count = _cache.Get<int>("visits") + 1;
            _cache.Set("visits", count);
            await context.Response.WriteAsync($"\nTotal visits: {count}");
        }
    }
}
