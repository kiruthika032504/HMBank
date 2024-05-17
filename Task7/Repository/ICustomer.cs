using Task7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Repository
{
    internal interface ICustomer
    {
        public Customer GetCustomerByCustomerId(int customerId);
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int customerId);
    }
}
