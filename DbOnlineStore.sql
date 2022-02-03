CREATE DATABASE IF NOT EXISTS [DbOnlineStore];

USE [DbOnlineStore];
GO

DROP TABLE IF EXISTS [dbo].[Customers];
DROP TABLE IF EXISTS [dbo].[Categories];
DROP TABLE IF EXISTS [dbo].[Users];
DROP TABLE IF EXISTS [dbo].[Products];
DROP TABLE IF EXISTS [dbo].[Items];
DROP TABLE IF EXISTS [dbo].[Orders];
DROP TABLE IF EXISTS [dbo].[Sales];
DROP TABLE IF EXISTS [dbo].[Roles];
DROP TABLE IF EXISTS [dbo].[Users_Roles];

CREATE TABLE [dbo].[Customers]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [User_Id] [uniqueidentifier] NOT NULL,
    [First_Name] [nvarchar](50) NOT NULL,
    [Last_Name] [nvarchar](50) NOT NULL,
    [Address] [nvarchar](150) NOT NULL,
    [Phone] [nvarchar](50) NOT NULL,
    [Nit] [nvarchar](50) NOT NULL,
);

CREATE TABLE [dbo].[Categories]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](50) NOT NULL UNIQUE,
);

CREATE TABLE [dbo].[Items]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Product_Id] [uniqueidentifier] NOT NULL,
    [Quantity] [int] NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
);

CREATE TABLE [dbo].[Orders]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Total_Price] [decimal](18, 2) NOT NULL,
    [Item_Id] [uniqueidentifier] NOT NULL,
);

CREATE TABLE [dbo].[Products]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](50) NOT NULL,
    [Stock] [int] NOT NULL,
    [Category_Id] [uniqueidentifier] NOT NULL,
);

CREATE TABLE [dbo].[Roles]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Name] [nvarchar](50) NOT NULL UNIQUE,
);

CREATE TABLE [dbo].[Sales]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Order_Id] [uniqueidentifier] NOT NULL,
    [Customer_Id] [uniqueidentifier] NOT NULL,
    [Date] [datetime] NOT NULL,
);

CREATE TABLE [dbo].[Users]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [User_Name] [nvarchar](50) NOT NULL UNIQUE,
    [Password] [nvarchar](50) NOT NULL,
    [Email] [nvarchar](50) NOT NULL UNIQUE,
);

CREATE TABLE [dbo].[Users_Roles]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [User_Id] [uniqueidentifier] NOT NULL,
    [Role_Id] [uniqueidentifier] NOT NULL,
);

ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]);
ALTER TABLE [dbo].[Items] ADD CONSTRAINT [FK_Items_Products] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Products] ([Id]);
ALTER TABLE [dbo].[Sales] ADD CONSTRAINT [FK_Sales_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([Id]);
ALTER TABLE [dbo].[Sales] ADD CONSTRAINT [FK_Sales_Orders] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Id]);
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_Sales] FOREIGN KEY ([Item_Id]) REFERENCES [dbo].[Items] ([Id]);
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Categories] ([Id]);
ALTER TABLE [dbo].[Users_Roles] ADD CONSTRAINT [FK_Users_Roles_Users] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]);
ALTER TABLE [dbo].[Users_Roles] ADD CONSTRAINT [FK_Users_Roles_Roles] FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Roles] ([Id]);


CREATE FUNCTION [dbo].[Calculate_Total_Price] (@Id_Item uniqueidentifier)
RETURNS decimal(18,2)
AS
BEGIN
    DECLARE @Total decimal(18,2);
    SELECT @Total = [Price] * [Quantity] FROM [dbo].[Items] WHERE [Id] = @Id_Item;
    RETURN @Total;
END
GO

INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (newid(), 'Electronics');
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (newid(), 'Clothes');
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (newid(), 'Food');
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (newid(), 'Books');
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (newid(), 'Drinks');

SELECT * FROM [dbo].[Products];

