using System;
using System.Linq;
using System.IO;
using System.IO.Enumeration;
using System.Text;

namespace TestFieldCSharp
{
    class Program
    {
        delegate int Operation(int n1, int n2);

        static void Main(string[] args)
        {
            Matrix matrix1 = new(3, 3, new Tuple<int, int>(0, 10));
            Matrix matrix2 = new(3, 7, new Tuple<int, int>(5, 15));

            Console.WriteLine(matrix2);
            Console.WriteLine(matrix2.CheckboardSignInversion());
        }
    }
}