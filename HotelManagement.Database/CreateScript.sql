USE [HotelManagement]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[HotelChainId] [int] NOT NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[Address3] [varchar](255) NULL,
	[Address4] [varchar](255) NULL,
	[Address5] [varchar](255) NULL,
	[ShortDescription] [varchar](255) NULL,
	[LongDescription] [varchar](4000) NULL,
	[InOperation] [bit] NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HotelChain]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HotelChain](
	[HotelChainId] [int] IDENTITY(1,1) NOT NULL,
	[HotelChainName] [varchar](255) NOT NULL,
 CONSTRAINT [PK_HotelChain] PRIMARY KEY CLUSTERED 
(
	[HotelChainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](4000) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[Description] [varchar](4000) NULL,
	[HotelId] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomImage]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomImage](
	[RoomImageId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[ImageUrl] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_RoomImage] PRIMARY KEY CLUSTERED 
(
	[RoomImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[MaxOccupants] [int] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setting](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Value] [varchar](255) NOT NULL,
	[Description] [varchar](4000) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[UserLevelId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLevel]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLevel](
	[UserLevelId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_UserLevel] PRIMARY KEY CLUSTERED 
(
	[UserLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserMenu]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMenu](
	[UserMenuId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_UserMenu] PRIMARY KEY CLUSTERED 
(
	[UserMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserType]    Script Date: 27/11/12 16:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

GO
INSERT [dbo].[Hotel] ([HotelId], [Name], [HotelChainId], [Address1], [Address2], [Address3], [Address4], [Address5], [ShortDescription], [LongDescription], [InOperation]) VALUES (1, N'Aylesbury', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[Hotel] ([HotelId], [Name], [HotelChainId], [Address1], [Address2], [Address3], [Address4], [Address5], [ShortDescription], [LongDescription], [InOperation]) VALUES (2, N'Uxbridge', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[Hotel] ([HotelId], [Name], [HotelChainId], [Address1], [Address2], [Address3], [Address4], [Address5], [ShortDescription], [LongDescription], [InOperation]) VALUES (3, N'Central London', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[HotelChain] ON 

GO
INSERT [dbo].[HotelChain] ([HotelChainId], [HotelChainName]) VALUES (1, N'CheapStayHotels')
GO
INSERT [dbo].[HotelChain] ([HotelChainId], [HotelChainName]) VALUES (2, N'FullFamilyHotel')
GO
SET IDENTITY_INSERT [dbo].[HotelChain] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

GO
INSERT [dbo].[Menu] ([MenuId], [Name], [Description], [Order]) VALUES (1, N'Hotel', N'Hotel Menu', 10)
GO
INSERT [dbo].[Menu] ([MenuId], [Name], [Description], [Order]) VALUES (2, N'Rooms', N'Room Menu', 20)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

GO
INSERT [dbo].[Room] ([RoomId], [Name], [RoomTypeId], [Description], [HotelId]) VALUES (2, N'101', 1, N'This is the best room of our hotel.', 1)
GO
INSERT [dbo].[Room] ([RoomId], [Name], [RoomTypeId], [Description], [HotelId]) VALUES (3, N'102', 1, NULL, 1)
GO
INSERT [dbo].[Room] ([RoomId], [Name], [RoomTypeId], [Description], [HotelId]) VALUES (4, N'103', 3, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 

GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (1, N'Delux Suite', 3)
GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (2, N'Family Room', 5)
GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (3, N'Single Room', 1)
GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (4, N'Double Room', 2)
GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (5, N'Twin Room', 2)
GO
INSERT [dbo].[RoomType] ([RoomTypeId], [Name], [MaxOccupants]) VALUES (6, N'Triple Room', 3)
GO
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (1, N'HeaderText', N'Hotel Management System', N'Main Header Text')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (2, N'AppCacheValidity', N'1', N'The no. of minutes after which the AppCache will be refreshed')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (5, N'HeaderImage', N'../../Content/images/main_image.jpg', N'The main image to display on the header')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (6, N'HotelName', N'Beach View', N'Beach View')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (7, N'HotelHeaderPhone', N'08001111111', N'Free Phone no')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (8, N'BookingHeaderText', N'Online Booking', N'Online Booking')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (9, N'CheckInHeaderText', N'Arrival', N'Check-In')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (10, N'CheckOutHeaderText', N'Departure', N'Check-Out')
GO
INSERT [dbo].[Setting] ([SettingId], [Name], [Value], [Description]) VALUES (11, N'SpecialOffersHeaderText', N'Latest Offers', N'Current Offers')
GO
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([UserId], [Password], [Email], [UserTypeId], [UserLevelId]) VALUES (1, N'admin@admin.co', N'admin@admin.co', 1, 1)
GO
INSERT [dbo].[User] ([UserId], [Password], [Email], [UserTypeId], [UserLevelId]) VALUES (2, N'res@res.co', N'res@res.co', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLevel] ON 

GO
INSERT [dbo].[UserLevel] ([UserLevelId], [Name]) VALUES (1, N'HotelChain')
GO
INSERT [dbo].[UserLevel] ([UserLevelId], [Name]) VALUES (2, N'Hotel')
GO
SET IDENTITY_INSERT [dbo].[UserLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMenu] ON 

GO
INSERT [dbo].[UserMenu] ([UserMenuId], [UserId], [MenuId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserMenu] ([UserMenuId], [UserId], [MenuId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UserMenu] ([UserMenuId], [UserId], [MenuId]) VALUES (3, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[UserMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 

GO
INSERT [dbo].[UserType] ([UserTypeId], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[UserType] ([UserTypeId], [Name]) VALUES (2, N'ReservationClerk')
GO
INSERT [dbo].[UserType] ([UserTypeId], [Name]) VALUES (3, N'ReportBuilder')
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([HotelId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
ALTER TABLE [dbo].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
ALTER TABLE [dbo].[UserMenu]  WITH CHECK ADD  CONSTRAINT [FK_UserMenu_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([MenuId])
GO
ALTER TABLE [dbo].[UserMenu] CHECK CONSTRAINT [FK_UserMenu_Menu]
GO
ALTER TABLE [dbo].[UserMenu]  WITH CHECK ADD  CONSTRAINT [FK_UserMenu_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserMenu] CHECK CONSTRAINT [FK_UserMenu_User]
GO
