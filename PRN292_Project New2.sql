SET NOCOUNT ON;
USE master;
GO
IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME='PRN292_Project')
	DROP DATABASE PRN292_Project;
CREATE DATABASE PRN292_Project;
GO
USE PRN292_Project;

--Create Book Related Tables--
CREATE TABLE [Authors]
(
	[AuthorID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FirstName] nvarchar(max) NOT NULL,
	[LastName] nvarchar(max),
	[BirthDate] date NOT NULL,
	[About] nvarchar(max)
);
CREATE TABLE [Categories]
(
	[CategoryID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryName] nvarchar(max) NOT NULL,
	[Description] nvarchar(max)
);
CREATE TABLE [Publishers]
(
	[PublisherID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[PublisherName] nvarchar(max) NOT NULL,
	[Address] nvarchar(max) NOT NULL,
	[Phone] varchar(max),
	[Fax] varchar(max),
	[Email] nvarchar(max)
);
CREATE TABLE [Books]
(
	[BookID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Title] nvarchar(max) NOT NULL,
	[AuthorID] int REFERENCES [Authors]([AuthorID]) NOT NULL,
	[PublisherID] int REFERENCES [Publishers]([PublisherID]) NOT NULL,
	[PublicationDate] date NOT NULL,
	[UnitPrice] money CHECK([UnitPrice] >= 0) NOT NULL,
	[UnitsInStock] int CHECK([UnitsInStock] >= 0) NOT NULL,
	[Description] nvarchar(max)
);
CREATE TABLE [Book_Category]
(
	[BookID] int REFERENCES [Books]([BookID]) NOT NULL,
	[CategoryID] int REFERENCES [Categories]([CategoryID]) NOT NULL,
	PRIMARY KEY ([BookID], [CategoryID])
);

--Create User Related Tables--
CREATE TABLE [Employees]
(
	[EmployeeID] int IDENTITY(1,1) PRIMARY KEY NOT NUll,
	[AccountName] varchar(max) NOT NULL,
	[AccountPassword] varchar(max) NOT NULL,
	[FirstName] nvarchar(max) NOT NULL,
	[LastName] nvarchar(max),
	[Phone] varchar(max),
	[Email] nvarchar(max)
);
CREATE TABLE [Roles]
(
	[RoleID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[RoleName] nvarchar(max) NOT NULL
);
CREATE TABLE [Features]
(
	[FeatureID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FeatureCode] varchar(max) NOT NULL,
	[FeatureName] varchar(max) NOT NULL
);
CREATE TABLE [Employee_Role]
(
	[EmployeeID] int REFERENCES [Employees]([EmployeeID]) NOT NULL,
	[RoleID] int REFERENCES [Roles]([RoleID]) NOT NULL,
	PRIMARY KEY ([EmployeeID], [RoleID])
);
CREATE TABLE [Role_Feature]
(
	[RoleID] int REFERENCES [Roles]([RoleID]) NOT NULL,
	[FeatureID] int REFERENCES [Features]([FeatureID]) NOT NULL,
	PRIMARY KEY ([RoleID], [FeatureID])
);

--Create Bill Related Tables--
CREATE TABLE [Bills]
(
	[BillID] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[BillDate] datetime NOT NULL,
	[EmployeeID] int REFERENCES [Employees]([EmployeeID]) NOT NULL
);
CREATE TABLE [Bill_Details]
(
	[BillID] int REFERENCES [Bills]([BillID]) NOT NULL,
	[BookID] int REFERENCES [Books]([BookID]) NOT NULL,
	[Quantity] int CHECK([Quantity] > 0) NOT NULL,
	[UnitPrice] money CHECK([UnitPrice] >= 0) NOT NULL,
	[Discount] real CHECK([Discount] >= 0 AND [Discount] <= 1) NOT NULL,
	PRIMARY KEY ([BillID], [BookID])
);

--Create Views And Functions--
GO
CREATE VIEW RAND_VIEW AS SELECT RAND() AS VALUE
GO
CREATE VIEW NEWID_VIEW AS SELECT NEWID() AS VALUE
GO
CREATE FUNCTION dbo.createRandomDate(@from date, @to date)
RETURNS date AS
BEGIN
	DECLARE @daysDiff int = 1 + datediff(day, @from, @to)
	DECLARE @randomDays int = (SELECT [Value] FROM [RAND_VIEW]) * @daysDiff
	RETURN dateadd(day, @randomDays, @from)
END
GO
CREATE FUNCTION dbo.createRandomPositiveInt(@min int, @max int)
RETURNS int AS
BEGIN
	RETURN ABS(CHECKSUM((SELECT [Value] FROM [NEWID_VIEW])) % (@max - @min + 1)) + @min
END
GO
CREATE FUNCTION dbo.createRandomPositiveBigInt(@min bigint, @max bigint)
RETURNS bigint AS
BEGIN
	RETURN ABS(CHECKSUM((SELECT [Value] FROM [NEWID_VIEW])) % (@max - @min + 1)) + @min
END
GO
CREATE FUNCTION dbo.selectRandomAuthorID()
RETURNS int AS
BEGIN
	RETURN (SELECT TOP 1 [AuthorID] FROM [Authors] ORDER BY (SELECT [Value] FROM [NEWID_VIEW]))
END
GO
CREATE FUNCTION dbo.selectRandomCategoryID(@bookID int)
RETURNS int AS
BEGIN
	RETURN
	(
		SELECT TOP 1 [CategoryID] FROM [Categories] WHERE [CategoryID] NOT IN
		(
			SELECT [CategoryID] FROM [Book_Category] WHERE [BookID] = @bookID
		)
		ORDER BY (SELECT [Value] FROM [NEWID_VIEW])
	)
END
GO
CREATE FUNCTION dbo.selectRandomPublisherID()
RETURNS int AS
BEGIN
	RETURN (SELECT TOP 1 [PublisherID] FROM [Publishers] ORDER BY (SELECT [Value] FROM [NEWID_VIEW]))
END
GO
CREATE FUNCTION dbo.selectRandomBookID()
RETURNS int AS
BEGIN
	RETURN (SELECT TOP 1 [BookID] FROM [Books] ORDER BY (SELECT [Value] FROM [NEWID_VIEW]))
END
GO
CREATE FUNCTION dbo.selectRandomEmployeeID()
RETURNS int AS
BEGIN
	RETURN (SELECT TOP 1 [Employees].[EmployeeID] FROM [Employees] INNER JOIN [Employee_Role] ON [Employees].[EmployeeID]=[Employee_Role].[EmployeeID] WHERE [RoleID] = 3 ORDER BY (SELECT [Value] FROM [NEWID_VIEW]))
END
GO
CREATE FUNCTION dbo.selectMaxBillID()
RETURNS int AS
BEGIN
	RETURN (SELECT MAX([BillID]) FROM [Bills])
END
GO
CREATE FUNCTION dbo.selectUnitPriceByBookID(@bookID int)
RETURNS money AS
BEGIN
	RETURN (SELECT [UnitPrice] FROM [Books] WHERE [BookID]=@bookID)
END
GO

--Insert Into User Related Tables--
GO
CREATE PROCEDURE insert_employees AS
BEGIN
	DECLARE @minPhoneNum bigint = 1000000000
	DECLARE @maxPhoneNum bigint = 9999999999
	INSERT INTO [Employees]([AccountName],[AccountPassword],[FirstName],[LastName],[Phone],[Email]) VALUES
		('mra', 'mra', N'Paolo', N'Accorti', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrb', 'mrb', N'Pedro', N'Afonso', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrc1', 'mrc1', N'Victoria', N'Ashworth', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrc2', 'mrc2', N'Helen', N'Bennett', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrc3', 'mrc3', N'Lesley', N'Brown', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrc4', 'mrc4', N'Francisco', N'Chang', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com'),
		('mrc5', 'mrc5', N'Philip', N'Cramer', dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),'test1@gmail.com')
	;
END
GO
EXEC insert_employees
GO
INSERT INTO [Roles]([RoleName]) VALUES
	('Admin'),
	('Store Manager'),
	('Cashier')
;
INSERT INTO [Features]([FeatureCode],[FeatureName]) VALUES
	('Read', 'Account'),
	('Create','Employee'), ('Read','Employee'), ('Update','Employee'), ('Delete','Employee'),
	('Create','Book'), ('Read','Book'), ('Update','Book'),
	('Create','Bill'), ('Read','Bill'), ('Delete','Bill') ,('List','Account'),('EditRole','Account'),('Edit','Account'),('Create','Account'),('Import','Book'),('Edit','Book'),('View','Book'),('View','Publisher'),('View','Author'),('View','Bill'),('Create','Book')
;
INSERT INTO [Employee_Role]([EmployeeID],[RoleID]) VALUES
	(1, 1), (2, 2), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3)
