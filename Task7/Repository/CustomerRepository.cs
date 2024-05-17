using Task7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Repository
{
    internal class CustomerRepository : ICustomer
    {
        // Declare a List
        List<Customer> customers = new List<Customer>();

        public Customer GetCustomerByCustomerId(int customerId)
        {
            return customers.FirstOrDefault(c => c.customerID == customerId);
        }
        public void AddCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }                
            customers.Add(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            var existingCustomer = customers.FirstOrDefault(c => c.customerID == customer.customerID);
            if(existingCustomer != null)
            {
                existingCustomer.firstName = customer.firstName;
                existingCustomer.lastName = customer.lastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.phoneNumber = customer.phoneNumber;
                existingCustomer.Address = customer.Address;
            }
        }
        public void DeleteCustomer(int customerId)
        {
            var customerToRemove = customers.FirstOrDefault(c => c.customerID == customerId);
            if(customerToRemove != null)
            {
                customers.Remove(customerToRemove);
            }
        }
    }
}
