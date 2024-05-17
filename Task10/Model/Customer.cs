using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.Model
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer()
        {
            CustomerId = CustomerId;
            FirstName = FirstName;
            LastName = LastName;
            Email = Email;
            PhoneNumber = PhoneNumber;
            Address = Address;
        }
        // Overload Constructor
        public Customer(int customerId, string firstName, string lastName, string email, string phoneNumber, string address)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Customer ID : {CustomerId}\nCustomer Name : {FirstName + " " + LastName}\nEmail : {Email}\nPhone Number : {PhoneNumber}\nAddress : {Address}");
        }
    }
}
