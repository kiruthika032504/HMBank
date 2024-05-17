using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Exception;

namespace Task14.Bean
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(decimal balance, Customer customer, decimal interestRate)
            : base("Savings", balance, customer)
        {
            InterestRate = interestRate;
            if (balance < 500)
            {
                throw new InvalidAccountException("Minimum balance for a savings account is 500");
            }
        }
    }

}
