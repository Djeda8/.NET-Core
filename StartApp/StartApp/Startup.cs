using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StartApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<MyContext>((serviceProvider, options) =>
                        options.UseSqlServer(connectionString)
                               .UseInternalServiceProvider(serviceProvider));
                        
            services.AddMvc();// Add the MVC framework services to the IoC container
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Here is the initialization code
            // Use 'app' to configure the pipeline and introduce the middlewares
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles(); // Return the content of static files requested.
            app.UseAuthentication(); // enables authentication capabilities.
            app.UseMvcWithDefaultRoute(); // Add MVC with a default route named 'default' and the following template: '{controller=Home}/{action=Index}/{id?}'.

            // Adds a finalizing middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
