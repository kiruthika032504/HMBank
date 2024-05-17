using System.Data.SqlClient;
using Task14.Bean;
using Task14.Exception;
using Task14.Repository;
using Task14.Service;

namespace Task14.App
{
    internal class HMBankApp
    {
        readonly IBankRepository bankRepo;
        public HMBankApp()
        {
            bankRepo = new BankRepository();
        }
        public void Run()
        {
            BankRepository bankRepository = new BankRepository();
            bool menuLoop = false;
            bool loginLoop = false;
            while (!loginLoop)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.Write("\nEnter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int authChoice))
                {
                    switch (authChoice)
                    {
                        case 1:
                            Register(bankRepository);
                            break;
                        case 2:
                            if (Login(bankRepository))
                            {
                                loop = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid username or password. Please try again.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                if (loop)
                {
                    break;
                }
            }
            // Display menu options
            while (!menuLoop)
            {
                Console.WriteLine("\nBanking System Menu\n");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Balance");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Get Transactions");
                Console.WriteLine("9. Calulate Interest");
                Console.WriteLine("10. EXIT");
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateAccount(bankRepository);
                            break;
                        case 2:
                            Deposit(bankRepository);
                            break;
                        case 3:
                            Withdraw(bankRepository);
                            break;
                        case 4:
                            Transfer(bankRepository);
                            break;
                        case 5:
                            GetAccountBalance(bankRepository);
                            break;
                        case 6:
                            GetAccountDetails(bankRepository);
                            break;
                        case 7:
                            ListAccounts(bankRepository);
                            return;
                        case 8:
                            GetTransactions(bankRepository);
                            break;
                        case 9:
                            CalculateInterest(bankRepository);
                            break;
                        case 10:
                            loop = true;
                            Console.WriteLine("Thankyou for using HMBank!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }

                Console.WriteLine();
            }
        }

        static void CreateAccount(BankRepository bankRepository)
        {
            Console.WriteLine("\nEnter customer details:\n");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("DOB (YYYY-MM-DD): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
           
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dob,
                Email = email,
                Phone = phone,
                Address = address
            };

            Console.Write("Account Type (Savings/Current): ");
            string accountType = Console.ReadLine();
            Console.Write("Initial Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.CreateAccount(customer, accountType, balance);
                Console.WriteLine("Account created successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
        static void Deposit(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.Deposit(accountNumber, amount);
                Console.WriteLine("\nDeposit successful.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Withdraw(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.Withdraw(accountNumber, amount);
                Console.WriteLine("\nWithdrawal successful.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Transfer(BankRepository bankRepository)
        {
            Console.Write("\nEnter sender account number: ");
            long fromAccountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter recipient account number: ");
            long toAccountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter transfer amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.Transfer(fromAccountNumber, toAccountNumber, amount);
                Console.WriteLine("\nTransfer successful.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void GetAccountBalance(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            try
            {
                decimal balance = bankRepository.GetAccountBalance(accountNumber);
                Console.WriteLine("\nAccount balance: " + balance);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void GetAccountDetails(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            try
            {
                Account account = bankRepository.GetAccountDetails(accountNumber);
                Console.WriteLine("\nAccount details:");
                Console.WriteLine("Account Number: " + accountNumber);
                Console.WriteLine("Account Type: " + account.AccountType);
                Console.WriteLine("Balance: " + account.Balance);
                Console.WriteLine("Customer ID: " + account.Customer.CustomerId);
                Console.WriteLine("Customer Name: " + (account.Customer.FirstName + " " + account.Customer.LastName));
                Console.WriteLine("Email: " + account.Customer.Email);
                Console.WriteLine("Phone: " + account.Customer.Phone);
                Console.WriteLine("Address: " + account.Customer.Address);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ListAccounts(BankRepository bankRepository)
        {
            try
            {
                List<Account> accounts = bankRepository.ListAccounts();
                Console.WriteLine("\nList of Accounts:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"\nAccount Number: {account.AccountId}");
                    Console.WriteLine($"Account Type: {account.AccountType}");
                    Console.WriteLine($"Balance: {account.Balance}");
                    Console.WriteLine($"Customer ID: {account.Customer.CustomerId}");
                    Console.WriteLine($"Customer Name: {account.Customer.FirstName} {account.Customer.LastName}");
                    Console.WriteLine($"Email: {account.Customer.Email}");
                    Console.WriteLine($"Phone: {account.Customer.Phone}");
                    Console.WriteLine($"Address: {account.Customer.Address}");
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void GetTransactions(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter start date (yyyy-MM-dd): ");
            DateTime fromDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date (yyyy-MM-dd): ");
            DateTime toDate = DateTime.Parse(Console.ReadLine());

            try
            {
                List<Transaction> transactions = bankRepository.GetTransactions(accountNumber, fromDate, toDate);
                Console.WriteLine("Transactions:");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"\nTransaction ID: {transaction.TransactionId}");
                    Console.WriteLine($"Account Number: {transaction.AccountId}");
                    Console.WriteLine($"Transaction Type: {transaction.TransactionType}");
                    Console.WriteLine($"Amount: {transaction.TransactionAmount}");
                    Console.WriteLine($"Transaction Date: {transaction.TransactionDate}");
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void CalculateInterest(BankRepository bankRepository)
        {
            Console.Write("\nEnter account number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            try
            {
                decimal interest = bankRepository.CalculateInterest(accountNumber);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}
