using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.Model;

namespace Task11.Services
{
    internal class IBankServiceProvider
    {
        void CreateAccount(Customer customer, long accNo, string accType, float balance);
        Account[] ListAccounts();
        void CalculateInterest();
    }
}
