using Task8.Model;
using Task8.Repository;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task8 : Inheritance and Polymorphism

            // Create Menu
            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateSavingsRepository.CreateSavingsAccount();
                    break;
                case 2:
                    CreateCurrentRepository.CreateCurrentAccount();
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

            #endregion
        }
    }
}
