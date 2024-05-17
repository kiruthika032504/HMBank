using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Bean;

namespace Task14.Repository
{
    internal interface IBankRepository
    {
        void CreateAccount(Customer customer, string accType, decimal balance);
        List<Account> ListAccounts();
        decimal CalculateInterest(long accNo);
        decimal GetAccountBalance(long accountNumber);
        void Deposit(long accountNumber, decimal amount);
        void Withdraw(long accountNumber, decimal amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        Account GetAccountDetails(long accountNumber);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
