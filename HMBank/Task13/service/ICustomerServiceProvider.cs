using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13.bean;

namespace Task13.service
{
    internal interface ICustomerServiceProvider
    {
        public void GetAccountBalance(long accountNumber);
        public void Deposit(long accountNumber, float amount);
        public void Withdraw(long accountNumber, float amount);
        public void Transfer(long fromAcountNumber, long toAccountNumber, float amount);
    }
}
