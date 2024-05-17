using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Model;

namespace Task8.Repository
{
    internal class CreateCurrentRepository
    {
        public static void CreateCurrentAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            string accType = "Savings";

            Console.WriteLine("Enter Account Balance: ");
            double balance = double.Parse(Console.ReadLine());

            CurrentAccount current = new CurrentAccount(accNo, accType, balance);
            Console.WriteLine("Account created successfully.");

            // Perform operations on Current Account
            current.Deposit(1550);
            current.Withdraw(1240);
        }
    }
}
