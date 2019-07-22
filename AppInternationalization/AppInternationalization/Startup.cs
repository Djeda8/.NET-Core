using AppInternationalization.Middelwares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AppInternationalization
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Force a culture by default
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Default an supported Cultures
            var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                };
            var locOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-ES"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            // Culture provider from the query string
            var queryStringProvider = locOptions.RequestCultureProviders
                            .OfType<QueryStringRequestCultureProvider>()
                            .FirstOrDefault();
            
            // Properties of the provider
            if (queryStringProvider != null)
            {
                queryStringProvider.QueryStringKey = "lang";
                queryStringProvider.UIQueryStringKey = "ui-lang";
            }

            // Routing de ASP.NET Core to change the culture
            // Culture provider from cookies
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet("culture/{culture}", async context =>
            {
                var culture = context.GetRouteValue("culture").ToString();
                context.Response.Cookies.Append(
                    key: CookieRequestCultureProvider.DefaultCookieName,
                    value: CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    options: new CookieOptions() { Expires = DateTimeOffset.MaxValue }
                );
                await context.Response.WriteAsync("Culture set to: " + culture);
            });

            var router = routeBuilder.Build();

            // Remove culture provider
            var acceptHeadersProvider = locOptions.RequestCultureProviders
                .OfType<AcceptLanguageHeaderRequestCultureProvider>()
                .FirstOrDefault();
            locOptions.RequestCultureProviders.Remove(acceptHeadersProvider);

            // Add a custom request culture
            locOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(ctx =>
            {
                var host = ctx.Request.Host.Host.ToLower();
                if (host.StartsWith("es."))
                    return Task.FromResult(new ProviderCultureResult("es-ES"));
                return Task.FromResult((ProviderCultureResult)null);
            }));

            app.UseRouter(router);

            app.UseRequestLocalization(locOptions);

            app.UseMiddleware<SetCultureMiddleware>();

            app.UseMiddleware<HelloWorldMiddleware>();
        }
    }
}
