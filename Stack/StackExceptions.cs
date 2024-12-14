using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class StackExceptions : Exception
    {
        public StackExceptions() : base() { }
        public StackExceptions(string message) : base(message) { }
    }

    internal class EmptyStackException : StackExceptions
    {
        public EmptyStackException() : base() { }
        public EmptyStackException(string message) : base(message) { }
    }

}
