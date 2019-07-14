using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace LoggerForLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        var env = hostingContext.HostingEnvironment;
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
                    // Requires `using Microsoft.Extensions.Logging;

                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
        logging.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
        logging.AddDebug();
        logging.AddEventSourceLogger();
    })
    .UseStartup<Startup>()
    .Build();

            webHost.Run();



            //var host = CreateWebHostBuilder(args).Build();

            //var logger = host.Services.GetRequiredService<ILogger<Program>>();
            ////logger.LogInformation("Seeded the database.");
            //try
            //{
            //    host.Run();
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // CreateDefaultBuilder, which adds the following logging providers:
            // Console
            // Debug
            // EventSource(starting in ASP.NET Core 2.2)
            // WebHost.CreateDefaultBuilder(args)

            var host = new WebHostBuilder()
               .UseKestrel() //add Kestrel as web server to the host
               .UseContentRoot(Directory.GetCurrentDirectory()) //Configure the the root directory
               .UseIISIntegration() // Configure the server to work as reverse server.
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   var env = hostingContext.HostingEnvironment;
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                             optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
               .ConfigureLogging((hostingContext, logging) =>
               {
                   // Requires `using Microsoft.Extensions.Logging;`
                   logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                   logging.AddConsole();
                   logging.AddDebug();
                   logging.AddEventSourceLogger();
               })
               .UseStartup<Startup>();

            return host;
        }
    }
}
