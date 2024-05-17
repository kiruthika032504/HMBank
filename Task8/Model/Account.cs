using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Model
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

        // Constructor Overload
        public Account(int accountNo, string accType, double balance)
        {
            accountNumber = accountNo;
            accountType = accType;
            accountBalance = balance;
        }

        // Overloaded Deposit Method -- DOUBLE
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
        // Overloaded Deposit Method -- INT
        public void Deposit(int amount)
        {
            Deposit((double)amount);
        }
        // Overloaded Deposit Method -- FLOAT
        public void Deposit(float amount)
        {
            Deposit((double)amount);
        }

        //Overloaded Withdraw Method -- DOUBLE
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
        // Overloaded Withdraw Method -- INT
        public void Withdraw(int amount)
        {
            Withdraw((double)amount);
        }
        // Overloaded Withdraw Method -- FLOAT
        public void Withdraw(float amount)
        {
            Withdraw((double)amount);
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
