using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.exception
{
    internal class InsufficientFundException : Exception
    {
        public InsufficientFundException(string message)
                : base(message)
        {
        }
    }
}
