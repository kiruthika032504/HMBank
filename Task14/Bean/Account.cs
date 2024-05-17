using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Exception;

namespace Task14.Bean
{
    public class Account
    {
        public long AccountNumber { get; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; }
        public long AccountId { get; internal set; }
        public string? CustomerId { get; internal set; }

        private static long lastAccNo = 1000;

        public Account()
        {
            AccountNumber = GenerateAccountNumber();
            AccountType = AccountType;
            Balance = Balance;
            Customer = Customer;
            Transactions = new List<Transaction>();
        }
        public Account(string accountType, decimal balance, Customer customer)
        {
            AccountNumber = GenerateAccountNumber();
            AccountType = accountType;
            Balance = balance;
            Customer = customer;
            Transactions = new List<Transaction>();
        }

        private static long GenerateAccountNumber()
        {
            lastAccNo++;
            return lastAccNo;
        }

        public void AddTransacton(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InsufficientBalanceException("Insufficient balance");
            }
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                toAccount.Deposit(amount);
            }
            else
            {
                throw new InsufficientBalanceException("Insufficient balance");
            }
        }
    }

}
