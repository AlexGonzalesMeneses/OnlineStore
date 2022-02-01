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

SELECT * FROM [dbo].[Categories];

INSERT [dbo].[Products] ([Id], [Name], [Stock], [Category_Id]) VALUES (NEWID(), N'Laptop', 100, '3ba82a90-2086-49e9-99a2-09f844a21d37');
select * from  [dbo].[Products];


INSERT INTO [dbo].[Orders] ([Id], [Total_Price], [Item_Id]) VALUES (NEWID(), [dbo].[Calculate_Total_Price](NEWID()), NEWID());
insert into [dbo].[Orders] (Id, Total_Price, Item_Id) values (NEWID(), [dbo].[Calculate_Total_Price]('1986FA39-0A70-4607-B47C-252DC8838022'), '1986FA39-0A70-4607-B47C-252DC8838022');
