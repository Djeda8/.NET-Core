using DemoFilters.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace DemoFilters.Controllers
{
    //[Authorize(Policy = "Family")]
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[Authorize(Roles ="admin")]
        //[Authorize(Policy = "Family")]
        public IActionResult About()
        {
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
