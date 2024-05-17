namespace Task2
{
    internal class Task2
    {
        static void Main(string[] args)
        {
            #region TASK 2 - Nested Conditional Statements

            /* Task 2: Nested Conditional Statements

            Create a program that simulates an ATM transaction. Display options such as "Check Balance," 
            "Withdraw," "Deposit,". Ask the user to enter their current balance and the amount they want to 
            withdraw or deposit. Implement checks to ensure that the withdrawal amount is not greater than the 
            available balance and that the withdrawal amount is in multiples of 100 or 500. Display appropriate 
            messages for success or failure.*/

            //ATM Transactions

            double balance = 12000;

            while (true)
            {
                Console.WriteLine("\nEnter your Choice of Operation :: ");
                Console.WriteLine(" 1. Check Balance");
                Console.WriteLine(" 2. Withdraw");
                Console.WriteLine(" 3. Deposit");
                Console.WriteLine(" 4. EXIT");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(balance);
                        break;

                    case 2:
                        Console.Write("Enter amount for Withdrawal :: ");
                        int withdrawalAmount = int.Parse(Console.ReadLine());
                        if (withdrawalAmount < balance)
                        {
                            if (withdrawalAmount % 100 == 0 | withdrawalAmount % 500 == 0)
                            {
                                balance = balance - withdrawalAmount;
                                Console.WriteLine("Amount withdrawal successfully done!");
                                Console.WriteLine($"Reporting Current Balance :: {balance}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance");
                        }
                        break;

                    case 3:
                        Console.Write("Enter amount to Deposit :: ");
                        int depositAmount = int.Parse(Console.ReadLine());
                        balance = balance + depositAmount;
                        Console.WriteLine("Amount successfully Deposited!");
                        Console.WriteLine($"Reporting Current Balance :: {balance}");
                        break;
                    case 4:
                        Console.WriteLine("Thankyou for using our ATM. GoodBye!");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }

            #endregion
        }
    }
}
