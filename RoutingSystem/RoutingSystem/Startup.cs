using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingSystem
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "FriendsByName",
                   template: "Products/Category/{category}",
                   defaults: new
                   {
                       controller = "Products",
                       action = "ByCategory"
                   });

                routes.MapRoute(
                    name: "FriendsByName",
                    template: "Products/All",
                    defaults: new
                    {
                        controller = "Products",
                        action = "index"
                    });

                routes.MapRoute(
                    name: "FriendsByName",
                    template: "Products/{id}",
                    defaults: new
                    {
                        controller = "Products",
                        action = "View"
                    });

                routes.MapRoute(
                    name: "FriendsByName",
                    template: "Friends/View/{name}",
                    defaults: new
                    {
                        controller = "friends",
                        action = "view"
                    });

                routes.MapRoute(
                    name: "FriendsByName",
                    template: "Delete/Friends/{id}",
                    defaults: new
                    {
                        controller = "friends",
                        action = "Delete"
                    });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
