using Binding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binding
{
    public class FriendBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var friend = bindingContext.Model as Friend;
            if (friend != null)
            {
                try
                {
                    friend.Name = bindingContext.ValueProvider.GetValue("Name").FirstValue;
                    friend.Age = Int32.Parse(bindingContext.ValueProvider.GetValue("Age").ToString());
                }
                catch (Exception)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
            return Task.CompletedTask;
        }
    }
}
