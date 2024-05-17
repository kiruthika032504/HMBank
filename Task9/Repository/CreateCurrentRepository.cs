using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Task9.Model;

namespace Task9.Repository
{
    internal class CreateCurrentRepository
    {
        public static void CreateCurrentAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name: ");
            string cusName = Console.ReadLine();

            Console.WriteLine("Enter Account Balance: ");
            double balance = double.Parse(Console.ReadLine());

            CurrentAccount current = new CurrentAccount(accNo, cusName, balance);
            Console.WriteLine("Account created successfully.");

            // Perform operations on the account
            current.Deposit(500);
            current.Withdraw(200);
            current.CalculateInterest();

        }
    }
}
