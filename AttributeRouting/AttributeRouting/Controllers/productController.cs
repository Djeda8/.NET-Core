using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeRouting.Controllers
{
    [Route("[Controller]")]
    public class ProductsController : Controller
    {
        [Route("products/{productId:int}/{productTitle}")]
        public IActionResult Show(int productId, string productTitle)
        {
            return Content($"Product Id: {productId}, Title: {productTitle}");
        }

        //[Route("products/{category}/{product}")]
        //public IActionResult Show2(string category, string product)
        //{
        //    return Content($"Product category: {category}, Product: {product}");
        //}

        [Route("catalog/{category}")]
        [Route("browse/{category}")]
        public IActionResult Index(string category)
        {
            return Content($"Product category: {category}");
        }

        [Route("products/{category}/{product}", Name = "ProductsByCategory")]
        public IActionResult Show3(string category, string product)
        {
            return Content($"Product category: {category}, Product: {product}");
        }
        // This is the default URL, It doesn't add
        // aditional fragments to the route.
        // URL example: /products
        public IActionResult ShowAll()
        {
            return Content($"Show alls");
        }
    }
}
