using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorsDebugging
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // To capture responses without content with 4xx and 5xx HTTP codes
            //app.UseStatusCodePages();
            //app.UseStatusCodePages("text/plain",  "Just another HTTP {0} error :)"); // {0} will be replaced by the status code


            // Or using custom logic:
            //app.UseStatusCodePages(async statusCodeContext =>
            //{
            //    var httpContext = statusCodeContext.HttpContext;
            //    var statusCode = httpContext.Response.StatusCode;
            //    if (statusCode == 404)
            //    {
            //        httpContext.Response.Redirect("/error404.html");
            //    }
            //    else
            //    {
            //        await httpContext.Response.WriteAsync($"Error {statusCode}");
            //    }
            //});

            // or to capture the errors and return the client a redirect
            //app.UseStatusCodePagesWithRedirects("/error{0}.html");


            // or we can use to indicate that you must capture the errors and generate an internal request
            app.UseStatusCodePagesWithReExecute("/error404");


            // To show a welcome page
            app.UseWelcomePage("/test");


            //// or simply we can capture the error responses
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/friendlyError500.html");
            //}

            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path == "/error404")
                {
                    var feature = ctx.Features.Get<IStatusCodeReExecuteFeature>();
                    var path = feature.OriginalPath;
                    await ctx.Response.WriteAsync($"Path not found: {path}");
                }
                else
                {
                    await next();
                }
            });

            //app.UseStaticFiles(); // Allows to return static files

            //app.Run(async (context) =>
            //{
            //    if (context.Request.Path == "/boom")
            //        throw new InvalidOperationException("Invalid operation");

            //    await context.Response.WriteAsync("Hello, world!");
            //});
        }
    }
}
