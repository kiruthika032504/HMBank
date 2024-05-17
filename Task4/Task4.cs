namespace Task4
{
    internal class Task4
    {
        static void Main(string[] args)
        {
            #region TASK 4 - Looping, Array and Data Validation
            
            /* Task 4: Looping, Array and Data Validation
            You are tasked with creating a program that allows bank customers to check their account balances. 
            The program should handle multiple customer accounts, and the customer should be able to enter their
            account number, balance to check the balance.
            Tasks:
            1.Create a Python program that simulates a bank with multiple customer accounts.
            2.Use a loop(e.g., while loop) to repeatedly ask the user for their account number and
            balance until they enter a valid account number.
            3.Validate the account number entered by the user.
            4.If the account number is valid, display the account balance.If not, ask the user to try again. */

            string[] accountNumber = new string[] { "6369453490", "6589236901", "6893672906", "6429645590", "6358923680" };
            string[] customerName = new string[] { "Reshma", "Joseph", "Rahul", "Swetha", "Nisha" };
            string[] accountBalance = new string[] { "55890", "60230", "500000", "7000", "15900" };


            bool checkMatch = false;
            while (!checkMatch)
            {
                Console.WriteLine("Enter your Account Number : ");
                string accNo = Console.ReadLine();
                for (int i = 0; i < accountNumber.Length; i++)
                {
                    if (accNo == accountNumber[i])
                    {
                        Console.WriteLine($"Dear {customerName[i]}, Your Balance is : {accountBalance[i]}");
                        checkMatch = true;
                    }
                }
                if (!checkMatch)
                {
                    Console.WriteLine("Invalid Account Number! Re-enter the correct account number.");
                }
            }

            #endregion
        }
    }
}
