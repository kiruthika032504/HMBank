using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9.Model
{
    internal class CurrentAccount : BankAccount
    {
        public double OverdraftLimit { get; set; }

        // Constructor
        public CurrentAccount()
        {
            OverdraftLimit = 1000;
        }

        // Constructor Overload
        public CurrentAccount(int accountNo, string accType, double balance) : base(accountNo, accType, balance)
        {
            OverdraftLimit = 1000;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (amount <= Balance + OverdraftLimit)
                {
                    Balance -= amount;
                    Console.WriteLine($"\nWithdrawn {amount}. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Exceeding Overdraft Limit");
                }
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposit of {amount} successful! New Balance : {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid Deposit Amount");
            }
        }
        public override void CalculateInterest()
        {
            double interestRate = 0.045;
            if (Balance > 0)
            {
                double interestAmount = Balance * interestRate;
                Balance += interestAmount;
                Console.WriteLine($"Interest calculate at 4.5% and added : {interestAmount}. New Balance : {Balance}");
            }
        }
    }
}
