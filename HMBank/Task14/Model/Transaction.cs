using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Model
{
    internal class Transaction
    {
        public Account Account { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string TransactionType { get; set; }
        public float TransactionAmount { get; set; }

    }
}
