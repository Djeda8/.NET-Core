using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLGeneration.Controllers
{
    public class TestController : Controller
    {
        public IActionResult GetLink()
        {
            var link = Url.Action("Privacy", "Home");
            // Resultado: "/home/about" (usando la ruta por defecto)
            return Content($"TestController.GetLink(): {link}");
        }
    }
}
