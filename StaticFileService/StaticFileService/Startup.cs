using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StaticFileService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // To provide "browsing" functionalities
            services.AddDirectoryBrowser();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Provide the ability to specify default documents
            //app.UseDefaultFiles();
            // Or you can put the names of the default files
            app.UseDefaultFiles(new DefaultFilesOptions()
            {
                DefaultFileNames = new List<string>() { "test.html" }
            });

            // To process requests to static files
            app.UseStaticFiles(new StaticFileOptions()
            {
                // Allows you to enter logic just before sending the response to the client
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers
                       .Add("X-Copyright", "Copyright (C) JMA");
                }
            });

            // To provide "browsing" functionalities
            //app.UseDirectoryBrowser();

            // Or you can activate StaticFiles, DirectoryBrowser and DefaultFiles
            //app.UseFileServer(enableDirectoryBrowsing: true);

            app.UseFileServer(new FileServerOptions()
            {
                RequestPath = "/static",
                EnableDirectoryBrowsing = true
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
