using HMBank.Model;
using HMBank.Repository;

namespace HMBank
{
    internal class HMBank
    {
        static void Main(string[] args)
        {
            
            #region Task8 : Inheritance and Polymorphism

            // Create Menu
            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    CreateSavingsAccount();
                    break;
                case 2:
                    CreateCurrentAccount();
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

            #endregion

            #region Task9 : Abstraction

            #endregion
        }       
    }
}
