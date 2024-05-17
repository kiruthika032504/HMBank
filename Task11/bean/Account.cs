using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11.bean
{
    internal class Account
    {
        public static long lastAccNo = 1001;
        public long AccountNumber = lastAccNo;
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public Customer Customer { get; set;}

        // Default Constructor
        public Account()
        {
            AccountNumber = AccountNumber;
            AccountType = AccountType;
            Balance = Balance;
            Customer = Customer;
        }
        // Overload Constructor
        public Account(string accountType, float balance, Customer customer)
        {
            AccountNumber = lastAccNo++;
            AccountType = accountType;
            Balance = balance;
            Customer = customer;
        }

         public override string ToString()
        {
            return $"Account Number : {AccountNumber}\nCustomer Name : {Customer.FirstName + " " + Customer.LastName}\nAccount Type : {AccountType}\nBalance : {Balance}";
        }

        public void Deposit(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            Balance += amount;
        }
    }
}
