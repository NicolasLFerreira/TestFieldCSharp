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
            Matrix matrix1 = new(new decimal[,] { { 1, 2, 3 }, { 0, 1, 4 }, { 5, 6, 0 } });
            Matrix matrix2 = new(new decimal[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix matrix3 = new(3, 3, new(0, 10));
            Matrix matrix4 = new(4, 4, new(0, 10));
            Matrix matrix5 = new(new decimal[,] { { 1, 2 }, { 3, 4 } });


            Console.WriteLine(matrix4);
            Console.WriteLine(matrix4.InverseMatrix());
            Console.WriteLine(matrix4.Multiplication(matrix4.InverseMatrix()));


            //Console.WriteLine(matrix);
            //Console.WriteLine(matrix.DeterminantLarge());
            //Console.WriteLine(matrix.Transpose());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants().CheckboardSignInversion());
            //Console.WriteLine(matrix.Transpose().MatrixOfDeterminants().CheckboardSignInversion().ScalarMultiplication(1 / matrix.DeterminantLarge()));
        }

        static void MatrixTesting(Matrix matrix)
        {
            Console.WriteLine(matrix);
            Console.WriteLine(matrix.InverseMatrix());
        }
    }
}