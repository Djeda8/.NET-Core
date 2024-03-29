﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Middlewares;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/error/show/{0}");
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error/show/500");
                app.UseCustomErrorPages();
            } else
            {
                app.UseExceptionHandler("/error/show/500");
                app.UseCustomErrorPages();
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseCalculator("/calc");
        }
    }
}
