using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllerTempData.Models;

namespace ControllerTempData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            TempData["Message"] = "Hi, I'm here!";
            TempData.Keep("Message");
            //return RedirectToAction("ShowMessage");
            return View();
        }

        public IActionResult ShowMessage()
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
