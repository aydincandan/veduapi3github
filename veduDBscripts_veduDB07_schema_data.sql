USE [master]
GO
/****** Object:  Database [veduDB07]    Script Date: 07.12.2018 01:04:50 ******/
CREATE DATABASE [veduDB07]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'veduDB07', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\veduDB07.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'veduDB07_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\veduDB07_log.ldf' , SIZE = 1344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [veduDB07] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [veduDB07].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [veduDB07] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [veduDB07] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [veduDB07] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [veduDB07] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [veduDB07] SET ARITHABORT OFF 
GO
ALTER DATABASE [veduDB07] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [veduDB07] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [veduDB07] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [veduDB07] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [veduDB07] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [veduDB07] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [veduDB07] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [veduDB07] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [veduDB07] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [veduDB07] SET  ENABLE_BROKER 
GO
ALTER DATABASE [veduDB07] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [veduDB07] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [veduDB07] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [veduDB07] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [veduDB07] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [veduDB07] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [veduDB07] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [veduDB07] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [veduDB07] SET  MULTI_USER 
GO
ALTER DATABASE [veduDB07] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [veduDB07] SET DB_CHAINING OFF 
GO
ALTER DATABASE [veduDB07] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [veduDB07] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [veduDB07] SET DELAYED_DURABILITY = DISABLED 
GO
USE [veduDB07]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DersDetaylar]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersDetaylar](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[DerslerIdE] [int] NULL,
	[TitleAciklama] [nvarchar](255) NULL,
	[Sirano] [int] NULL,
 CONSTRAINT [PK_DersDetaylar] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dersler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dersler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](64) NULL,
	[Sirano] [int] NULL,
 CONSTRAINT [PK_Dersler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Icerikler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Icerikler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[BelgeAdi] [nvarchar](32) NULL,
	[BelgeLink] [nvarchar](128) NULL,
	[BelgeAciklama] [nvarchar](256) NULL,
	[DerslerIdE] [int] NOT NULL,
	[Sirano] [int] NULL,
 CONSTRAINT [PK_Icerikler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KisiAdminler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisiAdminler](
	[AdminIdE] [int] NOT NULL,
	[YetkiSeviye] [int] NULL,
 CONSTRAINT [PK_KisiAdminler] PRIMARY KEY CLUSTERED 
(
	[AdminIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KisiAdresler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisiAdresler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NULL,
	[AcikAdres] [nvarchar](128) NULL,
	[Sehir] [nvarchar](20) NULL,
	[Ulke] [nvarchar](20) NULL,
	[newcurrent] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_KisiAdresler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kisiler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kisiler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[RegisterDate] [datetime2](7) NULL,
	[RegisterDateIP] [nvarchar](15) NULL,
	[ConfirmDate] [datetime2](7) NULL,
	[ConfirmDateIP] [nvarchar](15) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsEmailConfirmed] [bit] NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Username] [nvarchar](32) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Adi] [nvarchar](32) NULL,
	[Soyadi] [nvarchar](32) NULL,
	[TCkimlik] [nvarchar](11) NULL,
	[KisiTipi] [nvarchar](3) NULL,
 CONSTRAINT [PK_Kisiler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kisiler_Dersler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler_Dersler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NOT NULL,
	[DerslerIdE] [int] NOT NULL,
 CONSTRAINT [PK_Kisiler_Dersler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kisiler_Icerikler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler_Icerikler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NOT NULL,
	[IceriklerIdE] [int] NOT NULL,
 CONSTRAINT [PK_Kisiler_Icerikler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kisiler_Takvimler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler_Takvimler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NOT NULL,
	[TakvimlerIdE] [int] NOT NULL,
 CONSTRAINT [PK_Kisiler_Takvimler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KisiOgrenciler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisiOgrenciler](
	[OgrenciIdE] [int] NOT NULL,
	[IlgiAlanlari] [nvarchar](80) NULL,
 CONSTRAINT [PK_KisiOgrenciler] PRIMARY KEY CLUSTERED 
(
	[OgrenciIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KisiOgretmenler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisiOgretmenler](
	[OgretmenIdE] [int] NOT NULL,
	[UzmanlikAlanlari] [nvarchar](80) NULL,
 CONSTRAINT [PK_KisiOgretmenler] PRIMARY KEY CLUSTERED 
(
	[OgretmenIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KisiTelefonlar]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisiTelefonlar](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NULL,
	[Telefonu] [nvarchar](10) NULL,
	[UlkeKodu] [nvarchar](2) NULL,
	[newcurrent] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_KisiTelefonlar] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginTracker]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTracker](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KisilerIdE] [int] NULL,
	[KisiIdE] [int] NOT NULL,
	[LoginDate] [datetime2](7) NOT NULL,
	[LoginDateIP] [nvarchar](15) NULL,
 CONSTRAINT [PK_LoginTracker] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Takvimler]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Takvimler](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[KursZamani] [datetime2](7) NOT NULL,
	[KursAciklama] [nvarchar](256) NULL,
	[Sirano] [int] NULL,
	[DersDetaylarIdE] [int] NOT NULL DEFAULT ((0)),
	[DerslerIdE] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Takvimler] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestTuzel1]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestTuzel1](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[RegisterDate] [datetime2](7) NULL,
	[RegisterDateIP] [nvarchar](15) NULL,
	[ConfirmDate] [datetime2](7) NULL,
	[ConfirmDateIP] [nvarchar](15) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsEmailConfirmed] [bit] NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Username] [nvarchar](32) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Unvan] [nvarchar](32) NULL,
	[SirketAdi] [nvarchar](32) NULL,
	[VergiDairesi] [nvarchar](10) NULL,
	[VergiNo] [nvarchar](10) NULL,
	[testtuzel1value] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestTuzel1] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestTuzel2]    Script Date: 07.12.2018 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestTuzel2](
	[IdE] [int] IDENTITY(1,1) NOT NULL,
	[RegisterDate] [datetime2](7) NULL,
	[RegisterDateIP] [nvarchar](15) NULL,
	[ConfirmDate] [datetime2](7) NULL,
	[ConfirmDateIP] [nvarchar](15) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsEmailConfirmed] [bit] NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Username] [nvarchar](32) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Unvan] [nvarchar](32) NULL,
	[SirketAdi] [nvarchar](32) NULL,
	[VergiDairesi] [nvarchar](10) NULL,
	[VergiNo] [nvarchar](10) NULL,
	[testtuzel2value] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestTuzel2] PRIMARY KEY CLUSTERED 
