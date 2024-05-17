using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task14.Model;

namespace Task14.Repository
{
    internal class BankRepository : IBankRepository
    {
        private SqlConnection connection;

        public BankRepository()
        {
            connection = DBUtil.getDBConn(); // Establish database connection
        }

        public void CreateAccount(Customer customer, long accNo, string accType, decimal balance)
        {
            try
            {
                // Database logic to create account
                string query = "INSERT INTO Accounts (AccountNumber, AccountType, Balance, CustomerID) VALUES (@AccountNumber, @AccountType, @Balance, @CustomerID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accNo);
                    command.Parameters.AddWithValue("@AccountType", accType);
                    command.Parameters.AddWithValue("@Balance", balance);
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerId); // Assuming CustomerID is the foreign key in Accounts table
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error creating account: " + ex.Message);
            }
        }

        public List<Account> ListAccounts()
        {
            List<Account> accounts = new List<Account>();
            try
            {
                // Database logic to retrieve accounts
                string query = "SELECT * FROM Accounts";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Account account = new Account
                            {
                                AccountNumber = (long)reader["AccountNumber"],
                                AccountType = (string)reader["AccountType"],
                                Balance = (decimal)reader["Balance"],
                                Customer = GetCustomerById((int)reader["CustomerID"]) // Assuming there's a method to retrieve customer details
                            };
                            accounts.Add(account);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error listing accounts: " + ex.Message);
            }
            return accounts;
        }

        public string GetAccountDetails(long accountNumber)
        {
            string accountDetails = "";
            try
            {
                // Database logic to retrieve account details
                string query = "SELECT * FROM Accounts WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Account account = new Account
                            {
                                AccountNumber = (long)reader["AccountNumber"],
                                AccountType = (string)reader["AccountType"],
                                Balance = (decimal)reader["Balance"],
                                Customer = GetCustomerById((int)reader["CustomerID"]) // Assuming there's a method to retrieve customer details
                            };
                            accountDetails = $"Account Number: {account.AccountNumber}, Account Type: {account.AccountType}, Balance: {account.Balance}, Customer: {account.Customer.FirstName} {account.Customer.LastName}";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error getting account details: " + ex.Message);
            }
            return accountDetails;
        }

        public decimal CalculateInterest()
        {
            decimal totalInterest = 0;
            try
            {
                // Database logic to calculate interest
                // Example: SELECT SUM(Interest) FROM Accounts WHERE AccountType = 'Savings'
                string query = "SELECT SUM(Interest) FROM Accounts WHERE AccountType = 'Savings'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalInterest = (decimal)result;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error calculating interest: " + ex.Message);
            }
            return totalInterest;
        }

        public decimal GetAccountBalance(long accountNumber)
        {
            decimal balance = 0;
            try
            {
                // Database logic to retrieve account balance
                string query = "SELECT Balance FROM Accounts WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        balance = (decimal)result;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error getting account balance: " + ex.Message);
            }
            return balance;
        }

        public decimal Deposit(long accountNumber, decimal amount)
        {
            try
            {
                // Database logic to deposit amount
                string query = "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.ExecuteNonQuery();
                }
                return GetAccountBalance(accountNumber); // Return updated balance
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error depositing amount: " + ex.Message);
            }
        }

        public decimal Withdraw(long accountNumber, decimal amount)
        {
            try
            {
                // Database logic to withdraw amount
                string query = "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.ExecuteNonQuery();
                }
                return GetAccountBalance(accountNumber); // Return updated balance
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error withdrawing amount: " + ex.Message);
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            try
            {
                // Database logic to transfer amount from one account to another
                // Assuming atomic transaction with rollback on failure
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Withdraw(fromAccountNumber, amount); // Withdraw from source account
                        Deposit(toAccountNumber, amount); // Deposit to destination account
                        transaction.Commit(); // Commit the transaction if successful
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // Rollback transaction on failure
                        throw; // Rethrow the exception
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error transferring amount: " + ex.Message);
            }
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                // Database logic to retrieve transactions between two dates for an account
                string query = "SELECT * FROM Transactions WHERE AccountNumber = @AccountNumber AND TransactionDate BETWEEN @FromDate AND @ToDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction transaction = new Transaction
                            {
                                Account = GetAccountDetails(accountNumber),
                                Description = (string)reader["Description"],
                                DateTime = (DateTime)reader["TransactionDate"],
                                TransactionType = (string)reader["TransactionType"],
                                TransactionAmount = (decimal)reader["TransactionAmount"]
                            };
                            transactions.Add(transaction);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error getting transactions: " + ex.Message);
            }
            return transactions;
        }

        private Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            try
            {
                string query = "SELECT FirstName, LastName FROM Customers WHERE CustomerID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"]
                                // Add other customer attributes as needed
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error getting customer details: " + ex.Message);
            }
            return customer;
        }

    }

}
