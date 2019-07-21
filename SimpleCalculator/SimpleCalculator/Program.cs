using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace SimpleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
            {
                // Requires `using Microsoft.Extensions.Logging;`
                logging.AddConsole();
                logging.AddDebug();
                logging.AddFilter("System", LogLevel.None);
                logging.AddFilter("Microsoft", LogLevel.None);
                logging.AddFilter("SimpleCalculator", LogLevel.Trace);
            })
                .UseStartup<Startup>();
    }
}
