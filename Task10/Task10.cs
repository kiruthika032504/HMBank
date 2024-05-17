using Task10.Model;
using Task10.Repository;

namespace Task10
{
    internal class Task10
    {
        static void Main(string[] args)
        {
            IBankAccount<Account> bank = new BankAccountRepository<Account>();
            BankAccountRepository<Account> bankAccount = new BankAccountRepository<Account>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select operation:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Balance");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        bankAccount.CreateAccount("Savings", 550250, "Sarah");
                        bankAccount.CreateAccount("Current", 82000, "Ajay");
                        break;
                    case 2:
                        bankAccount.Deposit(1001,5500);
                        break;
                    case 3:
                        bankAccount.Withdraw(1001, 2450);
                        break;
                    case 4:
                        bankAccount.Transfer(1001, 1002, 6000);
                        break;
                    case 5:
                        bankAccount.GetAccountBalance(1001);
                        bankAccount.GetAccountBalance(1002);
                        break;
                    case 6:
                        bankAccount.GetAccountDetails(1001);
                        bankAccount.GetAccountDetails(1002);
                        break;
                    case 7:
                        Console.WriteLine("Thankyou for using HMBank.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
