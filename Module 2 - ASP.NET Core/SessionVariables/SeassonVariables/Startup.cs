using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SessionVariables
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddDistributedMemoryCache(); // Add services for caching in-memory
            // Add services state services
            services.AddSession(options =>
            {
                options.Cookie.Name = "MyAppSession";
                options.Cookie.Path = "/";
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet("visits", async (HttpContext context) =>
            {
                var newCount = context.Session.GetInt32("count").GetValueOrDefault() + 1;
                context.Session.SetInt32("count", newCount);
                await context.Response.WriteAsync($"Your visits: {newCount}");
            });

            routeBuilder.MapGet("reset", async (HttpContext context) =>
            {
                // context.Session.Clear();
                context.Session.Remove("count");
                await context.Response.WriteAsync($"Reset");
            });

            var router = routeBuilder.Build();
            app.UseRouter(router);
        }
    }
}
