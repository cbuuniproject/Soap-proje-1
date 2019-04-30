USE [master]
GO
/****** Object:  Database [AracKiralaDb]    Script Date: 30.04.2019 16:29:14 ******/
CREATE DATABASE [AracKiralaDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AracKiralaDb', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQL2012KURDUM\MSSQL\DATA\AracKiralaDb.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AracKiralaDb_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQL2012KURDUM\MSSQL\DATA\AracKiralaDb_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AracKiralaDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AracKiralaDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AracKiralaDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AracKiralaDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AracKiralaDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AracKiralaDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AracKiralaDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [AracKiralaDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AracKiralaDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AracKiralaDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AracKiralaDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AracKiralaDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AracKiralaDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AracKiralaDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AracKiralaDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AracKiralaDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AracKiralaDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AracKiralaDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AracKiralaDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AracKiralaDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AracKiralaDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AracKiralaDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AracKiralaDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AracKiralaDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AracKiralaDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AracKiralaDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AracKiralaDb] SET  MULTI_USER 
GO
ALTER DATABASE [AracKiralaDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AracKiralaDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AracKiralaDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AracKiralaDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AracKiralaDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 30.04.2019 16:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Aracs]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aracs](
	[aracId] [int] IDENTITY(1,1) NOT NULL,
	[sirketId] [int] NOT NULL,
	[marka] [nvarchar](50) NULL,
	[model] [nvarchar](50) NULL,
	[minEhliyetYasi] [int] NOT NULL,
	[minYasSiniri] [smallint] NOT NULL,
	[gunlukMaxKmSiniri] [smallint] NOT NULL,
	[anlikKm] [int] NOT NULL,
	[airbagSayisi] [tinyint] NOT NULL,
	[bagajHacmi] [smallint] NOT NULL,
	[koltukSayisi] [tinyint] NOT NULL,
	[gunlukFiyat] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Aracs] PRIMARY KEY CLUSTERED 
(
	[aracId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Calisans]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calisans](
	[calisanId] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[sirketId] [int] NOT NULL,
	[kullaniciId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Calisans] PRIMARY KEY CLUSTERED 
(
	[calisanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kiralamas]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kiralamas](
	[kiralamaId] [int] IDENTITY(1,1) NOT NULL,
	[sirketId] [int] NOT NULL,
	[musteriId] [int] NOT NULL,
	[aracId] [int] NOT NULL,
	[verilisTarihi] [datetime] NOT NULL,
	[geriAlisTarihi] [datetime] NULL,
	[verilisKm] [int] NOT NULL,
	[sonKm] [int] NULL,
	[ucret] [int] NULL,
 CONSTRAINT [PK_dbo.Kiralamas] PRIMARY KEY CLUSTERED 
(
	[kiralamaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kullanicis]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicis](
	[kullaniciId] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciAd] [nvarchar](50) NULL,
	[parola] [nvarchar](50) NULL,
	[kullaniciTuru] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.Kullanicis] PRIMARY KEY CLUSTERED 
(
	[kullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Musteris]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteris](
	[musteriId] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciId] [int] NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Musteris] PRIMARY KEY CLUSTERED 
(
	[musteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sirkets]    Script Date: 30.04.2019 16:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sirkets](
	[sirketId] [int] IDENTITY(1,1) NOT NULL,
	[sirketAdi] [nvarchar](50) NULL,
	[sehir] [nvarchar](50) NULL,
	[adres] [nvarchar](100) NULL,
	[sirketPuani] [int] NULL,
 CONSTRAINT [PK_dbo.Sirkets] PRIMARY KEY CLUSTERED 
(
	[sirketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_sirketId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_sirketId] ON [dbo].[Aracs]
(
	[sirketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_kullaniciId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_kullaniciId] ON [dbo].[Calisans]
(
	[kullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sirketId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_sirketId] ON [dbo].[Calisans]
(
	[sirketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_aracId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_aracId] ON [dbo].[Kiralamas]
(
	[aracId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sirketId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_sirketId] ON [dbo].[Kiralamas]
(
	[sirketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_kullaniciId]    Script Date: 30.04.2019 16:29:15 ******/
CREATE NONCLUSTERED INDEX [IX_kullaniciId] ON [dbo].[Musteris]
(
	[kullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aracs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Aracs_dbo.Sirkets_sirketId] FOREIGN KEY([sirketId])
REFERENCES [dbo].[Sirkets] ([sirketId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Aracs] CHECK CONSTRAINT [FK_dbo.Aracs_dbo.Sirkets_sirketId]
GO
ALTER TABLE [dbo].[Calisans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Calisans_dbo.Kullanicis_kullaniciId] FOREIGN KEY([kullaniciId])
REFERENCES [dbo].[Kullanicis] ([kullaniciId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calisans] CHECK CONSTRAINT [FK_dbo.Calisans_dbo.Kullanicis_kullaniciId]
GO
ALTER TABLE [dbo].[Calisans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Calisans_dbo.Sirkets_sirketId] FOREIGN KEY([sirketId])
REFERENCES [dbo].[Sirkets] ([sirketId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calisans] CHECK CONSTRAINT [FK_dbo.Calisans_dbo.Sirkets_sirketId]
GO
ALTER TABLE [dbo].[Kiralamas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Kiralamas_dbo.Aracs_aracId] FOREIGN KEY([aracId])
REFERENCES [dbo].[Aracs] ([aracId])
GO
ALTER TABLE [dbo].[Kiralamas] CHECK CONSTRAINT [FK_dbo.Kiralamas_dbo.Aracs_aracId]
GO
ALTER TABLE [dbo].[Kiralamas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Kiralamas_dbo.Sirkets_sirketId] FOREIGN KEY([sirketId])
REFERENCES [dbo].[Sirkets] ([sirketId])
GO
ALTER TABLE [dbo].[Kiralamas] CHECK CONSTRAINT [FK_dbo.Kiralamas_dbo.Sirkets_sirketId]
GO
ALTER TABLE [dbo].[Musteris]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Musteris_dbo.Kullanicis_kullaniciId] FOREIGN KEY([kullaniciId])
REFERENCES [dbo].[Kullanicis] ([kullaniciId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Musteris] CHECK CONSTRAINT [FK_dbo.Musteris_dbo.Kullanicis_kullaniciId]
GO
USE [master]
GO
ALTER DATABASE [AracKiralaDb] SET  READ_WRITE 
GO
