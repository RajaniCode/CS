USE [master];

IF OBJECT_ID ('Customer', N'U') IS NOT NULL
DROP TABLE dbo.Customer;

CREATE TABLE dbo.Customer
(
	CustomerId INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(max),
	LastName NVARCHAR(max),
    Synonym NVARCHAR(max),
    CONSTRAINT PK_custid PRIMARY KEY(CustomerId)
) 
ON [PRIMARY]
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Bill', 'Gates', 'Microsoft');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Larry', 'Page', 'Google');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Steve', 'Jobs', 'Apple');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Anders', 'Hejlsberg', 'C#');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Bjarne', 'Stroustrup', 'C++');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('James', 'Gosling', 'Java');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Scott', 'Guthrie', 'ASP.NET');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Don', 'Syme', 'F#');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Dennis', 'Ritchie', 'C');
GO

INSERT INTO dbo.Customer([FirstName], [LastName], [Synonym])
VALUES('Hasso', 'Plattner', 'SAP');
GO

SELECT * FROM dbo.Customer;
GO

/*
SET IDENTITY_INSERT dbo.Customer ON; 
GO

INSERT INTO dbo.Customer([CustomerId], [FirstName], [LastName], [Synonym])
VALUES(99, 'F', 'L', 'S');
GO

SELECT * FROM dbo.Customer;
GO
*/

IF OBJECT_ID ('Employee', N'U') IS NOT NULL
DROP TABLE dbo.Employee;

CREATE TABLE dbo.Employee
(
	EmployeeId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	FirstName NVARCHAR(max),
	LastName NVARCHAR(max),
    Synonym NVARCHAR(max),
    CONSTRAINT PK_empid PRIMARY KEY(EmployeeId)
) 
ON [PRIMARY]
GO

/*
-- uniqueidentifier -- NEWID() --  INT IDENTITY(1,1)
-- Operand type clash: uniqueidentifier is incompatible with int
INSERT INTO dbo.Employee([EmployeeId], [FirstName], [LastName], [Synonym])
VALUES(NEWID(), 'F', 'L', 'S');
GO

DECLARE @NewGuid uniqueidentifier = NEWID(); 
SELECT @NewGuid;
GO

SELECT * FROM dbo.Employee;
GO
*/

SELECT * FROM dbo.Employee;
GO