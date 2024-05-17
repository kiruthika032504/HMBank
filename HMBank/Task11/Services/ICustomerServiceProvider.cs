using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.Model;

namespace Task11.Services
{
    internal class ICustomerServiceProvider<T> where T : Account
    {
        void GetAccountBalance(long accountNumber);
        void Deposit(long accountNumber, float amount);
        void Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        Account GetAccountDetails(long accountNumber);

    }
}
