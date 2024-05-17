using Task8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Repository
{
    internal interface IAccount
    {
        public Account GetAccountByAccountNo(int accountNo);
        public void AddAccount(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(int accountNo);
    }
}
