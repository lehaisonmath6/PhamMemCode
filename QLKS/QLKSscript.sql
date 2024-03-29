USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 14/5/2019 10:03:40 PM ******/
CREATE DATABASE [QLKS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLKS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLKS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLKS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLKS] SET  MULTI_USER 
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLKS', N'ON'
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = OFF
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 14/5/2019 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [datetime] NULL,
	[IDPhong] [int] NULL,
	[TongTien] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[HoTenKhach] [nvarchar](max) NULL,
	[IDDatPhong] [int] NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDatPhong]    Script Date: 14/5/2019 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDatPhong](
	[IDDatPhong] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[IDPhong] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[TongTien] [int] NULL,
	[TienDaCoc] [int] NULL,
	[IDTrangThaiDat] [int] NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblDatPhong] PRIMARY KEY CLUSTERED 
(
	[IDDatPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPhong]    Script Date: 14/5/2019 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhong](
	[IDPhong] [int] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[IDTrangThaiPhong] [int] NULL,
	[UrlAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblPhong] PRIMARY KEY CLUSTERED 
(
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTrangThaiDat]    Script Date: 14/5/2019 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTrangThaiDat](
	[IDTrangThaiDat] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThaiDat] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblTrangThaiDat] PRIMARY KEY CLUSTERED 
(
	[IDTrangThaiDat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTrangThaiPhong]    Script Date: 14/5/2019 10:03:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTrangThaiPhong](
	[IDTrangThaiPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThai] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblTrangThaiPhong] PRIMARY KEY CLUSTERED 
(
	[IDTrangThaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [IDPhong], [TongTien], [MoTa], [HoTenKhach], [IDDatPhong], [SDT]) VALUES (1, CAST(N'2019-05-13T23:03:48.150' AS DateTime), 102, 150000, N'', N'Trần Minh Tuấn', 5, N'3123028139021')
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [IDPhong], [TongTien], [MoTa], [HoTenKhach], [IDDatPhong], [SDT]) VALUES (2, CAST(N'2019-05-13T23:07:26.057' AS DateTime), 101, 100000, N'', N'', 2, N'')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[tblDatPhong] ON 

INSERT [dbo].[tblDatPhong] ([IDDatPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [IDPhong], [MoTa], [TongTien], [TienDaCoc], [IDTrangThaiDat], [TenKhachHang], [SDT]) VALUES (1, CAST(N'2019-05-04' AS Date), CAST(N'2019-05-07' AS Date), 101, NULL, 100000, 100000, 1, NULL, NULL)
INSERT [dbo].[tblDatPhong] ([IDDatPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [IDPhong], [MoTa], [TongTien], [TienDaCoc], [IDTrangThaiDat], [TenKhachHang], [SDT]) VALUES (2, CAST(N'2019-05-08' AS Date), CAST(N'2019-05-09' AS Date), 101, NULL, 100000, 100000, 1, NULL, NULL)
INSERT [dbo].[tblDatPhong] ([IDDatPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [IDPhong], [MoTa], [TongTien], [TienDaCoc], [IDTrangThaiDat], [TenKhachHang], [SDT]) VALUES (3, CAST(N'2019-05-08' AS Date), CAST(N'2019-05-09' AS Date), 102, NULL, 100000, 100000, 1, NULL, NULL)
INSERT [dbo].[tblDatPhong] ([IDDatPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [IDPhong], [MoTa], [TongTien], [TienDaCoc], [IDTrangThaiDat], [TenKhachHang], [SDT]) VALUES (4, CAST(N'2019-05-04' AS Date), CAST(N'2019-05-06' AS Date), 101, N'', 1000000, 1000000, NULL, N'Trần Duy Hưng', N'02139201824921498210')
INSERT [dbo].[tblDatPhong] ([IDDatPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [IDPhong], [MoTa], [TongTien], [TienDaCoc], [IDTrangThaiDat], [TenKhachHang], [SDT]) VALUES (5, CAST(N'2019-05-13' AS Date), CAST(N'2019-05-14' AS Date), 102, N'', 150000, 0, NULL, N'Trần Minh Tuấn', N'3123028139021')
SET IDENTITY_INSERT [dbo].[tblDatPhong] OFF
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (101, N'Phòng tầng 1 nhìn ra biển', 3, NULL)
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (102, N'Phòng tầng 1 ở giữa', 3, NULL)
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (103, N'Phòng tầng 1  ở ngoài cùng nhìn ra đường', 3, NULL)
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (201, N'Phòng tầng 2', 3, NULL)
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (202, N'Phòng tầng 2 ở giữa', 3, NULL)
INSERT [dbo].[tblPhong] ([IDPhong], [MoTa], [IDTrangThaiPhong], [UrlAnh]) VALUES (203, N'Phòng tầng 2 ở bên phải', 3, NULL)
SET IDENTITY_INSERT [dbo].[tblTrangThaiDat] ON 

INSERT [dbo].[tblTrangThaiDat] ([IDTrangThaiDat], [TenTrangThaiDat]) VALUES (1, N'Khách đặt')
INSERT [dbo].[tblTrangThaiDat] ([IDTrangThaiDat], [TenTrangThaiDat]) VALUES (2, N'Khách đã đến')
INSERT [dbo].[tblTrangThaiDat] ([IDTrangThaiDat], [TenTrangThaiDat]) VALUES (3, N'Khách hủy')
SET IDENTITY_INSERT [dbo].[tblTrangThaiDat] OFF
SET IDENTITY_INSERT [dbo].[tblTrangThaiPhong] ON 

INSERT [dbo].[tblTrangThaiPhong] ([IDTrangThaiPhong], [TenTrangThai]) VALUES (1, N'Đã được đặt')
INSERT [dbo].[tblTrangThaiPhong] ([IDTrangThaiPhong], [TenTrangThai]) VALUES (2, N'Đang có khách')
INSERT [dbo].[tblTrangThaiPhong] ([IDTrangThaiPhong], [TenTrangThai]) VALUES (3, N'Trống')
SET IDENTITY_INSERT [dbo].[tblTrangThaiPhong] OFF
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_tblDatPhong] FOREIGN KEY([IDDatPhong])
REFERENCES [dbo].[tblDatPhong] ([IDDatPhong])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_tblDatPhong]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_tblPhong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[tblPhong] ([IDPhong])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_tblPhong]
GO
ALTER TABLE [dbo].[tblDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_tblDatPhong_tblPhong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[tblPhong] ([IDPhong])
GO
ALTER TABLE [dbo].[tblDatPhong] CHECK CONSTRAINT [FK_tblDatPhong_tblPhong]
GO
ALTER TABLE [dbo].[tblDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_tblDatPhong_tblTrangThaiDat] FOREIGN KEY([IDTrangThaiDat])
REFERENCES [dbo].[tblTrangThaiDat] ([IDTrangThaiDat])
GO
ALTER TABLE [dbo].[tblDatPhong] CHECK CONSTRAINT [FK_tblDatPhong_tblTrangThaiDat]
GO
ALTER TABLE [dbo].[tblPhong]  WITH CHECK ADD  CONSTRAINT [FK_tblPhong_tblTrangThaiPhong] FOREIGN KEY([IDTrangThaiPhong])
REFERENCES [dbo].[tblTrangThaiPhong] ([IDTrangThaiPhong])
GO
ALTER TABLE [dbo].[tblPhong] CHECK CONSTRAINT [FK_tblPhong_tblTrangThaiPhong]
GO
USE [master]
GO
ALTER DATABASE [QLKS] SET  READ_WRITE 
GO
