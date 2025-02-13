USE [Hotels]
GO
ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Rooms_RoomTypes_RoomTypeID]
GO
ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Rooms_Hotels]
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships] DROP CONSTRAINT [FK_RoomFeatureRelationships_Rooms_RoomID]
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships] DROP CONSTRAINT [FK_RoomFeatureRelationships_Features_FeatureID]
GO
ALTER TABLE [dbo].[ItemImageRelationships] DROP CONSTRAINT [FK_ItemImageRelationships_Images_ImageID]
GO
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_Rooms_RoomID]
GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[RoomTypes]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[Rooms]
GO
/****** Object:  Table [dbo].[RoomFacilitiesRelationships]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[RoomFacilitiesRelationships]
GO
/****** Object:  Table [dbo].[ItemImageRelationships]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[ItemImageRelationships]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[Images]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[Hotels]
GO
/****** Object:  Table [dbo].[Facilities]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP TABLE [dbo].[Facilities]
GO
USE [master]
GO
/****** Object:  Database [Hotels]    Script Date: 8/5/2018 11:42:06 PM ******/
DROP DATABASE [Hotels]
GO
/****** Object:  Database [Hotels]    Script Date: 8/5/2018 11:42:06 PM ******/
CREATE DATABASE [Hotels]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotels', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Hotels.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hotels_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Hotels_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Hotels] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotels].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotels] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotels] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Hotels] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotels] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotels] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotels] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotels] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotels] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotels] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotels] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hotels] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotels] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotels] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotels] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotels] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotels] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotels] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotels] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hotels] SET  MULTI_USER 
GO
ALTER DATABASE [Hotels] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotels] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotels] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotels] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Hotels]
GO
/****** Object:  Table [dbo].[Facilities]    Script Date: 8/5/2018 11:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facilities](
	[ID] [nvarchar](450) NOT NULL,
	[Icon] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 8/5/2018 11:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/5/2018 11:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ID] [nvarchar](450) NOT NULL,
	[RoomID] [nvarchar](450) NULL,
	[FilePath] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemImageRelationships]    Script Date: 8/5/2018 11:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemImageRelationships](
	[ItemID] [nvarchar](450) NOT NULL,
	[ImageID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ItemImageRelationships] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomFacilitiesRelationships]    Script Date: 8/5/2018 11:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFacilitiesRelationships](
	[RoomID] [nvarchar](450) NOT NULL,
	[FeatureID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_RoomFeatureRelationships] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[FeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/5/2018 11:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[ID] [nvarchar](450) NOT NULL,
	[Available] [bit] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[MaximumGuests] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[RoomTypeID] [nvarchar](450) NULL,
	[HotelID] [int] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 8/5/2018 11:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTypes](
	[ID] [nvarchar](450) NOT NULL,
	[BasePrice] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RoomTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([ID])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Rooms_RoomID]
GO
ALTER TABLE [dbo].[ItemImageRelationships]  WITH CHECK ADD  CONSTRAINT [FK_ItemImageRelationships_Images_ImageID] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemImageRelationships] CHECK CONSTRAINT [FK_ItemImageRelationships_Images_ImageID]
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeatureRelationships_Features_FeatureID] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Facilities] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships] CHECK CONSTRAINT [FK_RoomFeatureRelationships_Features_FeatureID]
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeatureRelationships_Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomFacilitiesRelationships] CHECK CONSTRAINT [FK_RoomFeatureRelationships_Rooms_RoomID]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_RoomTypes_RoomTypeID] FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[RoomTypes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_RoomTypes_RoomTypeID]
GO
USE [master]
GO
ALTER DATABASE [Hotels] SET  READ_WRITE 
GO
