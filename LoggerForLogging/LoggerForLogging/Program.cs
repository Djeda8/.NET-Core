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

namespace LoggerForLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("Seeded the database.");
            host.Run();
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
