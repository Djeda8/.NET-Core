using Microsoft.AspNetCore.Mvc;
using MVC_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Validation.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Create()
        {
            var newFriend = new Friend()
            {
                Name = "Default name",
                Age = 26,
                Address = new Address()
            };

            return View(newFriend);
        }
        [HttpPost]
        public IActionResult Create(Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return View(friend);
            }
            return Content($"Created: {friend.Name}");
        }
    }
}
