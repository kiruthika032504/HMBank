using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Model;

namespace Task14.Service
{
    internal interface IBankServiceProvider
    {
        Account CreateAccount(Customer customer, long accNo, string accType, decimal balance);
        Account[] ListAccounts();
        string GetAccountDetails(long accountNumber);
        decimal CalculateInterest();
    }
}
