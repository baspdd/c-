USE MASTER
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
CREATE TABLE [dbo].[Accounts] (
  [AccountId] [NVARCHAR](50) NOT NULL,
  [Password] [NVARCHAR](20) NOT NULL,
  [FullName] [NVARCHAR](50),
  [Type] [int] NOT NULL,
CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED
    (
        [AccountId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses] (
  [CourseId] [INT] IDENTITY(1,1) NOT NULL,
  [CourseName] [NVARCHAR](50) NOT NULL,
CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED
    (
	    [CourseId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keys] (
  [KeyId] [NVARCHAR](50) NOT NULL,
  [CourseId] [INT] NOT NULL,
CONSTRAINT [PK_Keys] PRIMARY KEY CLUSTERED
    (
	    [KeyId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions] (
  [QuestionId] [INT] NOT NULL,
  [KeyId] [NVARCHAR](50) NOT NULL,
  [Content] [NVARCHAR](200) NOT NULL,
  [Answer] [NVARCHAR](1000) NOT NULL,
  [RightAnswer] [NVARCHAR](200) NOT NULL,
CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED
    (
	    [QuestionId],[KeyId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams] (
  [ExamId] [INT] IDENTITY(1,1) NOT NULL,
  [AccountId] [NVARCHAR](50) NOT NULL,
  [KeyId] [NVARCHAR](50) NOT NULL,
  [Score] [NVARCHAR](200) NULL,
CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED
    (
	    [ExamId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamAnswers] (
  [ExamAnswer] [INT] NOT NULL,
  [ExamId] [INT] NOT NULL,
  [RightRightAnswer] [NVARCHAR](200) NOT NULL,
CONSTRAINT [PK_ExamAnswers] PRIMARY KEY CLUSTERED
    (
	    [ExamAnswer],[ExamId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




ALTER TABLE [dbo].[Keys]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO

ALTER TABLE [dbo].[Questions]  WITH CHECK ADD FOREIGN KEY([KeyId])
REFERENCES [dbo].[Keys] ([KeyId])
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD FOREIGN KEY([KeyId])
REFERENCES [dbo].[Keys] ([KeyId])
GO

ALTER TABLE [dbo].[ExamAnswers]  WITH CHECK ADD FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([ExamId])
GO


USE [MyStore]
GO

INSERT INTO [dbo].[Accounts] ([AccountId], [Password], [FullName], [Type])
VALUES
    ('duypdhe160308', '123', 'John Doe', 1),
    ('baspdd', '123', 'Jane Smith', 1),
    ('duy1', '123', 'Jane Smith', 1),
    ('duy2', '123', 'Jane Smith', 1),
    ('User3', 'Password3', 'Bob Johnson', 1),
    ('User4', 'Password4', 'Alice Brown', 1),
    ('staff', '123', 'Eve White', 0);


SET IDENTITY_INSERT [dbo].[Courses] ON;

INSERT INTO [dbo].[Courses] ([CourseId], [CourseName])
VALUES
    (1, 'Mathematics'),
    (2, 'History'),
    (3, 'Science'),
    (4, 'Literature'),
    (5, 'Computer Science');

SET IDENTITY_INSERT [dbo].[Courses] OFF;


INSERT INTO [dbo].[Keys] ([KeyId], [CourseId])
VALUES
    ('MAE101_FA23', 1),
	('MAE101_SU23', 1),
    ('Key2', 2),
    ('Key3', 3),
    ('Key4', 4),
    ('Key5', 5);



INSERT INTO [dbo].[Questions] ([QuestionId], [KeyId], [Content], [Answer], [RightAnswer])
VALUES
    (1, 'MAE101_FA23' , '2 + 2?', '4/5/6/7', '1'),
    (2, 'MAE101_FA23' , '2+5?', '5/3/4/7', '4'),
    (3, 'MAE101_FA23' ,'2?3', '</>/#/+', '1'),
    (4, 'MAE101_FA23' ,'n + 2 = 9. n? ', '3/6/7/9', '3'),
    (5, 'MAE101_FA23' ,'haha', '</>/#/+', '1/2/3'),
    (6, 'MAE101_FA23' ,'2+5?', '5/3/4/7', '4'),
    (7, 'MAE101_FA23' ,'2?3', '</>/#/+', '1'),
    (8, 'MAE101_FA23' ,'n + 2 = 9. n? ', '3/6/7/9', '3'),
    (9, 'MAE101_FA23' ,'haha', '</>/#/+', '1/2/3'),
    (1, 'Key2' , '2 + 2?', '4/5/6/7', '1'),
    (2, 'Key2' ,'2+5?', '5/3/4/7', '4'),
    (3, 'Key2' , '2?3', '</>/#/+', '1'),
    (4, 'Key2' ,'n + 2 = 9. n? ', '3/6/7/9', '3'),
    (5, 'Key2' ,'haha', '</>/#/+', '1/2/3');


SET IDENTITY_INSERT [dbo].[Exams] ON;

INSERT INTO [dbo].[Exams] ([ExamId], [AccountId], [KeyId], [Score])
VALUES
    (1, 'duy2', 'MAE101_FA23', '8.5'),
    (2, 'duy2', 'Key2', '9.2'),
    (3, 'duy1', 'Key2', '7.8');

SET IDENTITY_INSERT [dbo].[Exams] OFF;


INSERT INTO [dbo].[ExamAnswers] ([ExamAnswer], [ExamId], [RightRightAnswer])
VALUES
    (1, 1, 'Correct Answer 1'),
    (2, 1, 'Correct Answer 2'),
    (3, 1, 'Correct Answer 3'),
    (4, 2, 'Correct Answer 1'),
    (5, 2, 'Correct Answer 2'),
    (6, 2, 'Correct Answer 3'),
    (7, 3, 'Correct Answer 1'),
    (8, 3, 'Correct Answer 2'),
    (9, 3, 'Correct Answer 3'),
    (10, 3, 'Correct Answer 4');



-- INSERT INTO [dbo].[Accounts] ([AccountId], [Password], [FullName], [Type])
-- VALUES
--     ('duypdhe160308', '123', 'John Doe', 1),
--     ('baspdd', '123', 'Jane Smith', 1),
--     ('duy1', '123', 'Jane Smith', 1),
--     ('duy2', '123', 'Jane Smith', 1),
--     ('User3', 'Password3', 'Bob Johnson', 1),
--     ('User4', 'Password4', 'Alice Brown', 1),
--     ('User5', 'Password5', 'Eve White', 1);

-- INSERT INTO [dbo].[Courses] ([CourseName])
-- VALUES
--     ('Mathematics'),
--     ('History'),
--     ('Science'),
--     ('Literature'),
--     ('Computer Science');


-- INSERT INTO [dbo].[Keys] ([KeyId], [CourseId])
-- VALUES
--     ('MAE101_FA23', 1),
--     ('Key2', 2),
--     ('Key3', 3),
--     ('Key4', 4),
--     ('Key5', 5);


-- INSERT INTO [dbo].[Questions] ([QuestionId],[KeyId], [Content], [Answer], [RightAnswer])
-- VALUES
--     (1,'MAE101_FA23', '2 + 2?', '4/5/6/7', '1'),
--     (2,'MAE101_FA23', '2+5?', '5/3/4/7', '4'),
--     (3,'MAE101_FA23', '2?3', '</>/#/+', '1'),
--     (4,'MAE101_FA23', 'n + 2 = 9. n? ', '3/6/7/9', '3'),
--     (5,'MAE101_FA23', 'haha', '</>/#/+', '1/2/3'),
--     (6,'MAE101_FA23', '2+5?', '5/3/4/7', '4'),
--     (7,'MAE101_FA23', '2?3', '</>/#/+', '1'),
--     (8,'MAE101_FA23', 'n + 2 = 9. n? ', '3/6/7/9', '3'),
--     (9,'MAE101_FA23', 'haha', '</>/#/+', '1/2/3'),
--     (1,'Key2', '2 + 2?', '4/5/6/7', '1'),
--     (2,'Key2', '2+5?', '5/3/4/7', '4'),
--     (3,'Key2', '2?3', '</>/#/+', '1'),
--     (4,'Key2', 'n + 2 = 9. n? ', '3/6/7/9', '3'),
--     (5,'Key2', 'haha', '</>/#/+', '1/2/3');

-- INSERT INTO [dbo].[Exams] ([AccountId], [KeyId], [Score])
-- VALUES
--     ('duy2', 'MAE101_FA23', '85'),
--     ('duy2', 'Key2', '92'),
--     ('duy1', 'Key2', '78');


-- INSERT INTO [dbo].[ExamAnswers] ([ExamId], [RightRightAnswer])
-- VALUES
--     (1, 'Correct Answer 1'),
--     (1, 'Correct Answer 2'),
--     (1, 'Correct Answer 3'),
--     (2, 'Correct Answer 1'),
--     (2, 'Correct Answer 2'),
--     (2, 'Correct Answer 3'),
--     (3, 'Correct Answer 1'),
--     (3, 'Correct Answer 2'),
--     (3, 'Correct Answer 3'),
--     (3, 'Correct Answer 4');

