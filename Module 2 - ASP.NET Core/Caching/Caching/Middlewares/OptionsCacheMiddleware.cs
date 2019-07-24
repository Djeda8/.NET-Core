using Caching.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caching.Middlewares
{
    public class OptionsCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly INewsServices _newsServices;
        public OptionsCacheMiddleware(INewsServices newsServices, RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
            _newsServices = newsServices;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context); // Pass the control to the next middleware

            IList<string> news;
            if (!_cache.TryGetValue<IList<string>>("latestNews", out news))
            {
                news = _newsServices.GetLatestNews();
                var options = new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5),
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1)
                };

                // The entry can be removed, is not priority
                options.Priority = CacheItemPriority.Low;

                // Never removed the entry automatically 
                // We do this manually
                options.Priority = CacheItemPriority.NeverRemove;

                _cache.Set("latestNews", news, options);

                // To invalidate an entry
                _cache.Remove("latestNews");
            }

            await context.Response.WriteAsync($"\nNumber of News: {news.Count}");
        }
    }
}