--INSERT 100 PRODUCTS
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Samsung S10', 10, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Samsung S20', 10, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Samsung S21 ULTRA', 10, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Note 10', 100, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Note 20', 100, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Snickers', 210, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Food'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Coca Cola', 10010, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Drinks'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Pepsi', 11110, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Drinks'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Pizza', 1110, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Food'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'T-Shirt', 1110, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Clothes'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Jeans', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Clothes'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Shoes', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Clothes'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Don Quijote', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Books'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Harry Potter', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Books'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'Lord of the Rings', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Books'));
INSERT INTO [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (newid(), 'The Hobbit', 10111, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Books'));

INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'AGonzales', 'alex_gonzalesm@gmail.com','asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'JGonzales', 'JGon@gmail.com','asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'MGonzales', 'MG2s' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'RAUL1', 'rauls@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Juan2', 'DIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Juan1', 'DIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Marcelo2', 'DIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Clara', 'DIEwwG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Rubeen2', 'DIwrwfsEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Rpnaldd', 'DdasdasIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Ronaldito', 'DIEadsadaG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'Manuel', 'DIEdasG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'frabcis', 'dfasds@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'davudu', 'DasdaIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'marasdas', 'laasdas@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'das34s', 'dasdac@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'sheysd', 'asdasDIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'valess', 'vasDIEG@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'pxti', 'oxsdas@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'guyas', 'guyasdas@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'leticia', 'letoco@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'carmesss', 'carrmes@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'laatea', 'laurra@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'variniass', 'vavava@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'louiss2', 'loiasd@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'malcolmsd', 'malccolms@GMAIL.COM' ,'asda234wew23');
INSERT INTO [dbo].[Users] ([Id], [User_Name], [Email], [Password]) VALUES (newid(), 'maurroso', 'maoutos@GMAIL.COM' ,'asda234wew23');

SELECT * FROM [dbo].[Users];

INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (newid(), 'Admin');
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (newid(), 'Customer');

INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'AGonzales'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Admin'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'JGonzales'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'MGonzales'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'dIEGOMS'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'RAUL1'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Rpnaldd'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Ronaldito'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Manuel'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'davudu'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'marasdas'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'sheysd'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'valess'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'guyas'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'leticia'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'carmesss'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'variniass'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'louiss2'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'malcolmsd'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));
INSERT INTO [dbo].[Users_Roles] ([Id], [User_Id], [Role_Id]) VALUES (NEWID(), (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'maurroso'), (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Customer'));

INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
 VALUES (NEWID(), 'Juan', 'Gonzalez', 'Calle 1', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'JGonzales'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Maria', 'Gonzales', 'Calle 2', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'MGonzales'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Pedro', 'Gonzales', 'Calle 3', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'AGonzales'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Diego', 'Gonzalez', 'Calle 4', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'dIEGOMS'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Raul', 'Gonzalez', 'Calle 5', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'RAUL1'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Ronald', 'Raldez', 'Calle 6 av. 4 de agosto', '3123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Rpnaldd'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Juan', 'Zelaya', 'Calle 7', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'carmesss'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Dash', 'Santos', 'Calle 8', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'variniass'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])   
    VALUES (NEWID(), 'Ryan', 'Smith', 'Calle 9', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'louiss2'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Theo', 'Lazo', 'Calle 10', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'malcolmsd'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Bryan', 'Calle', 'Calle 11', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'maurroso'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])   
    VALUES (NEWID(), 'Manuel', 'Rioja', 'Calle 12 av. 4 de agosto', '3123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Ronaldito'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Jacobo', 'Sainz', 'Calle 13', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'Manuel'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Michelle', 'Garnica', 'Calle 14', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'davudu'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Mario', 'Ramires', 'Calle 15', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'marasdas'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Shirley', 'Gonzalez', 'Calle 16', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'sheysd'));
INSERT INTO [dbo].[Customers] ([Id], [First_Name], [Last_Name], [Address], [Phone], [Nit], [User_Id])
    VALUES (NEWID(), 'Valeria', 'Gonzalez', 'Calle 17', '123456789', 30122331223, (SELECT [Id] FROM [dbo].[Users] WHERE [User_Name] = 'valesd'));


SELECT * FROM [dbo].[Customers];

SELECT u.[User_Name] FROM [dbo].[Users] as u
    INNER JOIN [dbo].[Users_Roles] as s
        ON u.[Id] = s.[User_Id]
    WHERE s.[Role_Id] = (SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'Admin');

SELECT c.[First_Name] as [name], u.[User_Name] as [username] FROM [dbo].[Customers] as c
    INNER JOIN [dbo].[Users] as u
        ON c.[User_Id] = u.[Id]
    INNER JOIN [dbo].[Users_Roles] as s
        ON u.[Id] = s.[User_Id]
    INNER JOIN [dbo].[Roles] as r
        ON s.[Role_Id] = r.[Id]
    WHERE r.[Name] = 'Admin';
    

select * from [dbo].[Products];

INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3100.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'DonQuijote'), 10);
INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '200.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Mac Book Air 2019'), 20);
INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Coca Cola'), 13);
INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Coca Cola'), 13);
INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Coca Cola'), 13);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Shoes'), 13);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '3002.78', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Pizaa'), 2);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '23.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Jeans'), 113);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '23.18', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Pepsi'), 23);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '123.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'T-Shirt'), 23);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '223.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Harry Potter'), 233);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '113.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Harry Potter'), 22);
    INSERT INTO [dbo].[Items] ([Id], [Price], [Product_Id], [Quantity])
    VALUES (NEWID(), '13.98', (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'The Hobbits'), 22);

