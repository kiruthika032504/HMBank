using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Exception
{
    public class InsufficientBalanceException : System.Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

}
