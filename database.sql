USE [master]
GO
/****** Object:  Database [YTMovie]    Script Date: 15.01.2022 21:32:38 ******/
CREATE DATABASE [YTMovie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YTMovie', FILENAME = N'C:\Users\Yasin Torun\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\YTMovie.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YTMovie_log', FILENAME = N'C:\Users\Yasin Torun\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\YTMovie.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [YTMovie] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YTMovie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YTMovie] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [YTMovie] SET ANSI_NULLS ON 
GO
ALTER DATABASE [YTMovie] SET ANSI_PADDING ON 
GO
ALTER DATABASE [YTMovie] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [YTMovie] SET ARITHABORT ON 
GO
ALTER DATABASE [YTMovie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YTMovie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YTMovie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YTMovie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YTMovie] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [YTMovie] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [YTMovie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YTMovie] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [YTMovie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YTMovie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YTMovie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YTMovie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YTMovie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YTMovie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YTMovie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YTMovie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YTMovie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YTMovie] SET RECOVERY FULL 
GO
ALTER DATABASE [YTMovie] SET  MULTI_USER 
GO
ALTER DATABASE [YTMovie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YTMovie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YTMovie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YTMovie] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [YTMovie] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [YTMovie] SET QUERY_STORE = OFF
GO
USE [YTMovie]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [YTMovie]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 15.01.2022 21:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 15.01.2022 21:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CommentContent] [nvarchar](250) NOT NULL,
	[Score] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[MovieId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 15.01.2022 21:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieGenres]    Script Date: 15.01.2022 21:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieGenres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 15.01.2022 21:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Year] [int] NOT NULL,
	[Imdb] [real] NOT NULL,
	[Time] [nvarchar](20) NOT NULL,
	[VideoLink] [nvarchar](max) NOT NULL,
	[PosterLink] [nvarchar](max) NOT NULL,
	[WallpaperLink] [nvarchar](max) NOT NULL,
	[View] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_ToMovie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_ToMovie]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_MovieGenres_ToGenre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_MovieGenres_ToGenre]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_MovieGenres_ToMovie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_MovieGenres_ToMovie]
GO
USE [master]
GO
ALTER DATABASE [YTMovie] SET  READ_WRITE 
GO
