using System.Security.Principal;
using Task9.Model;
using Task9.Repository;

namespace Task9
{
    internal class Task9
    {
        static void Main(string[] args)
        {
            #region Task9 : Abstraction

            IBankAccount<BankAccount> accountRepository = new BankAccountRepository<BankAccount>();

            while (true)
            {
                Console.WriteLine("\nSelect operation:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());
                SavingsAccount savings = new SavingsAccount();
                switch (choice)
                {
                    case 1:
                        CreateAccountMenu(accountRepository);
                        break;
                    case 2:
                        savings.Deposit(1250);
                        break;
                    case 3:
                        savings.Withdraw(500);
                        break;
                    case 4:
                        Console.WriteLine("Thankyou for using HMBank.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            #endregion
        }

        public static void CreateAccountMenu(IBankAccount<BankAccount> accountRepository)
        {
            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. EXIT");

            int choice = int.Parse(Console.ReadLine());

            BankAccount account = null;

            switch (choice)
            {
                case 1:
                    CreateSavingsRepository.CreateSavingsAccount();
                    break;
                case 2:
                    CreateCurrentRepository.CreateCurrentAccount();
                    break;
                case 3:
                    Console.WriteLine("Thankyou for using HMBank");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
