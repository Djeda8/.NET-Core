using CustomValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomValidation.Validation
{
    public class IsValidFriend : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var friend = value as Friend;
            return friend != null && friend.Name.StartsWith("A") && friend.Age >= 18;
        }
    }
}
