using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class DelegateTesting
    {
        public delegate int Operation(int n1, int n2);

        public static int Sum(int n1, int n2) => n1 + n2;
        public static int Sub(int n1, int n2) => n1 - n2;
        public static int Mult(int n1, int n2) => n1 * n2;
        public static int Div(int n1, int n2) => n1 / n2;

        public static void Test()
        {
            List<Operation> operations = new List<Operation>()
            {
                Sum, Sub, Mult, Div
            };

            for (int i = 0; i < operations.Count; i++)
            {
                Operation oper = operations[i];
                Console.WriteLine(oper(3, 3));
            }
        }
    }
}
