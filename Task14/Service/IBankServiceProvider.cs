using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Bean;

namespace Task14.Service
{
    public interface IBankServiceProvider : ICustomerServiceProvider
    {
        void CreateAccount(Customer customer, long accNo, string accType, decimal balance);
        List<Account> ListAccounts();
        decimal CalculateInterest(long accNo);
    }

}
