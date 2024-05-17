using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9.Model;

namespace Task9.Repository
{
    internal interface IBankAccount<T> where T : BankAccount
    {
        T GetAccountById(int accountId);
        void AddAccount(T account);
        void UpdateAccount(T account);
        void DeleteAccount(int accountId);
    }
}
