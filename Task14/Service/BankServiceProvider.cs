using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Bean;
using Task14.Repository;

namespace Task14.Service
{
    public class BankServiceProvider : CustomerServiceProvider,IBankServiceProvider
    {
        private List<Account> accountList;
        private List<Transaction> transactionList;

        readonly IBankRepository bankRepository;
        public BankServiceProvider()
        {
            accountList = new List<Account>();
            transactionList = new List<Transaction>();
            bankRepository = new BankRepository();
        }

        public void CreateAccount(Customer customer, long accNo, string accType, decimal balance)
        {
            Account account;
            if (accType == "Savings")
            {
                account = new SavingsAccount(balance, customer, 0.0m); // Assuming interest rate is 0 for simplicity
            }
            else if (accType == "Current")
            {
                account = new CurrentAccount(balance, customer, 0.0m); // Assuming overdraft limit is 0 for simplicity
            }
            else if (accType == "Zero Balance")
            {
                account = new ZeroBalanceAccount(customer);
            }
            else
            {
                throw new ArgumentException("Invalid account type");
            }

            accountList.Add(account);
            accounts.Add(accNo, account);
        }

        public List<Account> ListAccounts()
        {
            return accountList;
        }

        public decimal CalculateInterest()
        {
            decimal totalInterest = 0;
            foreach (Account account in accountList)
            {
                if (account is SavingsAccount savingsAccount)
                {
                    decimal interest = savingsAccount.Balance * savingsAccount.InterestRate;
                    totalInterest += interest;
                }
            }
            return totalInterest;
        }

        // Implementing interface methods from ICustomerServiceProvider
        public decimal GetAccountBalance(long accountNumber)
        {
            return base.GetAccountBalance(accountNumber);
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            base.Deposit(accountNumber, amount);
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            base.Withdraw(accountNumber, amount);
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            base.Transfer(fromAccountNumber, toAccountNumber, amount);
        }

        public Account GetAccountDetails(long accountNumber)
        {
            return base.GetAccountDetails(accountNumber);
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            return base.GetTransactions(accountNumber, fromDate, toDate);
        }

        public decimal CalculateInterest(long accNo)
        {
            return base.CalculateInterest(accNo);            
        }
    }

}
