using System;
using System.Text;

namespace CITC_exercices.Chapter01
{
    public class Q01_4 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter01 - Q01_4---------------");
            Console.WriteLine("Replace spaces in string by %20" + Environment.NewLine);

            char[] test = "Hi, my name is oli        ".ToCharArray();
                        //"Hi,%20my%20name%20is%20oli"
    
            Console.WriteLine("Hi, my name is oli        " + " : " + Solution(test, 18));

            Console.WriteLine();
        }

        private string Solution(char[] s, int size)
        {
            // Assuming we dont know the size of s (s.Length)....
            int whiteSpaces = 0;
            for (int i = 0; i < size; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    whiteSpaces++;
                }
            }

            // If we know the size of s : newSize = s.Length...
            // whiteSpaces * 2 because assuming we have 2 whitespaces in string, there is going to be 4 more at the end
            int newSize = size + whiteSpaces * 2;

            for (int i = size - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    s[newSize - 1] = '0';
                    s[newSize - 2] = '2';
                    s[newSize - 3] = '%';
                    newSize -= 3;
                }
                else
                {
                    s[newSize - 1] = s[i];
                    newSize--;
                }
            }

            return new string(s);
        }
    }
}