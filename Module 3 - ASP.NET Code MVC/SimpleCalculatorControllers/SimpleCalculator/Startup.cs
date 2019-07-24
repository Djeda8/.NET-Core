using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Services;

namespace SimpleCalculator
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(ILogger<Startup> logger)
        {
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICalculatorServices, CalculatorServices>();
            services.AddTransient<ICalculationEngine, CalculationEngine>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/error/show/{0}");
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error/show/500");
            }
            else
            {
                app.UseExceptionHandler("/error/show/500");
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
