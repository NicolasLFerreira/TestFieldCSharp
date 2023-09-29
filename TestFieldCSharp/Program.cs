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
            //Matrix matrix = new(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            //Matrix matrix = new(3, 3, new(0, 10));

            Console.WriteLine(matrix);
            Console.WriteLine(matrix.InverseMatrix());

            //Console.WriteLine(matrix);
            //Console.WriteLine(matrix.DeterminantLarge());
            //Console.WriteLine(matrix.Transpose());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants().CheckboardSignInversion());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants().CheckboardSignInversion().ScalarMultiplication(1 / matrix.DeterminantLarge()));
        }
    }
}