using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13.bean;
using Task13.exception;

namespace Task13.service
{
    internal class BankServiceProvider : CustomerServiceProvider, IBankServiceProvider
    {
        protected List<Account> accountList = new List<Account>();
        protected HashSet<Account> accountSet = new HashSet<Account>();
        protected Dictionary<long, Account> accountDict = new Dictionary<long, Account>();

        private string branchName;
        private string branchAddress;

        public BankServiceProvider(string name, string address)
        {
            branchName = name;
            branchAddress = address;
        }

        // Create Account Method using List
        public Account CreateAccountUsingList(Customer customer, string accType, float balance)
        {
            Account newAccount = null;
            switch (accType.ToLower())
            {
                case "savings":
                    float interestRate = 0.045F;
                    float minBalance = 500;
                    if (balance > minBalance)
                    {
                        SavingsAccount savings = new SavingsAccount(customer, balance, interestRate);
                        accountList.Add(savings);
                        newAccount = savings;
                    }
                    else
                    {
                        throw new InsufficientFundException("Need a Minimum Balance of at least 500 for a Savings Account.");
                    }
                    break;
                case "current":
                    CurrentAccount current = new CurrentAccount(balance, customer);
                    accountList.Add(current);
                    newAccount = current;
                    break;
                case "zerobalance":
                    ZeroBalanceAccount zeroBalance = new ZeroBalanceAccount(customer);
                    accountList.Add(zeroBalance);
                    newAccount = zeroBalance;
                    break;
                default:
                    Console.WriteLine("Invalid Account Type");
                    break;
            }
            return newAccount;
        }

        // Create Account Method using HashSet
        public Account CreateAccountUsingSet(Customer customer, string accType, float balance)
        {
            Account newAccount = CreateAccountUsingList(customer, accType, balance);
            if (newAccount != null)
            {
                accountSet.Add(newAccount);
            }
            return newAccount;
        }

        // Create Account Method using HashMap
        public Account CreateAccountUsingHashMap(Customer customer, string accType, float balance)
        {
            Account newAccount = CreateAccountUsingList(customer, accType, balance);
            if (newAccount != null)
            {
                accountDict[newAccount.AccountNumber] = newAccount;
            }
            return newAccount;
        }

        // List Accounts Method using List
        public Account[] ListAccountsUsingList()
        {
            foreach(Account account in accountList)
            {
                Console.WriteLine(account);
            }
            return accountList.ToArray();
        }

        // List Accounts Method using HashSet
        public Account[] ListAccountsUsingSet()
        {
            foreach (Account account in accountSet)
            {
                Console.WriteLine(account);
            }
            return accountSet.ToArray();
        }

        // List Accounts Method using HashMap
        public Account[] ListAccountsUsingHashMap()
        {
            foreach (KeyValuePair<long,Account> account in accountDict)
            {
                Console.WriteLine(account.Value);
            }
            return accountDict.Values.ToArray();
        }

        // Get Account Details Method using List
        public Account GetAccountDetailsUsingList(long accNo)
        {
            foreach (Account account in accountList)
            {
                Console.WriteLine(account);
            }
            return accountList.FirstOrDefault(acc => acc.AccountNumber == accNo);
        }

        // Get Account Details Method using HashSet
        public Account GetAccountDetailsUsingSet(long accNo)
        {
            Account acc = new Account();
            if(acc.AccountNumber == accNo)
            {
                foreach (Account accountSet in accountSet)
                {
                    Console.WriteLine(accountSet);
                }
            }            
            return accountSet.FirstOrDefault(acc => acc.AccountNumber == accNo);
        }

        // Get Account Details Method using HashMap
        public Account GetAccountDetailsUsingHashMap(long accNo)
        {
            Account acc = new Account();
            if (acc.AccountNumber == accNo)
            {
                foreach (KeyValuePair<long,Account> accountDict in accountDict)
                {
                    Console.WriteLine(accountDict.Value);
                }
            }
            Account account;
            accountDict.TryGetValue(accNo, out account);
            return account;
        }

        // Deposit Method using List
        public void DepositUsingList(float amount, long accountNumber)
        {
            Account account = accountList.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposit of {amount} successful. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        // Deposit Method using HashSet
        public void DepositUsingSet(float amount, long accountNumber)
        {
            Account account = accountSet.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposit of {amount} successful. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        // Deposit Method using HashMap
        public void DepositUsingHashMap(float amount, long accountNumber)
        {
            Account account;
            if (accountDict.TryGetValue(accountNumber, out account))
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposit of {amount} successful. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
