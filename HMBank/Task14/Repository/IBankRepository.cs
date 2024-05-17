using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Model;

namespace Task14.Repository
{
    internal interface IBankRepository
    {
        void CreateAccount(Customer customer, long accNo, string accType, decimal balance);
        List<Account> ListAccounts();
        string GetAccountDetails(long accountNumber);
        decimal CalculateInterest();
        decimal GetAccountBalance(long accountNumber);
        decimal Deposit(long accountNumber, decimal amount);
        decimal Withdraw(long accountNumber, decimal amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
