using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.bean;

namespace Task.service
{
    internal interface IBankServiceProvider
    {
        Account CreateAccount(Customer customer, long accNo, string accType, decimal balance);
        Account[] ListAccounts();
        decimal CalculateInterest();
    }
}
