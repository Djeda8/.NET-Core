using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RoutingAuthentication.Handlers
{
    public class LoginHandlers
    {
        public static async Task GetLoginPageAsync(HttpContext context)
        {
            var body = @"
            <h1>Login</h1>
            <form method='post' action='/login'>
                Username:  <input type='text' name='username'><br>
                Password: <input type='password' name='password'><br>
                <hr>
                <input type='submit' value='Login' >
            </form>
        ";
            await PageUtils.SendPageAsync(context, "Login", body);
        }

        public static async Task DoLoginAsync(HttpContext context)
        {
            // Obtener los datos del formulario y comprobar credenciales.
            var username = context.Request.Form["username"].ToString();
            var password = context.Request.Form["password"].ToString();

            // a) Si las credenciales son incorrectas, mostramos una página de error
            if (!String.Equals("Djeda", username)&&!String.Equals("mce10j",password))
            {
                var body = @"
                   <h1>Invalid credentials</h1>
                   <p>Please <a href='/login'>Try again</a>.</p> 
                           ";
                await PageUtils.SendPageAsync(context, "Invalid credentials", body);
            }
            else
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Superadmin"));
                var principal = new ClaimsPrincipal(identity);

                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = true // make it persistent between sessions different from the browser
                    });

                context.Response.Redirect("/home");
            }


            // b) Si las credenciales son correctas, establecemos la cookie y redirigimos a /home 
        }

        public static async Task DoLogoutAsync(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await context.Response.WriteAsync($"Logged out!");
        }
    }
}
