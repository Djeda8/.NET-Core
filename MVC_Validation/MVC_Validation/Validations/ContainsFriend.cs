using MVC_Validation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Validation.Validations
{
    public class ContainsAttribute : ValidationAttribute
    {
        private readonly string _subString;

        public ContainsAttribute(string subString)
        {
            _subString = subString;
        }

        public override bool IsValid(object value)
        {
            var str = value?.ToString();
            return str?.Contains(_subString) ?? false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, _subString);
        }
    }
}
