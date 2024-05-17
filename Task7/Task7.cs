using Task7.Model;
using Task7.Repository;
using System.Security.Principal;

namespace Task7
{
    internal class Task7
    {
        static void Main(string[] args)
        {

            #region Task7 : Classes and Objects

            #region Customer Class

            ICustomer customerRepo = new CustomerRepository();

            // Add a Customer
            Customer newCustomer = new Customer()
            {
                customerID = 1,
                firstName = "Martina",
                lastName = "McPherson",
                Email = "martinamcp@example.com",
                phoneNumber = "9762569012",
                Address = "123 Main St, Anytown, Chennai"
            };
            customerRepo.AddCustomer(newCustomer);

            //Get Customer by ID
            Customer getCustomer = customerRepo.GetCustomerByCustomerId(1);
            if (getCustomer != null)
            {
                Console.WriteLine($"Customer {getCustomer.customerID} data found!\n");
                Console.WriteLine($"Name :: {getCustomer.firstName + " " + getCustomer.lastName}\nEmail :: {getCustomer.Email}\nPhone :: {getCustomer.phoneNumber}\nAddress :: {getCustomer.Address} ");
            }
            else
            {
                Console.WriteLine("Customer does not exist!");
            }

            #endregion

            #region Account Class

            IAccount accountRepo = new AccountRepository();

            // Add an Account
            Account newAccount1 = new Account()
            {
                accountNumber = 1,
                accountType = "Savings",
                accountBalance = 550000
            };
            accountRepo.AddAccount(newAccount1);

            //Get Account by AccountNo
            Account getAccount = accountRepo.GetAccountByAccountNo(1);
            if (getAccount != null)
            {
                Console.WriteLine($"\n\nAccount {getAccount.accountNumber} data found!\n");
                Console.WriteLine($"Account Type :: {getAccount.accountType}\nBalance :: {getAccount.accountBalance} \n\n");
            }
            else
            {
                Console.WriteLine("Account does not exist!\n\n");
            }

            #endregion

            #region Transactions on Account

            // Create another Account
            Account newAccount2 = new Account(2, "Savings", 85900);
            // Deposit
            newAccount2.Deposit(550);
            // Withdraw
            newAccount2.Withdraw(1000);
            // Calculate Interest
            newAccount2.CalculateInterest();
            #endregion

            #endregion
        }
    }
}