;
INSERT INTO [Role_Feature]([RoleID],[FeatureID]) VALUES
	(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (1, 11),(1,12),(1,13),(1,14),(1,15),(1,16),(1,17),(1,18),(1,19),(1,20),(1,21),(1,22),
	(2, 3), (2, 4), (2, 6), (2, 7), (2, 8),
	(3, 3), (3, 4), (3,7), (3, 9), (3, 10), (3, 11)
;

--Insert into Book Related Tables--
GO
CREATE PROCEDURE insert_authors AS
BEGIN
	DECLARE @minBirthDate date = '1980-01-01'
	DECLARE @maxBirthDate date = '1995-01-01'
	DECLARE @Foo TABLE ([FirstName] nvarchar(max))
	INSERT INTO @Foo VALUES
		(N'Johnson'),
		(N'Majorie'),
		(N'Cheryl'),
		(N'Michael'),
		(N'Dean'),
		(N'Meander'),
		(N'Abraham'),
		(N'Ann'),
		(N'Burt'),
		(N'Charlene'),
		(N'Morningstar'),
		(N'Reginald'),
		(N'Akiko'),
		(N'Innes'),
		(N'Michel'),
		(N'Dirk'),
		(N'Stearns'),
		(N'Livia'),
		(N'Sylvia'),
		(N'Sheryl'),
		(N'Heather'),
		(N'Anne'),
		(N'Albert')
	DECLARE @Bar TABLE ([LastName] nvarchar(max))
	INSERT INTO @Bar VALUES
		(N'White'),
		(N'Green'),
		(N'Carson'),
		(N'O''Leary'),
		(N'Straight'),
		(N'Smith'),
		(N'Bennet'),
		(N'Dull'),
		(N'Gringlesby'),
		(N'Locksley'),
		(N'Greene'),
		(N'Blotchet-Halls'),
		(N'Yokomoto'),
		(N'del Castillo'),
		(N'DeFrance'),
		(N'Stringer'),
		(N'MacFeather'),
		(N'Karsen'),
		(N'Panteley'),
		(N'Hunter'),
		(N'McBadden'),
		(N'Ringer'),
		(N'Ringer')
	DECLARE @numAuthors int = (SELECT COUNT(*) FROM @Foo)
	WHILE @numAuthors > 0
	BEGIN
		DECLARE @firstName nvarchar(max) =
		(
			SELECT [FirstName] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [FirstName]) AS [RowNumber], [FirstName] FROM @Foo
			)
			AS [Foo] WHERE [RowNumber] = @numAuthors
		)
		DECLARE @lastName nvarchar(max) =
		(
			SELECT [LastName] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [LastName]) AS [RowNumber], [LastName] FROM @Bar
			)
			AS [Bar] WHERE [RowNumber] = @numAuthors
		)
		INSERT INTO [Authors]([FirstName],[LastName],[BirthDate]) VALUES (
			@firstName,
			@lastName,
			dbo.createRandomDate(@minBirthDate,@maxBirthDate)
		)
		SET @numAuthors = @numAuthors - 1
	END
