using System;
using System.Collections.Generic;
using CITC_exercices.Utils;

namespace CITC_exercices.Suppl
{
    public class Suppl_02 : IQuestion
    {
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Suppl - Suppl_02---------------");
            Console.WriteLine("Find islands in map" + Environment.NewLine);

            int[,] map = 
            {
                { 1, 1, 0, 0, 1 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 0 },
                { 1, 0, 1, 1, 0 }
            }; // Should return 4

            Solution(map);

            Printer.Print2DArray(map);

            Console.WriteLine("Output : " + Solution(map));
            Console.WriteLine();
        }

        private int Solution(int[,] map)
        {
            int numberOfIslands = 0;
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];


            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1 && !visited[i, j])
                    {
                        BreadthFirstSearch(map, i, j, visited);
                        numberOfIslands++;
                    }
                }
            }

            return numberOfIslands;
        }

        private void BreadthFirstSearch(int[,] map, int i, int j, bool[,] visited)
        {
            (int, int)[] neighbors =
            {
                (1, -1), (0, 1), (1, 0), (1, 1),
                (-1, 1), (0, -1), (-1, 0), (-1, -1)
            };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((i, j));

            while (queue.Count > 0)
            {
                (int, int) coords = queue.Dequeue();
                visited[coords.Item1, coords.Item2] = true;
                
                foreach (var (item1, item2) in neighbors)
                {
                    int col = item1 + coords.Item1;
                    int row = item2 + coords.Item2;

                    if (col < map.GetLength(0) && col >= 0 &&
                        row < map.GetLength(1) && row >= 0 &&
                        !visited[col, row] && map[col, row] == 1)
                    {
                        queue.Enqueue((col, row));
                    }
                }
            }
        }
    }
}