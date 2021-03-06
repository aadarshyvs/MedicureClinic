USE [master]
GO
/****** Object:  Database [Medicure]    Script Date: 24-06-2022 08:49:59 ******/
CREATE DATABASE [Medicure]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Medicure', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Medicure.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Medicure_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Medicure_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Medicure] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Medicure].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Medicure] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Medicure] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Medicure] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Medicure] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Medicure] SET ARITHABORT OFF 
GO
ALTER DATABASE [Medicure] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Medicure] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Medicure] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Medicure] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Medicure] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Medicure] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Medicure] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Medicure] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Medicure] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Medicure] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Medicure] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Medicure] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Medicure] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Medicure] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Medicure] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Medicure] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Medicure] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Medicure] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Medicure] SET  MULTI_USER 
GO
ALTER DATABASE [Medicure] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Medicure] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Medicure] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Medicure] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Medicure] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Medicure]
GO
/****** Object:  Table [dbo].[Appointment_Log]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Appointment_Log](
	[Appointment_ID] [int] NOT NULL,
	[Patient_Id] [int] NOT NULL,
	[Physician_Id] [int] NOT NULL,
	[illness] [varchar](20) NOT NULL,
	[Date_of_visit] [varchar](20) NOT NULL,
	[Prescription_Status] [bit] NULL CONSTRAINT [DF_Appointment_Log_Prescription_Status]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Drug]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Drug](
	[Id] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Required_Qty] [int] NULL CONSTRAINT [DF_Drug_Required_Qty]  DEFAULT ((0)),
	[Instock_Qty] [int] NULL CONSTRAINT [DF_Drug_Instock_Qty]  DEFAULT ((100)),
	[Price] [float] NOT NULL,
	[Supplier_Id] [int] NOT NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
	[DateOfReg] [varchar](20) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Paitents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Physician]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Physician](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Specialization] [varchar](20) NOT NULL,
	[Username] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
 CONSTRAINT [PK_Physician] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prescription_Log]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription_Log](
	[Appointment_ID] [int] NOT NULL,
	[Drug_Id] [int] NOT NULL,
	[Dosage] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[Supplier_Id] [int] NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supplier_Log]    Script Date: 24-06-2022 08:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier_Log](
	[Supplier_Id] [int] NOT NULL,
	[Physician_ID] [int] NULL,
	[Drug_id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Date] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Medicure] SET  READ_WRITE 
GO
