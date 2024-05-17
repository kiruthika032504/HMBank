using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11.exception
{
    internal class InvalidAccountException : Exception
    {
        public InvalidAccountException() : base("Invalid account.") { }
        public InvalidAccountException(string message) : base(message) { }
        public InvalidAccountException(string message, Exception inner) : base(message, inner) { }
    }
}
