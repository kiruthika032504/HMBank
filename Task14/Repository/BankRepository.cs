using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Task14.Bean;
using Task14.Exception;
using Task14.Service;
using Task14.Utility;

namespace Task14.Repository
{

    public class BankRepository : IBankRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public BankRepository()
        {
            // sqlConnection = new SqlConnection("Server=DESKTOP-L411A1U;Database=HMBank;Trusted_Connection=True");

            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        public Customer GetCustomerById(int customerId)
        {
            cmd.CommandText = "SELECT * FROM Customers WHERE CustomerId = @CustomerIdGetC";
            cmd.Parameters.AddWithValue("@CustomerIdGetC", customerId);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                    return customer;
                }
                else
                {
                    return null; // Customer not found
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void CreateAccount(Customer customer, string accType, decimal balance)
        {
            using (SqlConnection connection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                // Open the connection
                connection.Open();

                // Start a transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert customer
                    string insertCustomerQuery = "INSERT INTO Customers (FirstName, LastName, DOB, Email, Phone, Address) " +
                                                 "VALUES (@FirstName, @LastName, @DOB, @Email, @Phone, @Address);" +
                                                 "SELECT SCOPE_IDENTITY();"; // Retrieve the generated CustomerId
                    SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, connection, transaction);
                    insertCustomerCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    insertCustomerCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                    insertCustomerCommand.Parameters.AddWithValue("@DOB", customer.DOB);
                    insertCustomerCommand.Parameters.AddWithValue("@Email", customer.Email);
                    insertCustomerCommand.Parameters.AddWithValue("@Phone",customer.Phone);
                    insertCustomerCommand.Parameters.AddWithValue("@Address", customer.Address);

                    // Set the connection for the customer command
                    insertCustomerCommand.Connection = connection;

                    // Execute the insert command and get the generated CustomerId
                    int customerId = Convert.ToInt32(insertCustomerCommand.ExecuteScalar());

                    // Insert account
                    string insertAccountQuery = "INSERT INTO Accounts (AccountType, Balance, CustomerId) " +
                                                "VALUES ( @AccountType, @Balance, @CustomerId)";
                    SqlCommand insertAccountCommand = new SqlCommand(insertAccountQuery, connection, transaction);
                    insertAccountCommand.Parameters.AddWithValue("@AccountType", accType);
                    insertAccountCommand.Parameters.AddWithValue("@Balance", balance);
                    insertAccountCommand.Parameters.AddWithValue("@CustomerId", customerId);

                    // Set the connection for the account command
                    insertAccountCommand.Connection = connection;

                    // Execute the insert command for the account
                    insertAccountCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();

                    Console.WriteLine("Insertion successful.");
                }
                catch (SqlException ex)
                {
                    // Rollback the transaction on error
                    transaction.Rollback();
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }
        }

        public List<Account> ListAccounts()
        {
            List<Account> accounts = new List<Account>();
            List<Customer> customers = new List<Customer>();
            cmd.CommandText = "SELECT A.*, C.* FROM Accounts A, Customers C";

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Create Customer object
                    Customer customer = new Customer();
                    customer.CustomerId = (int)reader["CustomerId"];
                    customer.FirstName = reader["FirstName"].ToString();
                    customer.LastName = reader["LastName"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Address = reader["Address"].ToString();
                    customers.Add(customer);


                    // Create Account object and add to the list
                    Account account = new Account
                    {
                        AccountId = Convert.ToInt32(reader["AccountId"]),
                        AccountType = reader["AccountType"].ToString(),
                        Balance = Convert.ToDecimal(reader["Balance"]),
                        Customer = customer
                    };
                    accounts.Add(account);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine("SQL Error: " + ex.Message);
                throw; // Rethrow the exception to maintain the stack trace
            }
            finally
            {
                sqlConnection.Close();
            }

            return accounts;
        }


