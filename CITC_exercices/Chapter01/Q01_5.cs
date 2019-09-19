using System;
using System.Text;

namespace CITC_exercices.Chapter01
{
    public class Q01_5 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter01 - Q01_5---------------");
            Console.WriteLine("Compress string" + Environment.NewLine);

            string test = "aabccccaaa";
            Console.WriteLine(test + " : " + Solution(test));

            Console.WriteLine();
        }

        private string Solution(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length;)
            {
                int sameLetterNumber = 1;
                int j = i + 1;
                while (j < s.Length && s[i] == s[j])
                {
                    sameLetterNumber++;
                    j++;
                }

                res += s[i];
                res += sameLetterNumber;

                i += sameLetterNumber;
            }

            return res.Length > s.Length ? s : res;
        }
    }
}