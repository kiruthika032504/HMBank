using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Bean;

namespace Task14.Service
{
    public interface ICustomerServiceProvider
    {
        decimal GetAccountBalance(long accountNumber);
        void Deposit(long accountNumber, decimal amount);
        void Withdraw(long accountNumber, decimal amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        Account GetAccountDetails(long accountNumber);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }

}
