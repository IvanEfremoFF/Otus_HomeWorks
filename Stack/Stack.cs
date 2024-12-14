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
        public int Size { get; private set; }
        public string Top { get; private set; }

        private StackItem _head;
        private class StackItem
        {
            public string Value { get; set; }
            public StackItem Prev { get; set; }
            public StackItem(StackItem stackItem, string value)
            {
                Prev = stackItem;
                Value = value;
            }
        }

        public Stack(params string[] values) {
            if (values.Length > 0) 
            {
                foreach (string value in values)
                {
                    StackItem newItem = new StackItem(_head, value);
                    _head = newItem;
                    Top = newItem.Value;                    
                    Size++;
                }
            }
        }

        public void Add(string value)
        {
            _head = new StackItem(_head, value);
            Top = _head.Value;
            Size++;
        }

        public string Pop()
        {
            if (Size == 0)
                throw new EmptyStackException("Stack is empty");

            var item = _head.Value;            
            _head = _head.Prev;
            Top = _head?.Value;
            Size--;
            return item;
        }

        public static Stack Concat(params Stack[] listOfStacks) 
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
