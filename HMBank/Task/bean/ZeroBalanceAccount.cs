using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.bean
{
    internal class ZeroBalanceAccount : Account
    {
        public ZeroBalanceAccount(Customer customer)
            : base(customer, "ZeroBalance", 0)
        {
        }
    }
}
