using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.bean
{
    internal class SavingsAccount : Account
    {
        public float InterestRate { get; set; }

        public SavingsAccount(Customer customer, decimal balance, float interestRate)
            : base(customer, "Savings", balance)
        {
            InterestRate = interestRate;
        }
    }
}
