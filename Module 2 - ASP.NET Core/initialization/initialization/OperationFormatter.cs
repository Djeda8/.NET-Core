﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace initialization
{
    public class OperationFormatter : IOperationFormatter
    {
        public string Format(int a, string operation, int b, int result)
        {
            return $"{a} {operation} {b} = {result}";
        }
    }
}
