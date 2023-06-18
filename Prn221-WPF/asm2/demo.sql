USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 10/26/2022 8:38:04 PM ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MyStore')
BEGIN
	ALTER DATABASE [MyStore] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [MyStore] SET ONLINE;
	DROP DATABASE [MyStore];
END
GO
CREATE DATABASE [MyStore]
GO
ALTER DATABASE [MyStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStore] SET RECOVERY FULL 
GO
ALTER DATABASE [MyStore] SET  MULTI_USER 
GO
ALTER DATABASE [MyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyStore', N'ON'
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = OFF
GO
USE [MyStore]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the Customers table
CREATE TABLE [dbo].[Customers] (
  [CustomerID] [VARCHAR](8) NOT NULL,
  [ContactName] [VARCHAR](50) NOT NULL,
  [Address] [VARCHAR](100),
  [Phone] [VARCHAR](12),
  CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED
    (
	    [CustomerID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the Orders table
CREATE TABLE [dbo].[Orders] (
  [OrderID] [VARCHAR](8) NOT NULL,
  [CustomerID] [VARCHAR](8) NOT NULL,
  [OrderDate] DATE NOT NULL,
  [RequiredDate] DATE,
  [ShippedDate] DATE,
  [Freight] FLOAT,
  [ShipAddress] VARCHAR(255) NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED
    (
	    [OrderID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the Products table
CREATE TABLE [dbo].[Products] (
  [ProductID] [VARCHAR](8) NOT NULL,
  [ProductName] [VARCHAR](50) NOT NULL,
  [SupplierID] [VARCHAR](8) NOT NULL,
  [CategoryID] [VARCHAR](8) NOT NULL,
  [QuantityPerUnit] [INT] NOT NULL,
  [UnitPrice] [FLOAT] NOT NULL,
  [ProductImage] [VARCHAR](800) NOT NULL,
  CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED
    (
	    [ProductID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the OrderDetails table
CREATE TABLE [dbo].[OrderDetails] (
  [OrderID] [VARCHAR](8) NOT NULL,
  [ProductID] [VARCHAR](8) NOT NULL,
  [UnitPrice] [FLOAT] NOT NULL,
  [Quantity] [INT] NOT NULL,
    CONSTRAINT [PK_orderdetails] PRIMARY KEY CLUSTERED
    (
        [OrderID] ASC,
	    [ProductID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the Categories table
CREATE TABLE [dbo].[Categories] (
  [CategoryID] [VARCHAR](8) NOT NULL,
  [CategoryName] [VARCHAR](50) NOT NULL,
  [Description] [VARCHAR](255),
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED
    (
        [CategoryID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the Suppliers table
CREATE TABLE [dbo].[Suppliers] (
  [SupplierID] [VARCHAR](8) NOT NULL,
  [CompanyName] [VARCHAR](50) NOT NULL,
  [Address] [VARCHAR](50) NOT NULL,
  [Phone] [VARCHAR](12) NOT NULL,
CONSTRAINT [PK_suppliers] PRIMARY KEY CLUSTERED
    (
        [SupplierID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Create the Account table
CREATE TABLE [dbo].[Account] (
  [AccountID] [VARCHAR](8) NOT NULL,
  [UserName] [VARCHAR](10) NOT NULL,
  [Password] [VARCHAR](20) NOT NULL,
  [FullName] [VARCHAR](50),
  [Type] [BIT] NOT NULL,
CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED
    (
        [AccountID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO


ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO


ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO


ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO


INSERT INTO [dbo].[Customers] ([CustomerID], [ContactName], [Address], [Phone])
VALUES
  ('CUST001', 'John Doe', '123 Main St', '555-123-4567'),
  ('CUST002', 'Jane Smith', '456 Oak Ave', '555-987-6543'),
  ('CUST003', 'Michael Brown', '789 Elm St', '555-555-5555'),
  ('CUST004', 'Emily Johnson', '321 Pine Dr', '555-111-2222'),
  ('CUST005', 'David Lee', '987 Maple Ln', '555-444-3333')

INSERT INTO [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipAddress])
VALUES
  ('ORDER001', 'CUST001', '2023-06-01', '2023-06-10', '2023-06-05', 10.50, '123 Main St, City'),
  ('ORDER002', 'CUST002', '2023-06-02', '2023-06-12', '2023-06-06', 8.20, '456 Oak Ave, Town'),
  ('ORDER003', 'CUST003', '2023-06-03', '2023-06-15', NULL, 15.00, '789 Elm St, Village'),
  ('ORDER004', 'CUST001', '2023-06-05', '2023-06-13', '2023-06-08', 12.75, '123 Main St, City'),
  ('ORDER005', 'CUST004', '2023-06-07', '2023-06-17', NULL, 9.80, '321 Pine Dr, Suburb')

INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName], [Description])
VALUES
  ('CAT001', 'Electronics', 'Electronic items'),
  ('CAT002', 'Home', 'Household items'),
  ('CAT003', 'Office', 'Office supplies'),
  ('CAT004', 'Sports', 'Sporting goods'),
  ('CAT005', 'Toys', 'Toys and games')

INSERT INTO [dbo].[Suppliers] ([SupplierID], [CompanyName], [Address], [Phone])
VALUES
  ('SUPP001', 'ABC Supplier', '123 Main St', '555-123-4567'),
  ('SUPP002', 'XYZ Supplier', '456 Oak Ave', '555-987-6543'),
  ('SUPP003', '123 Supplier', '789 Elm St', '555-555-5555'),
  ('SUPP004', '456 Supplier', '321 Pine Dr', '555-111-2222'),
  ('SUPP005', '789 Supplier', '987 Maple Ln', '555-444-3333')

INSERT INTO [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [ProductImage])
VALUES
  ('PROD001', 'Product 1', 'SUPP001', 'CAT001', 10, 9.99, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/350781265_1295263821372175_5190036337875935239_n.jpg?stp=cp6_dst-jpg&_nc_cat=107&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=c4q3kPNwXAIAX-F_o-p&_nc_ht=scontent.fhan6-1.fna&oh=00_AfB3fq_ByGWaTTblin61vC4GW2CkCVdbCIiy9TC2UmLd8A&oe=649337FF'),
  ('PROD002', 'morning', 'SUPP002', 'CAT001', 5, 19.99, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/350623235_638102698379060_752580631665324870_n.jpg?stp=cp6_dst-jpg&_nc_cat=102&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=JNdxlnDFmFEAX9uy7AV&_nc_ht=scontent.fhan6-1.fna&oh=00_AfCSn--yDS0Zv0qkPvRTHkboYt-N1n51xyVE1W7KT0AFww&oe=6494020C'),
  ('PROD003', 'hehe', 'SUPP001', 'CAT002', 8, 14.50, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/350634905_3537302983223926_8001267812871916369_n.jpg?stp=cp6_dst-jpg&_nc_cat=107&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=bI7IMmdyQY4AX9wZe8F&_nc_ht=scontent.fhan6-1.fna&oh=00_AfBQGyjXR7b331_LpHwCox8bVFliUd6lP7ln7CpccJEKgg&oe=649411DD'),
  ('PROD004', 'after', 'SUPP003', 'CAT002', 3, 24.75, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/330793600_1123879468294149_7690714287165358882_n.jpg?stp=dst-jpg_s600x600&_nc_cat=101&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=KXeFaakkvhoAX92IUMc&_nc_ht=scontent.fhan6-1.fna&oh=00_AfDQfGf_l380UQOlwUzt4AGlJbBvwJqtfmZGylpFi0ibjg&oe=6492D624'),
  ('PROD005', 'prn5', 'SUPP004', 'CAT003', 2, 8.95, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/330767980_1223434151713438_1827717881675134674_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=ICdaFz0I1RsAX_l6okD&_nc_ht=scontent.fhan6-1.fna&oh=00_AfB_7P9-5xVDn3_kQEg14WEi6zxKegk1cj7RjeYivrgPdA&oe=6492F08D'),
  ('PROD006', 'emss', 'SUPP003', 'CAT003', 2, 8.95, 'https://scontent.fhan6-1.fna.fbcdn.net/v/t39.30808-6/273023416_1286650261838847_3665950937971259236_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=8bfeb9&_nc_ohc=p8a3jq81QGoAX9p3jcx&_nc_ht=scontent.fhan6-1.fna&oh=00_AfDZJDoJ1XW1NLPkT7ihsk3f4PWXpYH7aHWhqiEvRTFK6w&oe=64932412')

INSERT INTO [dbo].[OrderDetails] ([OrderID], [ProductID], [UnitPrice], [Quantity])
VALUES
  ('ORDER001', 'PROD001', 9.99, 3),
  ('ORDER001', 'PROD002', 19.99, 2),
  ('ORDER002', 'PROD003', 14.50, 1),
  ('ORDER002', 'PROD004', 24.75, 4),
  ('ORDER003', 'PROD002', 19.99, 2)



INSERT INTO [dbo].[Account] ([AccountID], [UserName], [Password], [FullName], [Type])
VALUES
  ('CUST001', 'duy', '123', 'John Doe', 1),
  ('CUST002', 'user2', 'password2', 'Jane Smith', 0),
  ('CUST003', 'user3', 'password3', 'Michael Brown', 0),
  ('CUST004', 'user4', 'password4', 'Emily Johnson', 0),
  ('CUST005', 'user5', 'password5', 'David Lee', 1)


USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
