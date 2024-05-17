using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Exception
{
    public class InvalidAccountException : System.Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }

}
