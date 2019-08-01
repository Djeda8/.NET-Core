using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConventionRouting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //The same with UseMvcWithDefaultRoute
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "viewpost", // Unique name for the route
                    template: "view/{slug}", // template for the route
                    defaults: new { controller = "Blog", action = "ViewPost" }
                    );
                routes.MapRoute(
                    name: "archive",
                    template: "{controller}/{action}/{year}/{month}"
                    );
                routes.MapRoute(
                    name: "default1",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
                // Parameter name
                routes.MapRoute(
                name: "ProductsByCategory",  //Name for generate routes
                template: "products/{category}",
                defaults: new
                {
                    controller = "Products",
                    action = "ByCategory"
                });
                // Template parameter
                routes.MapRoute(
                name: "example1",
                template: "catalog/{family}/{subfamily}/{id}" //catalog/computers/netbooks/lenovo-yoga
                );
                routes.MapRoute(
                    name: "example2",
                    template: "/catalog/browse/{currentPage?}" //with optional parameter
                    );
                routes.MapRoute(
                    name: "example3",
                    template: "/catalog/browse/{currentPage=1}" //with default value
                    );
                routes.MapRoute(
                    name: "example4",
                    template: "/catalog/{*data}" // in /catalog/it/seems/it/is/raining?when=now where data = it/seems/it/is/raining?when=now
                    );
                // Default parameters
                routes.MapRoute(
               name: "Default2",
               template: "{controller}/{action}/{id?}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index"
               });
                routes.MapRoute(
                   name: "ProductsByCategory",
                   template: "browse/{categoryName}", // Must indicate the controller & action default
                   defaults: new
                   {
                       controller = "Products",
                       action = "Category",
                       categoryName = "all"
                   });
                // Constraint parameters
                routes.MapRoute(
                name: "Product",
                template: "Products/{productId}",
                defaults: new
                {
                    controller = "products",
                    action = "details"
                },
                constraints: new { productId = @"\d{1,5}" } // Regular expression
                );

                routes.MapRoute(
                    name: "Product1",
                    template: "Products/{productId}",
                    defaults: new
                    {
                        controller = "products",
                        action = "details"
                    },
                    constraints: new { productId = new EvenNumberConstraint() }
                    );


                routes.MapRoute(
                    name: "Product2",
                    template: "users/{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "users",
                        action = "home"
                    },
                    constraints: new { auth = new UserIsAuthenticatedConstraint() }
                    );
                // dataTokens parameter
                routes.MapRoute(
                name: "DataTokenTest",
                template: "datatoken",
                defaults: new
                {
                    controller = "Test",
                    action = "DataToken"
                },
                constraints: null,
                dataTokens: new { Message = "Hello!" }
                );
            });
        }
    }
}
