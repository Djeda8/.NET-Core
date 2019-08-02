using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeRouting.Controllers
{
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        [Route("[action]/{a}/{b}")]
        public IActionResult Sum(int a, int b)
        {
            return Content($"{a}+{b}={a + b}");
        }

        [Route("[action]/product/{a}/{b?}")]
        public IActionResult Product(int a, int b = 1)
        {
            return Content($"{a}*{b}={a * b}");
        }
    }
}
