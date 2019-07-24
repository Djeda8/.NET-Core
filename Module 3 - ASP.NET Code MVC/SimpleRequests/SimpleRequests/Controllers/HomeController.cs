using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequests.Controllers
{
    public class HomeController : Controller
    {
        // Default controller with default action
        public IActionResult Index()
        {
            return Content($"Welcome to my home page!");
        }
    }
}
