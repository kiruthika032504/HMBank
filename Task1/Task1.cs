namespace Task1
{
    internal class Task1
    {
        static void Main(string[] args)
        {
            #region TASK 1 - Conditional Statements // Loan Eligibility Check

            /* Task 1: Conditional Statements

            In a bank, you have been given the task is to create a program that checks if a customer is eligible for 
            a loan based on their credit score and income. The eligibility criteria are as follows:
                • Credit Score must be above 700.
                • Annual Income must be at least $50,000.
            Tasks:
                1. Write a program that takes the customer's credit score and annual income as input.
                2. Use conditional statements (if-else) to determine if the customer is eligible for a loan.
                3. Display an appropriate message based on eligibility.*/

            // Loan Eligibility Check

            // Getting Customer Name

            Console.Write("Enter your Name :: ");
            string name = Console.ReadLine();

            // Getting the Customer's Credit Score
            Console.Write($"{name} - Enter your Credit Score :: ");
            float creditScore = float.Parse(Console.ReadLine());

            //Getting the Customer's Credit Score
            Console.Write($"{name} - Enter your Annual Income :: ");
            double annualIncome = double.Parse(Console.ReadLine());

            //Check for Loan Eligibility
            if (creditScore > 700 & annualIncome >= 50000)
            {
                Console.WriteLine($"Dear {name}, \nCongratulations! You're eligible for applying loan at HMBank");
            }
            else
            {
                Console.WriteLine($"Dear {name}, \nWe are sorry to inform that you are not eligible for loan at HMBank");
            }

            #endregion
        }
    }
}
