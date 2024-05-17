using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.bean;
using Task11.exception;

namespace Task11.service
{
    internal class CustomerServiceProvider : ICustomerServiceProvider
    {
        Account account = new Account();
        protected List<Account> accountList = new List<Account>();
        public void Deposit(long accountNumber, float amount)
        {
            if(account.AccountNumber == accountNumber)
            {
                account.Balance += amount;
                Console.WriteLine($"Deposit of {amount} successful! New Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        public void GetAccountBalance(long accountNumber)
        {
            if (account.AccountNumber == accountNumber)
            {
                Console.WriteLine($"Reporting Account Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        public void Transfer(long fromAcountNumber, long toAccountNumber, float amount)
        {
            Account fromAccount = new Account();
            Account toAccount = new Account();

            if(account.AccountNumber == fromAcountNumber)
            {
                fromAccount = account;
            }
            if(account.AccountNumber == toAccountNumber)
            {
                toAccount = account;
            }
            if(fromAccount != null && toAccount != null)
            {
                if(fromAccount.Balance > toAccount.Balance)
                {
                    fromAccount.Balance -= amount;
                    toAccount.Balance += amount;
                    Console.WriteLine("Amount Transfer successful!");
                }
                else
                {
                    throw new InsufficientFundException("Insufficient funds in the source account.");
                }
            }
            else
            {
                throw new InvalidAccountException("One or both accounts not found.");
            }
        }

        public void Withdraw(long accountNumber, float amount)
        {
            if (account.AccountNumber == accountNumber)
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrawal of {amount} successful! New Balance : {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
    }
}
