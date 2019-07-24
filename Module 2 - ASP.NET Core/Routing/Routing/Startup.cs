using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Create the factory:
            var routeBuilder = new RouteBuilder(app);

            // Map the requests to the URL "/hello": https://localhost:44384/hello/Daniel
            routeBuilder.MapGet("hello/{name}", async context =>
            {
                var name = context.GetRouteValue("name").ToString();
                await context.Response.WriteAsync($"Hello {name}!");
            });

            // Build the IRoute and add the middleware to the pipeline
            var router = routeBuilder.Build();
            app.UseRouter(router);
        }
    }
}
