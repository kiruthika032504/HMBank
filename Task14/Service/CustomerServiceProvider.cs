using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Bean;
using Task14.Exception;
using Task14.Repository;

namespace Task14.Service
{    
    public class CustomerServiceProvider : ICustomerServiceProvider
    {
        protected Dictionary<long, Account> accounts;
        readonly IBankRepository bankRepository;
        public CustomerServiceProvider()
        {
            accounts = new Dictionary<long, Account>();
            bankRepository = new BankRepository();
        }

        public decimal GetAccountBalance(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Balance;
            }
            throw new InvalidAccountException("Account not found");
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].Deposit(amount);
            }
            else
            {
                throw new InvalidAccountException("Account not found");
            }
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].Withdraw(amount);
            }
            else
            {
                throw new InvalidAccountException("Account not found");
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            if (accounts.ContainsKey(fromAccountNumber) && accounts.ContainsKey(toAccountNumber))
            {
                Account fromAccount = accounts[fromAccountNumber];
                Account toAccount = accounts[toAccountNumber];
                fromAccount.Transfer(toAccount, amount);
            }
            else
            {
                throw new InvalidAccountException("One or more accounts not found");
            }
        }

        public Account GetAccountDetails(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber];
            }
            throw new InvalidAccountException("Account not found");
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                List<Transaction> transactions = new List<Transaction>();

                foreach (Transaction transaction in account.Transactions)
                {
                    if (transaction.TransactionDate >= fromDate && transaction.TransactionDate <= toDate)
                    {
                        transactions.Add(transaction);
                    }
                }

                return transactions;
            }
            throw new InvalidAccountException("Account not found");
        }

        internal decimal CalculateInterest(long accNo)
        {
            if (accounts.ContainsKey(accNo))
            {
                decimal interestRate = 0.05M; // Example interest rate (5%)
                decimal balance = accounts[accNo].Balance;
                decimal interest = balance * interestRate;
                return interest;
            }
            else
            {
                throw new InvalidAccountException("Account not found");
            }
        }
    }

}
