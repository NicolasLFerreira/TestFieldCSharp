using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Factorial
    {
        static double number = 1;
        static int precision = 3;

        static double Calculate(double input, int iteration)
        {
            if (iteration <= precision)
            {
                return Calculate((Math.Pow(input, iteration + 2) / FactorialRecursion(iteration + 2)), iteration);
            }
            return number;
        }

        static double FactorialRecursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * FactorialRecursion(number - 1);
        }
    }
}
