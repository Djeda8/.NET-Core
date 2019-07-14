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

namespace LoggerForLogging2
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }
        private readonly ILogger _logger;

        public Startup(ILogger<Startup> logger, IHostingEnvironment env)
        {
            // IConfigurationroot instance
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            
            Configuration = builder.Build();

            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(Configuration);

            // Type access to the configuration
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            _logger.LogInformation("Before");

            using (_logger.BeginScope("Some name"))
            using (_logger.BeginScope(42))
            using (_logger.BeginScope("Formatted {WithValue}", 12345))
            using (_logger.BeginScope(new Dictionary<string, object> { ["ViaDictionary"] = 100 }))
            {
                _logger.LogInformation("Hello from the Index!");
                _logger.LogDebug("Hello is done");
            }

            _logger.LogInformation("After");

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
