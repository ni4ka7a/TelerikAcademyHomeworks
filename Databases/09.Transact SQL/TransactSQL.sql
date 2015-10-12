-- 01.Create a database with two tables: 
-- Persons(Id(PK), FirstName, LastName, SSN) and
-- Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.

CREATE DATABASE Bank
GO

USE Bank
CREATE TABLE Persons (
	PersonId int IDENTITY NOT NULL,
	FirstName nvarchar(40) NOT NULL,
	LastName nvarchar(40) NOT NULL,
	SSN nvarchar(10) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(PersonId)
)
GO

CREATE TABLE Accounts (
	AccountId int IDENTITY NOT NULL,
	PersonId int NOT NULL,
	Balance money DEFAULT 0,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
	CONSTRAINT FK_Persons_Accounts FOREIGN KEY (PersonId)
	REFERENCES Persons(PersonId)
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Stamat', 'Petrov', '123123123'),
	   ('John', 'Smith', '32132131'),
	   ('Stamina', 'Nikolova', '324234435')
GO

INSERT INTO Accounts (PersonId, Balance)
VALUES (1, 100),
	   (2, 150),
	   (3, 50)
GO

CREATE PROC dbo.usp_SelectFullNameOfAllPersons
AS
  SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM Persons
GO

EXEC usp_SelectFullNameOfAllPersons
GO

-- 02.Create a stored procedure that accepts a number as a parameter and returns
-- all persons who have more money in their accounts than the supplied number.

CREATE PROC dbo.usp_SelectPersonsWithMoreMoneyThan(@amountOfMoney int = 0)
AS
  SELECT p.FirstName, p.LastName
  FROM Persons p
  JOIN Accounts a
  ON p.PersonId = a.PersonId
  WHERE a.Balance > @amountOfMoney
GO

EXEC usp_SelectPersonsWithMoreMoneyThan
GO


-- 03.Create a function that accepts as parameters – sum, yearly interest rate
-- and number of months.
-- It should calculate and return the new sum.
-- Write a SELECT to test whether the function works as expected.

CREATE PROC dbo.usp_CalculateInterestPerYear(@sum money = 0, @interestRate money = 0, @numberOfMonths int = 0)
AS
	RETURN @sum + (@interestRate * @sum * @numberOfMonths)
GO



DECLARE @interestPerYear money
EXEC @interestPerYear = usp_CalculateInterestPerYear 10, 1.1, 10

SELECT @interestPerYear
GO


-- 04.Create a stored procedure that uses the function from the previous
-- example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.


CREATE PROC dbo.usp_InterestPerPersonForOneMonth(@accountId int, @interestRate money)
AS
	DECLARE @balance money = (SELECT Balance FROM Accounts WHERE AccountId = @accountId)
	DECLARE @newBalance money

	EXEC @newBalance = usp_CalculateInterestPerYear @balance, @interestRate, 1

	SELECT p.FirstName, p.FirstName, a.Balance, @newBalance AS [New Balance]
	FROM Persons p 
	JOIN Accounts a
	ON a.PersonId = p.PersonId
	WHERE A.AccountId = @accountId
GO

EXEC usp_InterestPerPersonForOneMonth 1, 2.3
GO


-- 05.Add two more stored procedures WithdrawMoney(AccountId, money)
-- and DepositMoney(AccountId, money) that operate in transactions.

CREATE PROCEDURE dbo.usp_WithdrawMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

CREATE PROCEDURE dbo.usp_DepositMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance += @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO


EXEC usp_WithdrawMoney 1, 20

EXEC usp_DepositMoney 1, 50


-- 06.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into
-- the Logs table every time the sum on an account changes.

CREATE TABLE Logs (
	LogId int IDENTITY PRIMARY KEY NOT NULL,
	AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(AccountId),
	OldSum money NOT NULL,
	NewSum money NOT NULL,
)
GO

CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
	DECLARE @oldSum money
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT AccountId, @oldSum, Balance
        FROM inserted
GO

EXEC usp_DepositMoney 2, 100
SELECT * FROM Logs

-- 07.Define a function in the database TelerikAcademy that returns
-- all Employee's names (first or middle or last name) and all
-- town's names that are comprised of given set of letters.

USE TelerikAcademy
GO

CREATE FUNCTION ufn_SearchForWordsInGivenPattern(@pattern nvarchar(255))
	RETURNS @MatchedNames TABLE (Name varchar(50))
AS
BEGIN
	INSERT @MatchedNames
	SELECT * 
	FROM
		(SELECT e.FirstName FROM Employees e
        UNION
        SELECT e.LastName FROM Employees e
        UNION 
        SELECT t.Name FROM Towns t) as temp(name)
    WHERE PATINDEX('%[' + @pattern + ']', Name) > 0
	RETURN
END
GO


-- 08.Using database cursor write a T-SQL script that scans allemployees and
-- their addresses and prints all pairs of employees that live in the same town.

DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT emp1.FirstName, emp1.LastName, t1.Name, emp2.FirstName, emp2.LastName
    FROM Employees emp1
    JOIN Addresses a1
        ON emp1.AddressID = a1.AddressID
    JOIN Towns t1
        ON a1.TownID = t1.TownID,
        Employees emp2
    JOIN Addresses a2
        ON emp2.AddressID = a2.AddressID
    JOIN Towns t2
        ON a2.TownID = t2.TownID
    WHERE t1.TownID = t2.TownID AND emp1.EmployeeID != emp2.EmployeeID
    ORDER BY emp1.FirstName, emp2.FirstName

OPEN empCursor

DECLARE @firstName1 nvarchar(50), 
        @lastName1 nvarchar(50),
        @townName nvarchar(50),
        @firstName2 nvarchar(50),
        @lastName2 nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

DECLARE @counter int;
SET @counter = 0;

WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @counter = @counter + 1;

		PRINT @townName + ' -> ' + @firstName1 + ' ' + @lastName1 + ', ' +
			  @firstName2 + ' ' + @lastName2; 

		FETCH NEXT FROM empCursor 
		INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
	END

print 'Total records: ' + CAST(@counter AS nvarchar(10));

CLOSE empCursor
DEALLOCATE empCursor
