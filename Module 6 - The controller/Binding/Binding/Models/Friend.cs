using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binding.Models
{
    //[ModelBinder(typeof(FriendBinder))]
    [BindRequired]
    public class Friend
    {
        [BindRequired]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