END
GO
EXEC insert_authors
GO
INSERT INTO [Categories]([CategoryName]) VALUES
	(N'Business'),(N'Modern Cook'),(N'Popular Company'),(N'Psychology'),(N'Traditional Cook')
;
GO
CREATE PROCEDURE insert_publishers AS
BEGIN
	DECLARE @minPhoneNum bigint = 1000000000
	DECLARE @maxPhoneNum bigint = 9999999999
	DECLARE @Foo TABLE ([PublisherName] nvarchar(max))
	INSERT INTO @Foo VALUES
		(N'New Moon Books'),
		(N'Binnet & Hardley'),
		(N'Algodata Infosystems'),
		(N'Five Lakes Publishing'),
		(N'Ramona Publishers'),
		(N'GGG&G'),
		(N'Scootney Books'),
		(N'Lucerne Publishing')
	DECLARE @Bar TABLE ([Address] nvarchar(max))
	INSERT INTO @Bar VALUES
		(N'Boston, MA, USA'),
		(N'Washington, DC, USA'),
		(N'Berkeley, CA, USA'),
		(N'Chicago, IL, USA'),
		(N'Dallas, TX, USA'),
		(N'Mnchen, Germany'),
		(N'New York, NY, USA'),
		(N'Paris, France')
	DECLARE @numPublishers int = (SELECT COUNT(*) FROM @Foo)
	WHILE @numPublishers > 0
	BEGIN
		DECLARE @publisherName nvarchar(max) = 
		(
			SELECT [PublisherName] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [PublisherName]) AS [RowNumber], [PublisherName] FROM @Foo
			)
			AS [Foo] WHERE [RowNumber] = @numPublishers
		)
		DECLARE @address nvarchar(max) = 
		(
			SELECT [Address] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [Address]) AS [RowNumber], [Address] FROM @Bar
			)
			AS [Bar] WHERE [RowNumber] = @numPublishers
		)
		INSERT INTO [Publishers]([PublisherName],[Address],[Phone],[Fax]) VALUES (
			@publisherName,
			@address,
			dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum),
			dbo.createRandomPositiveBigInt(@minPhoneNum,@maxPhoneNum)
		)
		SET @numPublishers = @numPublishers - 1
	END
