--------------------------- TASK 1 - Database Design -------------------------------------------------
-- Create the database named "HMBank"
CREATE DATABASE HMBank
-- Use Database
USE HMBank
-- Define the schema for the Customers, Accounts, and Transactions tables based on the provided schema
CREATE TABLE Customers(
customer_id INT IDENTITY(1,1) not null PRIMARY KEY,
first_name VARCHAR(50) not null,
last_name VARCHAR(50),
DOB DATE,
Email VARCHAR(50), 
phone_number VARCHAR(10) not null, 
[address] VARCHAR(250) not null)

CREATE TABLE Accounts(
account_id INT IDENTITY(101,1) not null PRIMARY KEY,
customer_id INT FOREIGN KEY REFERENCES Customers(customer_id), --- Create Foreign Key constraints for referential integrity.
account_type VARCHAR(50),
balance INT)

CREATE TABLE Transactions(
transaction_id INT IDENTITY(1001,1) not null PRIMARY KEY,
account_id INT FOREIGN KEY REFERENCES Accounts(account_id),
transaction_type VARCHAR(50),
amount INT,
transaction_date DATE)

-------------------- TASK 2 - Select, Where, Between, AND, LIKE --------------------------------

-- I. a) Insert at least 10 sample records into each of the following tables - Customer
INSERT INTO Customers(first_name,last_name,DOB,Email,phone_number,[address]) 
VALUES
('John', 'Doe', '1990-05-15', 'john.doe@example.com', '1234567890', '123 Main St'),
('Alice', 'Smith', '1985-09-20', 'alice.smith@example.com', '2345678901', '456 Elm St'),
('Michael', 'Johnson', '1978-03-10', 'michael.johnson@example.com', '3456789012', '789 Oak St'),
('Emily', 'Brown', '1995-07-25', 'emily.brown@example.com', '4567890123', '987 Maple St'),
('David', 'Lee', '1980-01-05', 'david.lee@example.com', '5678901234', '654 Pine St'),
('Sarah', 'Wilson', '1992-11-12', 'sarah.wilson@example.com', '6789012345', '321 Cedar St'),
('Jessica', 'Taylor', '1987-04-30', 'jessica.taylor@example.com', '7890123456', '135 Walnut St'),
('Matthew', 'Anderson', '1970-08-08', 'matthew.anderson@example.com', '8901234567', '246 Birch St'),
('Samantha', 'Martinez', '1983-12-18', 'samantha.martinez@example.com', '9012345678', '579 Spruce St'),
('Daniel', 'Garcia', '1998-06-22', 'daniel.garcia@example.com', '0123456789', '798 Fir St')

-- Setting Constraint for Account Type
ALTER TABLE Accounts
ADD CONSTRAINT CK_Accounts_AccType
CHECK(account_type IN('Savings','Current','Zero_Balance'))

-- b) Insert at least 10 sample records into each of the following tables - Accounts
INSERT INTO Accounts(customer_id,account_type,balance)
VALUES
(1,'Zero_Balance', 5000),
(2,'Current', 7000),
(2,'Savings', 5800),
(2,'Zero_Balance', 4300),
(3,'Savings', 3000),
(4,'Zero_Balance', 6000),
(5,'Savings', 4000),
(5,'Current', 9000),
(6,'Current', 8000),
(7,'Savings', 2000),
(8,'Zero_Balance', 9000),
(8,'Current', 3500),
(8,'Savings', 7400),
(9,'Savings', 1000),
(10,'Current', 7500)

-- Setting Constraint for Transaction Type
ALTER TABLE Transactions
ADD CONSTRAINT CK_Transactions_TrscType
CHECK(transaction_type IN('Deposit','Withdrawal','Transfer'))

-- c) Insert at least 10 sample records into each of the following tables - Transactions
INSERT INTO Transactions(account_id,transaction_type,amount,transaction_date)
VALUES
(101,'Deposit', 1000, '2024-04-01'),
(102,'Transfer', 500, '2024-04-02'),
(102,'Deposit', 1500, '2024-04-02'),
(102,'Withdrawal', 750, '2024-04-02'),
(103,'Deposit', 1500, '2024-04-03'),
(104,'Withdrawal', 700, '2024-04-04'),
(105,'Deposit', 2000, '2024-04-05'),
(106,'Withdrawal', 1200, '2024-04-06'),
(107,'Transfer', 800, '2024-04-07'),
(108,'Withdrawal', 900, '2024-04-08'),
(108,'Deposit', 900, '2024-04-08'),
(109,'Deposit', 600, '2024-04-09'),
(110,'Transfer', 750, '2024-04-10')

-- Display the table content
SELECT * FROM Customers
SELECT * FROM Accounts
SELECT * FROM Transactions

-- II. Write SQL queries for the following tasks:

