using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;

namespace Task10.Repository
{
    internal class BankAccountRepository<T> : IBankAccount<T> where T : Account
    {
        private List<Account> accounts = new List<Account>();
        public void CreateAccount(string accType, float balance, string customerName)
        {
            Account account = new Account(accType, balance, customerName);
            accounts.Add(account);
            Console.WriteLine("Account created successfully.");
        }

        public void GetAccountBalance(long accountNumber)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if(account != null)
            {
                Console.WriteLine($"Reporting Account Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist!");
            }
        }

        public void Deposit(long accountNumber, float amount)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Balance += amount;
                Console.WriteLine($"Deposit of {amount} successful! New Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist!");
            }
        }

        public void Withdraw(long accountNumber, float amount)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null && account.Balance >= amount)
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrawal of {amount} successful! New Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance or Account does not exist");
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            if(fromAccountNumber > toAccountNumber)
            {
                Withdraw(fromAccountNumber, amount);
                Deposit(toAccountNumber, amount);
            }
            else
            {
                Console.WriteLine("Error transferring funds.");
                Deposit(fromAccountNumber, amount); // Rollback withdrawal
            }
  
        }

        public Account GetAccountDetails(long accountNumber)
        {
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if(account != null)
            {
                Console.WriteLine($"Account Number : {account.AccountNumber}\nCustomer Name : {account.Customer}\nAccount Type : {account.AccountType}\nBalance : {account.Balance}");
                return account;
            }
            else
            {
                Console.WriteLine("No Account Found.");
                return null;
            }
        }
    }
}
