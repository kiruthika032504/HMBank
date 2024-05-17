using Task8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Repository
{
    internal class AccountRepository : IAccount
    {
        // Declare a List
        List<Account> accounts = new List<Account>();
        public Account GetAccountByAccountNo(int accountNo)
        {
            return accounts.FirstOrDefault(a => a.accountNumber == accountNo);
        }
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            accounts.Add(account);
        }
        public void UpdateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var existingAccount = accounts.FirstOrDefault(a => a.accountNumber == account.accountNumber);
            if (existingAccount != null)
            {
                existingAccount.accountType = account.accountType;
                existingAccount.accountBalance = account.accountBalance;
            }
        }
        public void DeleteAccount(int accountNo)
        {
            var accountToRemove = accounts.FirstOrDefault(a => a.accountNumber == accountNo);
            if (accountToRemove != null)
            {
                accounts.Remove(accountToRemove);
            }
        }
    }
}
