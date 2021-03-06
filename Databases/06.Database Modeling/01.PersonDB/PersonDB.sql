USE [master]
GO
/****** Object:  Database [PersonDB]    Script Date: 10/6/2015 12:27:39 PM ******/
CREATE DATABASE [PersonDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PersonDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PersonDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonDB] SET  MULTI_USER 
GO
ALTER DATABASE [PersonDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonDB', N'ON'
GO
USE [PersonDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/6/2015 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_text] [nvarchar](50) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 10/6/2015 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/6/2015 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 10/6/2015 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 10/6/2015 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [Address_text], [town_id]) VALUES (1, N'Mladost 1', 1)
INSERT [dbo].[Address] ([Id], [Address_text], [town_id]) VALUES (2, N'Mladost 3', 1)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Asia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Africa')
INSERT [dbo].[Continent] ([id], [name]) VALUES (4, N'Antarctica')
INSERT [dbo].[Continent] ([id], [name]) VALUES (5, N'Australia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (6, N'North America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (7, N'South America')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (2, N'France', 1)
INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (3, N'Germany', 1)
INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (4, N'China', 2)
INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (5, N'Malaysia', 2)
INSERT [dbo].[Country] ([Id], [name], [continent_id]) VALUES (6, N'Egypt', 3)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [address_id]) VALUES (1, N'Pesho', N'Petrov', 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [address_id]) VALUES (2, N'Stamat', N'Dimitrov', 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [address_id]) VALUES (3, N'Stamina', N'Petrova', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([Id], [Name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([Id], [Name], [country_id]) VALUES (2, N'Burgas', 1)
INSERT [dbo].[Town] ([Id], [Name], [country_id]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Town] ([Id], [Name], [country_id]) VALUES (4, N'Plovdiv', 1)
INSERT [dbo].[Town] ([Id], [Name], [country_id]) VALUES (5, N'Berlin', 3)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PersonDB] SET  READ_WRITE 
GO
