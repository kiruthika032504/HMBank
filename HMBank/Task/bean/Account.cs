using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.bean
{
    internal class Acccount
    {
        private static long lastAccNo = 1000;
        public long AccountNumber { get; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }

        public Account(Customer customer, string accType, decimal balance)
        {
            AccountNumber = ++lastAccNo;
            AccountType = accType;
            Balance = balance;
            Customer = customer;
        }
    }
}
