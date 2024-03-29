﻿

namespace AppSettings
{
    public class Startup
    {
        private readonly ILogger _logger;

        private IConfigurationRoot Configuration { get; }
        

        public Startup(ILogger<Startup> logger, IHostingEnvironment env)
        {
            _logger = logger;
            
            // IConfigurationroot instance
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddIniFile("otherfile.ini");
            // (the last win)

            Configuration = builder.Build();

            var title = Configuration["title"]; // "My application"
            var stringOption = Configuration["options:stringOption"]; // "Hello"

        }
               
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Access to application settings, Injection of dependencies
            services.AddSingleton<IConfigurationRoot>(Configuration);

            // Type access to the configuration
            services.AddOptions();
            services.Configure<MyAppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceCollection services)
        {
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

            app.Run(async ctx =>
            {
                // Request an IConfigurationRoot object to the IoC container
                //var config = ctx.RequestServices.GetService<IConfigurationRoot>();
                //var title = config["title"];
                //await ctx.Response.WriteAsync($"Title: {title}");

                // Type access to the configuration
                var options = ctx.RequestServices.GetService<IOptions<MyAppSettings>>();
                MyAppSettings settings = options.Value;
                var title = settings.Title;
                var stringOption = settings.Options.StringOption;
                await ctx.Response.WriteAsync($"Title: {title}, Options>StringOption: {stringOption}");
            });
        }
    }
}
