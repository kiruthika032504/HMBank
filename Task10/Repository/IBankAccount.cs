using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;

namespace Task10.Repository
{
    internal interface IBankAccount<T> where T : Account
    {
        void CreateAccount(string accType, float balance, string customerName);
        void GetAccountBalance(long accountNumber);
        void Deposit(long accountNumber, float amount);
        void Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        Account GetAccountDetails(long accountNumber);

    }
}
