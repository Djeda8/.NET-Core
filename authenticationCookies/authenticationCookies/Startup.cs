using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace authenticationCookies
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "Auth";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/users/denied";
                    options.LoginPath = "/users/login";
                });
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet("login/{name}/{email}", async (HttpContext context) =>
            {
                var name = context.GetRouteValue("name").ToString();
                var email = context.GetRouteValue("email").ToString();

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                identity.AddClaim(new Claim(ClaimTypes.Email, email));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Superadmin"));
                var principal = new ClaimsPrincipal(identity);

                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                    new AuthenticationProperties()
                    {
                        IsPersistent = true // make it persistent between sessions different from the browser
                    });
                              
                await context.Response.WriteAsync("Logged in!");
            });

            routeBuilder.MapGet("private", async (HttpContext context) =>
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    await context.Response.WriteAsync($"Not authorized");
                }
                else
                {
                    var name = context.User.Identity.Name;
                    var email = context.User.Claims
                                       .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                    var roles = string.Join(", ", context.User.Claims
                                                      .Where(c => c.Type == ClaimTypes.Role)
                                                      .Select(c => c.Value));
                    await context.Response.WriteAsync($"Logged in {name}, email: {email}, roles: {roles}");
                }
            });

            routeBuilder.MapGet("logout", async context =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await context.Response.WriteAsync($"Logged out!");
            });

            var router = routeBuilder.Build();
            app.UseRouter(router);
        }
    }
}
