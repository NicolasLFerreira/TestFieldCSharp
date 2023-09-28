using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class GCD
    {
        static void GCDTesting()
        {
            int a, b, n, range;

            for (int i = 20; i < 30; i++)
            {
                n = (int)(DateTimeOffset.Now.ToUnixTimeSeconds() % int.MaxValue);

                range = (n % (i) + i) * i;
                a = new Random().Next(range / i, range);
                b = new Random().Next(range / i, range);

                Console.WriteLine($"Integers: {a}, {b}");

                Console.WriteLine($"Normal: {GCDMain(a, b)}");
                Console.WriteLine($"Redux: {GCDRedux(a, b)}");
                Console.WriteLine($"OneLinerSizeCheck: {GCDOneLinerSizeCheck(a, b)}");
                Console.WriteLine($"OneLiner: {GCDOneLiner(a > b ? a : b, a < b ? a : b)}");
                Console.WriteLine($"NoRecursion: {GCDNoRecursion(a, b)}");
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            //Console.WriteLine(GCD(180, 288));
            //Console.WriteLine(GCD(108, 180));
            //Console.WriteLine(GCD(72, 108));
            //Console.WriteLine(GCD(36, 72));
        }

        static int GCDMain(int a, int b)
        {
            int greatest;
            int lowest;
            int fit;
            int equation;
            int rest;

            if (a > b)
            {
                greatest = a;
                lowest = b;
            }
            else
            {
                greatest = b;
                lowest = a;
            }

            rest = greatest % lowest;

            fit = (int)Math.Floor((decimal)(greatest / lowest));
            equation = lowest * (greatest / lowest >= 2 ? fit : 1) + rest;

            //Console.WriteLine($"{lowest} * {fit} = {fit * lowest}, + {rest} = {fit * lowest + greatest % lowest}");
            Console.WriteLine($"{greatest} = {lowest} * {fit} + {rest}");

            if (rest != 0)
            {
                return GCDMain(lowest, rest);
            }

            return equation / fit;
        }

        static int GCDRedux(int a, int b)
        {
            int greatest = a > b ? a : b;
            int lowest = a < b ? a : b;
            int rest = greatest % lowest;
            return rest == 0 ? lowest : GCDRedux(lowest, rest);
        }

        static int GCDOneLinerSizeCheck(int a, int b) =>
            (a > b ? a : b) % (a < b ? a : b) == 0 ? a < b ? a : b + (a > b ? a : b) % (a < b ? a : b) : GCDOneLinerSizeCheck(a < b ? a : b, (a > b ? a : b) % (a < b ? a : b));

        static int GCDOneLiner(int a, int b) =>
            a % b == 0 ? b + a % b : GCDOneLiner(b, a % b);

        static int GCDNoRecursion(int a, int b)
        {
            int greatest = a > b ? a : b;
            int lowest = a < b ? a : b;
            int rest;

            while (true)
            {
                rest = greatest % lowest;
                if (rest == 0) return lowest;
                greatest = lowest;
                lowest = rest;
            }
        }
    }
}