(
	[IdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205180356_000', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205180727_001', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205181009_002', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205182727_003', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205182929_004', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205183145_005', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181205190003_006', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206085428_007', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206085702_008', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206090653_009', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206090916_010', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206140015_011', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206165519_012', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181206210319_013', N'2.1.3-rtm-32065')
SET IDENTITY_INSERT [dbo].[DersDetaylar] ON 

INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (1, 1, N'MAT(1)', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (2, 1, N'MAT(2)', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (3, 1, N'MAT(3)', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (4, 1, N'MAT IV', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (5, 2, N'FİZIK I', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (6, 2, N'FIZIK II', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (7, 2, N'FIZIK III', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (8, 3, N'EKONOMIYE GIRIS', NULL)
INSERT [dbo].[DersDetaylar] ([IdE], [DerslerIdE], [TitleAciklama], [Sirano]) VALUES (9, 3, N'EKON 2', NULL)
SET IDENTITY_INSERT [dbo].[DersDetaylar] OFF
SET IDENTITY_INSERT [dbo].[Dersler] ON 

INSERT [dbo].[Dersler] ([IdE], [Title], [Sirano]) VALUES (1, N'MAT', NULL)
INSERT [dbo].[Dersler] ([IdE], [Title], [Sirano]) VALUES (2, N'FIZ', NULL)
INSERT [dbo].[Dersler] ([IdE], [Title], [Sirano]) VALUES (3, N'EKO', NULL)
SET IDENTITY_INSERT [dbo].[Dersler] OFF
SET IDENTITY_INSERT [dbo].[Icerikler] ON 

INSERT [dbo].[Icerikler] ([IdE], [BelgeAdi], [BelgeLink], [BelgeAciklama], [DerslerIdE], [Sirano]) VALUES (2, N'nükleer fizik', NULL, NULL, 2, NULL)
INSERT [dbo].[Icerikler] ([IdE], [BelgeAdi], [BelgeLink], [BelgeAciklama], [DerslerIdE], [Sirano]) VALUES (3, N'stagflasyon', NULL, NULL, 3, NULL)
INSERT [dbo].[Icerikler] ([IdE], [BelgeAdi], [BelgeLink], [BelgeAciklama], [DerslerIdE], [Sirano]) VALUES (4, N'Büyülü matematik', NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Icerikler] OFF
SET IDENTITY_INSERT [dbo].[KisiAdresler] ON 

INSERT [dbo].[KisiAdresler] ([IdE], [KisilerIdE], [AcikAdres], [Sehir], [Ulke], [newcurrent]) VALUES (1, 1, N'qoıqweruyqoqıweuyro', N'ist', N'TR', 0)
INSERT [dbo].[KisiAdresler] ([IdE], [KisilerIdE], [AcikAdres], [Sehir], [Ulke], [newcurrent]) VALUES (2, 2, N'ağaoglu B1-16', N'IST', N'Tr', 0)
INSERT [dbo].[KisiAdresler] ([IdE], [KisilerIdE], [AcikAdres], [Sehir], [Ulke], [newcurrent]) VALUES (3, 1, N'atasehir', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[KisiAdresler] OFF
SET IDENTITY_INSERT [dbo].[Kisiler] ON 

INSERT [dbo].[Kisiler] ([IdE], [RegisterDate], [RegisterDateIP], [ConfirmDate], [ConfirmDateIP], [IsActive], [IsDeleted], [IsEmailConfirmed], [Email], [Username], [PasswordHash], [PasswordSalt], [Adi], [Soyadi], [TCkimlik], [KisiTipi]) VALUES (1, CAST(N'2018-12-06 15:23:01.4071191' AS DateTime2), N'1.1.1.1', NULL, NULL, 0, 0, 0, N'vvvvv', NULL, 0x758858249DC1372DF11AFAB172D9CBD539B5422BD3ADBB8928D948C409E06639B3E959590C701A4545EF26ED05ACC2173950480A600C52DB1090EBF1397FF0A1, 0xB5AA89A002429D95085B8659175C432C58B5D7E2B65289F156584A01C3B2CD6A34A81F315BFFCCB588E55B9B46ACEBF97E224E789F90A3A2B76068B016FED3032C2629AA784501B1A9017963466A44FA9B4DC910F9049A5CF0F6072B574BCA5DDCE38B468BBB5692AC6C2786E62338773171B64A74F1C1E898EB3A770B109638, N'aydın', N'candan', N'12345678901', N'TEA')
INSERT [dbo].[Kisiler] ([IdE], [RegisterDate], [RegisterDateIP], [ConfirmDate], [ConfirmDateIP], [IsActive], [IsDeleted], [IsEmailConfirmed], [Email], [Username], [PasswordHash], [PasswordSalt], [Adi], [Soyadi], [TCkimlik], [KisiTipi]) VALUES (2, CAST(N'2018-12-06 17:07:59.2803368' AS DateTime2), N'1.1.1.1', NULL, NULL, 0, 0, 0, N'öööö', NULL, 0xF2C05CEFB7A255639BA4F12193549CEF2A9C00C8ECB7F596B5A003A114DD8B9025A886AC035D6BB30FF63B8BA31594EC91837E4F89EC007A6244754D3D5A0D0D, 0x7ACD38108C2A99B973543443834E454FDC23AE8C56A4121A12FBE66F721377372D9BA86648E90C39F122875AD727BFB82BDCB976A06F476B47008AF930E3F2DA104345835304EF8CE7B2CE5FF1EEB3BDDEE0DBEC3A24A41B950FFCB1D16EB70E4E0F4BDDC0D10774BA65C6E69E691D5646E9898E3731433CBD4993244777CF05, N'dicle', N'candan', N'01234567890', N'STU')
SET IDENTITY_INSERT [dbo].[Kisiler] OFF
SET IDENTITY_INSERT [dbo].[Kisiler_Dersler] ON 

INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (5, 1, 1)
INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (4, 1, 2)
INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (6, 1, 3)
INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (1, 2, 1)
INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (3, 2, 2)
INSERT [dbo].[Kisiler_Dersler] ([IdE], [KisilerIdE], [DerslerIdE]) VALUES (2, 2, 3)
SET IDENTITY_INSERT [dbo].[Kisiler_Dersler] OFF
SET IDENTITY_INSERT [dbo].[Kisiler_Icerikler] ON 

INSERT [dbo].[Kisiler_Icerikler] ([IdE], [KisilerIdE], [IceriklerIdE]) VALUES (1, 1, 2)
INSERT [dbo].[Kisiler_Icerikler] ([IdE], [KisilerIdE], [IceriklerIdE]) VALUES (3, 1, 3)
INSERT [dbo].[Kisiler_Icerikler] ([IdE], [KisilerIdE], [IceriklerIdE]) VALUES (5, 2, 2)
INSERT [dbo].[Kisiler_Icerikler] ([IdE], [KisilerIdE], [IceriklerIdE]) VALUES (6, 2, 3)
INSERT [dbo].[Kisiler_Icerikler] ([IdE], [KisilerIdE], [IceriklerIdE]) VALUES (4, 2, 4)
SET IDENTITY_INSERT [dbo].[Kisiler_Icerikler] OFF
SET IDENTITY_INSERT [dbo].[Kisiler_Takvimler] ON 

INSERT [dbo].[Kisiler_Takvimler] ([IdE], [KisilerIdE], [TakvimlerIdE]) VALUES (2, 1, 2)
INSERT [dbo].[Kisiler_Takvimler] ([IdE], [KisilerIdE], [TakvimlerIdE]) VALUES (1, 1, 3)
INSERT [dbo].[Kisiler_Takvimler] ([IdE], [KisilerIdE], [TakvimlerIdE]) VALUES (3, 2, 1)
INSERT [dbo].[Kisiler_Takvimler] ([IdE], [KisilerIdE], [TakvimlerIdE]) VALUES (4, 2, 3)
SET IDENTITY_INSERT [dbo].[Kisiler_Takvimler] OFF
INSERT [dbo].[KisiOgrenciler] ([OgrenciIdE], [IlgiAlanlari]) VALUES (2, N'fizik, matematik, uzay')
INSERT [dbo].[KisiOgretmenler] ([OgretmenIdE], [UzmanlikAlanlari]) VALUES (1, N'pedagoji, eğitim')
SET IDENTITY_INSERT [dbo].[KisiTelefonlar] ON 

INSERT [dbo].[KisiTelefonlar] ([IdE], [KisilerIdE], [Telefonu], [UlkeKodu], [newcurrent]) VALUES (1, 1, N'5324912165', N'TR', 0)
INSERT [dbo].[KisiTelefonlar] ([IdE], [KisilerIdE], [Telefonu], [UlkeKodu], [newcurrent]) VALUES (2, 2, N'5326983289', N'TR', 0)
SET IDENTITY_INSERT [dbo].[KisiTelefonlar] OFF
SET IDENTITY_INSERT [dbo].[LoginTracker] ON 

INSERT [dbo].[LoginTracker] ([IdE], [KisilerIdE], [KisiIdE], [LoginDate], [LoginDateIP]) VALUES (1, NULL, 1, CAST(N'2018-12-06 16:32:12.9465736' AS DateTime2), N'2.2.2.2')
INSERT [dbo].[LoginTracker] ([IdE], [KisilerIdE], [KisiIdE], [LoginDate], [LoginDateIP]) VALUES (2, NULL, 2, CAST(N'2018-12-06 19:35:24.6392624' AS DateTime2), N'2.2.2.2')
SET IDENTITY_INSERT [dbo].[LoginTracker] OFF
SET IDENTITY_INSERT [dbo].[Takvimler] ON 

INSERT [dbo].[Takvimler] ([IdE], [KursZamani], [KursAciklama], [Sirano], [DersDetaylarIdE], [DerslerIdE]) VALUES (1, CAST(N'2018-12-06 00:00:00.0000000' AS DateTime2), N'6 ARALIK kursu', NULL, 3535, 1423)
INSERT [dbo].[Takvimler] ([IdE], [KursZamani], [KursAciklama], [Sirano], [DersDetaylarIdE], [DerslerIdE]) VALUES (2, CAST(N'2018-12-31 00:00:00.0000000' AS DateTime2), N'Yılsonu kursu', NULL, 5858, 2522)
INSERT [dbo].[Takvimler] ([IdE], [KursZamani], [KursAciklama], [Sirano], [DersDetaylarIdE], [DerslerIdE]) VALUES (3, CAST(N'2019-01-01 00:00:00.0000000' AS DateTime2), N'Yılbası kursu', NULL, 34563, 1444)
SET IDENTITY_INSERT [dbo].[Takvimler] OFF
/****** Object:  Index [IX_DersDetaylar_DerslerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_DersDetaylar_DerslerIdE] ON [dbo].[DersDetaylar]
(
	[DerslerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Dersler_Title]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Dersler_Title] ON [dbo].[Dersler]
(
	[Title] ASC
)
WHERE ([Title] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Icerikler_BelgeAdi]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Icerikler_BelgeAdi] ON [dbo].[Icerikler]
(
	[BelgeAdi] ASC
)
WHERE ([BelgeAdi] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Icerikler_BelgeLink]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Icerikler_BelgeLink] ON [dbo].[Icerikler]
(
	[BelgeLink] ASC
)
WHERE ([BelgeLink] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KisiAdresler_KisilerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_KisiAdresler_KisilerIdE] ON [dbo].[KisiAdresler]
(
	[KisilerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Kisiler_Email]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Kisiler_Email] ON [dbo].[Kisiler]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Kisiler_Username]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Kisiler_Username] ON [dbo].[Kisiler]
(
	[Username] ASC
)
WHERE ([Username] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Dersler_DerslerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_Kisiler_Dersler_DerslerIdE] ON [dbo].[Kisiler_Dersler]
(
	[DerslerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Dersler_KisilerIdE_DerslerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Kisiler_Dersler_KisilerIdE_DerslerIdE] ON [dbo].[Kisiler_Dersler]
(
	[KisilerIdE] ASC,
	[DerslerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Icerikler_IceriklerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_Kisiler_Icerikler_IceriklerIdE] ON [dbo].[Kisiler_Icerikler]
(
	[IceriklerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Icerikler_KisilerIdE_IceriklerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Kisiler_Icerikler_KisilerIdE_IceriklerIdE] ON [dbo].[Kisiler_Icerikler]
(
	[KisilerIdE] ASC,
	[IceriklerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Takvimler_KisilerIdE_TakvimlerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Kisiler_Takvimler_KisilerIdE_TakvimlerIdE] ON [dbo].[Kisiler_Takvimler]
(
	[KisilerIdE] ASC,
	[TakvimlerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kisiler_Takvimler_TakvimlerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_Kisiler_Takvimler_TakvimlerIdE] ON [dbo].[Kisiler_Takvimler]
(
	[TakvimlerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KisiTelefonlar_KisilerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_KisiTelefonlar_KisilerIdE] ON [dbo].[KisiTelefonlar]
(
	[KisilerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_KisiTelefonlar_UlkeKodu_Telefonu]    Script Date: 07.12.2018 01:04:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KisiTelefonlar_UlkeKodu_Telefonu] ON [dbo].[KisiTelefonlar]
(
	[UlkeKodu] ASC,
	[Telefonu] ASC
)
WHERE ([UlkeKodu] IS NOT NULL AND [Telefonu] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LoginTracker_KisilerIdE]    Script Date: 07.12.2018 01:04:50 ******/
CREATE NONCLUSTERED INDEX [IX_LoginTracker_KisilerIdE] ON [dbo].[LoginTracker]
(
	[KisilerIdE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DersDetaylar]  WITH CHECK ADD  CONSTRAINT [FK_DersDetaylar_Dersler_DerslerIdE] FOREIGN KEY([DerslerIdE])
REFERENCES [dbo].[Dersler] ([IdE])
GO
ALTER TABLE [dbo].[DersDetaylar] CHECK CONSTRAINT [FK_DersDetaylar_Dersler_DerslerIdE]
GO
ALTER TABLE [dbo].[KisiAdminler]  WITH CHECK ADD  CONSTRAINT [FK_KisiAdminler_Kisiler_AdminIdE] FOREIGN KEY([AdminIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KisiAdminler] CHECK CONSTRAINT [FK_KisiAdminler_Kisiler_AdminIdE]
GO
ALTER TABLE [dbo].[KisiAdresler]  WITH CHECK ADD  CONSTRAINT [FK_KisiAdresler_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
GO
ALTER TABLE [dbo].[KisiAdresler] CHECK CONSTRAINT [FK_KisiAdresler_Kisiler_KisilerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Dersler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Dersler_Dersler_DerslerIdE] FOREIGN KEY([DerslerIdE])
REFERENCES [dbo].[Dersler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Dersler] CHECK CONSTRAINT [FK_Kisiler_Dersler_Dersler_DerslerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Dersler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Dersler_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Dersler] CHECK CONSTRAINT [FK_Kisiler_Dersler_Kisiler_KisilerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Icerikler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Icerikler_Icerikler_IceriklerIdE] FOREIGN KEY([IceriklerIdE])
REFERENCES [dbo].[Icerikler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Icerikler] CHECK CONSTRAINT [FK_Kisiler_Icerikler_Icerikler_IceriklerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Icerikler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Icerikler_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Icerikler] CHECK CONSTRAINT [FK_Kisiler_Icerikler_Kisiler_KisilerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Takvimler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Takvimler_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Takvimler] CHECK CONSTRAINT [FK_Kisiler_Takvimler_Kisiler_KisilerIdE]
GO
ALTER TABLE [dbo].[Kisiler_Takvimler]  WITH CHECK ADD  CONSTRAINT [FK_Kisiler_Takvimler_Takvimler_TakvimlerIdE] FOREIGN KEY([TakvimlerIdE])
REFERENCES [dbo].[Takvimler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kisiler_Takvimler] CHECK CONSTRAINT [FK_Kisiler_Takvimler_Takvimler_TakvimlerIdE]
GO
ALTER TABLE [dbo].[KisiOgrenciler]  WITH CHECK ADD  CONSTRAINT [FK_KisiOgrenciler_Kisiler_OgrenciIdE] FOREIGN KEY([OgrenciIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KisiOgrenciler] CHECK CONSTRAINT [FK_KisiOgrenciler_Kisiler_OgrenciIdE]
GO
ALTER TABLE [dbo].[KisiOgretmenler]  WITH CHECK ADD  CONSTRAINT [FK_KisiOgretmenler_Kisiler_OgretmenIdE] FOREIGN KEY([OgretmenIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KisiOgretmenler] CHECK CONSTRAINT [FK_KisiOgretmenler_Kisiler_OgretmenIdE]
GO
ALTER TABLE [dbo].[KisiTelefonlar]  WITH CHECK ADD  CONSTRAINT [FK_KisiTelefonlar_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
GO
ALTER TABLE [dbo].[KisiTelefonlar] CHECK CONSTRAINT [FK_KisiTelefonlar_Kisiler_KisilerIdE]
GO
ALTER TABLE [dbo].[LoginTracker]  WITH CHECK ADD  CONSTRAINT [FK_LoginTracker_Kisiler_KisilerIdE] FOREIGN KEY([KisilerIdE])
REFERENCES [dbo].[Kisiler] ([IdE])
GO
ALTER TABLE [dbo].[LoginTracker] CHECK CONSTRAINT [FK_LoginTracker_Kisiler_KisilerIdE]
GO
USE [master]
GO
ALTER DATABASE [veduDB07] SET  READ_WRITE 
GO
