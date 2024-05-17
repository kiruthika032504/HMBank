using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9.Model;

namespace Task9.Repository
{
    internal class CreateSavingsRepository
    {
        public static void CreateSavingsAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name: ");
            string cusName = Console.ReadLine();        

            Console.WriteLine("Enter Account Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Interest rate (e.g., 0.045 for 4.5%): ");
            double interest = double.Parse(Console.ReadLine());

            SavingsAccount savings = new SavingsAccount(accNo, cusName, balance, interest);
            Console.WriteLine("Account created successfully.");

            // Perform operations on Savings Account
            savings.Deposit(550);
            savings.Withdraw(240);
            savings.CalculateInterest();
        }
    }
}
