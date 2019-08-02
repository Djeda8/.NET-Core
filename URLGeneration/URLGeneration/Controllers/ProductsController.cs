using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLGeneration.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult GetLink()
        {
            // We Obtein /Products/ByCategory?category=netbooks
            //var url = Url.Action("ByCategory", "Products", new { category = "netbooks" });
            //var url = Url.RouteUrl("ProductsByCategory", new { category = "netbooks" });

            var urlContext = new UrlRouteContext()
            {
                Host = "myserver.com:8080",
                Fragment = "target",
                Protocol = "https",
                RouteName = "ProductsByCategory",
                Values = new { category = "netbooks" }
            };

            // We obtein https://myserver.com:8080/products/category/netbooks#target
            //var url = Url.RouteUrl(urlContext);

            // We obtein https://localhost:44300/products/category/netbooks
            var url = Url.Link("ProductsByCategory", new { category = "netbooks" });

            
            return Content($"ProductsController.GetLink(): {url}");
        }

        public IActionResult ByCategory(string category)
        {
            return Content($"Category: {category}");
        }

    }
}
 