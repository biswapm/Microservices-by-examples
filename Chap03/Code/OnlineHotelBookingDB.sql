USE [master]
GO
/****** Object:  Database [HotelBooking_DDD]    Script Date: 7/25/2018 9:26:52 AM ******/
CREATE DATABASE [HotelBooking_DDD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelBooking_DDD', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HotelBooking_DDD.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HotelBooking_DDD_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HotelBooking_DDD_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
USE [HotelBooking_DDD]
GO
/****** Object:  Table [dbo].[HotelBooking_DDDs]    Script Date: 7/25/2018 9:26:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelBooking_DDDs](
	[BookingID] [int] NOT NULL,
	[HotelID] [int] NULL,
	[ChekInDate] [datetime] NULL,
	[CheckOutDate] [datetime] NULL,
	[UserID] [int] NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[InvoiveNumber] [nvarchar](50) NULL,
	[BookingDate] [datetime] NULL,
	[Amount] [numeric](18, 0) NULL,
 CONSTRAINT [PK_HotelBooking_DDDs] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelCategories]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelCategories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_HotelCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelFacilities]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelFacilities](
	[FacilitiesId] [int] NOT NULL,
	[FacilityName] [nvarchar](50) NULL,
	[IconUrl] [nvarchar](200) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_HotelFacilities] PRIMARY KEY CLUSTERED 
(
	[FacilitiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelImageGallery]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelImageGallery](
	[ImageId] [int] NOT NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_HotelImageGallery] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelReviews]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelReviews](
	[ReviewID] [int] NULL,
	[Review] [text] NULL,
	[Ratings] [int] NULL,
	[UserID] [int] NULL,
	[HotelID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelRooms]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[BreakfastIncluded] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_HotelRooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 7/25/2018 9:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[HotelPolicy] [nvarchar](50) NULL,
	[Ratings] [int] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[PrimaryContactPerson] [nvarchar](50) NULL,
	[Address] [text] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[HotelBooking_DDDs]  WITH CHECK ADD  CONSTRAINT [FK_HotelBooking_DDDs_Hotels] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelId])
GO
ALTER TABLE [dbo].[HotelBooking_DDDs] CHECK CONSTRAINT [FK_HotelBooking_DDDs_Hotels]
GO
ALTER TABLE [dbo].[HotelFacilities]  WITH CHECK ADD  CONSTRAINT [FK_HotelFacilities_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([HotelId])
GO
ALTER TABLE [dbo].[HotelFacilities] CHECK CONSTRAINT [FK_HotelFacilities_Hotels]
GO
ALTER TABLE [dbo].[HotelImageGallery]  WITH CHECK ADD  CONSTRAINT [FK_HotelImageGallery_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([HotelId])
GO
ALTER TABLE [dbo].[HotelImageGallery] CHECK CONSTRAINT [FK_HotelImageGallery_Hotels]
GO
ALTER TABLE [dbo].[HotelReviews]  WITH CHECK ADD  CONSTRAINT [FK_HotelReviews_Hotels] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelId])
GO
ALTER TABLE [dbo].[HotelReviews] CHECK CONSTRAINT [FK_HotelReviews_Hotels]
GO
ALTER TABLE [dbo].[HotelRooms]  WITH CHECK ADD  CONSTRAINT [FK_HotelRooms_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([HotelId])
GO
ALTER TABLE [dbo].[HotelRooms] CHECK CONSTRAINT [FK_HotelRooms_Hotels]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_HotelCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[HotelCategories] ([CategoryId])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_HotelCategories]
GO
USE [master]
GO
ALTER DATABASE [HotelBooking_DDD] SET  READ_WRITE 
GO
