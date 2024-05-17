using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13.exception
{
    internal class OverDraftLimitExceededException : Exception
    {
        public OverDraftLimitExceededException() : base("Overdraft limit exceeded.") { }
        public OverDraftLimitExceededException(string message) : base(message) { }
        public OverDraftLimitExceededException(string message, Exception inner) : base(message, inner) { }
    }
}
