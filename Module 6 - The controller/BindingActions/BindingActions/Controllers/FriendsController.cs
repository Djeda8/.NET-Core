using BindingActions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingActions.Controllers
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
            if (!string.IsNullOrEmpty(friend.Name) && friend.Age >= 18)
            {
                return Content($"{friend.Name} is {friend.Age} years old /n" +
                $" Street: {friend.Address.Street} in {friend.Address.ZipCode} {friend.Address.City}");
            }
            if (string.IsNullOrEmpty(friend.Name))
            {
                ViewData["NameError"] = "Invalid name";
            }
            if (friend.Age < 18)
            {
                ViewData["AgeError"] = "Enter a valid age (>17)";
            }

            
            return View(friend);
        }
    }
}
