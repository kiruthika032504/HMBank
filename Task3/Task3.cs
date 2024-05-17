namespace Task3
{
    internal class Task3
    {
        static void Main(string[] args)
        {
            #region TASK 3 - Loop Structures

            /* Task 3: Loop Structures

            You are responsible for calculating compound interest on savings accounts for bank customers. You
            need to calculate the future balance for each customer's savings account after a certain number of years.
            Tasks:
            1.Create a program that calculates the future balance of a savings account.
            2.Use a loop structure(e.g., for loop) to calculate the balance for multiple customers.
            3.Prompt the user to enter the initial balance, annual interest rate, and the number of years.
            4.Calculate the future balance using the formula: 
            future_balance = initial_balance * (1 + annual_interest_rate / 100) ^ years.
            5.Display the future balance for each customer. */

            // Calculating Future Balance of a Savings Account

            string[] Customers = { "Akash", "Cerina", "Dilip", "Sushila" };
            foreach (string Customer in Customers)
            {
                Console.WriteLine($"Dear {Customer}, Enter Your Initial Balance :: ");
                double initialBalance = double.Parse(Console.ReadLine());
                Console.WriteLine($"Dear {Customer}, Enter the Annual Interest Rate :: ");
                double interest_rate = double.Parse(Console.ReadLine());
                Console.WriteLine($"Dear {Customer}, Enter the Number of Years (to calaculate Interest) :: ");
                int years = int.Parse(Console.ReadLine());

                double future_balance = initialBalance * Math.Pow(1 + (interest_rate / 100), years);
                Console.WriteLine($" Dear {Customer}, Your Balance in {years} years would be :: {future_balance}\n");
            }

            #endregion
        }
    }
}
