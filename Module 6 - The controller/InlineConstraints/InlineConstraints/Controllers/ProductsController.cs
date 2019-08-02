using Microsoft.AspNetCore.Mvc;

namespace InlineConstraints.Controllers
{
    public class ProductsController : Controller
    {
        [Route("product/edit/{id:int}")]
        public ActionResult GetProductById(int id)
        {
            return Content($"Product id: {id}");
        }
    }
}
