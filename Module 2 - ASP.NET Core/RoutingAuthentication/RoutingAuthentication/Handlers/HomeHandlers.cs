using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RoutingAuthentication.Handlers
{
    public class HomeHandlers
    {
        public static async Task GetHomePageAsync(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/login");
            }
            else
            {
                var cache = context.RequestServices.GetService<IDistributedCache>();
                var cacheTotalVisits = await cache.GetStringAsync("TotalVisits") ?? "0";
                var totalVisits = Convert.ToInt32(cacheTotalVisits) + 1;
                var userVisits = context.Session.GetInt32("UserVisits").GetValueOrDefault() + 1;

                var name = context.User.Identity.Name;
                var body = $@"
                <h1>Home</h1>
                Hello, {name}!
                <p>Your visits: {userVisits}. Total visits: {totalVisits}.</p>
                <a href='/logout'>Logout
                ";

                await cache.SetStringAsync("TotalVisits", totalVisits.ToString());
                context.Session.SetInt32("UserVisits", userVisits);

                await PageUtils.SendPageAsync(context, "Home", body);
            }
        }

        // Si el usuario no está autenticado, redirigir a /login
        // En caso contrario, mostrar la página de inicio que incluya
        // el nombre del usuario y un link hacia /logout
    }
}
