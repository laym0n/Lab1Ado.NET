USE [master]
GO

/****** Object:  Database [Aquapark]    Script Date: 19.11.2022 0:14:41 ******/
CREATE DATABASE [Aquapark]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Aquapark', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Aquapark.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Aquapark_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Aquapark_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aquapark].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Aquapark] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Aquapark] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Aquapark] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Aquapark] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Aquapark] SET ARITHABORT OFF 
GO

ALTER DATABASE [Aquapark] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Aquapark] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Aquapark] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Aquapark] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Aquapark] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Aquapark] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Aquapark] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Aquapark] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Aquapark] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Aquapark] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Aquapark] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Aquapark] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Aquapark] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Aquapark] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Aquapark] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Aquapark] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Aquapark] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Aquapark] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Aquapark] SET  MULTI_USER 
GO

ALTER DATABASE [Aquapark] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Aquapark] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Aquapark] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Aquapark] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Aquapark] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Aquapark] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Aquapark] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Aquapark] SET  READ_WRITE 
GO
USE [Aquapark]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bracelet](
	[Bracelet_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NOT NULL,
	[Deposit] [int] NOT NULL,
 CONSTRAINT [PK_bracelet] PRIMARY KEY CLUSTERED 
(
	[Bracelet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[bracelet]  WITH CHECK ADD  CONSTRAINT [FK_bracelet_Customer] FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO

ALTER TABLE [dbo].[bracelet] CHECK CONSTRAINT [FK_bracelet_Customer]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[recreation_area](
	[recreation_area_id] [int] IDENTITY(1,1) NOT NULL,
	[cost_in_hour] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_recreation_area] PRIMARY KEY CLUSTERED 
(
	[recreation_area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[operation](
	[operation_id] [int] IDENTITY(1,1) NOT NULL,
	[recreation_area_id] [int] NOT NULL,
	[bracelet_id] [int] NOT NULL,
	[sum] [int] NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_operation] PRIMARY KEY CLUSTERED 
(
	[operation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[operation] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [time]
GO

ALTER TABLE [dbo].[operation]  WITH CHECK ADD  CONSTRAINT [FK_operation_bracelet] FOREIGN KEY([bracelet_id])
REFERENCES [dbo].[bracelet] ([Bracelet_id])
GO

ALTER TABLE [dbo].[operation] CHECK CONSTRAINT [FK_operation_bracelet]
GO

ALTER TABLE [dbo].[operation]  WITH CHECK ADD  CONSTRAINT [FK_operation_recreation_area] FOREIGN KEY([recreation_area_id])
REFERENCES [dbo].[recreation_area] ([recreation_area_id])
GO

ALTER TABLE [dbo].[operation] CHECK CONSTRAINT [FK_operation_recreation_area]
GO

SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (1, 'Кочнев' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (2, 'Михайлов' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (3, 'Иванов' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (4, 'Докетов' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (5, 'Лапшин' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (6, 'Комаров' ,'RegularCustomer')
INSERT INTO [dbo].[Customer] ([Customer_ID], [Name] ,[Status]) VALUES (7, 'Замыцкий' ,'RegularCustomer')

SET IDENTITY_INSERT [dbo].[Customer] OFF

GO
SET IDENTITY_INSERT [dbo].[recreation_area] ON 

INSERT INTO [dbo].[recreation_area] ([recreation_area_id], [cost_in_hour] ,[Name]) VALUES (1, 100 , 'Бар')
INSERT INTO [dbo].[recreation_area] ([recreation_area_id], [cost_in_hour] ,[Name]) VALUES (2, 200 , 'Горки')
INSERT INTO [dbo].[recreation_area] ([recreation_area_id], [cost_in_hour] ,[Name]) VALUES (3, 300 , 'Бассейн')
INSERT INTO [dbo].[recreation_area] ([recreation_area_id], [cost_in_hour] ,[Name]) VALUES (4, 400 , 'Дельфинарий')

SET IDENTITY_INSERT [dbo].[recreation_area] OFF

GO
SET IDENTITY_INSERT [dbo].[bracelet] ON 

INSERT INTO [dbo].[bracelet] ([Bracelet_id], [Customer_id] ,[Deposit]) VALUES (1, 2 ,100)
INSERT INTO [dbo].[bracelet] ([Bracelet_id], [Customer_id] ,[Deposit]) VALUES (2, 3 ,1000)

SET IDENTITY_INSERT [dbo].[bracelet] OFF

GO
SET IDENTITY_INSERT [dbo].[operation] ON 

INSERT INTO [dbo].[operation] ([operation_id], [recreation_area_id] ,[bracelet_id] ,[sum] ,[time]) VALUES (1, 2 ,2,500,'10.09.2002')
SET IDENTITY_INSERT [dbo].[operation] OFF

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[operations_between]
    @low_sum int,
    @upper_sum int
AS
select o.operation_id, o.bracelet_id, o.recreation_area_id, o.sum, o.time from operation o
where o.sum between @low_sum and @upper_sum
GO