using System;
using System.Linq;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Numerics;
using System.Net.Http.Headers;
using System.Globalization;
using System.Collections.Concurrent;

namespace TestFieldCSharp
{
    class Program
    {
        public static bool abc(string s1, string s2)
        {
            int[] sc1 = new int[26];
            int[] sc2 = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {

            }

            return true;
        }

        public static bool IsAnnagram(string s1, string s2)
        {
            int[] sc1 = new int[26];
            int[] sc2 = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                sc1[s1[i] - 97]++;
                sc2[s2[i] - 97]++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (sc1[i] != sc2[i]) return false;
            }
            return true;
        }

        public string MapToByte(char s)
        {
            string a = Convert.ToString((byte)s);
            if ((byte)s < 100)
            {
                return '0' + a;
            }
            return a;
        }

        public static bool IsPalindrome(string word)
        {

            // 0 1 2 3 4 

            for (int left = 0, right = word.Length - 1; left < Math.Ceiling(word.Length / 2d); left++, right--)
            {
                if (word[left] != word[right]) return false;
            }

            return true;
        }

        struct WeightValue
        {
            public int Value { get; set; }
            public int Weight { get; set; }
        }

        // 20 - 80 = 100
        // 100 / 100 = 1
        // 1*20 = 20, 1*80 = 80

        // 20 - 30 = 50
        // 100 / 50 = 2
        // 2*20 = 40
        // 2*30 = 60
        // 100

        // 60 - 120 = 180
        // 100 / 180 = 5/9
        // 5/9*60 = 33.33333
        // 5/9*120 = 66.66666
        // total = 100

        static void Main()
        {

        }

        static void Main4()
        {
            return;
            List<(int, char)> output = [];

            string input = "a-1";

            int anchor = 0;
            char? current = null;

            for (int pointer = 0; pointer < input.Length; pointer++)
            {
                current ??= input[anchor];

                if (pointer + 1 < input.Length && input[pointer + 1] == current) continue;

                output.Add((pointer + 1 - anchor, (char)current));
                current = null;
                anchor = pointer + 1;
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item}");
            }

            return;
            WeightValue[] wv =
                [
                  new() { Value = 30, Weight = 234 },
                  new() { Value = 30, Weight = 699 },
                ];

            int tw = 0;

            foreach (var item in wv)
            {
                tw += item.Weight;
            }

            double factor = 100d / tw;

            double[] normalisedWeights = new double[2];

            for (int i = 0; i < 2; i++)
            {
                normalisedWeights[i] = factor * wv[i].Weight;
            }

            foreach (var item in normalisedWeights)
            {
                Console.WriteLine(item);
            }

            return;

            string name = "nicolas";
            uint bitmask = 0;

            for (int i = 0; i < name.Length; i++)
            {
                bitmask |= 1u << name[i] - 97;
            }

            bitmask |= 1u << 31;

            Console.WriteLine(Convert.ToString(bitmask, 2));

            Console.Write("      ");
            for (char i = 'z'; i >= 'a'; i--)
            {
                Console.Write(i);
            }

            Console.WriteLine();

            for (int i = 0; i < 32; i++)
            {
                Console.WriteLine($"{(char)(97 + i)} -> {(((bitmask & (1u << i)) == 0) ? 0 : 1)}");
            }

            return;
            string s1 = "nicolas";
            string s2 = "casinlo";

            Console.WriteLine(IsAnnagram(s1, s2));

            return;
            string word = "abbceee";
            int variance = 0;

            Dictionary<char, int> occurrence = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!occurrence.ContainsKey(word[i])) occurrence.Add(word[i], 1);
                else occurrence[word[i]]++;
            }

            foreach (KeyValuePair<char, int> kvp in occurrence)
            {
                variance += kvp.Value - variance;
            }

            Console.WriteLine(variance);

            foreach (char item in word)
            {
                Console.WriteLine($"{item} -> {occurrence[item]}");
            }
        }

        static void Main3(string[] args)
        {
            TicTacToe t = new();

            t.GameLoop();
        }

        static async Task Main2(string[] args)
        {

            await TaskTest();
            await TaskTest2();
        }

        public static async Task TaskTest()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }
        public static async Task TaskTest2()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("[]");
                }
            });
        }
    }
}
