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
            services.AddTransient<IAdder, BasicCalculator>();
            services.AddTransient<IOperationFormatter, OperationFormatter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAdder adder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            Console.WriteLine("3");


            // Hello world middleware
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path == "/hello-world")
                {
                    // Procesa la petición y no permite la ejecución de middlewares posteriores
                    await ctx.Response.WriteAsync("Hello, world!");
                }
                else
                {
                    // Pasa el control al siguiente middleware
                    await next();
                }
            });

            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path.ToString().StartsWith("/hello"))
                {
                    // Procesa la petición y no permite la ejecución de otros middlewares
                    await ctx.Response.WriteAsync("Hello, user!");
                }
                else
                {
                    // Pasa la petición al siguiente middleware
                    await next();
                }
            });

            app.Run(async (context) =>
            {
                if (context.Request.Path == "/add")
                {
                    int a = 0, b = 0;
                    int.TryParse(context.Request.Query["a"], out a);
                    int.TryParse(context.Request.Query["b"], out b);

                    //var adder = app.ApplicationServices.GetService<IAdder>();
                    await context.Response.WriteAsync(adder.Add(a, b));
                }
                else
                {
                    await context.Response.WriteAsync($"Try again!");
                }
            });

            // Request Info middleware
            app.Run(async ctx =>
            {
                await ctx.Response.WriteAsync($"Path requested: {ctx.Request.Path}");
            });

            //app.Run(async (context) =>
            //{
            //    var msg = $"Current environment: {env.EnvironmentName}";
            //    await context.Response.WriteAsync(msg);
            //});

            //if (env.IsDevelopment())
            //{
            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Development environment");
            //    });
            //}
            //else
            //{
            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("No development environment");
            //    });
            //}
        }
    }
}
