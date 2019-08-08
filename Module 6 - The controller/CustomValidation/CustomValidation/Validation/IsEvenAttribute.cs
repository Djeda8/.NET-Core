using System;
using System.ComponentModel.DataAnnotations;

namespace CustomValidation.Validation
{
    public class IsEvenAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int i = Convert.ToInt32(value);
            return i % 2 == 0;
        }
    }
}
