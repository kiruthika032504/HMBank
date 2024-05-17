namespace Task6
{
    internal class Task6
    {
        static void Main(string[] args)
        {
            #region TASK 6 - Transaction History

            /* Task 6: Password Validation
            Create a program that maintains a list of bank transactions(deposits and withdrawals) for a customer. 
            Use a while loop to allow the user to keep adding transactions until they choose to exit.Display the
            transaction history upon exit using looping statements.*/

            List<(string transactionType, int amount, int balance)> transactionHistory = new List<(string, int, int)>();
            int accBalance = 0;
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. EXIT \n");

            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("Enter your Choice :: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the amount to Deposit :: ");
                        int depositAmount = int.Parse(Console.ReadLine());
                        if (accBalance == 0)
                        {
                            accBalance = accBalance + depositAmount;
                            transactionHistory.Add(("Deposit", depositAmount, accBalance));
                        }
                        else if (accBalance != 0)
                        {
                            accBalance = accBalance + depositAmount;
                            transactionHistory.Add(("Deposit", depositAmount, accBalance));
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the amount to Withdraw :: ");
                        int withdrawalAmount = int.Parse(Console.ReadLine());
                        if (withdrawalAmount < accBalance)
                        {
                            accBalance = accBalance - withdrawalAmount;
                            transactionHistory.Add(("Withdrawal", withdrawalAmount, accBalance));
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance!");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Thanks for using HMBank!");
                        Console.WriteLine($"Your Current Account Balance is :: {accBalance} \n\n");

                        Console.WriteLine("-- TRANSACTION HISTORY --\n\n");
                        Console.WriteLine("TransType Amount Balance");
                        foreach (var transaction in transactionHistory)
                        {
                            Console.WriteLine(transaction.ToString());
                        }
                        loop = true;
                        break;
                }
            }

            #endregion
        }
    }
}
