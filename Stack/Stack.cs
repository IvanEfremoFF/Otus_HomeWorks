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

        List<string> _stack = new List<string>();
        public int Size { get; private set; }
        public string Top { get; private set; }

        public Stack(params string[] values) {
            _stack.AddRange(values);
            _stack.Reverse();
            SetSizeAndTop();
        }

        public void Add(string value)
        {
            _stack.Reverse();
            _stack.Add(value);
            _stack.Reverse();
            SetSizeAndTop();
        }

        public string Pop()
        {
            if (_stack.Count == 0)
            { 
                var ex = new EmptyStackException("Stack is empty");
                throw ex;
            }
            

            var item = _stack[0];

            _stack.RemoveAt(0);
            SetSizeAndTop();

            return item;
        }

        private void SetSizeAndTop() {
            Size = _stack.Count;
            if (_stack.Count > 0)
                Top = _stack[0];
            else
                Top = null;
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
