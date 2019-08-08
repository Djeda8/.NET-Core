using CustomValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomValidation.Models
{
    [IsValidFriend]
    public class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [IsEven]
        public int Age { get; set; }
        public string Description { get; set; }
    }
}
