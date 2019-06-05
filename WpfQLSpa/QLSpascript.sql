USE [master]
GO
/****** Object:  Database [QLSpa]    Script Date: 7/5/2019 6:22:29 PM ******/
CREATE DATABASE [QLSpa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLSpa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLSpa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLSpa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLSpa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLSpa] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSpa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSpa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSpa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSpa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSpa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSpa] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSpa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLSpa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSpa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSpa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSpa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSpa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSpa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSpa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSpa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSpa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLSpa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSpa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSpa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSpa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSpa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSpa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSpa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSpa] SET RECOVERY FULL 
GO
ALTER DATABASE [QLSpa] SET  MULTI_USER 
GO
ALTER DATABASE [QLSpa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSpa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLSpa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLSpa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLSpa] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLSpa', N'ON'
GO
ALTER DATABASE [QLSpa] SET QUERY_STORE = OFF
GO
USE [QLSpa]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[IDDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](max) NULL,
	[DonGia] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[IDDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu_SanPham]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu_SanPham](
	[IDDichVu] [int] NOT NULL,
	[IDSanPham] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonViTinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_DichVu_SanPham] PRIMARY KEY CLUSTERED 
(
	[IDDichVu] ASC,
	[IDSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangSanXuat]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangSanXuat](
	[IDHangSanXuat] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangSanXuat] PRIMARY KEY CLUSTERED 
