using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.bean;

namespace Task.service
{
    internal class CustomerServiceProviderImpl
    {
        private Dictionary<long, Account> accountList = new Dictionary<long, Account>();

        public decimal GetAccountBalance(long accountNumber)
        {
            if (accountList.ContainsKey(accountNumber))
            {
                return accountList[accountNumber].Balance;
            }
            throw new InvalidOperationException("Account not found.");
        }

        public decimal Deposit(long accountNumber, decimal amount)
        {
            if (accountList.ContainsKey(accountNumber))
            {
                return accountList[accountNumber].Deposit(amount);
            }
            throw new InvalidOperationException("Account not found.");
        }

        public decimal Withdraw(long accountNumber, decimal amount)
        {
            if (accountList.ContainsKey(accountNumber))
            {
                return accountList[accountNumber].Withdraw(amount);
            }
            throw new InvalidOperationException("Account not found.");
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            if (accountList.ContainsKey(fromAccountNumber) && accountList.ContainsKey(toAccountNumber))
            {
                accountList[fromAccountNumber].Withdraw(amount);
                accountList[toAccountNumber].Deposit(amount);
            }
            else
            {
                throw new InvalidOperationException("One or both accounts not found.");
            }
        }

        public string GetAccountDetails(long accountNumber)
        {
            if (accountList.ContainsKey(accountNumber))
            {
                Account account = accountList[accountNumber];
                return $"Account Number: {account.AccountNumber}, Account Type: {account.AccountType}, Balance: {account.Balance}, Customer Name: {account.Customer.FirstName} {account.Customer.LastName}";
            }
            throw new InvalidOperationException("Account not found.");
        }

        public void CreateAccount(Customer customer, long accNo, string accType, decimal balance)
        {
            Account newAccount = null;
            switch (accType.ToLower())
            {
                case "savings":
                    newAccount = new SavingsAccount(customer, balance, 0.045f);
                    break;
                case "current":
                    newAccount = new CurrentAccount(customer, balance, 1000);
                    break;
                case "zerobalance":
                    newAccount = new ZeroBalanceAccount(customer);
                    break;
                default:
                    throw new InvalidOperationException("Invalid account type.");
            }
            if (newAccount != null)
            {
                accountList.Add(newAccount.AccountNumber, newAccount);
            }
        }

        public Account[] ListAccounts()
        {
            return new List<Account>(accountList.Values).ToArray();
        }

        public decimal CalculateInterest()
        {
            // Implementation of interest calculation based on bank policies
            return 0.0m;
        }
    }
}
