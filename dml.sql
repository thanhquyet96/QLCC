USE [master]
GO
/****** Object:  Database [QuanLyChamCong]    Script Date: 3/22/2023 11:18:00 AM ******/
CREATE DATABASE [QuanLyChamCong]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyChamCong', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER02\MSSQL\DATA\QuanLyChamCong.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyChamCong_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER02\MSSQL\DATA\QuanLyChamCong_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyChamCong] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyChamCong].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyChamCong] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyChamCong] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyChamCong] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyChamCong] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyChamCong] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyChamCong] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyChamCong] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyChamCong] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyChamCong] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyChamCong] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyChamCong] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyChamCong]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[NgayChamCongId] [int] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuChamCong]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianChamCong] [datetime] NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[NgayChamCong] [date] NOT NULL,
 CONSTRAINT [PK_LichSuChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NgayChamCong]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NgayChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianChamCong] [datetime] NULL,
	[ThoiGianRaVe] [datetime] NULL,
	[NgayChamCong] [date] NULL,
	[NhanVienId] [int] NULL,
 CONSTRAINT [PK_NgayChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NghiPhep]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NghiPhep](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[LyDo] [nvarchar](50) NOT NULL,
	[NguoiPheDuyetId] [int] NOT NULL,
	[ThoiGianTao] [datetime] NOT NULL,
	[TaoChoNgay] [date] NOT NULL,
	[LoaiNghi] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_NghiPhep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SinhNhat] [date] NOT NULL,
	[HeSoLuong] [float] NOT NULL,
	[NgayNghiPhep] [int] NULL,
	[SoNgayDaNghi] [int] NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien_Quyen]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_Quyen](
	[NhanVienId] [int] NOT NULL,
	[QuyenId] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien_Quyen] PRIMARY KEY CLUSTERED 
(
	[NhanVienId] ASC,
	[QuyenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 3/22/2023 11:18:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[NghiPhep] ON 

INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai]) VALUES (6, 1, N'123456', 0, CAST(N'2023-03-21 13:24:34.640' AS DateTime), CAST(N'0001-01-01' AS Date), 1, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai]) VALUES (7, 1, N'mn', 0, CAST(N'2023-03-21 23:43:36.533' AS DateTime), CAST(N'0001-01-01' AS Date), 2, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai]) VALUES (8, 1, N'nm', 0, CAST(N'2023-03-21 23:45:05.783' AS DateTime), CAST(N'0001-01-01' AS Date), 2, 1)
SET IDENTITY_INSERT [dbo].[NghiPhep] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([Id], [HoVaTen], [SoDienThoai], [DiaChi], [SinhNhat], [HeSoLuong], [NgayNghiPhep], [SoNgayDaNghi], [TaiKhoan], [MatKhau]) VALUES (1, N'Phan Thành Quyết', N'0949660502', N'Hồng Thuận Nam Định', CAST(N'2023-03-20' AS Date), 2.3, 12, 12, N'admin', N'123')
INSERT [dbo].[NhanVien] ([Id], [HoVaTen], [SoDienThoai], [DiaChi], [SinhNhat], [HeSoLuong], [NgayNghiPhep], [SoNgayDaNghi], [TaiKhoan], [MatKhau]) VALUES (6, N'Quyết', N'0949660403', N'Hà nội', CAST(N'2023-03-21' AS Date), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (1, 3)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (1, 4)
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([Id], [TenQuyen]) VALUES (2, N'ADMIN')
INSERT [dbo].[Quyen] ([Id], [TenQuyen]) VALUES (3, N'USER')
INSERT [dbo].[Quyen] ([Id], [TenQuyen]) VALUES (4, N'Role')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NgayChamCong] FOREIGN KEY([NgayChamCongId])
REFERENCES [dbo].[NgayChamCong] ([Id])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NgayChamCong]
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NhanVien] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NhanVien]
GO
ALTER TABLE [dbo].[LichSuChamCong]  WITH CHECK ADD  CONSTRAINT [FK_LichSuChamCong_NhanVien] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[LichSuChamCong] CHECK CONSTRAINT [FK_LichSuChamCong_NhanVien]
GO
ALTER TABLE [dbo].[NghiPhep]  WITH CHECK ADD  CONSTRAINT [FK_NghiPhep_NhanVien] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[NghiPhep] CHECK CONSTRAINT [FK_NghiPhep_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien_Quyen]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Quyen_NhanVien] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[NhanVien_Quyen] CHECK CONSTRAINT [FK_NhanVien_Quyen_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien_Quyen]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Quyen_Quyen] FOREIGN KEY([QuyenId])
REFERENCES [dbo].[Quyen] ([Id])
GO
ALTER TABLE [dbo].[NhanVien_Quyen] CHECK CONSTRAINT [FK_NhanVien_Quyen_Quyen]
GO
USE [master]
GO
ALTER DATABASE [QuanLyChamCong] SET  READ_WRITE 
GO
