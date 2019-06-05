USE [master]
GO
/****** Object:  Database [ThiOnline]    Script Date: 4/6/2019 10:08:12 AM ******/
CREATE DATABASE [ThiOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThiOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ThiOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ThiOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ThiOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ThiOnline] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThiOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThiOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThiOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThiOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThiOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThiOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThiOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ThiOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThiOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThiOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThiOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThiOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThiOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThiOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThiOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThiOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ThiOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThiOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThiOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThiOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThiOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThiOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThiOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThiOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [ThiOnline] SET  MULTI_USER 
GO
ALTER DATABASE [ThiOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThiOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThiOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThiOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ThiOnline] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ThiOnline', N'ON'
GO
ALTER DATABASE [ThiOnline] SET QUERY_STORE = OFF
GO
USE [ThiOnline]
GO
/****** Object:  Table [dbo].[BaiThi]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiThi](
	[IDBaiThi] [int] IDENTITY(1,1) NOT NULL,
	[IDCaThi] [int] NULL,
	[IDNguoiDung] [int] NULL,
	[SoCauDung] [int] NULL,
	[TongSoCau] [int] NULL,
	[IDDeThi] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThoiGianDangNhap] [datetime] NULL,
	[ThoiGianNopBai] [datetime] NULL,
 CONSTRAINT [PK_NhatKyThi] PRIMARY KEY CLUSTERED 
(
	[IDBaiThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiThi_DapAn]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiThi_DapAn](
	[IDBaiThi] [int] NOT NULL,
	[IDCauHoi] [int] NOT NULL,
	[TraLoi] [nvarchar](max) NULL,
	[DapAn] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_BaiThi_DapAn] PRIMARY KEY CLUSTERED 
(
	[IDBaiThi] ASC,
	[IDCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaThi]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaThi](
	[IDCa] [int] IDENTITY(1,1) NOT NULL,
	[TenCa] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
	[IDKyThi] [int] NULL,
 CONSTRAINT [PK_CaThi] PRIMARY KEY CLUSTERED 
(
	[IDCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[IDCauHoi] [int] IDENTITY(1,1) NOT NULL,
	[TenCauHoi] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DapAn] [nvarchar](max) NULL,
	[TracNghiemA] [nvarchar](max) NULL,
	[TracNghiemB] [nvarchar](max) NULL,
	[TracNghiemC] [nvarchar](max) NULL,
	[TracNghiemD] [nvarchar](max) NULL,
	[IDDoanVan] [int] NULL,
	[IDDoKho] [int] NULL,
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[IDCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuongHoc]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongHoc](
	[IDChuongHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenChuong] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[IDMonHoc] [int] NULL,
 CONSTRAINT [PK_ChuongHoc] PRIMARY KEY CLUSTERED 
(
	[IDChuongHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeThi]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeThi](
	[IDDeThi] [int] IDENTITY(1,1) NOT NULL,
	[IDMonHoc] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThoiGian] [nvarchar](50) NULL,
	[TenDe] [nvarchar](max) NULL,
	[IDCaThi] [int] NULL,
 CONSTRAINT [PK_DeThi] PRIMARY KEY CLUSTERED 
(
	[IDDeThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeThi_CauHoi]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeThi_CauHoi](
	[IDDeThi] [int] NOT NULL,
	[IDCauHoi] [int] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_DeThi_CauHoi] PRIMARY KEY CLUSTERED 
(
	[IDDeThi] ASC,
	[IDCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanVan]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanVan](
	[IDDoanVan] [int] IDENTITY(1,1) NOT NULL,
	[TenDoanVan] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[IDChuongHoc] [int] NULL,
 CONSTRAINT [PK_DoanVan] PRIMARY KEY CLUSTERED 
(
	[IDDoanVan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoKho]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoKho](
	[IDDoKho] [int] NOT NULL,
	[TenDoKho] [nvarchar](max) NULL,
 CONSTRAINT [PK_DoKho] PRIMARY KEY CLUSTERED 
(
	[IDDoKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 4/6/2019 10:08:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[IDKhoa] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoa] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[IDKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KyThi]    Script Date: 4/6/2019 10:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KyThi](
	[IDKyThi] [int] IDENTITY(1,1) NOT NULL,
	[TenKyThi] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_KyThi] PRIMARY KEY CLUSTERED 
(
	[IDKyThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 4/6/2019 10:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[IDMonHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenMonHoc] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[IDKhoa] [int] NOT NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[IDMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 4/6/2019 10:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IDNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](max) NULL,
	[GioiTinh] [bit] NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[UrlAnh] [nvarchar](max) NULL,
	[IDVaiTro] [int] NULL,
	[MoRong] [bit] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[IDNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 4/6/2019 10:08:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[IDVaiTro] [int] IDENTITY(1,1) NOT NULL,
	[TenVaiTro] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_VaiTro] PRIMARY KEY CLUSTERED 
(
	[IDVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaiThi] ON 

INSERT [dbo].[BaiThi] ([IDBaiThi], [IDCaThi], [IDNguoiDung], [SoCauDung], [TongSoCau], [IDDeThi], [MoTa], [ThoiGianDangNhap], [ThoiGianNopBai]) VALUES (17, 6, 5, 1, 2, 9, NULL, NULL, CAST(N'2019-06-04T09:52:13.573' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaiThi] OFF
INSERT [dbo].[BaiThi_DapAn] ([IDBaiThi], [IDCauHoi], [TraLoi], [DapAn], [MoTa]) VALUES (17, 2003, N'A', N'A', NULL)
INSERT [dbo].[BaiThi_DapAn] ([IDBaiThi], [IDCauHoi], [TraLoi], [DapAn], [MoTa]) VALUES (17, 2005, N'A', N'B', NULL)
SET IDENTITY_INSERT [dbo].[CaThi] ON 

INSERT [dbo].[CaThi] ([IDCa], [TenCa], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [IDKyThi]) VALUES (6, N'Ca 1', N'Ca buổi sáng', CAST(N'2019-09-15T00:00:00.000' AS DateTime), CAST(N'2019-10-18T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[CaThi] ([IDCa], [TenCa], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [IDKyThi]) VALUES (7, N'Ca 2', N'Ca buổi chiều', CAST(N'2019-10-15T00:00:00.000' AS DateTime), CAST(N'2019-11-15T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[CaThi] OFF
SET IDENTITY_INSERT [dbo].[CauHoi] ON 

INSERT [dbo].[CauHoi] ([IDCauHoi], [TenCauHoi], [MoTa], [DapAn], [TracNghiemA], [TracNghiemB], [TracNghiemC], [TracNghiemD], [IDDoanVan], [IDDoKho]) VALUES (2003, N'Công nghệ phần mềm là gì', NULL, N'A', N'Là ngành làm ra phần mềm ', N'Là ngành làm ra phần cứng', N'Là ngành làm ra  tivi', N'Là ngành làm ra của cải vật chất', 1004, 1)
INSERT [dbo].[CauHoi] ([IDCauHoi], [TenCauHoi], [MoTa], [DapAn], [TracNghiemA], [TracNghiemB], [TracNghiemC], [TracNghiemD], [IDDoanVan], [IDDoKho]) VALUES (2005, N'5 +5 =?', NULL, N'B', N'1', N'10', N'0', N'2', 1004, 2)
SET IDENTITY_INSERT [dbo].[CauHoi] OFF
SET IDENTITY_INSERT [dbo].[ChuongHoc] ON 

INSERT [dbo].[ChuongHoc] ([IDChuongHoc], [TenChuong], [MoTa], [IDMonHoc]) VALUES (1005, N'Chương 1 : Giới thiệu về  môn  công nghệ phần mềm', NULL, 1004)
SET IDENTITY_INSERT [dbo].[ChuongHoc] OFF
SET IDENTITY_INSERT [dbo].[DeThi] ON 

INSERT [dbo].[DeThi] ([IDDeThi], [IDMonHoc], [MoTa], [ThoiGian], [TenDe], [IDCaThi]) VALUES (9, 1004, NULL, N'45', N'111', 6)
SET IDENTITY_INSERT [dbo].[DeThi] OFF
INSERT [dbo].[DeThi_CauHoi] ([IDDeThi], [IDCauHoi], [MoTa]) VALUES (9, 2003, NULL)
INSERT [dbo].[DeThi_CauHoi] ([IDDeThi], [IDCauHoi], [MoTa]) VALUES (9, 2005, NULL)
SET IDENTITY_INSERT [dbo].[DoanVan] ON 

INSERT [dbo].[DoanVan] ([IDDoanVan], [TenDoanVan], [MoTa], [IDChuongHoc]) VALUES (1004, N'Câu hỏi chương', N'Các câu hỏi của chương đặt ở đây', 1005)
SET IDENTITY_INSERT [dbo].[DoanVan] OFF
INSERT [dbo].[DoKho] ([IDDoKho], [TenDoKho]) VALUES (1, N'Dễ')
INSERT [dbo].[DoKho] ([IDDoKho], [TenDoKho]) VALUES (2, N'Trung bình')
INSERT [dbo].[DoKho] ([IDDoKho], [TenDoKho]) VALUES (3, N'Khó')
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([IDKhoa], [TenKhoa], [MoTa]) VALUES (1004, N'Khoa công nghệ thông tin', N'Khoa đào tạo sinh viên về lập trình máy tính , lập trình phần mềm, trí tuệ nhân tạo ...')
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[KyThi] ON 

INSERT [dbo].[KyThi] ([IDKyThi], [TenKyThi], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (2, N'Kỳ thi kết thúc học phần 2019', NULL, CAST(N'2019-06-04' AS Date), CAST(N'2019-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[KyThi] OFF
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([IDMonHoc], [TenMonHoc], [MoTa], [IDKhoa]) VALUES (1004, N'Công nghệ phần mềm', N'Bộ môn đào tạo xây dựng các phần mềm trên máy tính, điện thoại', 1004)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([IDNguoiDung], [HoTen], [NgaySinh], [QueQuan], [GioiTinh], [SDT], [Email], [TenDangNhap], [MatKhau], [UrlAnh], [IDVaiTro], [MoRong]) VALUES (5, N'Lê Hải Sơn', CAST(N'1995-09-15' AS Date), N'Quảng Ninh', 1, N'2198309123', N'lehaisonmath6@gmail.com', N'lehaisonmath6@gmail.com', N'123456', NULL, 1, NULL)
INSERT [dbo].[NguoiDung] ([IDNguoiDung], [HoTen], [NgaySinh], [QueQuan], [GioiTinh], [SDT], [Email], [TenDangNhap], [MatKhau], [UrlAnh], [IDVaiTro], [MoRong]) VALUES (6, N'Quản lý', NULL, NULL, NULL, NULL, NULL, N'admin', N'admin', NULL, 3, NULL)
INSERT [dbo].[NguoiDung] ([IDNguoiDung], [HoTen], [NgaySinh], [QueQuan], [GioiTinh], [SDT], [Email], [TenDangNhap], [MatKhau], [UrlAnh], [IDVaiTro], [MoRong]) VALUES (7, N'Trần Văn Trường', NULL, NULL, NULL, NULL, NULL, N'giamthi', N'giamthi', NULL, 2, NULL)
INSERT [dbo].[NguoiDung] ([IDNguoiDung], [HoTen], [NgaySinh], [QueQuan], [GioiTinh], [SDT], [Email], [TenDangNhap], [MatKhau], [UrlAnh], [IDVaiTro], [MoRong]) VALUES (8, N'Trần Trường Minh', CAST(N'1995-11-10' AS Date), N'Hà Nội', NULL, N'12392183219321321', NULL, N'sinhvien', N'12345', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
SET IDENTITY_INSERT [dbo].[VaiTro] ON 

INSERT [dbo].[VaiTro] ([IDVaiTro], [TenVaiTro], [MoTa]) VALUES (1, N'Sinh Viên', NULL)
INSERT [dbo].[VaiTro] ([IDVaiTro], [TenVaiTro], [MoTa]) VALUES (2, N'Giám Thị', NULL)
INSERT [dbo].[VaiTro] ([IDVaiTro], [TenVaiTro], [MoTa]) VALUES (3, N'Admin', NULL)
SET IDENTITY_INSERT [dbo].[VaiTro] OFF
ALTER TABLE [dbo].[BaiThi]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyThi_DeThi] FOREIGN KEY([IDDeThi])
REFERENCES [dbo].[DeThi] ([IDDeThi])
GO
ALTER TABLE [dbo].[BaiThi] CHECK CONSTRAINT [FK_NhatKyThi_DeThi]
GO
ALTER TABLE [dbo].[BaiThi]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyThi_SinhVien] FOREIGN KEY([IDNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IDNguoiDung])
GO
ALTER TABLE [dbo].[BaiThi] CHECK CONSTRAINT [FK_NhatKyThi_SinhVien]
GO
ALTER TABLE [dbo].[BaiThi_DapAn]  WITH CHECK ADD  CONSTRAINT [FK_BaiThi_DapAn_BaiThi1] FOREIGN KEY([IDBaiThi])
REFERENCES [dbo].[BaiThi] ([IDBaiThi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaiThi_DapAn] CHECK CONSTRAINT [FK_BaiThi_DapAn_BaiThi1]
GO
ALTER TABLE [dbo].[BaiThi_DapAn]  WITH CHECK ADD  CONSTRAINT [FK_BaiThi_DapAn_CauHoi] FOREIGN KEY([IDCauHoi])
REFERENCES [dbo].[CauHoi] ([IDCauHoi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaiThi_DapAn] CHECK CONSTRAINT [FK_BaiThi_DapAn_CauHoi]
GO
ALTER TABLE [dbo].[CaThi]  WITH CHECK ADD  CONSTRAINT [FK_CaThi_KyThi] FOREIGN KEY([IDKyThi])
REFERENCES [dbo].[KyThi] ([IDKyThi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CaThi] CHECK CONSTRAINT [FK_CaThi_KyThi]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_DoanVan] FOREIGN KEY([IDDoanVan])
REFERENCES [dbo].[DoanVan] ([IDDoanVan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_DoanVan]
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_CauHoi_DoKho] FOREIGN KEY([IDDoKho])
REFERENCES [dbo].[DoKho] ([IDDoKho])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CauHoi] CHECK CONSTRAINT [FK_CauHoi_DoKho]
GO
ALTER TABLE [dbo].[ChuongHoc]  WITH CHECK ADD  CONSTRAINT [FK_ChuongHoc_MonHoc] FOREIGN KEY([IDMonHoc])
REFERENCES [dbo].[MonHoc] ([IDMonHoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChuongHoc] CHECK CONSTRAINT [FK_ChuongHoc_MonHoc]
GO
ALTER TABLE [dbo].[DeThi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_CaThi] FOREIGN KEY([IDCaThi])
REFERENCES [dbo].[CaThi] ([IDCa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeThi] CHECK CONSTRAINT [FK_DeThi_CaThi]
GO
ALTER TABLE [dbo].[DeThi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_MonHoc] FOREIGN KEY([IDMonHoc])
REFERENCES [dbo].[MonHoc] ([IDMonHoc])
GO
ALTER TABLE [dbo].[DeThi] CHECK CONSTRAINT [FK_DeThi_MonHoc]
GO
ALTER TABLE [dbo].[DeThi_CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_CauHoi_CauHoi] FOREIGN KEY([IDCauHoi])
REFERENCES [dbo].[CauHoi] ([IDCauHoi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeThi_CauHoi] CHECK CONSTRAINT [FK_DeThi_CauHoi_CauHoi]
GO
ALTER TABLE [dbo].[DeThi_CauHoi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_CauHoi_DeThi] FOREIGN KEY([IDDeThi])
REFERENCES [dbo].[DeThi] ([IDDeThi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeThi_CauHoi] CHECK CONSTRAINT [FK_DeThi_CauHoi_DeThi]
GO
ALTER TABLE [dbo].[DoanVan]  WITH CHECK ADD  CONSTRAINT [FK_DoanVan_ChuongHoc] FOREIGN KEY([IDChuongHoc])
REFERENCES [dbo].[ChuongHoc] ([IDChuongHoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoanVan] CHECK CONSTRAINT [FK_DoanVan_ChuongHoc]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_Khoa] FOREIGN KEY([IDKhoa])
REFERENCES [dbo].[Khoa] ([IDKhoa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_Khoa]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_VaiTro] FOREIGN KEY([IDVaiTro])
REFERENCES [dbo].[VaiTro] ([IDVaiTro])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_VaiTro]
GO
USE [master]
GO
ALTER DATABASE [ThiOnline] SET  READ_WRITE 
GO
