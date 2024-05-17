using System.Runtime.CompilerServices;
using Task11.service;
using Task11.BankApp;

namespace Task11
{
    internal class Task11
    {
        static void Main(string[] args)
        {
            IBankServiceProvider serviceProvider = new BankServiceProvider("Main Branch", "123, Main St");
            HMBankApp bankApp = new HMBankApp(serviceProvider);
            bankApp.Run();
        }
    }
}
