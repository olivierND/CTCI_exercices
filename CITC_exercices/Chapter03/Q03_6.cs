using System;
using System.Text;

namespace CITC_exercices.Chapter03
{
    public class Q03_6 : IQuestion
    {
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter03 - Q03_6---------------");
            Console.WriteLine("Implement a program to sort a stack in ascending order" + Environment.NewLine);

            Stack s = new Stack();

            s.Push(2);
            s.Push(8);
            s.Push(1);
            s.Push(3);
            s.Push(5);
            s.Push(2);
            s.Push(1);
            s.Push(10);
            s.Push(4);

            Console.WriteLine(DisplayStack(s) + " : " + DisplayStack(Solution(s)));
        }

        public Stack Solution(Stack s)
        {
            Stack s2 = new Stack();
            while (!s.IsEmpty())
            {
                Node n = s.Pop();

                if (s2.IsEmpty())
                {
                    s2.Push(n.Value);
                }
                else
                {
                    while (!s2.IsEmpty() && s2.Peek().Value < n.Value)
                    {
                        s.Push(s2.Pop().Value);
                    }

                    s2.Push(n.Value);
                }
            }

            return s2;
        }

        public string DisplayStack(Stack s)
        {
            if (s == null)
            {
                return "";
            }

            Node top = s.Peek();

            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");
            while (top != null)
            {
                sb.Append(top.Value + " ");
                top = top.Next;
            }

            sb.Append("}");

            return sb.ToString();
        }
    }

    public class Stack
    {
        private Node _top;
        private int _count;

        public Node Pop()
        {
            if (_top == null)
            {
                return null;
            }

            Node oldTop = _top;
            _top = _top.Next;

            _count--;

            return oldTop;
        }

        public void Push(int value)
        {
            if (_count == 0)
            {
                _top = new Node { Next = null, Value = value };
            }
            else
            {
                Node newNode = new Node { Next = _top, Value = value };
                _top = newNode;
            }

            _count++;
        }

        public Node Peek()
        {
            return _top;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }

    public class Node
    {
        public int Value;
        public Node Next;
    }
}