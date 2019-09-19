using System;
using System.Collections.Generic;

namespace CITC_exercices.Chapter01
{
    public class Q01_3 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter01 - Q01_3---------------");
            Console.WriteLine("Determine if 2 strings are are a permutation of each other" + Environment.NewLine);

            Tuple<string, string> a = new Tuple<string, string>("abcdef", "abcdefg" );
            Tuple<string, string> b = new Tuple<string, string>("abcdef", "fedcba" );
            Tuple<string, string>[] pairs = {a, b};

            foreach (Tuple<string, string> pair in pairs)
            {
                Console.WriteLine(pair.Item1 + ", " + pair.Item2 + " : " + Solution(pair.Item1, pair.Item2));
            }

            Console.WriteLine();
        }

        private bool Solution(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            Dictionary<char, int> d = new Dictionary<char, int>();

            foreach (char c in a)
            {
                if (d.ContainsKey(c))
                {
                    d[c]++;
                }
                else
                {
                    d.Add(c, 1);
                }
            }

            foreach (char c in b)
            {
                if (--d[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}