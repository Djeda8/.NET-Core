using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace AppInternationalization.Middelwares
{
    public class SetCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public SetCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/es"))
            {
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo("es-ES");
            }
            await _next(context);
        }
    }
}
