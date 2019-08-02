using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSystem2.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        // Ruta: /Products/All
        [Route("All")]
        [Route("/")]
        public IActionResult Index()
        {
            var message = "ProductsController.Index()";
            return Content(message);
        }

        // Ruta: /Products/Lenovo-yoga
        [Route("{id}")]
        public IActionResult View(string id)
        {
            var message = string.Format("ProductsController.View('{0}')", id);
            return Content(message);
        }

        // Ruta: /Products/Category/Ultrabooks
        [Route("Category/{category:EndsWith(ERS)}")]
        public IActionResult ByCategory(string category)
        {
            var message = string.Format("ProductsController.ByCategory('{0}')", category);
            return Content(message);
        }
    }
}