END
GO
EXEC insert_publishers
GO
CREATE PROCEDURE insert_books AS
BEGIN
	DECLARE @minPublicationDate date = '2000-01-01'
	DECLARE @maxPublicationDate date = GETDATE()
	DECLARE @minUnitPrice money = 50
	DECLARE @maxUnitPrice money = 125
	DECLARE @minUnitsInStock int = 0
	DECLARE @maxUnitsInStock int = 125
	DECLARE @Foo TABLE ([Title] nvarchar(max))
	INSERT INTO @Foo([Title]) VALUES
		(N'The Busy Executive''s Database Guide'),
		(N'Cooking with Computers: Surreptitious Balance Sheets'),
		(N'You Can Combat Computer Stress!'),
		(N'Straight Talk About Computers'),
		(N'Silicon Valley Gastronomic Treats'),
		(N'The Gourmet Microwave'),
		(N'The Psychology of Computer Cooking'),
		(N'But Is It User Friendly?'),
		(N'Secrets of Silicon Valley'),
		(N'Net Etiquette'),
		(N'Computer Phobic AND Non-Phobic Individuals: Behavior Variations'),
		(N'Is Anger the Enemy?'),
		(N'Life Without Fear'),
		(N'Prolonged Data Deprivation: Four Case Studies'),
		(N'Emotional Security: A New Algorithm'),
		(N'Onions, Leeks, and Garlic: Cooking Secrets of the Mediterranean'),
		(N'Fifty Years in Buckingham Palace Kitchens'),
		(N'Sushi, Anyone?')
	DECLARE @numBooks int = (SELECT COUNT(*) FROM @Foo)
	WHILE @numBooks > 0
	BEGIN
		DECLARE @title nvarchar(max) = 
		(
			SELECT [Title] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [Title]) AS [RowNumber], [Title] FROM @Foo
			)
			AS [Foo] WHERE [RowNumber] = @numBooks
		)
		INSERT INTO [Books]([Title],[AuthorID],[PublisherID],[PublicationDate],[UnitPrice],[UnitsInStock]) VALUES (
			@title,
			dbo.selectRandomAuthorID(),
			dbo.selectRandomPublisherID(),
			dbo.createRandomDate(@minPublicationDate,@maxPublicationDate),
			dbo.createRandomPositiveInt(@minUnitPrice,@maxUnitPrice) * 1000,
			dbo.createRandomPositiveInt(@minUnitsInStock,@maxUnitsInStock)
		)
		SET @numBooks = @numBooks - 1
	END
