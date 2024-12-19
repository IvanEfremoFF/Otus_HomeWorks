
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

        private class StackItem
        {
            public string? Value { get; set; } 
            public StackItem? Next { get; set; } 
        }

        public Stack(params string[] values) {
            if (values.Length > 0) 
            {
                foreach (string value in values)
                {
                    var  newItem = new StackItem { Next = _head, Value = value };
                    _head = newItem;
                    Size++;
                }
            }
        }

        public void Add(string value)
        {
            _head = new StackItem { Next = _head, Value = value };
            Size++;
        }

        public string? Pop()
        {
            if (Size == 0)
                throw new EmptyStackException("Stack is empty");

            string? item = _head?.Value;            
            _head = _head?.Next;
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
