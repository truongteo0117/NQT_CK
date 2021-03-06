USE [master]
GO
/****** Object:  Database [giaodichchungkhoan]    Script Date: 5/20/2021 9:54:45 PM ******/
CREATE DATABASE [giaodichchungkhoan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'giaodichchungkhoan', FILENAME = N'E:\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\giaodichchungkhoan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'giaodichchungkhoan_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\giaodichchungkhoan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [giaodichchungkhoan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [giaodichchungkhoan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET ARITHABORT OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [giaodichchungkhoan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [giaodichchungkhoan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [giaodichchungkhoan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [giaodichchungkhoan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [giaodichchungkhoan] SET  MULTI_USER 
GO
ALTER DATABASE [giaodichchungkhoan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [giaodichchungkhoan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [giaodichchungkhoan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [giaodichchungkhoan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [giaodichchungkhoan]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/20/2021 9:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cophieu]    Script Date: 5/20/2021 9:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cophieu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[mck] [nchar](10) NULL,
	[coPhieu] [nvarchar](max) NULL,
	[coPhieuLP] [nvarchar](max) NULL,
 CONSTRAINT [PK_cophieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giaodich]    Script Date: 5/20/2021 9:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giaodich](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mSan] [nchar](10) NULL,
	[mck] [nchar](10) NULL,
	[mUser] [int] NOT NULL,
	[lenh] [nvarchar](50) NULL,
	[soCoPhieu] [nvarchar](50) NULL,
	[soTien] [nvarchar](max) NULL,
	[trangThai] [nchar](10) NULL,
	[thoiGian] [datetime] NULL,
	[phien] [nvarchar](50) NULL,
	[lenhGia] [nchar](10) NULL,
	[khoiluongKhop] [nvarchar](50) NULL,
	[giaKhop] [nvarchar](max) NULL,
 CONSTRAINT [PK_giaodich] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giaodiches]    Script Date: 5/20/2021 9:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giaodiches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mSan] [nvarchar](max) NULL,
	[mck] [nvarchar](max) NULL,
	[mUser] [int] NOT NULL,
	[lenh] [nvarchar](max) NULL,
	[soCoPhieu] [nvarchar](max) NULL,
	[soTien] [nvarchar](max) NULL,
	[trangThai] [nvarchar](max) NULL,
	[thoiGian] [datetime] NOT NULL,
	[phien] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.giaodiches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoidung]    Script Date: 5/20/2021 9:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoidung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[tien] [nvarchar](max) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[san_HNX]    Script Date: 5/20/2021 9:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[san_HNX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mck] [ntext] NULL,
	[tc] [float] NULL,
	[giaTran] [float] NULL,
	[giaSan] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[san_HOSE]    Script Date: 5/20/2021 9:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[san_HOSE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mck] [ntext] NULL,
	[tc] [float] NULL,
	[giaTran] [float] NULL,
	[giaSan] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanhnx]    Script Date: 5/20/2021 9:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanhnx](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mck] [nchar](10) NULL,
	[tc] [float] NULL,
	[giaTran] [float] NULL,
	[giaSan] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanhose]    Script Date: 5/20/2021 9:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanhose](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mck] [nchar](10) NULL,
	[tc] [float] NULL,
	[giaTran] [float] NULL,
	[giaSan] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 5/20/2021 9:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[tien] [nvarchar](max) NULL,
	[cophieu] [nvarchar](max) NULL,
	[giaodich_id] [int] NULL,
 CONSTRAINT [PK_dbo.users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202104300757423_InitialCreate', N'GiaoDichChungKhoan.ViewModel.Context', 0x1F8B0800000000000400ED5ACD6EE33610BE17E83B083AB545D672B29736B077B1759285D1CD0F22EFA2B705238D6D62295215A9D446D127EBA18FD457E8507FA628D996E2382D8A22179BE47C9C197E331C8EF3D71F7F8EDEAE22E63C4222A9E063F77430741DE08108295F8CDD54CD5F7DEFBE7DF3F557A3CB305A399FCA75AFF53A94E472EC2E958ACF3D4F064B88881C443448841473350844E491507867C3E10FDEE9A90708E12296E38CEE53AE6804D917FC3A113C8058A5845D8B10982CC671C6CF509D1B12818C490063F73D25E28206CBC932E58B9F9682F0C1270ABF6682AEF38E51823AF9C0E6AE4338178A28D4F8FCA3045F25822FFC1807089BAD63C07573C22414969C6F9677356A78A68DF236822554904A25A29E80A7AF0B2F79B6F8937CED565E443F5EA2BFD55A5B9DF972EC2ED08D21BAD175ECCDCE272CD10B5B5D9DB979500A9F38CD2527154B904CFAEFC499A44CA5098C39A42A21ECC4B94B1F180D7E82F54C7C013EE62963A6B6A82FCED50670E82E1131246A7D0FF3C2061ABA8E5797F36CC14ACC90C9AD9B72F5FACC756E7073F2C0A02283E1095F8904DE0387842808EF885290E0594E43C8DCD9D8DDDA2BF2092F7743F66148B9CE35597D00BE50CBB18B1F5DE78AAE202C470A0D3E728A1188422A4961EF26C197E3EF81E193ECF3DB6E08067C79743DA59888BB2585F405769A5138FEE162B8F0C56C49E8F1775A0A8AC15C9974818C9F618AEE7DD0F1F2288EB9218F749145A5B59FA6A6749D7B60D9AC5CD238CFFF5596FA5C2CB94A44742F9891FCF299CFBE489300B79C89D6E9194916A0EA1A8DBC4D46DD9967D32C729E9063B5E0FFF975E75E9C687E1E3B305E22CE03111F216D6D23E93B294540B323B0AA812254EABA5EF2D0D91D37B9D266CCA1EE484A1A230D5181B13B1C0C4E1B4ED80A5C469C019CC7511DF43BDB5CC3B066506291A90845AE1536EBEFB0522DC1894A14F1290BB7DA7A6B3C1F94814402852966E3EF863F1AB6D7312E2342591B426EB8256D18BA81B0F39DB1A83D23DA1960EF41574A9B367B9D61CA6335604AB3ED345337B085D3D5696EDE0A5EFE58281F15DE9657C5E89AC4318697F1CA28461C3F7F624C5EF9FD2BEE28C7F002D9527857DA563B61E6230BB066B55B43B8A2895478FF9207A2037C12462DCB72EE6EE154B98B45CFE641955C2B05F4E75C68D7336BC36A0B71E3CA2BB42EC22C9E190AC6816F17CD5E7B8491A4E546990896467CDBADB44B3AAFC14DF97CA407822EB06B007AA0877C5E3CD7103EB604F52E8CBC7A3621F291EE0846696CC218C37DB0F2E2B70E948F7547316A5B13C818EE815555AF35A86AB43B5251BE9A30C5501363E4596CB703CC6B449895E6EC88ED14CF45CE7CB668CE6E98FE91DC2E769C28CE2B3D533E1FE9C190C6B1AA9E7CAD6A3413A41A7C7976D4AFC83A45EC52A0675E2FC5BA1CB9BEEE2D4FB5570F4D0775224A05D6C618EDA36AF7DE8A15F5C81315EBAD0FDEC321CD8AEEA9D4AFA2AA84EF68AE5D153559D1288EEC251527AB22C92A86464561B2BF0FDBA854F225AE83E63FD2505729FE5A2A88067AC1C0FF854D18469CDA2CB8269CCE41AAFC91EA9E0D4FCFAC06EEBFA799EA4919B28E1DD5177F6953EDD5BD6FE99E7D1CB379C91F49122C49F24D4456DF9A483D1B9487E1984DC8CCE4035A900769D268331E8866B6120F826AB40B0F43B35A8221124B1DDC12ECA152BF26DB7F23ECCC9ED661A7F75CA4B27A530761D56E37C38B8D16CC9487B01ABBBF6572E7CEF4E7CF86E889739BE0FD71EE0C9DDF9FC6A0833B60CFD1F44A8D7CD6B5C7A57F3B8539249A5D84E13D2F31E669B3B6BC4B280F684C98AD77B3D8E91216DA9315A43D73013170CD77D3AE2EFBEC29ED2A5C2B42F739A0771FD06EB9ECEED46D4E7B47B72F2F8630673E083CE29C9EE52C34FB5DF61E3913B6F402DBB0D3BC60FF87DA84B596DEB696670BF7EDA7C551DA80CD8A162964FCFF01F257D2C50642D7E91C821A79AA35533E1725912D8DCA2556CABB0645F0E624EF1245E72450381D8094597FFF136169F6A07F8070CA6F5315A70A4D86E881D57EFCD0B1B06BFFACD759D779741B673F873D8709A826D597FF2DFF31A52CACF4BE6A5E68DB20749015B7A43E4BA56FCBC5BA42BA11BC2350E1BE2A37CC208A1982C95BEE9347788A6EC8F20FB020C1BA7C986C07D97F1075B78F2E285924249205C6461EBF2287C368F5E66FBEF1865486230000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[cophieu] ON 

INSERT [dbo].[cophieu] ([id], [id_user], [mck], [coPhieu], [coPhieuLP]) VALUES (1, 2, N'AAV       ', N'18000', N'1000')
INSERT [dbo].[cophieu] ([id], [id_user], [mck], [coPhieu], [coPhieuLP]) VALUES (2, 2, N'BXH       ', N'1000', NULL)
INSERT [dbo].[cophieu] ([id], [id_user], [mck], [coPhieu], [coPhieuLP]) VALUES (4, 1, N'AAA       ', N'19090', N'900')
INSERT [dbo].[cophieu] ([id], [id_user], [mck], [coPhieu], [coPhieuLP]) VALUES (5, 1, N'ADS       ', N'34700', N'5000')
INSERT [dbo].[cophieu] ([id], [id_user], [mck], [coPhieu], [coPhieuLP]) VALUES (6, 1, N'BXH       ', N'16700', N'100')
SET IDENTITY_INSERT [dbo].[cophieu] OFF
GO
SET IDENTITY_INSERT [dbo].[giaodich] ON 

INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2126, N'HOSE      ', N'ADS       ', 1, N'Bán', N'5000', N'17000', N'Đã Nhận   ', CAST(N'2021-05-17T04:15:03.133' AS DateTime), N'Phiên Mở Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2127, N'HOSE      ', N'AMD       ', 1, N'Mua', N'1000', N'7160', N'Đã Nhận   ', CAST(N'2021-05-17T04:15:23.603' AS DateTime), N'Phiên Mở Cửa', N'ATO       ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2128, N'HNX       ', N'AAV       ', 1, N'Mua', N'100', N'16100', N'Đã Nhận   ', CAST(N'2021-05-17T04:15:42.143' AS DateTime), N'Phiên liên tục', N'MAK       ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2129, N'HNX       ', N'BXH       ', 1, N'Bán', N'100', N'10800', N'Đã Nhận   ', CAST(N'2021-05-17T04:16:01.077' AS DateTime), N'Phiên liên tục', N'MOK       ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2130, N'HOSE      ', N'AMD       ', 1, N'Mua', N'100', N'7000', N'Đã Nhận   ', CAST(N'2021-05-17T14:40:11.313' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2131, N'HOSE      ', N'AAA       ', 1, N'Bán', N'100', N'16550', N'Đã Nhận   ', CAST(N'2021-05-17T14:40:45.880' AS DateTime), N'Phiên Đóng Cửa', N'ATC       ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2132, N'HNX       ', N'BXH       ', 1, N'Bán', N'100', N'13000', N'Đã Nhận   ', CAST(N'2021-05-17T14:41:13.990' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2133, N'HOSE      ', N'AAA       ', 1, N'Bán', N'19900', N'16550', N'Đã Nhận   ', CAST(N'2021-05-17T21:23:12.983' AS DateTime), N'Phiên Đóng Cửa', N'ATC       ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2134, N'HOSE      ', N'AAA       ', 1, N'Mua', N'100', N'16000', N'Đã Nhận   ', CAST(N'2021-05-17T21:36:03.083' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2135, N'HOSE      ', N'AAA       ', 1, N'Bán', N'10', N'14450', N'Đã Nhận   ', CAST(N'2021-05-17T21:37:44.407' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2136, N'HOSE      ', N'ADS       ', 1, N'Mua', N'10', N'17000', N'Đã Nhận   ', CAST(N'2021-05-17T21:38:09.797' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2137, N'HNX       ', N'AAV       ', 1, N'Mua', N'100', N'16000', N'Đã Nhận   ', CAST(N'2021-05-17T21:38:31.367' AS DateTime), N'Phiên Đóng Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2138, N'HNX       ', N'AAV       ', 2, N'Bán', N'1000', N'16000', N'Đã Nhận   ', CAST(N'2021-05-19T00:02:28.157' AS DateTime), N'Phiên liên tục', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2139, N'HOSE      ', N'AMD       ', 2, N'Mua', N'10000', N'7160', N'Đã Nhận   ', CAST(N'2021-05-19T00:03:08.710' AS DateTime), N'Phiên Mở Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2140, N'HOSE      ', N'AAA       ', 3, N'Mua', N'100', N'15000', N'Đã Nhận   ', CAST(N'2021-05-19T00:28:20.190' AS DateTime), N'Phiên Mở Cửa', N'LO        ', N'', N'')
INSERT [dbo].[giaodich] ([id], [mSan], [mck], [mUser], [lenh], [soCoPhieu], [soTien], [trangThai], [thoiGian], [phien], [lenhGia], [khoiluongKhop], [giaKhop]) VALUES (2141, N'HOSE      ', N'AAA       ', 1, N'Bán', N'900', N'16550', N'Đã Nhận   ', CAST(N'2021-05-19T16:14:42.150' AS DateTime), N'Phiên Đóng Cửa', N'ATC       ', N'', N'')
SET IDENTITY_INSERT [dbo].[giaodich] OFF
GO
SET IDENTITY_INSERT [dbo].[nguoidung] ON 

INSERT [dbo].[nguoidung] ([id], [name], [tien]) VALUES (1, N'user1     ', N'58784600')
INSERT [dbo].[nguoidung] ([id], [name], [tien]) VALUES (2, N'user2     ', N'628400000')
INSERT [dbo].[nguoidung] ([id], [name], [tien]) VALUES (3, N'user3     ', N'7500000')
SET IDENTITY_INSERT [dbo].[nguoidung] OFF
GO
SET IDENTITY_INSERT [dbo].[san_HNX] ON 

INSERT [dbo].[san_HNX] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (1, N'AAV', 14.7, 16.1, 13.3)
INSERT [dbo].[san_HNX] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (2, N'ABT', 30, 33, 27)
INSERT [dbo].[san_HNX] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (3, N'BXH', 12, 13.2, 10.8)
SET IDENTITY_INSERT [dbo].[san_HNX] OFF
GO
SET IDENTITY_INSERT [dbo].[san_HOSE] ON 

INSERT [dbo].[san_HOSE] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (1, N'AAA', 15.5, 16.55, 14.45)
INSERT [dbo].[san_HOSE] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (2, N'ADS', 16.55, 17.7, 15.4)
INSERT [dbo].[san_HOSE] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (3, N'AMD', 6.7, 7.16, 6.24)
SET IDENTITY_INSERT [dbo].[san_HOSE] OFF
GO
SET IDENTITY_INSERT [dbo].[sanhnx] ON 

INSERT [dbo].[sanhnx] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (1, N'AAV       ', 14.7, 16.1, 13.3)
INSERT [dbo].[sanhnx] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (2, N'ABT       ', 30, 33, 27)
INSERT [dbo].[sanhnx] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (3, N'BXH       ', 12, 13.2, 10.8)
SET IDENTITY_INSERT [dbo].[sanhnx] OFF
GO
SET IDENTITY_INSERT [dbo].[sanhose] ON 

INSERT [dbo].[sanhose] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (1, N'AAA       ', 15.5, 16.55, 14.45)
INSERT [dbo].[sanhose] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (2, N'ADS       ', 16.55, 17.7, 15.4)
INSERT [dbo].[sanhose] ([id], [mck], [tc], [giaTran], [giaSan]) VALUES (3, N'AMD       ', 6.7, 7.16, 6.24)
SET IDENTITY_INSERT [dbo].[sanhose] OFF
GO
/****** Object:  Index [IX_giaodich]    Script Date: 5/20/2021 9:54:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_giaodich] ON [dbo].[giaodich]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_giaodich_id]    Script Date: 5/20/2021 9:54:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_giaodich_id] ON [dbo].[users]
(
	[giaodich_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cophieu]  WITH CHECK ADD  CONSTRAINT [FK_cophieu_nguoidung] FOREIGN KEY([id_user])
REFERENCES [dbo].[nguoidung] ([id])
GO
ALTER TABLE [dbo].[cophieu] CHECK CONSTRAINT [FK_cophieu_nguoidung]
GO
ALTER TABLE [dbo].[giaodich]  WITH CHECK ADD  CONSTRAINT [FK_giaodich_nguoidung] FOREIGN KEY([mUser])
REFERENCES [dbo].[nguoidung] ([id])
GO
ALTER TABLE [dbo].[giaodich] CHECK CONSTRAINT [FK_giaodich_nguoidung]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.users_dbo.giaodiches_giaodich_id] FOREIGN KEY([giaodich_id])
REFERENCES [dbo].[giaodiches] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_dbo.users_dbo.giaodiches_giaodich_id]
GO
USE [master]
GO
ALTER DATABASE [giaodichchungkhoan] SET  READ_WRITE 
GO