-- 1. Write a SQL query to retrieve the name, account type and email of all customers.

SELECT CONCAT(c.first_name, ' ', c.last_name) AS [Name], c.Email, a.account_type
FROM Customers c
LEFT JOIN Accounts a 
ON c.customer_id = a.customer_id

-- 2. Write a SQL query to list all transaction corresponding customer.

SELECT c.*, t.* FROM Transactions t
JOIN Accounts a
ON t.account_id = a.account_id
JOIN Customers c
ON c.customer_id = a.customer_id

-- 3. Write a SQL query to increase the balance of a specific account by a certain amount.

UPDATE Accounts
SET balance = balance + 1520
WHERE balance BETWEEN 4000 AND 8000

-- 4. Write a SQL query to Combine first and last names of customers as a full_name.

SELECT CONCAT(first_name,' ',last_name) AS [Name] FROM Customers

-- 5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.

DELETE FROM Accounts 
WHERE balance = 0 
AND account_type = 'Savings'

-- 6. Write a SQL query to Find customers living in a specific city.

ALTER TABLE Customers
ADD City VARCHAR(30)

UPDATE Customers
SET City = 'Chennai' 
WHERE customer_id IN(1,3,5)
UPDATE Customers
SET City = 'Hyderabad' 
WHERE customer_id IN(4,8)
UPDATE Customers
SET City = 'Mumbai' 
WHERE customer_id IN(2,7)
UPDATE Customers
SET City = 'Bangalore' 
WHERE customer_id IN(6,10)
UPDATE Customers
SET City = 'Delhi' 
WHERE customer_id=9

SELECT * FROM Customers
WHERE City = 'Chennai'

-- 7. Write a SQL query to Get the account balance for a specific account.

SELECT balance FROM Accounts
WHERE account_id = 104

-- 8. Write a SQL query to List all current accounts with a balance greater than $1,000.

SELECT * FROM Accounts
WHERE balance > 1000 AND account_type = 'Current'

-- 9. Write a SQL query to Retrieve all transactions for a specific account.

SELECT * FROM Transactions
WHERE transaction_id = 1006

-- 10. Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.

ALTER TABLE Accounts
ADD interest_rate DECIMAL(4,2)

UPDATE Accounts
SET interest_rate = 15.67
WHERE account_type = 'Savings'

UPDATE Accounts
SET interest_rate = 10.72
WHERE account_type = 'Current'

UPDATE Accounts
SET interest_rate = 5.97
WHERE account_type = 'Zero_Balance'

SELECT account_id, balance * interest_rate / 100 AS interest_accrued FROM Accounts
WHERE account_type = 'Savings'

-- 11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.

SELECT * FROM Accounts AS acc
WHERE acc.balance < 5000;

-- 12. Write a SQL query to Find customers not living in a specific city.

SELECT * FROM Customers
WHERE City != 'Chennai'

-------------------- TASK 3 - Aggregate functions, Having, Order By, GroupBy and Joins --------------------------------

-- 1. Write a SQL query to Find the average account balance for all customers.

SELECT Customers.first_name, Customers.last_name, AVG(balance) AS AverageBalance
FROM Accounts
JOIN Customers
ON Accounts.customer_id = Customers.customer_id
GROUP BY Customers.first_name, Customers.last_name, Customers.customer_id

-- 2. Write a SQL query to Retrieve the top 10 highest account balances.

SELECT TOP 10 balance 
FROM Accounts
ORDER BY balance DESC;

-- 3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.

SELECT transaction_date, SUM(amount) AS TotalDeposits
FROM Transactions
WHERE transaction_date = '2024-04-02' AND transaction_type = 'Deposit'
GROUP BY transaction_date

-- 4. Write a SQL query to Find the Oldest and Newest Customers.

SELECT TOP 1 * FROM Customers
ORDER BY customer_id ASC -- Oldest Customer

SELECT TOP 1 * FROM Customers
ORDER BY customer_id DESC -- Newest Customer

-- 5. Write a SQL query to Retrieve transaction details along with the account type.

SELECT t.*, a.account_type FROM Transactions t
LEFT JOIN Accounts a
ON t.account_id = a.account_id

-- 6. Write a SQL query to Get a list of customers along with their account details.

SELECT C.customer_id, CONCAT(C.first_name,' ', C.last_name) AS [Name], A.*
FROM Customers C
RIGHT JOIN Accounts A
ON A.customer_id = C.customer_id

-- 7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.

SELECT T.*, C.* FROM Transactions T
JOIN Accounts A
ON T.account_id = A.account_id
JOIN Customers C
ON C.customer_id = A.customer_id
WHERE T.amount BETWEEN 1000 AND 4000

-- 8. Write a SQL query to Identify customers who have more than one account.

