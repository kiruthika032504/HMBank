using Task13.BankApp;
using Task13.service;

namespace Task13
{
    internal class Task13
    {
        static void Main(string[] args)
        {
            IBankServiceProvider serviceProvider = new BankServiceProvider("Main Branch", "123, Main St");
            HMBankApp bankApp = new HMBankApp(serviceProvider);
            bankApp.Run();
        }
    }
}
