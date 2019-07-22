using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var name = context.User.Identity.Name;
                var body = $@"
                <h1>Home</h1>
                Hello, {name}!
                <a href='/logout'>Logout
                ";
                await PageUtils.SendPageAsync(context, "Home", body);
            }
        }

        // Si el usuario no está autenticado, redirigir a /login
        // En caso contrario, mostrar la página de inicio que incluya
        // el nombre del usuario y un link hacia /logout
    }
}
