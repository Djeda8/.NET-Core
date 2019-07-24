using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Middlewares
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(ILogger<Startup> logger)
        {
            _logger = logger;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //... Others middlewares
            //app.Use(async (context, next) =>
            //{
            //    // Do something before to pass the control to the next middleware
            //    await next(); // Pasamos el control al siguiente middleware
            //    // Do something after to execute the next middleware
            //});
            //... Others middlewares
                        
            app.Use(async (context, next) =>
            {
                var watch = Stopwatch.StartNew();
                await next();
                var path = context.Request.Path;
                var statusCode = context.Response.StatusCode;
                _logger.LogDebug($"Path='{path}', status={statusCode}, time={watch.Elapsed}");
            });
            //app.UseStaticFiles();

            // Add the middleware to the pipeline
            //app.UseMiddleware<MyCustomMiddleware>();

            //Or you can use
            //app.UseRequestMyCustomMiddleware();

            //Or you can use a branch
            app.Map("/Custom", (IApplicationBuilder branch) =>
            {
                branch.UseRequestMyCustomMiddleware();
            });
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
