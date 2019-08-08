using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllerViewBag.Models;

namespace ControllerViewBag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Friend friend = new Friend()
            {
                Name="Daniel",
                Phone="620 59 47 65"
            };

            if (friend == null)
                return View("error");

            ViewBag.Date = DateTime.Now;
            ViewBag.Friend = friend;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
