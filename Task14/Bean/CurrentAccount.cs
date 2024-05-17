using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Exception;

namespace Task14.Bean
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(decimal balance, Customer customer, decimal overdraftLimit)
            : base("Current", balance, customer)
        {
            OverdraftLimit = overdraftLimit;
        }
    }

}
