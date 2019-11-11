using System;
using System.Text;

namespace CITC_exercices.Chapter03
{
    public class Q03_2 : IQuestion
    {
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter03 - Q03_2---------------");
            Console.WriteLine("Implement stack that always keeps min and you can get it in O(1)" + Environment.NewLine);

            StackWithMin stack = new StackWithMin();

            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(1);
            stack.Push(6);
            stack.Pop();
            stack.Pop();
            stack.Push(1);

            NodeWithMin top = stack.Peek();
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            while (top != null)
            {
                sb.Append(top.Value + " ");
                top = top.Next;
            }

            sb.Append("}");

            Console.WriteLine(sb + " : " + stack.Min());

            Console.WriteLine();
        }
    }

    public class StackWithMin
    {
        private NodeWithMin _top;

        public NodeWithMin Pop()
        {
            if(_top == null)
            {
                return null;
            }
            NodeWithMin n = _top;
            _top = _top.Next;

            return n;
        }

        public void Push(int value)
        {
            NodeWithMin n = new NodeWithMin
            {
                Value = value,
            };

            if (_top == null)
            {
                n.Min = value;
                n.Next = null;
                _top = n;

                return;
            }

            n.Min = value < _top.Min ? value : _top.Min;
            n.Next = _top;

            _top = n;
        }

        public NodeWithMin Peek()
        {
            return _top;
        }

        public int Min()
        {
            return _top.Min;
        }
    }

    public class NodeWithMin
    {
        public int Value;

        public int Min;

        public NodeWithMin Next;
    }
}