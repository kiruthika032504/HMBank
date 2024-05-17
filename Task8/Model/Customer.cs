using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Model
{
    internal class Customer
    {
        public int customerID {  get; set; }
        public string firstName {  get; set; }
        public string lastName {  get; set; }
        public string Email {  get; set; }
        public string phoneNumber { get; set; }
        public string Address {  get; set; }

        //Constructor
        //Default Constructor
        public Customer()
        {
            customerID = 0;
            firstName = "";
            lastName = "";
            Email = "";
            phoneNumber = "";
            Address = "";
        }
        //Constructor Overload
        public Customer(int Id, string fname, string lname, string email, string phoneNo, string address)
        {
            customerID = Id;
            firstName = fname;
            lastName = lname;
            Email = email;
            phoneNumber = phoneNo;
            Address = address;
        }
    }
}
