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
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_desc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[pub_id] [int] IDENTITY(1,1) NOT NULL,
	[pub_name] [nvarchar](50) NULL,
	[city] [nvarchar](100) NOT NULL,
	[state] [nvarchar](100) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[pub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[source] [nvarchar](100) NULL,
	[first_name] [nvarchar](100) NULL,
	[middle_name] [nvarchar](100) NULL,
	[last_name] [nvarchar](100) NULL,
	[role_id] [int] NULL,
	[pub_id] [int] NULL,
	[hire_date] [Date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[type] [nvarchar](100) NOT NULL,
	[pub_id] [int] NOT NULL,
	[price] [money] NOT NULL,
	[advance] [nvarchar](100) NOT NULL,
	[royalty] [nvarchar](100) NOT NULL,
	[sale] [float] NOT NULL,
	[note] [nvarchar](100) NOT NULL,
	[publishdate] [Date] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[city] [nvarchar](100) NOT NULL,
	[state] [nvarchar](100) NOT NULL,
	[zip] [nvarchar](100) NOT NULL,
	[email_address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BookAuthor](
	[author_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[author_order] [nvarchar](100) NOT NULL,
	[royaltypercent] [float] NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[author_id],[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO


ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO

ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO

ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO


INSERT INTO [dbo].[Role] ([role_desc])
VALUES ('Administrator'), ('Editor'), ('Author'), ('Reader'), ('Guest');



INSERT INTO [dbo].[Publisher] ([pub_name], [city], [state], [country])
VALUES 
    ('Publisher A', 'New York', 'New York', 'USA'),
    ('Publisher B', 'London', 'England', 'UK'),
    ('Publisher C', 'Sydney', 'New South Wales', 'Australia');



INSERT INTO [dbo].[User] ([email], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date])
VALUES 
    ('admin@example.com', 'admin123', 'Website', 'John', 'Doe', 'Admin', 1, 1, GETDATE()),
    ('editor@example.com', 'editor123', 'Website', 'Jane', 'Smith', 'Editor', 2, 1, GETDATE()),
    ('author@example.com', 'author123', 'Website', 'Michael', 'Johnson', 'Author', 3, 2, GETDATE()),
    ('reader@example.com', 'reader123', 'Website', 'Sarah', 'Williams', 'Reader', 4, 2, GETDATE()),
    ('guest@example.com', 'guest123', 'Website', 'Alex', 'Brown', 'Guest', 5, 3, GETDATE());

	
INSERT INTO [dbo].[Book] ([title], [type], [pub_id], [price], [advance], [royalty], [sale], [note], [publishdate])
VALUES 
    ('Book 1', 'Fiction', 1, 19.99, '1000', '10%', 0.5, 'Note 1', GETDATE()),
    ('Book 2', 'Non-fiction', 2, 29.99, '1500', '15%', 0.75, 'Note 2', GETDATE()),
    ('Book 3', 'Fiction', 1, 24.99, '1200', '12%', 0.6, 'Note 3', GETDATE()),
    ('Book 4', 'Non-fiction', 3, 34.99, '2000', '20%', 0.8, 'Note 4', GETDATE()),
    ('Book 5', 'Fiction', 2, 14.99, '800', '8%', 0.4, 'Note 5', GETDATE());

INSERT INTO [dbo].[Author] ([first_name], [last_name], [phone], [address], [city], [state], [zip], [email_address])
VALUES 
    ('Author 1', 'Doe', '123-456-7890', '123 Main St', 'New York', 'New York', '12345', 'author1@example.com'),
    ('Author 2', 'Smith', '987-654-3210', '456 Elm St', 'London', 'England', '54321', 'author2@example.com'),
    ('Author 3', 'Johnson', '555-123-4567', '789 Oak St', 'Sydney', 'New South Wales', '67890', 'author3@example.com'),
    ('Author 4', 'Williams', '222-333-4444', '321 Pine St', 'New York', 'New York', '67890', 'author4@example.com'),
    ('Author 5', 'Brown', '111-222-3333', '654 Maple St', 'London', 'England', '12345', 'author5@example.com');

INSERT INTO [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royaltypercent])
VALUES 
    (1, 1, 'First Author', 10),
    (2, 1, 'Second Author', 20),
    (3, 2, 'First Author', 15),
    (4, 3, 'First Author', 12),
    (5, 4, 'First Author', 18);