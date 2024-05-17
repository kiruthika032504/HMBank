using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.Model
{
    internal class Account
    {
        private static long lasAccNo = 1001;
        public long AccountNumber {  get; set; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public string Customer { get; set;}

        // Default Constructor
        public Account()
        {
            AccountNumber = lasAccNo++;
            AccountType = "";
            Balance = 0;
            Customer = "";
        }
        // Overload Constructor
        public Account(string accountType, float balance, string customer)
        {
            AccountNumber = lasAccNo++;
            AccountType = accountType;
            Balance = balance;
            Customer = customer;
        }

         public override string ToString()
        {
            return $"Account Number : {AccountNumber}\nCustomer Name : {Customer}\nAccount Type : {AccountType}\nBalance : {Balance}";
        }

    }
}
