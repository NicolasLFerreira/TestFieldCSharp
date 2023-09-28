using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Factors
    {
        static void EntryPoint()
        {
            int factors;
            List<int> hundreds = new();
            for (int i = 1; i < 5000; i++)
            {
                factors = MostFactorsUnder(i);
                if ((double)((100.0 / i) * factors) == 100) hundreds.Add(i);
            }

            foreach (var item in hundreds)
            {
                Console.WriteLine(item);
            }

            //int factors;
            //for (int i = 1; i < 1000; i++)
            //{
            //    factors = MostFactorsUnder(i);
            //    Console.WriteLine($"{i}: {factors}, {(double)((100.0/i)*factors)}%");
            //}

            //List<int> factors = FactorCalculator(1000);

            //foreach (int item in factors)
            //{
            //    Console.WriteLine(item);
            //}


            return;
            string input = Console.ReadLine() ?? "";

            Console.WriteLine(input.Count());

            return;
            Directory.SetCurrentDirectory(@"C:\Users\nicol\Downloads\Images");
            List<string> files = new(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));

            Console.WriteLine(files.Count);

            FileInfo f;

            for (int i = 0; i < files.Capacity; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(files[i]);
                f = new FileInfo(files[i]);

                f.MoveTo($"{i}.jpg");
            }

            return;

            //int a = 0b1101;
            //int b = 0b1010;

            //Console.WriteLine($"{a}, {b}, {a ^ b}");
            //Console.WriteLine($"{Convert.ToString(a, 2)}, {Convert.ToString(b, 2)}, {Convert.ToString(a ^ b, 2)}");

            //List<Operation> operations = new()
            //{
            //    new      Operation((int n1, int n2) => n1 + n2),
            //    new Operation((int n1, int n2) => n1 * n2)
            //};

            //for (int i = 0; i < operations.Count; i++)
            //{
            //    Console.WriteLine(operations[i](1, 2));
            //}
        }

        // Keeping these here for showcasing the power of refactoring

        public static List<int> FactorCalculator(int number)
        {
            List<int> factors = new();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0) factors.Add(i);
            }

            return factors;
        }

        public static int MostFactorsUnder(int number)
        {
            int currentFactors, currentNum = 0, max = 0;

            for (int i = 0; i <= number; i++)
            {
                currentFactors = FactorCalculator(i).Count;
                if (currentFactors > max)
                {
                    max = currentFactors;
                    currentNum = i;
                }
            }

            return currentNum;
        }
    }
}
