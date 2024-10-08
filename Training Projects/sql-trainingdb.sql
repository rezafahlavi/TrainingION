USE [master]
GO
/****** Object:  Database [TrainingDB]    Script Date: 3/30/2021 10:41:45 PM ******/
CREATE DATABASE [TrainingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JADE2019\MSSQL\DATA\TrainingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JADE2019\MSSQL\DATA\TrainingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TrainingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrainingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrainingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrainingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TrainingDB] SET  MULTI_USER 
GO
ALTER DATABASE [TrainingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TrainingDB', N'ON'
GO
ALTER DATABASE [TrainingDB] SET QUERY_STORE = OFF
GO
USE [TrainingDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/30/2021 10:41:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Qty] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 3/30/2021 10:41:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[Phone] [varchar](20) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/30/2021 10:41:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [UserID], [Name], [Qty], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, N'Gray Table', 1, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [UserID], [Name], [Qty], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 1, N'Black Chair', NULL, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [UserID], [Name], [Qty], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 1, N'Colorful Painting', 2, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [UserID], [Name], [Qty], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, N'Paper Bags', 1000, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [UserID], [Name], [Qty], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, N'Pencils', 10000, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[UserDetails] ([UserID], [FullName], [Phone], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'John Doe', N'62812121212', 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserDetails] ([UserID], [FullName], [Phone], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Jane Smith', N'62813131313', 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserDetails] ([UserID], [FullName], [Phone], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Jack Black', N'62811212323', 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [IsActive], [IsVerified], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'jdoe', 1, 1, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([UserID], [UserName], [IsActive], [IsVerified], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'jsmith', 1, 0, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([UserID], [UserName], [IsActive], [IsVerified], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'jblack', 0, 0, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Users]
GO
USE [master]
GO
ALTER DATABASE [TrainingDB] SET  READ_WRITE 
GO