(
	[IDHangSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SinhNhat] [date] NULL,
	[GioiTinh] [bit] NULL,
	[CMT] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichChamSoc]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichChamSoc](
	[IDLichChamSoc] [nvarchar](50) NOT NULL,
	[IDLieuTrinh] [nvarchar](50) NULL,
	[ThoiGian] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[IDTrangThaiChamSoc] [int] NULL,
 CONSTRAINT [PK_LichChamSoc] PRIMARY KEY CLUSTERED 
(
	[IDLichChamSoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichHen]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichHen](
	[IDLichHen] [int] IDENTITY(1,1) NOT NULL,
	[IDKhachHang] [nvarchar](50) NULL,
	[ThoiGianHen] [datetime] NULL,
	[ThoiGianBaoTruoc] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[IDTrangThaiHen] [int] NULL,
 CONSTRAINT [PK_LichHen] PRIMARY KEY CLUSTERED 
(
	[IDLichHen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichLieuTrinh]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichLieuTrinh](
	[IDLichLieuTrinh] [int] IDENTITY(1,1) NOT NULL,
	[IDLieuTrinh] [int] NULL,
	[ThoiGianDieuTri] [datetime] NULL,
	[ThoiGianBaoTruoc] [datetime] NULL,
	[MoTa] [nvarchar](max) NULL,
	[DaThucHien] [bit] NULL,
 CONSTRAINT [PK_LichLieuTrinh] PRIMARY KEY CLUSTERED 
(
	[IDLichLieuTrinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LieuTrinh]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LieuTrinh](
	[IDLieuTrinh] [int] IDENTITY(1,1) NOT NULL,
	[IDDichVu] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[HoaHong] [int] NULL,
	[TongSoBuoi] [int] NULL,
	[SoBuoiDaSuDung] [int] NULL,
	[TongTien] [int] NULL,
	[NgayMua] [date] NULL,
	[SoTienDaThanhToan] [int] NULL,
	[SoTienChuaThanhToan] [int] NULL,
	[IDKhachhang] [nvarchar](50) NULL,
	[IDNhanVien] [nvarchar](50) NULL,
 CONSTRAINT [PK_LieuTrinh] PRIMARY KEY CLUSTERED 
(
	[IDLieuTrinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNhanVien] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[CMT] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[GioiTinh] [bit] NULL,
	[SinhNhat] [date] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IDSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[DonVi] [nvarchar](max) NULL,
	[DonGia] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[UrlAnh] [nvarchar](max) NULL,
	[IDHangSanXuat] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IDSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThaiHen]    Script Date: 7/5/2019 6:22:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiHen](
	[IDTrangThaiHen] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThai] [nvarchar](max) NULL,
 CONSTRAINT [PK_TrangThaiHen] PRIMARY KEY CLUSTERED 
(
	[IDTrangThaiHen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([IDDichVu], [TenDichVu], [DonGia], [MoTa]) VALUES (4, N'Tắm trắng', 500000, N'Tắm trắng toàn thân')
INSERT [dbo].[DichVu] ([IDDichVu], [TenDichVu], [DonGia], [MoTa]) VALUES (5, N'Trị mụn', 150000, N'Chuyên trị mụn thâm ,nám')
SET IDENTITY_INSERT [dbo].[DichVu] OFF
INSERT [dbo].[DichVu_SanPham] ([IDDichVu], [IDSanPham], [SoLuong], [DonViTinh]) VALUES (4, 1, 1, N'Lọ')
INSERT [dbo].[DichVu_SanPham] ([IDDichVu], [IDSanPham], [SoLuong], [DonViTinh]) VALUES (4, 2, 1, N'Lọ')
INSERT [dbo].[DichVu_SanPham] ([IDDichVu], [IDSanPham], [SoLuong], [DonViTinh]) VALUES (5, 1, 1, N'Lọ')
SET IDENTITY_INSERT [dbo].[HangSanXuat] ON 

INSERT [dbo].[HangSanXuat] ([IDHangSanXuat], [TenHang], [MoTa], [DiaChi]) VALUES (1, N'Cty mỹ phẩm việt nam', N'Cty chuyên sản xuất kem chống nắng ', N'Ba đình Hà nội')
INSERT [dbo].[HangSanXuat] ([IDHangSanXuat], [TenHang], [MoTa], [DiaChi]) VALUES (2, N'Cty Dior', N'Cty mỹ phẩm cao cấp', N'Từ liêm Hà Nội')
INSERT [dbo].[HangSanXuat] ([IDHangSanXuat], [TenHang], [MoTa], [DiaChi]) VALUES (3, N'Hòa bình', N'Công ty TNHH Hòa bình group', N'Hà Nội')
INSERT [dbo].[HangSanXuat] ([IDHangSanXuat], [TenHang], [MoTa], [DiaChi]) VALUES (4, N'Công ty TNHH mụn thái dương', N'', N'Cao Bằng')
SET IDENTITY_INSERT [dbo].[HangSanXuat] OFF
INSERT [dbo].[KhachHang] ([IDKhachHang], [HoTen], [SDT], [Email], [SinhNhat], [GioiTinh], [CMT], [DiaChi]) VALUES (N'KH0384399862', N'Lê Hải Sơn', N'0384399862', N'lehaisonmath6@gmail.com', CAST(N'2019-04-09' AS Date), 1, N'1457981459', N'Hạ Long')
INSERT [dbo].[KhachHang] ([IDKhachHang], [HoTen], [SDT], [Email], [SinhNhat], [GioiTinh], [CMT], [DiaChi]) VALUES (N'KH0966782825', N'Trần Minh Tuấn', N'0966782825', N'fasdfkalsjflja@gmail.com', CAST(N'1995-07-05' AS Date), 1, N'1233124124214', N'Khánh Hòa')
SET IDENTITY_INSERT [dbo].[LichHen] ON 

INSERT [dbo].[LichHen] ([IDLichHen], [IDKhachHang], [ThoiGianHen], [ThoiGianBaoTruoc], [NoiDung], [IDTrangThaiHen]) VALUES (2, N'KH0384399862', CAST(N'2019-04-26T00:00:00.000' AS DateTime), CAST(N'2019-04-25T00:00:00.000' AS DateTime), N'Hẹn gặp về dịch vụ ', 3)
INSERT [dbo].[LichHen] ([IDLichHen], [IDKhachHang], [ThoiGianHen], [ThoiGianBaoTruoc], [NoiDung], [IDTrangThaiHen]) VALUES (3, N'KH0966782825', CAST(N'2019-05-04T00:00:00.000' AS DateTime), CAST(N'2019-05-03T00:00:00.000' AS DateTime), N'Hẹn gặp  tư vấn về tắm trắng', 1)
SET IDENTITY_INSERT [dbo].[LichHen] OFF
SET IDENTITY_INSERT [dbo].[LichLieuTrinh] ON 

INSERT [dbo].[LichLieuTrinh] ([IDLichLieuTrinh], [IDLieuTrinh], [ThoiGianDieuTri], [ThoiGianBaoTruoc], [MoTa], [DaThucHien]) VALUES (1, 12, CAST(N'2019-04-26T00:00:00.000' AS DateTime), CAST(N'2019-04-25T00:00:00.000' AS DateTime), N'Khách đến sớn nhé', 0)
INSERT [dbo].[LichLieuTrinh] ([IDLichLieuTrinh], [IDLieuTrinh], [ThoiGianDieuTri], [ThoiGianBaoTruoc], [MoTa], [DaThucHien]) VALUES (2, 12, CAST(N'2019-05-17T00:00:00.000' AS DateTime), CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'', 0)
INSERT [dbo].[LichLieuTrinh] ([IDLichLieuTrinh], [IDLieuTrinh], [ThoiGianDieuTri], [ThoiGianBaoTruoc], [MoTa], [DaThucHien]) VALUES (3, 13, CAST(N'2019-05-03T00:00:00.000' AS DateTime), CAST(N'2019-05-02T00:00:00.000' AS DateTime), N'Khách hàng pha đến điều trị lần 1 cho tắm trắng', 1)
SET IDENTITY_INSERT [dbo].[LichLieuTrinh] OFF
SET IDENTITY_INSERT [dbo].[LieuTrinh] ON 

INSERT [dbo].[LieuTrinh] ([IDLieuTrinh], [IDDichVu], [MoTa], [HoaHong], [TongSoBuoi], [SoBuoiDaSuDung], [TongTien], [NgayMua], [SoTienDaThanhToan], [SoTienChuaThanhToan], [IDKhachhang], [IDNhanVien]) VALUES (12, 4, N'Tắm trắng cho anh sơn', 10000, 10, 0, 1000000, CAST(N'2019-04-25' AS Date), 1000000, NULL, N'KH0384399862', N'NV3921081982489')
INSERT [dbo].[LieuTrinh] ([IDLieuTrinh], [IDDichVu], [MoTa], [HoaHong], [TongSoBuoi], [SoBuoiDaSuDung], [TongTien], [NgayMua], [SoTienDaThanhToan], [SoTienChuaThanhToan], [IDKhachhang], [IDNhanVien]) VALUES (13, 4, N'Tắm trắng cho khách hàng Pha', 10000, 10, 0, 1500000, CAST(N'2019-05-03' AS Date), 1500000, NULL, N'KH0966782825', N'NV3921081982489')
SET IDENTITY_INSERT [dbo].[LieuTrinh] OFF
INSERT [dbo].[NhanVien] ([IDNhanVien], [HoTen], [SDT], [CMT], [DiaChi], [Email], [GioiTinh], [SinhNhat]) VALUES (N'NV3921081982489', N'Nguyễn Thanh Tùng', N'3921081982489', N'123312389219', N'Hà Nam', N'tung@gmail.com', 1, CAST(N'2019-04-10' AS Date))
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([IDSanPham], [TenSanPham], [DonVi], [DonGia], [MoTa], [UrlAnh], [IDHangSanXuat]) VALUES (1, N'Kem trắng da ban đêm dior', N'lọ', 500000, N'Chỉ là kem thôi', N'D:\WpfQLSpa\WpfQLSpa\bin\Debug\img\kemtrangdabandem.jpg', 2)
INSERT [dbo].[SanPham] ([IDSanPham], [TenSanPham], [DonVi], [DonGia], [MoTa], [UrlAnh], [IDHangSanXuat]) VALUES (2, N'Kem dưỡng trắng da ban ngày', N'lọ', 500000, N'Dùng cho ban ngày', N'D:\WpfQLSpa\WpfQLSpa\bin\Debug\img\kemtrangdabandem.jpg', 2)
INSERT [dbo].[SanPham] ([IDSanPham], [TenSanPham], [DonVi], [DonGia], [MoTa], [UrlAnh], [IDHangSanXuat]) VALUES (3, N'Son việt', N'thỏi', 100000, N'Son bôi môi', N'D:\WpfQLSpa\WpfQLSpa\bin\Debug\img\son.jpg', 1)
INSERT [dbo].[SanPham] ([IDSanPham], [TenSanPham], [DonVi], [DonGia], [MoTa], [UrlAnh], [IDHangSanXuat]) VALUES (4, N'Kem nối mi', N'Lọ', 100000, N'Dùng cho nối mi tóc', N'', 2)
INSERT [dbo].[SanPham] ([IDSanPham], [TenSanPham], [DonVi], [DonGia], [MoTa], [UrlAnh], [IDHangSanXuat]) VALUES (5, N'Thuốc trị mụn arona', N'Lọ', 150000, N'Thuốc trị mụn mặt', N'D:\WpfQLSpa\WpfQLSpa\bin\Debug\img\son.jpg', 2)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[TrangThaiHen] ON 

INSERT [dbo].[TrangThaiHen] ([IDTrangThaiHen], [TenTrangThai]) VALUES (1, N'Chờ')
INSERT [dbo].[TrangThaiHen] ([IDTrangThaiHen], [TenTrangThai]) VALUES (2, N'Đang thực hiện')
INSERT [dbo].[TrangThaiHen] ([IDTrangThaiHen], [TenTrangThai]) VALUES (3, N'Đã thực hiện')
INSERT [dbo].[TrangThaiHen] ([IDTrangThaiHen], [TenTrangThai]) VALUES (4, N'Thất bại')
SET IDENTITY_INSERT [dbo].[TrangThaiHen] OFF
ALTER TABLE [dbo].[DichVu_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_SanPham_DichVu] FOREIGN KEY([IDDichVu])
REFERENCES [dbo].[DichVu] ([IDDichVu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DichVu_SanPham] CHECK CONSTRAINT [FK_DichVu_SanPham_DichVu]
GO
ALTER TABLE [dbo].[DichVu_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_SanPham_SanPham] FOREIGN KEY([IDSanPham])
REFERENCES [dbo].[SanPham] ([IDSanPham])
GO
ALTER TABLE [dbo].[DichVu_SanPham] CHECK CONSTRAINT [FK_DichVu_SanPham_SanPham]
GO
ALTER TABLE [dbo].[LichHen]  WITH CHECK ADD  CONSTRAINT [FK_LichHen_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[LichHen] CHECK CONSTRAINT [FK_LichHen_KhachHang]
GO
ALTER TABLE [dbo].[LichHen]  WITH CHECK ADD  CONSTRAINT [FK_LichHen_TrangThaiHen] FOREIGN KEY([IDTrangThaiHen])
REFERENCES [dbo].[TrangThaiHen] ([IDTrangThaiHen])
GO
ALTER TABLE [dbo].[LichHen] CHECK CONSTRAINT [FK_LichHen_TrangThaiHen]
GO
ALTER TABLE [dbo].[LichLieuTrinh]  WITH CHECK ADD  CONSTRAINT [FK_LichLieuTrinh_LieuTrinh] FOREIGN KEY([IDLieuTrinh])
REFERENCES [dbo].[LieuTrinh] ([IDLieuTrinh])
GO
ALTER TABLE [dbo].[LichLieuTrinh] CHECK CONSTRAINT [FK_LichLieuTrinh_LieuTrinh]
GO
ALTER TABLE [dbo].[LieuTrinh]  WITH CHECK ADD  CONSTRAINT [FK_LieuTrinh_DichVu1] FOREIGN KEY([IDDichVu])
REFERENCES [dbo].[DichVu] ([IDDichVu])
GO
ALTER TABLE [dbo].[LieuTrinh] CHECK CONSTRAINT [FK_LieuTrinh_DichVu1]
GO
ALTER TABLE [dbo].[LieuTrinh]  WITH CHECK ADD  CONSTRAINT [FK_LieuTrinh_KhachHang] FOREIGN KEY([IDKhachhang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[LieuTrinh] CHECK CONSTRAINT [FK_LieuTrinh_KhachHang]
GO
ALTER TABLE [dbo].[LieuTrinh]  WITH CHECK ADD  CONSTRAINT [FK_LieuTrinh_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[LieuTrinh] CHECK CONSTRAINT [FK_LieuTrinh_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_HangSanXuat] FOREIGN KEY([IDHangSanXuat])
REFERENCES [dbo].[HangSanXuat] ([IDHangSanXuat])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_HangSanXuat]
GO
USE [master]
GO
ALTER DATABASE [QLSpa] SET  READ_WRITE 
GO
