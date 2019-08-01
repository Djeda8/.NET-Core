using Microsoft.AspNetCore.Mvc;

namespace InlineConstraints.Controllers
{
    public class TestController : Controller
    {
        [Route("/test/{data:alpha:length(3)?}")]
        public ActionResult Test(string data)
        {
            return Content($"data : {data}");
        }

        [Route("add-even/{n:even}")]
        public ActionResult AddEvenNumber(int n)
        {
            return Content($"n : {n}");
        }
    }
}
