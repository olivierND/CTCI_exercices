using System;
using System.Collections.Generic;
using System.Text;

namespace CITC_exercices.Chapter02
{
    public class Q02_3 : IQuestion
    {

        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter02 - Q02_3---------------");
            Console.WriteLine("Remove node in middle of linked list with only access to this node" + Environment.NewLine);

            List<int> list = new List<int> { 1, 3, 4, 2, 1 };
            LinkedList<int> test = new LinkedList<int>(list);
            LinkedList<int> res = Solution(FindMiddleNode(test));

            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                sb.Append(i);
            }

            sb.Append(" : ");

            foreach (int i in res)
            {
                sb.Append(i);
            }

            Console.WriteLine(sb);
            Console.WriteLine();
        }

        private LinkedList<int> Solution(LinkedListNode<int> n)
        {
            /*
             * Solution optimale :
             *
             *      if(n?.Next == null) {
             *           return;
             *      }
             *      n.Value = n.Next.Value;
             *      n.Next = n.Next.Next;
             *
             * Mais on ne peut pas setter n.Next en c# car il est readonly, on doit donc reconstruire la liste completement
             * ce qui est vraiment plus couteux
             */

            if (n?.Next == null)
            {
                return null;
            }

            LinkedListNode<int> node = n;
            while (node.Previous != null)
            {
                node = node.Previous;
            }

            List<int> l = new List<int>();
            while (node != null)
            {
                if (node != n)
                {
                    l.Add(node.Value);
                }

                node = node.Next;
            }

            return new LinkedList<int>(l);
        }

        private LinkedListNode<int> FindMiddleNode(LinkedList<int> l)
        {
            if (l.First == null)
            {
                return null;
            }

            LinkedListNode<int> head = l.First;
            LinkedListNode<int> runner = l.First;

            while (runner?.Next != null)
            {
                if (runner == null)
                {
                    return head.Next;
                }
                head = head?.Next;
                runner = runner.Next.Next;
            }

            return head;
        }
    }
}