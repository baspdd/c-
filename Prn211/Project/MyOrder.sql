﻿USE [master]
GO
/****** Object:  Database [ASMSS]    Script Date: 10/26/2022 8:38:04 PM ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ASMSS')
BEGIN
	ALTER DATABASE [ASMSS] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [ASMSS] SET ONLINE;
	DROP DATABASE [ASMSS];
END
GO
CREATE DATABASE [ASMSS]
GO
ALTER DATABASE [ASMSS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ASMSS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ASMSS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ASMSS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ASMSS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ASMSS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ASMSS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ASMSS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ASMSS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ASMSS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ASMSS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ASMSS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ASMSS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ASMSS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ASMSS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ASMSS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ASMSS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ASMSS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ASMSS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ASMSS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ASMSS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ASMSS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ASMSS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ASMSS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ASMSS] SET RECOVERY FULL 
GO
ALTER DATABASE [ASMSS] SET  MULTI_USER 
GO
ALTER DATABASE [ASMSS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ASMSS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ASMSS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ASMSS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ASMSS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ASMSS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ASMSS', N'ON'
GO
ALTER DATABASE [ASMSS] SET QUERY_STORE = OFF
GO
USE [ASMSS]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/26/2022 8:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](11) NULL,
	[address] [nvarchar](200) NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/26/2022 8:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[type] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[image] [varchar](4000) NULL,
	[is_sale] [int] NULL,
	[description] [nvarchar](4000) NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/26/2022 8:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 10/26/2022 8:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[oid] [int] NOT NULL,
	[proID] [int] NOT NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK_orderitem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/26/2022 8:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](

	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[send] [Date] NULL,
	[received] [Date] NULL,
	[status] [int] NOT NULL,
	[total][decimal] NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT INTO [dbo].[User] ([id],[fullname],[email],[phone],[address],[username],[password])
     VALUES (1,'Duy Pham','duy@gmail.com','0942127769','sadsa','duy','2002')
GO
SET IDENTITY_INSERT [dbo].[User] OFF 
GO

SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT INTO [dbo].[Category] ([id],[name]) VALUES (1,'Chairs')
GO
INSERT INTO [dbo].[Category] ([id],[name]) VALUES (2,'Table')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF 
GO

SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT INTO [dbo].[Product] ([id],[title],[type],[price],[image],[is_sale],[description],[amount])
     VALUES  (1, 'Armrest Chair', 1, 15299.000, 'https://www.ikea.com/om/en/images/products/stefan-chair-brown-black__0727320_pe735593_s5.jpg?f=s', 0, 'Shilpi Handicrafts Wooden Armrest Chair for Home & Office (Solid Wood, Standard)' , 10)
GO
INSERT INTO [dbo].[Product] ([id],[title],[type],[price],[image],[is_sale],[description],[amount])
     VALUES  (2, 'stealt Chair', 1, 15299.000, 'https://mobileimages.lowes.com/productimages/9a8fed5d-da28-4a56-b2df-6a952050ef0a/44126414.jpg?size=pdhism', 5, 'Shilpi Handicrafts Wooden Armrest Chair for Home & Office (Solid Wood, Standard)' , 30)
GO
INSERT INTO [dbo].[Product] ([id],[title],[type],[price],[image],[is_sale],[description],[amount])
     VALUES  (3, 'NODELAND', 2, 15299.000, 'https://www.ikea.com/in/en/images/products/nodeland-coffee-table-medium-brown__0974637_pe812499_s5.jpg?f=xl', 12, 'NODELAND Coffee table, medium brown, 80x50 cm (31 1/2x19 5/8 ")' , 12)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF 
GO

SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT INTO [dbo].[Order] ([id],[uid],[send],[received],[status],[total]) VALUES (1, 1  ,CAST(N'2022-03-15' AS Date),NULL,0, 129504.21)
GO
SET IDENTITY_INSERT [dbo].[Order] OFF 
GO



SET IDENTITY_INSERT [dbo].[OrderItem] ON 
GO
INSERT INTO [dbo].[OrderItem] ([id],[oid],[proID],[amount]) VALUES  (1,1, 1,3)
GO
INSERT INTO [dbo].[OrderItem] ([id],[oid],[proID],[amount]) VALUES  (2,1, 2,3)
GO
INSERT INTO [dbo].[OrderItem] ([id],[oid],[proID],[amount]) VALUES  (3,1, 3,3)
GO
SET IDENTITY_INSERT [dbo].[OrderItem] OFF 
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([type])
REFERENCES [dbo].[Category] ([id])
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([uid])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([oid])
REFERENCES [dbo].[Order] ([id])
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([proID])
REFERENCES [dbo].[Product] ([id])
GO

USE [master]
GO
ALTER DATABASE [ASMSS] SET  READ_WRITE 
GO