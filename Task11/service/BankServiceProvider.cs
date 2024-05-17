using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.bean;
using Task11.exception;

namespace Task11.service
{
    internal class BankServiceProvider : CustomerServiceProvider, IBankServiceProvider
    {
        

        protected List<Account> accountList = new List<Account>();
        private string branchName;
        private string branchAddress;
        Account account = new Account();

        public BankServiceProvider(string name, string address)
        {
            branchName = name;
            branchAddress = address;
        }

        public void CalculateInterest(float balance, float interestRate)
        {
            interestRate = 0.045F;
            if(balance <= 0)
            {
                throw new InsufficientFundException("Balance must be greater than zero to calculate interest");
            }
            if (account.Balance > 0)
            {
                float interestAmount = account.Balance * interestRate;
                account.Balance += interestAmount;
                Console.WriteLine($"Interest calculate at 4.5% and added : {interestAmount}. New Balance : {account.Balance}");
            }
        }

        public Account CreateAccount(Customer customer,string accType, float balance)
        {
            Account newAccount = null;
            switch(accType.ToLower())
            {
                case "savings":
                    float interestRate = 0.045F;
                    float minBalance = 500;
                    if(balance > minBalance)
                    {
                        SavingsAccount savings = new SavingsAccount(customer, balance, interestRate);
                        Console.WriteLine($"\nCustomer Name : {savings.Customer.FirstName + " " + savings.Customer.LastName}\nAccount Number : {savings.AccountNumber}\nAccount Balance : {savings.Balance}");
                        accountList.Add(savings);
                    }
                    else
                    {
                        throw new InsufficientFundException("Need a Minimum Balance of at least 500 for a Savings Account.");
                    }
                    break;
                case "current":
                    CurrentAccount current = new CurrentAccount(balance, customer);
                    Console.WriteLine($"\nCustomer Name : {current.Customer.FirstName + " " + current.Customer.LastName}\nAccount Number : {current.AccountNumber}\nAccount Balance : {current.Balance}");
                    accountList.Add(current);
                    break;
                case "zerobalance":
                    ZeroBalanceAccount zeroBalance = new ZeroBalanceAccount(customer);
                    Console.WriteLine($"\nCustomer Name : {zeroBalance.Customer.FirstName + " " + zeroBalance.Customer.LastName}  \nAccount Number :   {zeroBalance.AccountNumber}\nAccount Balance : {zeroBalance.Balance}");
                    accountList.Add(zeroBalance);
                    break;
                default:
                    Console.WriteLine("Invalid Account Type");
                    break;
            }
            return newAccount;
        }

        public Account[] ListAccounts()
        {
            foreach(Account account in accountList)
            {
                Console.WriteLine(account);
            }
            return accountList.ToArray();
        }

        public Account[] GetAccountDetails(long accNo)
        {
            foreach (Account account in accountList)
            {
                if (account.AccountNumber == accNo)
                {
                    Console.WriteLine($"Account Number : {account.AccountNumber}\nCustomer Name : {account.Customer.FirstName + " " + account.Customer.LastName}\nAccountType : {account.AccountType}\nAccount Balance : {account.Balance}");
                }
                return accountList.ToArray ();
            }
            return null;
        }

        public void Deposit(float amount, long accountNumber)
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
    }
}
