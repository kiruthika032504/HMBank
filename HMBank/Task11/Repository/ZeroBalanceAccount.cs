using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.Model;

namespace Task11.Repository
{
    internal abstract class ZeroBalanceAccount : Account
    {
        public ZeroBalanceAccount(Customer customer) : base("Zero Balance", 0, customer)
        {

        }
        public override void CalculateInterest()
        {
            Console.WriteLine("Zero balance account does not accrue interest");
        }

        public override void Withdraw(float amount)
        {
            Console.WriteLine("Cannot withdraw from a zero balance account.");
        }
    }
}
