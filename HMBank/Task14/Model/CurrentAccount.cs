using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.exception;
using Task14.Model;

namespace Task14.bean
{
    internal class CurrentAccount : Account
    {
        public double OverdraftLimit { get; set; }

        // Constructor
        public CurrentAccount()
        {
            OverdraftLimit = 1000;
        }

        // Constructor Overload
        public CurrentAccount(float balance,Customer customer) : base(customer,"Current",balance)
        {
            OverdraftLimit = 1000;
        }

        public void Withdraw(float amount)
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
                    throw new OverDraftLimitExceededException("Amount exceeds the OverDraft Limit.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public void Deposit(float amount)
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
        public void CalculateInterest()
        {
            float interestRate = 0.045F;
            if (Balance > 0)
            {
                float interestAmount = Balance * interestRate;
                Balance += interestAmount;
                Console.WriteLine($"Interest calculate at 4.5% and added : {interestAmount}. New Balance : {Balance}");
            }
        }
    }
}
