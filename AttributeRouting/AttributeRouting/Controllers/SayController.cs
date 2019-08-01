using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeRouting.Controllers
{
    public class SayController : Controller
    {
        [Route("hello")]
        public IActionResult Hello()
        {
            return Content("Hello!");
        }
    }
}
