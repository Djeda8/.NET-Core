using Caching.Middlewares;
using Caching.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Caching
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INewsServices, NewsServices>();
            // Use cache in memory
            services.AddMemoryCache();
            // Responses to requests of the same type
            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCounterMiddleware();

            app.UseStaticFiles();

            //app.UseOptionsCacheMiddleware();

            // Responses to requests of the same type
            app.UseResponseCaching();
            app.Run(async (context) =>
            {
                context.Response.Headers["Cache-Control"] = "public, max-age=20";
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(
                    DateTime.Now.ToString("T")
                    + " <a href='/'>Reload</a>");
            });
        }
    }
}
