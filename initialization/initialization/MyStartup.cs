using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace initialization
{
    public class MyStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("2");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            Console.WriteLine("3");

            //app.Run(async (context) =>
            //{
            //    var msg = $"Current environment: {env.EnvironmentName}";
            //    await context.Response.WriteAsync(msg);
            //});

            if (env.IsDevelopment())
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Development environment");
                });
            }
            else
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("No development environment");
                });
            }
        }
    }
}
