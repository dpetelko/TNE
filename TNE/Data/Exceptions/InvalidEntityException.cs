using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Data.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException()
        {
        }

        public InvalidEntityException(string message)
            : base(message)
        {
        }

        public InvalidEntityException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
