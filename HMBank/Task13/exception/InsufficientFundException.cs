using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13.exception
{
    internal class InsufficientFundException : Exception
    {
        public InsufficientFundException() : base("Insufficient funds.") { }
        public InsufficientFundException(string message) : base(message) { }
        public InsufficientFundException(string message, Exception inner) : base(message, inner) { }
    }
}
