using System;
using System.Collections.Generic;

namespace CITC_exercices.Chapter01
{
    public class Q01_1: IQuestion
    {
        // Determine if a string has all unique characters
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter01 - Q01_1---------------");
            Console.WriteLine("Determine if a string has all unique characters : " + Environment.NewLine);

            string[] words = {"abcdef", "abcdefa"};

            foreach (string w in words)
            {
                Console.WriteLine(w + " : " + Solution(w));
            }

            Console.WriteLine();
        }

        private bool Solution(string w)
        {
            Dictionary<char, bool> usedChars = new Dictionary<char, bool>();
            foreach (char c in w)
            {
                if (usedChars.ContainsKey(c))
                {
                    return false;
                }
                usedChars.Add(c, true);
            }

            return true;
        }
    }
}