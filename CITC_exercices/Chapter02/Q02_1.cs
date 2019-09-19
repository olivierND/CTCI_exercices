using System;
using System.Collections.Generic;
using System.Text;

namespace CITC_exercices.Chapter02
{
    public class Q02_1 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter02 - Q02_1---------------");
            Console.WriteLine("Remove duplicates in linked list" + Environment.NewLine);

            List<int> list = new List<int> {1, 2, 3, 1, 4, 2, 2, 1};
            LinkedList<int> test = new LinkedList<int>(list);
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                sb.Append(i);
            }

            sb.Append(" : ");
            LinkedList<int> res = Solution(test);
            foreach (int n in res)
            {
                sb.Append(n);
            }

            Console.WriteLine(sb.ToString());

            Console.WriteLine();
        }

        private LinkedList<int> Solution(LinkedList<int> l)
        {
            Dictionary<int, bool> d = new Dictionary<int, bool>();
            LinkedListNode<int> head = l.First;

            if (head == null)
            {
                return l;
            }
            d.Add(head.Value, true);

            while (head.Next != null)
            {
                if (d.ContainsKey(head.Next.Value))
                {
                    l.Remove(head.Next);
                }
                else
                {
                    d.Add(head.Next.Value, true);
                    head = head.Next;
                }
            }
            return l;
        }
    }
}