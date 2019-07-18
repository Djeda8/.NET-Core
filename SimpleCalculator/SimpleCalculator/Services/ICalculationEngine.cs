using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Services
{
    public interface ICalculationEngine
    {
        int Add(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }
}
