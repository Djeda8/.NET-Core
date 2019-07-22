using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (String.Equals("Djeda", username))
            {
                context.Response.Redirect("/home");
            }


            // b) Si las credenciales son correctas, establecemos la cookie y redirigimos a /home 
        }
    }
}
