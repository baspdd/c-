USE [master]
GO
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MySaleDB')
BEGIN
	ALTER DATABASE [MySaleDB] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [MySaleDB] SET ONLINE;
	DROP DATABASE [MySaleDB];
END
CREATE DATABASE [MySaleDB]
GO
USE [MySaleDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Weight] [float] NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [Date] NOT NULL,
	[RequiredDate] [Date] NOT NULL,
	[ShippedDate] [Date] NOT NULL,
	[Freight] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OrdersDetail](
	[OrderId] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NULL,
 CONSTRAINT [PK_OrdersDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId],[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO

ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO

ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO


INSERT INTO [dbo].[Categories] ([CategoryName])
VALUES ('Category 1'), ('Category 2'), ('Category 3'), ('Category 4'), ('Category 5');

INSERT INTO [dbo].[Members] ([Email], [CompanyName], [City], [Country], [Password])
VALUES
    ('member1@example.com', 'Company 1', 'City 1', 'Country 1', 'password1'),
    ('member2@example.com', 'Company 2', 'City 2', 'Country 2', 'password2'),
    ('member3@example.com', 'Company 3', 'City 3', 'Country 3', 'password3'),
    ('member4@example.com', 'Company 4', 'City 4', 'Country 4', 'password4'),
    ('member5@example.com', 'Company 5', 'City 5', 'Country 5', 'password5');

	INSERT INTO [dbo].[Products] ([CategoryID], [ProductName], [Weight], [UnitPrice], [UnitsInStock])
VALUES
    (1, 'Product 1', 1.5, 10.99, 100),
    (2, 'Product 2', 2.0, 19.99, 50),
    (1, 'Product 3', 0.5, 5.99, 200),
    (3, 'Product 4', 1.0, 8.99, 75),
    (2, 'Product 5', 1.8, 14.99, 120);

	INSERT INTO [dbo].[Orders] ([MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight])
VALUES
    (1, '2023-09-01', '2023-09-05', '2023-09-03', 10),
    (2, '2023-09-02', '2023-09-06', '2023-09-04', 15),
    (3, '2023-09-03', '2023-09-07', '2023-09-05', 12),
    (4, '2023-09-04', '2023-09-08', '2023-09-06', 18),
    (5, '2023-09-05', '2023-09-09', '2023-09-07', 20);

	INSERT INTO [dbo].[OrdersDetail] ([OrderId], [ProductID], [UnitPrice], [Quantity], [Discount])
VALUES
    (1, 1, 10.99, 2, 0.05),
    (2, 2, 19.99, 1, 0.1),
    (3, 3, 5.99, 3, 0.0),
    (4, 4, 8.99, 2, 0.0),
    (5, 5, 14.99, 1, 0.2);