using System;
using System.Collections.Generic;
using System.Text;

namespace CITC_exercices.Chapter02
{
    public class Q02_2 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter02 - Q02_2---------------");
            Console.WriteLine("Return nth from last element in linked list" + Environment.NewLine);

            List<int> list = new List<int> { 1, 3, 1, 4, 2, 1 };
            LinkedList<int> test = new LinkedList<int>(list);
            int n = 3;
            IntWrapper intWrapper = new IntWrapper();

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            foreach (int i in list)
            {
                sb.Append(i);
                sb2.Append(i);
            }

            sb.Append(" with n = " + n + " : " + Solution(test.First, n).Value);
            sb2.Append(" with n = " + n + " and Recursive Solution : " + RecursiveSolution(test.First, n, intWrapper).Value);
            Console.WriteLine(sb);
            Console.WriteLine(sb2);

            Console.WriteLine();
        }

        private LinkedListNode<int> Solution(LinkedListNode<int> head, int n)
        {
            if (n < 0)
            {
                return null;
            }

            LinkedListNode<int> runner = head;
            for (int i = 0; i < n - 1; i++)
            {
                if (runner.Next == null)
                {
                    return null;
                }
                runner = runner.Next;
            }

            while (runner.Next != null)
            {
                head = head?.Next;
                runner = runner.Next;
            }

            return head;
        }

        private LinkedListNode<int> RecursiveSolution(LinkedListNode<int> head, int n, IntWrapper i)
        {
            if (head == null)
            {
                return null;
            }

            LinkedListNode<int> node = RecursiveSolution(head.Next, n, i);
            i.Value++;

            return i.Value == n ? head : node;
        }
    }

    public class IntWrapper
    {
        public int Value;
    }
}