using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13.bean
{
    internal class ZeroBalanceAccount : Account
    {
        public ZeroBalanceAccount(Customer customer)
        {
            Customer = customer;
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
            Console.WriteLine("Cannot withdraw amount in Zero-Balance account");
        }
        public void CalculateInterest()
        {
            Console.WriteLine("Zero Balance account does not accrue interest");
        }
    }
}
