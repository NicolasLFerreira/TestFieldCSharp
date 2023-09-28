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
            Matrix matrix = new(new double[,] { { 1, 2, 3 }, { 0, 1, 4 }, { 5, 6, 0 } });

            Console.WriteLine(matrix);
            Console.WriteLine(matrix.Transpose());
            Console.WriteLine(matrix.Transpose().MatrixOfDeterminants());
            Console.WriteLine(matrix.Transpose().MatrixOfDeterminants().CheckboardSignInversion());
        }
    }
}