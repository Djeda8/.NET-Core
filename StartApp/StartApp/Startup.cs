using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StartApp
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
            // Here is the initialization code
            // Use 'app' to configure the pipeline and introduce the middlewares
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseErrorHandler("/html/errorpage.htm"); // Captures the errors and return the content of the static page "html / errorpage.htm"
            app.UseStaticFiles(); // Returns the content of static files requested.
            app.UseIdentity(); // Adds Identity Framework for managing user authentication.
            app.UseMvcWithDefaultRoute(); // Adds MVC with a default route named 'default' and the following template: '{controller=Home}/{action=Index}/{id?}'.

            // Adds a finalize middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
