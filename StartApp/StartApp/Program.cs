using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace StartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            //Return a IWebHostBuilder
            // use Kestrel as the web server
            // set the ContentRootPath to the result of GetCurrentDirectory()
            // load IConfiguration from 'appsettings.json' and 'appsettings.[EnvironmentName].json'
            // load IConfiguration from User Secrets when EnvironmentName is 'Development'
            // load IConfiguration from environment variables
            // load IConfiguration from supplied command line args
            // configure the ILoggerFactory to log to the console and debug output
            // enable IIS integration.
            //var host = WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>();

            //Return a IWebHost
            var host = new WebHostBuilder()
                .UseKestrel() //add Kestrel as web server to the host
                .UseContentRoot(Directory.GetCurrentDirectory()) //Configure the the root directory
                .UseIISIntegration() // Configure the server to work as reverse server.
                .UseStartup<Startup>(); // Inicate where is the initilization code.
                                        //.Build(); //Optional here the diference is that you returns an IWebHostBuilder or an IWebHost
        return host;
        }
    }
}