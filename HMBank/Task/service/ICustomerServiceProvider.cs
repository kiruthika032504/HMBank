using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.service
{
    internal interface ICustomerServiceProvider
    {
        decimal GetAccountBalance(long accountNumber);
        decimal Deposit(long accountNumber, decimal amount);
        decimal Withdraw(long accountNumber, decimal amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        string GetAccountDetails(long accountNumber);
    }
}
