using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Model;

namespace Task14.bean
{
    internal class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount()
        {
            InterestRate = 0;
        }
        public SavingsAccount(Customer customer, float balance, double interestRate) : base(customer,"Savings",balance)
        {
            InterestRate = interestRate;
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
        public void Withdraw(float amount)
        {
            if (amount > 0)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrawal of {amount} successful! New Balance : {Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance");
                }
            }
            else
            {
                Console.WriteLine("Invalid Withdrawal Amount");
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
