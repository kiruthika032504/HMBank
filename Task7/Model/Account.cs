using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Model
{
    internal class Account
    {
        public int accountNumber {  get; set; }
        public string accountType {  get; set; }
        public double accountBalance {  get; set; }

        //Constructor
        public Account()
        {
            accountNumber = 0;
            accountType = ""; 
            accountBalance = 0;
        }

        // Constructor with Parameter specification
        public Account(int accountNo, string accType, double balance)
        {
            accountNumber = accountNo;
            accountType = accType;
            accountBalance = balance;
        }

        // Deposit Method
        public void Deposit(double amount)
        {
            if(amount > 0)
            {
                accountBalance += amount;
                Console.WriteLine($"Deposit of {amount} successful! New Balance : {accountBalance}");
            }
            else
            {
                Console.WriteLine("Invalid Deposit Amount");
            }
        }
       
        // Withdraw Method
        public void Withdraw(double amount)
        {
            if(amount > 0)
            {
                if(amount <= accountBalance)
                {
                    accountBalance -= amount;
                    Console.WriteLine($"Withdrawal of {amount} successful! New Balance : {accountBalance}");
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
        
        // CalculateInterest Method
        public virtual void CalculateInterest()
        {
            double interestRate = 0.045;
            if(accountBalance > 0)
            {
                if (accountType == "Savings")
                {
                    double interestAmount = accountBalance * interestRate;
                    accountBalance += interestAmount;
                    Console.WriteLine($"Interest calculate at 4.5% and added : {interestAmount}. New Balance : {accountBalance}");
                }
            }
        }
    }
}
