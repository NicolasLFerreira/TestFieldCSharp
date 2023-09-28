using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal static class RandomUtilities
    {
        public static string SpaceFormatting(string number, int positions)
        {
            StringBuilder s = new(positions);
            int start = positions - number.Length;

            for (int i = 0; i < start; i++)
            {
                s.Append(' ');
            }

            s.Append(number);

            return s.ToString();
        }

        public static int GetIntLength(double value)
        {
            return value.ToString().Length;
        }
    }
}
