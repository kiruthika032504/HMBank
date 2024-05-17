using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Model
{
    internal class SavingsAccount : Account
    {

        public double InterestRate = 0.045;

        // Constructor Overload
        public SavingsAccount(int accountNo, string accType, double balance) : base(accountNo, accType, balance)
        {
            InterestRate = 0.045;
        }
        

        public override void CalculateInterest()
        {
            double interestAmount = accountBalance * InterestRate;
            accountBalance = accountBalance + interestAmount;
            Console.WriteLine($"\nUpdated Balance amount (inclusive of interest) : {accountBalance}");
        }
    }
}
