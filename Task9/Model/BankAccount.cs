using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9.Model
{
    internal abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        // Default Constructor 
        public BankAccount()
        {
            AccountNumber = 0;
            CustomerName = "";
            Balance = 0;
        }

        // Overload Constructor with attributes
        public BankAccount(int accountNo, string customerName, double balance)
        {
            AccountNumber = accountNo;
            CustomerName = customerName;
            Balance = balance;
        }

        // Abstract Methods 
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void CalculateInterest();

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number : {AccountNumber}\nCustomer Name : {CustomerName}\nBalance : {Balance}");
        }

    }
}
