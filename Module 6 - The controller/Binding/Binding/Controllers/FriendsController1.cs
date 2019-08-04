using Binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{
    public class FriendsController1 : Controller
    {
        public IActionResult Show(Friend friend)
        {
            return Content($"{friend.Name} is {friend.Age} years old ");
        }
        [HttpPost]
        public IActionResult Update([Bind("Name", "Age", Prefix = "Friend")]Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return Content("Error getting friend");
            }

            return Content($"Update {friend.Name} is {friend.Age} years old ");
        }
    }
}
