USE [master]
GO
/****** Object:  Database [HotelProject]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE DATABASE [HotelProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\HotelProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\HotelProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelProject] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelProject] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelProject] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelProject] SET  MULTI_USER 
GO
ALTER DATABASE [HotelProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelProject] SET QUERY_STORE = OFF
GO
USE [HotelProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/25/2020 8:44:31 AM ******/
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
/****** Object:  Table [dbo].[Bookings]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
	[DurationStay] [int] NOT NULL,
	[SecretCode] [nvarchar](6) NULL,
	[Status] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRooms]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
 CONSTRAINT [PK_BookRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryRooms]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CategoryRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryService]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryService](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_CategoryService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](300) NOT NULL,
	[LastName] [nvarchar](300) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Email] [varchar](300) NOT NULL,
	[IdentityNo] [nvarchar](9) NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DateRequest] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[Payment] [int] NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[OrderNo] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](3) NOT NULL,
	[CategoryRoomId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 3/25/2020 8:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CategoryServiceId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_GuestId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_GuestId] ON [dbo].[Bookings]
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookRooms_BookingId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_BookRooms_BookingId] ON [dbo].[BookRooms]
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookRooms_RoomId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_BookRooms_RoomId] ON [dbo].[BookRooms]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ServiceId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ServiceId] ON [dbo].[OrderDetails]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_BookingId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_BookingId] ON [dbo].[Orders]
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rooms_CategoryRoomId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_CategoryRoomId] ON [dbo].[Rooms]
(
	[CategoryRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Services_CategoryServiceId]    Script Date: 3/25/2020 8:44:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Services_CategoryServiceId] ON [dbo].[Services]
(
	[CategoryServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT ((0)) FOR [DurationStay]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT ((0.0)) FOR [Amount]
GO
ALTER TABLE [dbo].[CategoryRooms] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0.0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [OrderNo]
GO
ALTER TABLE [dbo].[Rooms] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Services] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[Services] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Guest_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guest] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Guest_GuestId]
GO
ALTER TABLE [dbo].[BookRooms]  WITH CHECK ADD  CONSTRAINT [FK_BookRooms_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookRooms] CHECK CONSTRAINT [FK_BookRooms_Bookings_BookingId]
GO
ALTER TABLE [dbo].[BookRooms]  WITH CHECK ADD  CONSTRAINT [FK_BookRooms_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookRooms] CHECK CONSTRAINT [FK_BookRooms_Rooms_RoomId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Services_ServiceId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Bookings_BookingId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_CategoryRooms_CategoryRoomId] FOREIGN KEY([CategoryRoomId])
REFERENCES [dbo].[CategoryRooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_CategoryRooms_CategoryRoomId]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_CategoryService_CategoryServiceId] FOREIGN KEY([CategoryServiceId])
REFERENCES [dbo].[CategoryService] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_CategoryService_CategoryServiceId]
GO
USE [master]
GO
ALTER DATABASE [HotelProject] SET  READ_WRITE 
GO
