using System;

namespace CITC_exercices.Utils
{
    public static class Printer
    {
        public static void Print2DArray(int[,] array)
        {
            string print = string.Empty;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                print += "{ ";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    print += array[i, j] + " ";
                }

                print += "} \n";
            }

            Console.WriteLine(print);
        }
    }
}