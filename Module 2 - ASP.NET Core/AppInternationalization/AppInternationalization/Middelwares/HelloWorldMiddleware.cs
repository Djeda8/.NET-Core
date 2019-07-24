using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Threading.Tasks;

namespace AppInternationalization.Middelwares
{
    public class HelloWorldMiddleware
    {
        private readonly IStringLocalizer<HelloWorldMiddleware> _loc;
        public HelloWorldMiddleware(RequestDelegate next, IStringLocalizer<HelloWorldMiddleware> loc)
        {
            _loc = loc;
        }

        public async Task Invoke(HttpContext context)
        {
            //var culture = CultureInfo.CurrentCulture.Name;
            //await context.Response.WriteAsync($"Hello world! Current culture: {culture}");
            var culture = CultureInfo.CurrentCulture.Name;
            var text = _loc["Message", culture];
            await context.Response.WriteAsync(text);
        }
    }
}
