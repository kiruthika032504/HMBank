using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task11.bean;
using Task11.service;

namespace Task11.BankApp
{
    internal class HMBankApp
    {
        BankServiceProvider bankService = new BankServiceProvider("Main Branch","123, Main St");
        CustomerServiceProvider customerService = new CustomerServiceProvider();
        private IBankServiceProvider serviceProvider;

        public HMBankApp(IBankServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            Account account = new Account();

            bool exitLoop = false;
            while(!exitLoop)
            {
                Console.WriteLine("\nBank Account Operations:\n");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Account Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. EXIT");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nChoose Account Typpe:\n");
                        Console.WriteLine("1. Savings Account");
                        Console.WriteLine("2. Current Account");
                        Console.WriteLine("3. Zero Balance Account");
                        Console.WriteLine("4. EXIT");

                        int typeChoice = int.Parse(Console.ReadLine());
                        Customer customer1 = new Customer(101, "Rita", "Jospeh", "ritajospeh@gmail.com", "9823756890", "123, Steep St");
                        Customer customer2 = new Customer(102, "Jospeh", "Antony", "antonyjospeh@gmail.com", "9234780122", "123, Steep St");
                        Account newAccount1 = new Account("Savings", 525000, customer1);
                        Account newAccount2 = new Account("Current",2505020, customer2);
                        switch(typeChoice)
                        {
                            case 1:
                                bankService.CreateAccount(customer1, "Savings", 525000);
                                bankService.CreateAccount(customer2, "Savings", 1299000);
                                Console.WriteLine("Savings Account created successfully");
                                break;
                            case 2:
                                bankService.CreateAccount(customer1, "Current", 1250040);
                                bankService.CreateAccount(customer2, "Current", 5000500);
                                Console.WriteLine("Current Account created successfully");
                                break;
                            case 3:
                                bankService.CreateAccount(customer2, "ZeroBalance", 50000);
                                Console.WriteLine("Zero Balance Account created successfully");
                                break;
                            case 4:                               
                                break;
                            default:
                                Console.WriteLine("invalid choice");
                                break;

                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Enter Account Number:");
                        long accNo = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Deposit Amount: ");
                        float amount = float.Parse(Console.ReadLine());
                        if(account.AccountNumber == accNo)
                        {
                            float newAmount = account.Balance + amount;
                            customerService.Deposit(accNo, newAmount);
                        }
                        else
                        {
                            customerService.Deposit(accNo, amount);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Account Number:");
                        long accNo1 = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Withdraw Amount: ");
                        float amount1 = float.Parse(Console.ReadLine());
                        customerService.Withdraw(accNo1, amount1);
                        break;
                    case 4:
                        Console.WriteLine("Enter Account Number:");
                        long accNo2 = long.Parse(Console.ReadLine());
                        customerService.GetAccountBalance(accNo2);
                        break;
                    case 5:
                        Console.WriteLine("Enter Account Number from which amount must be withdrawn:");
                        long fAccNo = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Account Number to which amount must be deposited:");
                        long tAccNo = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Amount: ");
                        float amount2 = float.Parse(Console.ReadLine());
                        customerService.Transfer(fAccNo,tAccNo,amount2);
                        break;
                    case 6:
                        Console.WriteLine("Enter Account Number:");
                        long accNo3 = long.Parse(Console.ReadLine());
                        bankService.GetAccountDetails(accNo3);
                        break;
                    case 7:
                        bankService.ListAccounts();
                        break;
                    case 8:
                        Console.WriteLine("Thankyou for using HMBank");
                        exitLoop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice of Operation");
                        break;
                }
            }
        }
    }
}