        public decimal GetAccountBalance(long accountNumber)
        {
            cmd.CommandText = "SELECT Balance FROM Accounts WHERE AccountId = @AccountIdB";
            cmd.Parameters.AddWithValue("@AccountIdB", accountNumber);

            try
            {
                sqlConnection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                throw new InvalidAccountException("Account not found");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw; // Rethrow the exception to maintain the stack trace
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            cmd.CommandText = "UPDATE Accounts SET Balance = Balance + @DepositAmount WHERE AccountId = @AccountIdD";
            cmd.Parameters.AddWithValue("@DepositAmount", amount);
            cmd.Parameters.AddWithValue("@AccountIdD", accountNumber);

            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw ex; // Rethrow the exception to maintain the stack trace
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Withdraw(long accountNumber, decimal amount)
        {
            cmd.CommandText = "UPDATE Accounts SET Balance = Balance - @WithdrawAmount WHERE AccountId = @AccountIdW AND Balance >= @WithdrawAmount";
            cmd.Parameters.AddWithValue("@WithdrawAmount", amount);
            cmd.Parameters.AddWithValue("@AccountIdW", accountNumber);

            try
            {
                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("Insufficient balance");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw ex; // Rethrow the exception to maintain the stack trace
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            // Start a transaction for atomicity
            SqlTransaction transaction = null;
            try
            {
                sqlConnection.Open();
                transaction = sqlConnection.BeginTransaction();

                // Withdraw from sender account
                Withdraw(fromAccountNumber, amount, sqlConnection, transaction);

                // Deposit into receiver account
                Deposit(toAccountNumber, amount, sqlConnection, transaction);

                // Commit transaction if successful
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                // Rollback transaction on failure
                transaction?.Rollback();
                Console.WriteLine("SQL Error: " + ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();

            }
        }

        private void Withdraw(long accountNumber, decimal amount, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountId = @AccountIdWith AND Balance >= @Amount";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@AccountIdWith", accountNumber);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new InvalidOperationException("Insufficient balance");
            }
        }

        private void Deposit(long accountNumber, decimal amount, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountId = @AccountIdDepo";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@AccountIdDepo", accountNumber);

            command.ExecuteNonQuery();
        }
        public Account GetAccountDetails(long accountNumber)
        {
            Account account = null;
            cmd.CommandText = "SELECT A.*, C.* " +
                              "FROM Accounts A " +
                              "JOIN Customers C ON A.CustomerId = C.CustomerId " +
                              "WHERE A.AccountId = @AccountIdG";
            cmd.Parameters.AddWithValue("@AccountIdG", accountNumber);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };

                    account = new Account
                    {
                        AccountType = reader["AccountType"].ToString(),
                        Balance = Convert.ToDecimal(reader["Balance"]),
                        Customer = customer
                    };
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return account;
        }

        public List<Transaction> GetTransactions(long accNo, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            cmd.CommandText = "SELECT * FROM Transactions WHERE TransactionDate BETWEEN @FromDate AND @ToDate AND AccountId = @AccountIdT";

            cmd.Parameters.AddWithValue("@AccountIdT", accNo);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = Convert.ToInt32(reader["TransactionId"]),
                        AccountId = Convert.ToInt64(reader["AccountId"]),
                        TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),
                        TransactionType = reader["TransactionType"].ToString(),
                        TransactionAmount = Convert.ToDecimal(reader["Amount"])
                    };
                    transactions.Add(transaction);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return transactions;
        }

        public decimal CalculateInterest(long accountNumber)
        {
            cmd.CommandText = "SELECT Balance, InterestRate FROM Accounts WHERE AccountId = @AccountIdC";
            cmd.Parameters.AddWithValue("@AccountIdC", accountNumber);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    decimal balance = Convert.ToDecimal(reader["Balance"]);
                    decimal interest = (decimal) reader["InterestRate"];
                    decimal interestCalculated = balance * (interest / 100); // Convert interest rate from percentage to decimal
                    decimal newBalance = balance + interestCalculated;
                    Console.WriteLine($"Calculated Interest : {interestCalculated}. New Balance : {newBalance}");
                    return interestCalculated;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return 1;
        }
    }
}



