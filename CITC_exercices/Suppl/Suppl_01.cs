using System;
using System.Collections.Generic;
using System.Linq;

namespace CITC_exercices.Suppl
{
    public class Suppl_01 : IQuestion
    {
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Suppl - Suppl_01---------------");
            Console.WriteLine("Write function that computes minimum unused value > Min and < Max of the array. A negative value in the array marks the end of the list of values." + Environment.NewLine);

            int[] array = {8, 9, 87, 30, 145, 6, 241, 245, 5, 7, 110, -1};   //Output should be 10

            string print = "{ ";
            foreach (int a in array)
            {
                print += a + ", ";
            }

            print += "} : " + Solution(array);

            Console.WriteLine(print);
            Console.WriteLine();
        }

        private int Solution(int[] array)
        {
            int min = 1000;
            int max = 0;

            foreach (int a in array)
            {
                if (a < 0) break;

                if (a < min) { min = a; }
                
                if (a > max) { max = a; }
            }

            int increment = 1;

            while (array.Contains(min + increment) && min + increment < max) { increment++; }

            return min + increment;
        }
    }
}