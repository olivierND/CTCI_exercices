using System;
using System.Collections.Generic;
using System.Text;

namespace CITC_exercices.Chapter02
{
    public class Q02_4 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter02 - Q02_4---------------");
            Console.WriteLine("Sort linked list around pivot" + Environment.NewLine);

            List<int> list = new List<int> { 1, 3, 1, 4, 2, 1 };
            LinkedList<int> test = new LinkedList<int>(list);

            LinkedListNode<int> res = Solution(test.First, 3);

            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                sb.Append(i);
            }

            sb.Append(" : ");

            while (res != null)
            {
                sb.Append(res.Value);
                res = res.Next;
            }

            Console.WriteLine(sb);
            Console.WriteLine();
        }

        private LinkedListNode<int> Solution(LinkedListNode<int> head, int pivot)
        {
            LinkedList<int> l1 = new LinkedList<int>(new List<int>());
            LinkedList<int> l2 = new LinkedList<int>();

            while (head != null)
            {
                LinkedListNode<int> newNode = new LinkedListNode<int>(head.Value);
                if (head.Value >= pivot)
                {
                    l2.AddLast(newNode);
                }
                else
                {
                    l1.AddLast(newNode);
                }

                head = head.Next;
            }

            LinkedListNode<int> newHead = l2.First;
            while (newHead != null)
            {
                LinkedListNode<int> newNode = new LinkedListNode<int>(newHead.Value);
                l1.AddLast(newNode);
                newHead = newHead.Next;
            }

            return l1.First;
        }
    }
}