using System;
using System.Collections.Generic;
using System.Linq;

namespace CITC_exercices
{
    public class GoogleExercice
    {
        public void Run()
        {
            Console.WriteLine("---------------GoogleExercice---------------");



            Console.WriteLine();
        }

        private string Solution(string[] A)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string a in A)
            {
                if (a.StartsWith("+"))
                {
                    string key = a.Replace("+", string.Empty);
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, 1);
                    }
                    else
                    {
                        dict[key]++;
                    }
                }
            }

            int max = 0;
            List<string> rooms = new List<string>();
            foreach (KeyValuePair<string, int> d in dict)
            {
                if (d.Value >= max)
                {
                    if (d.Value > max)
                    {
                        max = d.Value;
                        rooms.Clear();
                    }

                    rooms.Add(d.Key);
                }   
            }

            rooms.Sort();
            return rooms.FirstOrDefault();
        }
    }
}