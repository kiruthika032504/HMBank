using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Bean
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public long AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }

    }

}
