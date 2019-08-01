using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingDemo.Controllers
{
    [Route("[controller]/[action]/{a}/{b?}")]
    public class CalcController : Controller
    {
        public IActionResult Sum(int a, int b=10)
        {
            return Content($"{a}+{b}={a + b}");
        }
        public IActionResult Product(int a, int b = 1)
        {
            return Content($"{a}*{b}={a * b}");
        }
    }
}
