using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Model;

namespace Task8.Repository
{
    internal class CreateSavingsRepository
    {
        public static void CreateSavingsAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            string accType = "Savings";

            Console.WriteLine("Enter Account Balance: ");
            double balance = double.Parse(Console.ReadLine());

            SavingsAccount savings = new SavingsAccount(accNo, accType, balance);
            Console.WriteLine("Account created successfully.");

            // Perform operations on Savings Account
            savings.Deposit(550);
            savings.Withdraw(240);
            savings.CalculateInterest();
        }
    }
}
