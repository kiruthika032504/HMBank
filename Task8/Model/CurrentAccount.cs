using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Model
{
    internal class CurrentAccount : Account
    {

        public double OverdraftLimit { get; set; }

        // Constructor Overload
        public CurrentAccount(int accountNo, string accType, double balance) : base(accountNo, accType, balance)
        {
            OverdraftLimit = 1000;
        }

        public void Withdraw(double amount)
        {
            if( amount > 0 )
            {
                if( amount <= accountBalance + OverdraftLimit )
                {
                    accountBalance -= amount;
                    Console.WriteLine($"\nWithdrawn {amount}. New balance: {accountBalance}");
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
    }
}
