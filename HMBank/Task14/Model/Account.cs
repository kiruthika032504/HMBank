using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Model
{
    internal class Account
    {
        private static long lastAccNo = 1000;
        public long AccountNumber {  get; set; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public Customer Customer { get; set;}

        // Default Constructor
        public Account()
        {
            AccountNumber = ++lastAccNo;
            AccountType = AccountType;
            Balance = Balance;
            Customer = Customer;
        }
        // Overload Constructor
        public Account(Customer customer,string accType, float balance)
        {
            AccountNumber = ++lastAccNo;
            AccountType = accType;
            Balance = balance;
            Customer = customer;
        }

         public override string ToString()
        {
            return $"Account Number : {AccountNumber}\nCustomer Name : {Customer}\nAccount Type : {AccountType}\nBalance : {Balance}";
        }

    }
}
