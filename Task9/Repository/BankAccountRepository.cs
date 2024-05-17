using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9.Model;

namespace Task9.Repository
{
    internal class BankAccountRepository<T> : IBankAccount<T> where T : BankAccount
    {
        private List<T> accounts;

        public BankAccountRepository()
        {
            accounts = new List<T>();
        }

        public T GetAccountById(int accountId)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountId);
        }

        public void AddAccount(T account)
        {
            accounts.Add(account);
        }

        public void UpdateAccount(T account)
        {
            var existingAccount = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount.CustomerName = account.CustomerName;
                existingAccount.Balance = account.Balance;
                // Update specific properties for SavingsAccount or CurrentAccount
                if (existingAccount is SavingsAccount savingsAccount && account is SavingsAccount newSavingsAccount)
                {
                    savingsAccount.InterestRate = newSavingsAccount.InterestRate;
                }
            }
        }
        public void DeleteAccount(int accountId)
        {
            var accountToRemove = accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (accountToRemove != null)
                accounts.Remove(accountToRemove);
        }
    }
}
