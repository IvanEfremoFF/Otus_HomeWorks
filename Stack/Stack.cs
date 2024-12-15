using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{

    internal class Stack
    {
        public int Size { get; private set;}

        public string? Top
        {
            get => _head?.Value;
            private set => _ = _head?.Value;
        }

        private StackItem? _head;
        private class StackItem(StackItem? stackItem, string value)
        {
            public string Value { get; set; } = value;
            public StackItem? Prev { get; set; } = stackItem;
        }

        public Stack(params string[] values) {
            if (values.Length > 0) 
            {
                foreach (string value in values)
                {
                    StackItem newItem = new(_head, value);
                    _head = newItem;
                    Size++;
                }
            }
        }

        public void Add(string value)
        {
            _head = new StackItem(_head, value);
            Size++;
        }

        public string? Pop()
        {
            if (Size == 0)
                throw new EmptyStackException("Stack is empty");

            var item = _head?.Value;            
            _head = _head?.Prev;
            Size--;
            return item;
        }

        public static Stack? Concat(params Stack[] listOfStacks) 
        {
            if (listOfStacks.Length == 0)
                return null;

            var result = new Stack();
            foreach (var stack in listOfStacks) 
            {
                while (stack.Top != null) 
                { 
                    result.Add(stack.Top);
                    stack.Pop();
                }
            }

            return result;
        }
    }
}
