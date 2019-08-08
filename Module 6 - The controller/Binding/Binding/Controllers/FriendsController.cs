using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Binding.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Show(Friend friend)
        {
            return Content($"{friend.Name} is {friend.Age} years old ");
        }
        [HttpPost]
        //public IActionResult Update([ModelBinder(BinderType = typeof(FriendBinder))] Friend friend)
        //public IActionResult Update([Bind("Name", "Age", Prefix = "Friend")]Friend friend)
        //{
            // First option
            //if (!ModelState.IsValid)
            //{
            //    return Content("Error getting friend");
            //}
            //return Content($"Update {friend.Name} is {friend.Age} years old ");
        //}

        public async Task<IActionResult> Update(/*int id*/)
        {
            var friend = new Friend();// _friendsRepository.GetById(id);
            if (friend != null)
            {
                if (await TryUpdateModelAsync(friend, "friend", f => f.Name, f => f.Age))
                {
                    //await _friendsRepository.SaveChangesAsync();
                    return Content("Updated!");
                }
                return Content("Error binding friend");
            }
            return Content("Friend not found");

        }
    }
}
