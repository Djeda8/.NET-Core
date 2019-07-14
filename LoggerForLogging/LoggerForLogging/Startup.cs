using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggerForLogging
{
    public class Startup
    {
        private readonly ILogger _logger;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot Configuration { get; }

        public Startup(ILogger<Startup> logger, IHostingEnvironment env)
        {
            // Now is better to use that
            _logger = logger;

            // IConfigurationroot instance
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            // (the last win)

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceCollection services)
        {
            // Type access to the configuration
            services.AddSingleton<IConfigurationRoot>(Configuration);

            // We can use that
            //ILogger logger1 = loggerFactory.CreateLogger<Startup>();
            //ILogger logger2 = loggerFactory.CreateLogger("Startup");
            //logger1.LogInformation("Application starting1");
            //logger2.LogInformation("Application starting2");

            // Or we can use that, I prefer that
            _logger.LogInformation("Application starting3");
            _logger.LogInformation("The app is starting at {0:t}", DateTime.Now);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
