using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9.Model
{
    internal class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount()
        {
            InterestRate = 0;
        }
        public SavingsAccount(int accountNo,string customerName, double balance, double interestRate) : base (accountNo,customerName,balance)
        {
            InterestRate = interestRate;
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
        public override void Withdraw(double amount)
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
