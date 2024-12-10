using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class InputDataException : Exception    
    {
        public InputDataException()
        {
        }

        public InputDataException(string message) : base(message)
        {
        }

    }


    class NoRootsException: Exception
    {
        public NoRootsException()
        {
        }

        public NoRootsException(string message) : base(message) 
        {
        }

    }

}