SELECT customer_id, COUNT(account_id) AS AccountCount
FROM Accounts
GROUP BY customer_id
HAVING COUNT(account_id) > 1

-- 9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.

SELECT 
(SELECT SUM(amount) FROM Transactions WHERE transaction_type = 'Deposit') - 
(SELECT SUM(amount) FROM Transactions WHERE transaction_type = 'Withdrawal')
AS Differences

-- 10. Write a SQL query to Calculate the average daily balance for each account over a specified period.

SELECT A.account_id, AVG(balance) AS AverageDailyBalance
FROM Accounts A
JOIN Transactions T
ON A.account_id = T.account_id
WHERE T.transaction_date BETWEEN '2024-04-02' AND '2024-04-06'
GROUP BY A.account_id

-- 11. Calculate the total balance for each account type.

SELECT account_type,SUM(balance) AS TotalBalance
FROM Accounts 
GROUP BY account_type

-- 12. Identify accounts with the highest number of transactions order by descending order.

SELECT TOP 1 COUNT(account_id) AS HighestTransaction FROM Transactions
GROUP BY account_id
ORDER BY HighestTransaction DESC

-- 13. List customers with high aggregate account balances, along with their account types.

SELECT C.customer_id, C.first_name, C.last_name,A.account_type, SUM(A.balance) AS AggregateBalance
FROM Customers C
JOIN Accounts A
ON C.customer_id = A.customer_id
GROUP BY C.customer_id, C.first_name, C.last_name, A.account_type
HAVING SUM(A.balance) > 5000
ORDER BY AggregateBalance DESC

-- 14. Identify and list duplicate transactions based on transaction amount, date, and account.

SELECT account_id, amount, transaction_date FROM Transactions
GROUP BY amount, transaction_date, account_id
HAVING COUNT(*) > 1
ORDER BY amount, transaction_date, account_id

--------------------------------- TASK 4 - Subquery and its type ------------------------------------------

-- 1. Retrieve the customer(s) with the highest account balance.

SELECT C.*, A.account_type, A.balance AS HighestAccountBalance FROM Customers C,Accounts A
WHERE C.customer_id = A.customer_id 
AND A.balance = (SELECT MAX(balance) FROM Accounts)

-- 2. Calculate the average account balance for customers who have more than one account.

SELECT
    AVG(balance) AS AverageBalance
FROM Accounts
WHERE customer_id IN (
    SELECT customer_id FROM Accounts
    GROUP BY customer_id
    HAVING COUNT(*) > 1
)

-- 3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.

SELECT account_id, amount FROM Transactions
WHERE amount > ( SELECT AVG(amount) FROM Transactions)

-- 4. Identify customers who have no recorded transactions.

SELECT customer_id, CONCAT(first_name,' ',last_name) AS Non_Transacted_Customers FROM Customers
WHERE customer_id IN(
	SELECT customer_id FROM Accounts
	WHERE account_id NOT IN(
		SELECT account_id FROM Transactions
	)
)
GROUP BY customer_id, first_name, last_name

-- 5. Calculate the total balance of accounts with no recorded transactions.

SELECT C.customer_id, CONCAT(C.first_name,' ',C.last_name) AS Non_Transacted_Customers, SUM(A.balance) AS TotalBalance 
FROM Customers C, Accounts A
WHERE C.customer_id IN(
	SELECT A.customer_id FROM Accounts
	WHERE A.account_id NOT IN(
		SELECT account_id FROM Transactions
	)
)
GROUP BY C.customer_id, first_name, last_name

-- 6. Retrieve transactions for accounts with the lowest balance.

SELECT * FROM Transactions
WHERE account_id IN(
	SELECT account_id FROM Accounts
	WHERE balance = (
		SELECT MIN(balance) AS Lowest_Balance FROM Accounts
	)
)

-- 7. Identify customers who have accounts of multiple types.

SELECT * FROM Customers
WHERE customer_id IN(
	SELECT customer_id FROM Accounts
	GROUP BY customer_id
	HAVING COUNT(customer_id) > 1
)

-- 8. Calculate the percentage of each account type out of the total number of accounts.

SELECT account_type, 
	   COUNT(*) * 100/ (SELECT COUNT(*) FROM Accounts) AS Percentage_of_Accounts
FROM Accounts
GROUP BY account_type

-- 9. Retrieve all transactions for a customer with a given customer_id.

SELECT * FROM Transactions
WHERE account_id IN(
	SELECT account_id FROM Accounts
	WHERE customer_id IN(
		SELECT customer_id FROM Customers) 
	AND customer_id = 5
)

-- 10. Calculate the total balance for each account type, including a subquery within the SELECT clause.

SELECT account_type,
	   (SELECT SUM(balance) FROM Accounts WHERE account_type = A.account_type)  AS Total_Balance 
FROM Accounts A
GROUP BY account_type


