using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.bean
{
    internal class CurrentAccount : Account
    {
        public float OverdraftLimit { get; set; }

        public CurrentAccount(Customer customer, decimal balance, float overdraftLimit)
            : base(customer, "Current", balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public new decimal Withdraw(decimal amount)
        {
            if (amount > Balance + (decimal)OverdraftLimit)
            {
                throw new InvalidOperationException("Withdrawal amount exceeds available balance and overdraft limit.");
            }
            Balance -= amount;
            return Balance;
        }
    }
}
