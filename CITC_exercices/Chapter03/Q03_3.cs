using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CITC_exercices.Chapter03
{
    public class Q03_3 : IQuestion
    {
        public void Run()
        {
            Console.WriteLine("---------------CITC_exercices.Chapter03 - Q03_3---------------");
            Console.WriteLine("Implement data structure with multiple stacks of limited length" + Environment.NewLine);

            SetOfStacks<int> setOfStacks = new SetOfStacks<int>(2);

            setOfStacks.Push(2);
            setOfStacks.Push(2);
            setOfStacks.Push(2);
            setOfStacks.Push(2);
            setOfStacks.Push(2);
            setOfStacks.Push(2);
            setOfStacks.Push(2);

            setOfStacks.PopAt(2);
            setOfStacks.PopAt(2);
            setOfStacks.Pop();

            List<Stack<int>> stacks = setOfStacks.GetStacks();

            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            foreach(Stack<int> stack in stacks)
            {
                sb.Append(" { ");
                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop() + " ");
                }
                sb.Append("}");

            }

            sb.Append(" }");

            Console.WriteLine("Pushed 2 seven times, PopAt(2) twice then Pop() once (with capacity of 2): ");
            Console.WriteLine(sb);

            Console.WriteLine();
        }

        private string Solution()
        {
            return "";
        }
    }

    public class SetOfStacks<T>
    {
        private List<Stack<T>> _stacks;
        private readonly int _capacity;

        public SetOfStacks(int capacity)
        {
            _capacity = capacity;
            _stacks = new List<Stack<T>>();
        }

        public object Pop()
        {
            if (_stacks.Count == 0)
            {
                return null;
            }

            T value = _stacks.Last().Pop();

            if (_stacks.Last().Count == 0)
            {
                _stacks.Remove(_stacks.Last());
            }

            return value;
        }

        public List<Stack<T>> GetStacks()
        {
            return _stacks;
        }

        public object PopAt(int index)
        {
            if (index > _stacks.Count)
            {
                return null;
            }

            Stack<T> s = _stacks.ElementAt(index);

            T value = s.Pop();

            if (s.Count == 0)
            {
                _stacks.RemoveAt(index);
            }

            return value;
        }

        public void Push(T value)
        {
            if (_stacks.Count == 0 || _stacks.Last().Count == _capacity)
            {
                Stack<T> newStack = new Stack<T>();
                newStack.Push(value);
                _stacks.Add(newStack);
            }
            else
            {
                _stacks.Last().Push(value);
            }
        }

        public T Peek()
        {
            return _stacks.Last().Peek();
        }
    }
}