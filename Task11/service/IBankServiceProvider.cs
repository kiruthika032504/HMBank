using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.bean;

namespace Task11.service
{
    internal interface IBankServiceProvider
    {
        public Account CreateAccount(Customer customer, string accType, float balance);
        public void CalculateInterest(float balance, float interestRate);
        Account[] ListAccounts();
        public Account[] GetAccountDetails(long accNo);
    }
}
