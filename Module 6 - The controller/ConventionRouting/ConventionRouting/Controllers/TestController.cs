using Microsoft.AspNetCore.Mvc;

namespace ConventionRouting.Controllers
{
    public class TestController : Controller
    {
        public IActionResult DataToken()
        {
            var message = RouteData.DataTokens["message"]?.ToString()
                          ?? "No data token";
            return Content(message);
        }
    }
}
