CREATE DATABASE QLCC;
USE QLCC;
CREATE TABLE [dbo].[ChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [int] NULL,
	[NgayChamCongId] [int] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuChamCong]    Script Date: 3/31/2023 4:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[NgayChamCong] [date] NOT NULL,
	[ThoiGianChamCong] [decimal](18, 0) NULL,
 CONSTRAINT [PK_LichSuChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NgayChamCong]    Script Date: 3/31/2023 4:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NgayChamCong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianChamCong] [datetime] NULL,
	[ThoiGianRaVe] [datetime] NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_NgayChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NghiPhep]    Script Date: 3/31/2023 4:00:44 PM ******/
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
	[HinhThucNghi] [int] NOT NULL,
 CONSTRAINT [PK_NghiPhep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 3/31/2023 4:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SinhNhat] [date] NULL,
	[HeSoLuong] [float] NULL,
	[NgayNghiPhep] [int] NULL,
	[SoNgayDaNghi] [int] NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[LuongCoBan] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien_Quyen]    Script Date: 3/31/2023 4:00:44 PM ******/
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
/****** Object:  Table [dbo].[Quyen]    Script Date: 3/31/2023 4:00:44 PM ******/
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
SET IDENTITY_INSERT [dbo].[ChamCong] ON 

INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (1, 1, 19)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (2, 1, 20)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (3, 1, 21)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (4, 1, 22)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (5, 1, 23)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (6, 1, 24)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (7, 1, 25)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (8, 1, 26)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (9, 1, 27)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (10, 1, 28)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (11, 1, 29)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (12, 1, 30)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (13, 1, 31)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (14, 1, 32)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (15, 1, 33)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (16, 1, 34)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (17, 1, 35)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (18, 1, 36)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (19, 1, 37)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (20, 1, 38)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (21, 1, 39)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (22, 1, 40)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (23, 1, 41)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (24, 1, 42)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (25, 1, 43)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (26, 1, 44)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (27, 1, 45)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (28, 1, 46)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (29, 1, 47)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (30, 1, 48)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (31, 1, 49)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (32, 1, 50)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (33, 1, 51)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (34, 1, 52)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (35, 1, 53)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (36, 1, 54)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (37, 1, 55)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (38, 1, 56)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (39, 1, 57)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (40, 1, 58)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (41, 1, 59)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (42, 1, 60)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (43, 1, 61)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (44, 1, 62)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (45, 1, 63)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (46, 1, 64)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (47, 1, 65)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (48, 1, 66)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (49, 1, 67)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (50, 1, 68)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (51, 1, 69)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (52, 1, 70)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (53, 1, 71)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (54, 1, 72)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (55, 1, 73)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (56, 1, 74)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (57, 1, 75)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (58, 1, 76)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (59, 1, 77)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (60, 1, 78)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (61, 1, 79)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (62, 1, 80)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (63, 1, 81)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (64, 1, 82)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (65, 1, 83)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (66, 1, 84)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (67, 1, 85)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (68, 1, 86)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (69, 1, 87)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (70, 1, 88)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (71, 1, 89)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (72, 1, 90)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (73, 1, 91)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (74, 1, 92)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (75, 1, 93)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (76, 1, 94)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (77, 1, 95)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (78, 1, 96)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (79, 1, 97)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (80, 1, 98)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (81, 1, 99)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (82, 1, 100)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (83, 1, 101)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (84, 1, 102)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (85, 1, 103)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (86, 1, 104)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (87, 1, 105)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (88, 1, 106)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (89, 1, 107)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (90, 1, 108)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (91, 1, 109)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (92, 1, 110)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (93, 1, 111)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (94, 1, 112)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (95, 1, 113)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (96, 1, 114)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (97, 1, 115)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (98, 1, 116)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (99, 1, 117)
GO
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (100, 1, 118)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (101, 1, 119)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (102, 1, 120)
INSERT [dbo].[ChamCong] ([Id], [NhanVienId], [NgayChamCongId]) VALUES (103, 1, 121)
SET IDENTITY_INSERT [dbo].[ChamCong] OFF
SET IDENTITY_INSERT [dbo].[LichSuChamCong] ON 

INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (1, 1, CAST(N'2023-01-01' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (2, 1, CAST(N'2023-01-02' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (3, 1, CAST(N'2023-01-03' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (4, 1, CAST(N'2023-01-04' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (5, 1, CAST(N'2023-01-05' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (6, 1, CAST(N'2023-01-06' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (7, 1, CAST(N'2023-01-07' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (8, 1, CAST(N'2023-01-08' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (9, 1, CAST(N'2023-01-09' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (10, 1, CAST(N'2023-01-10' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (11, 1, CAST(N'2023-01-11' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (12, 1, CAST(N'2023-01-12' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (13, 1, CAST(N'2023-01-13' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (14, 1, CAST(N'2023-01-14' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (15, 1, CAST(N'2023-01-15' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (16, 1, CAST(N'2023-01-16' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (17, 1, CAST(N'2023-01-17' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (18, 1, CAST(N'2023-01-18' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (19, 1, CAST(N'2023-01-19' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (20, 1, CAST(N'2023-01-20' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (21, 1, CAST(N'2023-02-01' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (22, 1, CAST(N'2023-02-02' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (23, 1, CAST(N'2023-02-03' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (24, 1, CAST(N'2023-02-04' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (25, 1, CAST(N'2023-02-05' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (26, 1, CAST(N'2023-02-06' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (27, 1, CAST(N'2023-02-07' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (28, 1, CAST(N'2023-02-08' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (29, 1, CAST(N'2023-02-09' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (30, 1, CAST(N'2023-02-10' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (31, 1, CAST(N'2023-02-11' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (32, 1, CAST(N'2023-02-12' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (33, 1, CAST(N'2023-02-13' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (34, 1, CAST(N'2023-02-14' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (35, 1, CAST(N'2023-02-15' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (36, 1, CAST(N'2023-02-16' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (37, 1, CAST(N'2023-02-17' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (38, 1, CAST(N'2023-02-18' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (39, 1, CAST(N'2023-02-19' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (40, 1, CAST(N'2023-02-20' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (41, 1, CAST(N'2023-03-01' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (42, 1, CAST(N'2023-03-02' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (43, 1, CAST(N'2023-03-03' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (44, 1, CAST(N'2023-03-04' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (45, 1, CAST(N'2023-03-05' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (46, 1, CAST(N'2023-03-06' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (47, 1, CAST(N'2023-03-07' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (48, 1, CAST(N'2023-03-08' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (49, 1, CAST(N'2023-03-09' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (50, 1, CAST(N'2023-03-10' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (51, 1, CAST(N'2023-03-11' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (52, 1, CAST(N'2023-03-12' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (53, 1, CAST(N'2023-03-13' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (54, 1, CAST(N'2023-03-14' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (55, 1, CAST(N'2023-03-15' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (56, 1, CAST(N'2023-03-16' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (57, 1, CAST(N'2023-03-17' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (58, 1, CAST(N'2023-03-18' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (59, 1, CAST(N'2023-03-19' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (60, 1, CAST(N'2023-03-20' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (61, 1, CAST(N'2023-04-01' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (62, 1, CAST(N'2023-04-02' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (63, 1, CAST(N'2023-04-03' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (64, 1, CAST(N'2023-04-04' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (65, 1, CAST(N'2023-04-05' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (66, 1, CAST(N'2023-04-06' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (67, 1, CAST(N'2023-04-07' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (68, 1, CAST(N'2023-04-08' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (69, 1, CAST(N'2023-04-09' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (70, 1, CAST(N'2023-04-10' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (71, 1, CAST(N'2023-04-11' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (72, 1, CAST(N'2023-04-12' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (73, 1, CAST(N'2023-04-13' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (74, 1, CAST(N'2023-04-14' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (75, 1, CAST(N'2023-04-15' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (76, 1, CAST(N'2023-04-16' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (77, 1, CAST(N'2023-04-17' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (78, 1, CAST(N'2023-04-18' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (79, 1, CAST(N'2023-04-19' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (80, 1, CAST(N'2023-04-20' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (81, 1, CAST(N'2023-05-01' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (82, 1, CAST(N'2023-05-02' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (83, 1, CAST(N'2023-05-03' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (84, 1, CAST(N'2023-05-04' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (85, 1, CAST(N'2023-05-05' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (86, 1, CAST(N'2023-05-06' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (87, 1, CAST(N'2023-05-07' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (88, 1, CAST(N'2023-05-08' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (89, 1, CAST(N'2023-05-09' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (90, 1, CAST(N'2023-05-10' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (91, 1, CAST(N'2023-05-11' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (92, 1, CAST(N'2023-05-12' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (93, 1, CAST(N'2023-05-13' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (94, 1, CAST(N'2023-05-14' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (95, 1, CAST(N'2023-05-15' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (96, 1, CAST(N'2023-05-16' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (97, 1, CAST(N'2023-05-17' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (98, 1, CAST(N'2023-05-18' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (99, 1, CAST(N'2023-05-19' AS Date), CAST(0 AS Decimal(18, 0)))
GO
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (100, 1, CAST(N'2023-05-20' AS Date), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[LichSuChamCong] ([Id], [NhanVienId], [NgayChamCong], [ThoiGianChamCong]) VALUES (101, 1, CAST(N'2023-03-31' AS Date), CAST(0 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[LichSuChamCong] OFF
SET IDENTITY_INSERT [dbo].[NgayChamCong] ON 

INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (19, CAST(N'2023-01-01 00:00:00.000' AS DateTime), CAST(N'2023-01-01 00:00:00.000' AS DateTime), N'01-01-2023', CAST(N'2023-01-01' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (20, CAST(N'2023-01-02 00:00:00.000' AS DateTime), CAST(N'2023-01-02 00:00:00.000' AS DateTime), N'02-01-2023', CAST(N'2023-01-02' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (21, CAST(N'2023-01-03 00:00:00.000' AS DateTime), CAST(N'2023-01-03 00:00:00.000' AS DateTime), N'03-01-2023', CAST(N'2023-01-03' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (22, CAST(N'2023-01-04 00:00:00.000' AS DateTime), CAST(N'2023-01-04 00:00:00.000' AS DateTime), N'04-01-2023', CAST(N'2023-01-04' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (23, CAST(N'2023-01-05 00:00:00.000' AS DateTime), CAST(N'2023-01-05 00:00:00.000' AS DateTime), N'05-01-2023', CAST(N'2023-01-05' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (24, CAST(N'2023-01-06 00:00:00.000' AS DateTime), CAST(N'2023-01-06 00:00:00.000' AS DateTime), N'06-01-2023', CAST(N'2023-01-06' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (25, CAST(N'2023-01-07 00:00:00.000' AS DateTime), CAST(N'2023-01-07 00:00:00.000' AS DateTime), N'07-01-2023', CAST(N'2023-01-07' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (26, CAST(N'2023-01-08 00:00:00.000' AS DateTime), CAST(N'2023-01-08 00:00:00.000' AS DateTime), N'08-01-2023', CAST(N'2023-01-08' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (27, CAST(N'2023-01-09 00:00:00.000' AS DateTime), CAST(N'2023-01-09 00:00:00.000' AS DateTime), N'09-01-2023', CAST(N'2023-01-09' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (28, CAST(N'2023-01-10 00:00:00.000' AS DateTime), CAST(N'2023-01-10 00:00:00.000' AS DateTime), N'10-01-2023', CAST(N'2023-01-10' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (29, CAST(N'2023-01-11 00:00:00.000' AS DateTime), CAST(N'2023-01-11 00:00:00.000' AS DateTime), N'11-01-2023', CAST(N'2023-01-11' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (30, CAST(N'2023-01-12 00:00:00.000' AS DateTime), CAST(N'2023-01-12 00:00:00.000' AS DateTime), N'12-01-2023', CAST(N'2023-01-12' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (31, CAST(N'2023-01-13 00:00:00.000' AS DateTime), CAST(N'2023-01-13 00:00:00.000' AS DateTime), N'13-01-2023', CAST(N'2023-01-13' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (32, CAST(N'2023-01-14 00:00:00.000' AS DateTime), CAST(N'2023-01-14 00:00:00.000' AS DateTime), N'14-01-2023', CAST(N'2023-01-14' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (33, CAST(N'2023-01-15 00:00:00.000' AS DateTime), CAST(N'2023-01-15 00:00:00.000' AS DateTime), N'15-01-2023', CAST(N'2023-01-15' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (34, CAST(N'2023-01-16 00:00:00.000' AS DateTime), CAST(N'2023-01-16 00:00:00.000' AS DateTime), N'16-01-2023', CAST(N'2023-01-16' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (35, CAST(N'2023-01-17 00:00:00.000' AS DateTime), CAST(N'2023-01-17 00:00:00.000' AS DateTime), N'17-01-2023', CAST(N'2023-01-17' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (36, CAST(N'2023-01-18 00:00:00.000' AS DateTime), CAST(N'2023-01-18 00:00:00.000' AS DateTime), N'18-01-2023', CAST(N'2023-01-18' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (37, CAST(N'2023-01-19 00:00:00.000' AS DateTime), CAST(N'2023-01-19 00:00:00.000' AS DateTime), N'19-01-2023', CAST(N'2023-01-19' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (38, CAST(N'2023-01-20 00:00:00.000' AS DateTime), CAST(N'2023-01-20 00:00:00.000' AS DateTime), N'20-01-2023', CAST(N'2023-01-20' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (39, CAST(N'2023-02-01 00:00:00.000' AS DateTime), CAST(N'2023-02-01 00:00:00.000' AS DateTime), N'01-02-2023', CAST(N'2023-02-01' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (40, CAST(N'2023-02-02 00:00:00.000' AS DateTime), CAST(N'2023-02-02 00:00:00.000' AS DateTime), N'02-02-2023', CAST(N'2023-02-02' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (41, CAST(N'2023-02-03 00:00:00.000' AS DateTime), CAST(N'2023-02-03 00:00:00.000' AS DateTime), N'03-02-2023', CAST(N'2023-02-03' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (42, CAST(N'2023-02-04 00:00:00.000' AS DateTime), CAST(N'2023-02-04 00:00:00.000' AS DateTime), N'04-02-2023', CAST(N'2023-02-04' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (43, CAST(N'2023-02-05 00:00:00.000' AS DateTime), CAST(N'2023-02-05 00:00:00.000' AS DateTime), N'05-02-2023', CAST(N'2023-02-05' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (44, CAST(N'2023-02-06 00:00:00.000' AS DateTime), CAST(N'2023-02-06 00:00:00.000' AS DateTime), N'06-02-2023', CAST(N'2023-02-06' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (45, CAST(N'2023-02-07 00:00:00.000' AS DateTime), CAST(N'2023-02-07 00:00:00.000' AS DateTime), N'07-02-2023', CAST(N'2023-02-07' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (46, CAST(N'2023-02-08 00:00:00.000' AS DateTime), CAST(N'2023-02-08 00:00:00.000' AS DateTime), N'08-02-2023', CAST(N'2023-02-08' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (47, CAST(N'2023-02-09 00:00:00.000' AS DateTime), CAST(N'2023-02-09 00:00:00.000' AS DateTime), N'09-02-2023', CAST(N'2023-02-09' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (48, CAST(N'2023-02-10 00:00:00.000' AS DateTime), CAST(N'2023-02-10 00:00:00.000' AS DateTime), N'10-02-2023', CAST(N'2023-02-10' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (49, CAST(N'2023-02-11 00:00:00.000' AS DateTime), CAST(N'2023-02-11 00:00:00.000' AS DateTime), N'11-02-2023', CAST(N'2023-02-11' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (50, CAST(N'2023-02-12 00:00:00.000' AS DateTime), CAST(N'2023-02-12 00:00:00.000' AS DateTime), N'12-02-2023', CAST(N'2023-02-12' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (51, CAST(N'2023-02-13 00:00:00.000' AS DateTime), CAST(N'2023-02-13 00:00:00.000' AS DateTime), N'13-02-2023', CAST(N'2023-02-13' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (52, CAST(N'2023-02-14 00:00:00.000' AS DateTime), CAST(N'2023-02-14 00:00:00.000' AS DateTime), N'14-02-2023', CAST(N'2023-02-14' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (53, CAST(N'2023-02-15 00:00:00.000' AS DateTime), CAST(N'2023-02-15 00:00:00.000' AS DateTime), N'15-02-2023', CAST(N'2023-02-15' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (54, CAST(N'2023-02-16 00:00:00.000' AS DateTime), CAST(N'2023-02-16 00:00:00.000' AS DateTime), N'16-02-2023', CAST(N'2023-02-16' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (55, CAST(N'2023-02-17 00:00:00.000' AS DateTime), CAST(N'2023-02-17 00:00:00.000' AS DateTime), N'17-02-2023', CAST(N'2023-02-17' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (56, CAST(N'2023-02-18 00:00:00.000' AS DateTime), CAST(N'2023-02-18 00:00:00.000' AS DateTime), N'18-02-2023', CAST(N'2023-02-18' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (57, CAST(N'2023-02-19 00:00:00.000' AS DateTime), CAST(N'2023-02-19 00:00:00.000' AS DateTime), N'19-02-2023', CAST(N'2023-02-19' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (58, CAST(N'2023-02-20 00:00:00.000' AS DateTime), CAST(N'2023-02-20 00:00:00.000' AS DateTime), N'20-02-2023', CAST(N'2023-02-20' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (59, CAST(N'2023-03-01 00:00:00.000' AS DateTime), CAST(N'2023-03-01 00:00:00.000' AS DateTime), N'01-03-2023', CAST(N'2023-03-01' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (60, CAST(N'2023-03-02 00:00:00.000' AS DateTime), CAST(N'2023-03-02 00:00:00.000' AS DateTime), N'02-03-2023', CAST(N'2023-03-02' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (61, CAST(N'2023-03-03 00:00:00.000' AS DateTime), CAST(N'2023-03-03 00:00:00.000' AS DateTime), N'03-03-2023', CAST(N'2023-03-03' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (62, CAST(N'2023-03-04 00:00:00.000' AS DateTime), CAST(N'2023-03-04 00:00:00.000' AS DateTime), N'04-03-2023', CAST(N'2023-03-04' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (63, CAST(N'2023-03-05 00:00:00.000' AS DateTime), CAST(N'2023-03-05 00:00:00.000' AS DateTime), N'05-03-2023', CAST(N'2023-03-05' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (64, CAST(N'2023-03-06 00:00:00.000' AS DateTime), CAST(N'2023-03-06 00:00:00.000' AS DateTime), N'06-03-2023', CAST(N'2023-03-06' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (65, CAST(N'2023-03-07 00:00:00.000' AS DateTime), CAST(N'2023-03-07 00:00:00.000' AS DateTime), N'07-03-2023', CAST(N'2023-03-07' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (66, CAST(N'2023-03-08 00:00:00.000' AS DateTime), CAST(N'2023-03-08 00:00:00.000' AS DateTime), N'08-03-2023', CAST(N'2023-03-08' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (67, CAST(N'2023-03-09 00:00:00.000' AS DateTime), CAST(N'2023-03-09 00:00:00.000' AS DateTime), N'09-03-2023', CAST(N'2023-03-09' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (68, CAST(N'2023-03-10 00:00:00.000' AS DateTime), CAST(N'2023-03-10 00:00:00.000' AS DateTime), N'10-03-2023', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (69, CAST(N'2023-03-11 00:00:00.000' AS DateTime), CAST(N'2023-03-11 00:00:00.000' AS DateTime), N'11-03-2023', CAST(N'2023-03-11' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (70, CAST(N'2023-03-12 00:00:00.000' AS DateTime), CAST(N'2023-03-12 00:00:00.000' AS DateTime), N'12-03-2023', CAST(N'2023-03-12' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (71, CAST(N'2023-03-13 00:00:00.000' AS DateTime), CAST(N'2023-03-13 00:00:00.000' AS DateTime), N'13-03-2023', CAST(N'2023-03-13' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (72, CAST(N'2023-03-14 00:00:00.000' AS DateTime), CAST(N'2023-03-14 00:00:00.000' AS DateTime), N'14-03-2023', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (73, CAST(N'2023-03-15 00:00:00.000' AS DateTime), CAST(N'2023-03-15 00:00:00.000' AS DateTime), N'15-03-2023', CAST(N'2023-03-15' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (74, CAST(N'2023-03-16 00:00:00.000' AS DateTime), CAST(N'2023-03-16 00:00:00.000' AS DateTime), N'16-03-2023', CAST(N'2023-03-16' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (75, CAST(N'2023-03-17 00:00:00.000' AS DateTime), CAST(N'2023-03-17 00:00:00.000' AS DateTime), N'17-03-2023', CAST(N'2023-03-17' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (76, CAST(N'2023-03-18 00:00:00.000' AS DateTime), CAST(N'2023-03-18 00:00:00.000' AS DateTime), N'18-03-2023', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (77, CAST(N'2023-03-19 00:00:00.000' AS DateTime), CAST(N'2023-03-19 00:00:00.000' AS DateTime), N'19-03-2023', CAST(N'2023-03-19' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (78, CAST(N'2023-03-20 00:00:00.000' AS DateTime), CAST(N'2023-03-20 00:00:00.000' AS DateTime), N'20-03-2023', CAST(N'2023-03-20' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (79, CAST(N'2023-04-01 00:00:00.000' AS DateTime), CAST(N'2023-04-01 00:00:00.000' AS DateTime), N'01-04-2023', CAST(N'2023-04-01' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (80, CAST(N'2023-04-02 00:00:00.000' AS DateTime), CAST(N'2023-04-02 00:00:00.000' AS DateTime), N'02-04-2023', CAST(N'2023-04-02' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (81, CAST(N'2023-04-03 00:00:00.000' AS DateTime), CAST(N'2023-04-03 00:00:00.000' AS DateTime), N'03-04-2023', CAST(N'2023-04-03' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (82, CAST(N'2023-04-04 00:00:00.000' AS DateTime), CAST(N'2023-04-04 00:00:00.000' AS DateTime), N'04-04-2023', CAST(N'2023-04-04' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (83, CAST(N'2023-04-05 00:00:00.000' AS DateTime), CAST(N'2023-04-05 00:00:00.000' AS DateTime), N'05-04-2023', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (84, CAST(N'2023-04-06 00:00:00.000' AS DateTime), CAST(N'2023-04-06 00:00:00.000' AS DateTime), N'06-04-2023', CAST(N'2023-04-06' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (85, CAST(N'2023-04-07 00:00:00.000' AS DateTime), CAST(N'2023-04-07 00:00:00.000' AS DateTime), N'07-04-2023', CAST(N'2023-04-07' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (86, CAST(N'2023-04-08 00:00:00.000' AS DateTime), CAST(N'2023-04-08 00:00:00.000' AS DateTime), N'08-04-2023', CAST(N'2023-04-08' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (87, CAST(N'2023-04-09 00:00:00.000' AS DateTime), CAST(N'2023-04-09 00:00:00.000' AS DateTime), N'09-04-2023', CAST(N'2023-04-09' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (88, CAST(N'2023-04-10 00:00:00.000' AS DateTime), CAST(N'2023-04-10 00:00:00.000' AS DateTime), N'10-04-2023', CAST(N'2023-04-10' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (89, CAST(N'2023-04-11 00:00:00.000' AS DateTime), CAST(N'2023-04-11 00:00:00.000' AS DateTime), N'11-04-2023', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (90, CAST(N'2023-04-12 00:00:00.000' AS DateTime), CAST(N'2023-04-12 00:00:00.000' AS DateTime), N'12-04-2023', CAST(N'2023-04-12' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (91, CAST(N'2023-04-13 00:00:00.000' AS DateTime), CAST(N'2023-04-13 00:00:00.000' AS DateTime), N'13-04-2023', CAST(N'2023-04-13' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (92, CAST(N'2023-04-14 00:00:00.000' AS DateTime), CAST(N'2023-04-14 00:00:00.000' AS DateTime), N'14-04-2023', CAST(N'2023-04-14' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (93, CAST(N'2023-04-15 00:00:00.000' AS DateTime), CAST(N'2023-04-15 00:00:00.000' AS DateTime), N'15-04-2023', CAST(N'2023-04-15' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (94, CAST(N'2023-04-16 00:00:00.000' AS DateTime), CAST(N'2023-04-16 00:00:00.000' AS DateTime), N'16-04-2023', CAST(N'2023-04-16' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (95, CAST(N'2023-04-17 00:00:00.000' AS DateTime), CAST(N'2023-04-17 00:00:00.000' AS DateTime), N'17-04-2023', CAST(N'2023-04-17' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (96, CAST(N'2023-04-18 00:00:00.000' AS DateTime), CAST(N'2023-04-18 00:00:00.000' AS DateTime), N'18-04-2023', CAST(N'2023-04-18' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (97, CAST(N'2023-04-19 00:00:00.000' AS DateTime), CAST(N'2023-04-19 00:00:00.000' AS DateTime), N'19-04-2023', CAST(N'2023-04-19' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (98, CAST(N'2023-04-20 00:00:00.000' AS DateTime), CAST(N'2023-04-20 00:00:00.000' AS DateTime), N'20-04-2023', CAST(N'2023-04-20' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (99, CAST(N'2023-05-01 00:00:00.000' AS DateTime), CAST(N'2023-05-01 00:00:00.000' AS DateTime), N'01-05-2023', CAST(N'2023-05-01' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (100, CAST(N'2023-05-02 00:00:00.000' AS DateTime), CAST(N'2023-05-02 00:00:00.000' AS DateTime), N'02-05-2023', CAST(N'2023-05-02' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (101, CAST(N'2023-05-03 00:00:00.000' AS DateTime), CAST(N'2023-05-03 00:00:00.000' AS DateTime), N'03-05-2023', CAST(N'2023-05-03' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (102, CAST(N'2023-05-04 00:00:00.000' AS DateTime), CAST(N'2023-05-04 00:00:00.000' AS DateTime), N'04-05-2023', CAST(N'2023-05-04' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (103, CAST(N'2023-05-05 00:00:00.000' AS DateTime), CAST(N'2023-05-05 00:00:00.000' AS DateTime), N'05-05-2023', CAST(N'2023-05-05' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (104, CAST(N'2023-05-06 00:00:00.000' AS DateTime), CAST(N'2023-05-06 00:00:00.000' AS DateTime), N'06-05-2023', CAST(N'2023-05-06' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (105, CAST(N'2023-05-07 00:00:00.000' AS DateTime), CAST(N'2023-05-07 00:00:00.000' AS DateTime), N'07-05-2023', CAST(N'2023-05-07' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (106, CAST(N'2023-05-08 00:00:00.000' AS DateTime), CAST(N'2023-05-08 00:00:00.000' AS DateTime), N'08-05-2023', CAST(N'2023-05-08' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (107, CAST(N'2023-05-09 00:00:00.000' AS DateTime), CAST(N'2023-05-09 00:00:00.000' AS DateTime), N'09-05-2023', CAST(N'2023-05-09' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (108, CAST(N'2023-05-10 00:00:00.000' AS DateTime), CAST(N'2023-05-10 00:00:00.000' AS DateTime), N'10-05-2023', CAST(N'2023-05-10' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (109, CAST(N'2023-05-11 00:00:00.000' AS DateTime), CAST(N'2023-05-11 00:00:00.000' AS DateTime), N'11-05-2023', CAST(N'2023-05-11' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (110, CAST(N'2023-05-12 00:00:00.000' AS DateTime), CAST(N'2023-05-12 00:00:00.000' AS DateTime), N'12-05-2023', CAST(N'2023-05-12' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (111, CAST(N'2023-05-13 00:00:00.000' AS DateTime), CAST(N'2023-05-13 00:00:00.000' AS DateTime), N'13-05-2023', CAST(N'2023-05-13' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (112, CAST(N'2023-05-14 00:00:00.000' AS DateTime), CAST(N'2023-05-14 00:00:00.000' AS DateTime), N'14-05-2023', CAST(N'2023-05-14' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (113, CAST(N'2023-05-15 00:00:00.000' AS DateTime), CAST(N'2023-05-15 00:00:00.000' AS DateTime), N'15-05-2023', CAST(N'2023-05-15' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (114, CAST(N'2023-05-16 00:00:00.000' AS DateTime), CAST(N'2023-05-16 00:00:00.000' AS DateTime), N'16-05-2023', CAST(N'2023-05-16' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (115, CAST(N'2023-05-17 00:00:00.000' AS DateTime), CAST(N'2023-05-17 00:00:00.000' AS DateTime), N'17-05-2023', CAST(N'2023-05-17' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (116, CAST(N'2023-05-18 00:00:00.000' AS DateTime), CAST(N'2023-05-18 00:00:00.000' AS DateTime), N'18-05-2023', CAST(N'2023-05-18' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (117, CAST(N'2023-05-19 00:00:00.000' AS DateTime), CAST(N'2023-05-19 00:00:00.000' AS DateTime), N'19-05-2023', CAST(N'2023-05-19' AS Date))
GO
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (118, CAST(N'2023-05-20 00:00:00.000' AS DateTime), CAST(N'2023-05-20 00:00:00.000' AS DateTime), N'20-05-2023', CAST(N'2023-05-20' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (119, CAST(N'2023-03-31 10:55:37.120' AS DateTime), CAST(N'2023-03-31 10:55:37.120' AS DateTime), N'31-03-2023', CAST(N'2023-03-31' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (120, CAST(N'2023-03-31 10:55:37.910' AS DateTime), CAST(N'2023-03-31 10:55:37.910' AS DateTime), N'31-03-2023', CAST(N'2023-03-31' AS Date))
INSERT [dbo].[NgayChamCong] ([Id], [ThoiGianChamCong], [ThoiGianRaVe], [Ten], [Date]) VALUES (121, CAST(N'2023-03-31 10:55:40.590' AS DateTime), CAST(N'2023-03-31 10:55:40.590' AS DateTime), N'31-03-2023', CAST(N'2023-03-31' AS Date))
SET IDENTITY_INSERT [dbo].[NgayChamCong] OFF
SET IDENTITY_INSERT [dbo].[NghiPhep] ON 

INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai], [HinhThucNghi]) VALUES (9, 1, N'gfg', 1, CAST(N'2023-03-30 10:31:46.383' AS DateTime), CAST(N'2023-03-30' AS Date), 3, 2, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai], [HinhThucNghi]) VALUES (1009, 1, N'hjh', 1, CAST(N'2023-03-31 10:56:28.513' AS DateTime), CAST(N'2023-03-28' AS Date), 2, 2, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai], [HinhThucNghi]) VALUES (1010, 1, N'hjh', 1, CAST(N'2023-03-31 10:58:23.010' AS DateTime), CAST(N'2023-03-27' AS Date), 2, 2, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai], [HinhThucNghi]) VALUES (1011, 1, N'e', 1, CAST(N'2023-03-31 11:01:07.263' AS DateTime), CAST(N'2023-03-21' AS Date), 3, 2, 1)
INSERT [dbo].[NghiPhep] ([Id], [NhanVienId], [LyDo], [NguoiPheDuyetId], [ThoiGianTao], [TaoChoNgay], [LoaiNghi], [TrangThai], [HinhThucNghi]) VALUES (1012, 1, N'23', 1, CAST(N'2023-03-31 11:02:36.247' AS DateTime), CAST(N'2023-03-23' AS Date), 2, 2, 2)
SET IDENTITY_INSERT [dbo].[NghiPhep] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([Id], [HoVaTen], [SoDienThoai], [DiaChi], [SinhNhat], [HeSoLuong], [NgayNghiPhep], [SoNgayDaNghi], [TaiKhoan], [MatKhau], [LuongCoBan]) VALUES (1, N'Phan Thành Quyết', N'0949660502', N'Hồng Thuận Nam Định', CAST(N'2023-03-20' AS Date), 2.3, 12, 12, N'admin', N'123', CAST(51000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([Id], [HoVaTen], [SoDienThoai], [DiaChi], [SinhNhat], [HeSoLuong], [NgayNghiPhep], [SoNgayDaNghi], [TaiKhoan], [MatKhau], [LuongCoBan]) VALUES (6, N'Quyết', N'0949660403', N'Hà nội', CAST(N'2023-03-21' AS Date), 1, NULL, NULL, NULL, NULL, CAST(610000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([Id], [HoVaTen], [SoDienThoai], [DiaChi], [SinhNhat], [HeSoLuong], [NgayNghiPhep], [SoNgayDaNghi], [TaiKhoan], [MatKhau], [LuongCoBan]) VALUES (7, N'Quất', NULL, NULL, NULL, 1, NULL, NULL, N'quat', N'123', NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (1, 2)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (1, 3)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (1, 4)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (7, 2)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (7, 3)
INSERT [dbo].[NhanVien_Quyen] ([NhanVienId], [QuyenId]) VALUES (7, 4)
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