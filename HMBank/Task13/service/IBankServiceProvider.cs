using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13.bean;

namespace Task13.service
{
    internal interface IBankServiceProvider
    {
        public Account CreateAccountUsingList(Customer customer, string accType, float balance);
        public Account CreateAccountUsingSet(Customer customer, string accType, float balance);
        public Account CreateAccountUsingHashMap(Customer customer, string accType, float balance);
        public Account[] ListAccountsUsingList();
        public Account[] ListAccountsUsingSet();
        public Account[] ListAccountsUsingHashMap();
        public Account GetAccountDetailsUsingList(long accNo);
        public Account GetAccountDetailsUsingSet(long accNo);
        public Account GetAccountDetailsUsingHashMap(long accNo);
        public void DepositUsingList(float amount, long accountNumber);
        public void DepositUsingSet(float amount, long accountNumber);
        public void DepositUsingHashMap(float amount, long accountNumber);
    }
}