END
GO
EXEC insert_books
GO
CREATE PROCEDURE insert_into_book_category AS
BEGIN
	DECLARE @numBooks int = (SELECT COUNT(*) FROM [Books])
	WHILE @numBooks > 0
	BEGIN
		SELECT [BookID] INTO [Foo] FROM [Books]
		DECLARE @bookID int =
		(
			SELECT [BookID] FROM
			(
				SELECT ROW_NUMBER() OVER (ORDER BY [BookID]) AS [RowNumber], [BookID] FROM [Foo]
			)
			AS [Bar] WHERE [RowNumber] = @numBooks
		)
		DECLARE @numCategories int = dbo.createRandomPositiveInt(1,2)
		WHILE @numCategories > 0
		BEGIN
			DECLARE @categoryID int = dbo.selectRandomCategoryID(@bookID)
			INSERT INTO [Book_Category] VALUES (@bookID, @categoryID)
			SET @numCategories = @numCategories - 1
		END
		DROP TABLE [Foo]
		SET @numBooks = @numBooks - 1
	END
END
GO
EXEC insert_into_book_category
GO

--Insert Into Bill Related Tables--
GO
CREATE PROCEDURE insert_bills AS
BEGIN
	DECLARE @numBills int = 5250
	WHILE @numBills > 0
	BEGIN
		DECLARE @billDate date = dbo.createRandomDate('2020-01-01',GETDATE())
		INSERT INTO [Bills]([BillDate],[EmployeeID])
			VALUES (@billDate, dbo.selectRandomEmployeeID())
		DECLARE @billID int = dbo.selectMaxBillID()
		BEGIN
			DECLARE @numBooks int =  dbo.createRandomPositiveInt(2,4)
			SELECT TOP (@numBooks) [BookID] INTO [Foo] FROM [Books] ORDER BY NEWID()
			WHILE @numBooks > 0
			BEGIN
				DECLARE @bookID int =
				(
					SELECT [BookID] FROM
					(
						SELECT ROW_NUMBER() OVER (ORDER BY [BookID]) AS [RowNumber], [BookID] FROM [Foo]
					)
					AS [Bar] WHERE [RowNumber] = @numBooks
				)
				DECLARE @quantity int = dbo.createRandomPositiveInt(1,2)
				DECLARE @unitPrice money = dbo.selectUnitPriceByBookID(@bookID)
				INSERT INTO [Bill_Details]([BillID],[BookID],[Quantity],[UnitPrice],[Discount]) VALUES (@billID, @bookID, @quantity, @unitPrice, 0)
				SET @numBooks = @numBooks - 1
			END
			DROP TABLE [Foo]
		END
		SET @numBills = @numBills - 1
	END
END
GO
EXEC insert_bills
GO