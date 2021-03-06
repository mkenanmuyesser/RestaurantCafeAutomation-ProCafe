USE [master]
GO
/****** Object:  Database [ProCafeDB]    Script Date: 13.07.2022 10:56:15 ******/
CREATE DATABASE [ProCafeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB130920134344Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ProCafeDB.mdf' , SIZE = 4096KB , MAXSIZE = 102400KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB130920134344Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ProCafeDB_1.ldf' , SIZE = 3456KB , MAXSIZE = 51200KB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProCafeDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProCafeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProCafeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProCafeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProCafeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProCafeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProCafeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProCafeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProCafeDB] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [ProCafeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProCafeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProCafeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProCafeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProCafeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProCafeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProCafeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProCafeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProCafeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProCafeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProCafeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProCafeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProCafeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProCafeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProCafeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProCafeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProCafeDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProCafeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProCafeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProCafeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProCafeDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProCafeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProCafeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProCafeDB', N'ON'
GO
ALTER DATABASE [ProCafeDB] SET QUERY_STORE = OFF
GO
USE [ProCafeDB]
GO
/****** Object:  User [USR130920134344]    Script Date: 13.07.2022 10:56:15 ******/
CREATE USER [USR130920134344] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR130920134344]
GO
/****** Object:  Table [dbo].[A_Siparis_Opsiyon]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Siparis_Opsiyon](
	[SiparisOpsiyon] [int] IDENTITY(1,1) NOT NULL,
	[SiparisKey] [int] NOT NULL,
	[UrunOpsiyonTurKey] [int] NOT NULL,
 CONSTRAINT [PK_A_Siparis_Opsiyon] PRIMARY KEY CLUSTERED 
(
	[SiparisOpsiyon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_Siparis_Urun]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Siparis_Urun](
	[SiparisUrunKey] [int] IDENTITY(1,1) NOT NULL,
	[SiparisKey] [int] NOT NULL,
	[UrunKey] [int] NOT NULL,
	[SiparisParca] [bit] NOT NULL,
	[SiparisOnay] [bit] NOT NULL,
	[SiparisMutfakTeslim] [bit] NOT NULL,
 CONSTRAINT [PK_A_Siparis_Urun] PRIMARY KEY CLUSTERED 
(
	[SiparisUrunKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_Urun_Opsiyon]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Urun_Opsiyon](
	[UrunOpsiyonKey] [int] IDENTITY(1,1) NOT NULL,
	[UrunKey] [int] NULL,
	[OpsiyonKey] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[UrunOpsiyonKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genel_Ayar]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genel_Ayar](
	[GenelAyarKey] [int] IDENTITY(1,1) NOT NULL,
	[GenelSirketAd] [nvarchar](50) NULL,
	[GenelFaturaBilgi] [nvarchar](500) NULL,
	[GenelFaturaMesaj] [nvarchar](500) NULL,
	[GenelSirketLogo] [image] NULL,
	[GenelMutfakKullanimi] [bit] NOT NULL,
	[GenelKdvDahil] [bit] NOT NULL,
	[GenelIndirimOran] [tinyint] NOT NULL,
	[GenelDefaultResim] [image] NOT NULL,
 CONSTRAINT [PK_GenelAyar] PRIMARY KEY CLUSTERED 
(
	[GenelAyarKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciKey] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciTurKey] [int] NULL,
	[KullaniciKullaniciAd] [nvarchar](20) NULL,
	[KullaniciKullaniciParola] [nvarchar](20) NULL,
	[KullaniciAd] [nvarchar](20) NULL,
	[KullaniciSoyad] [nvarchar](20) NULL,
	[KullaniciTcNo] [char](11) NULL,
	[KullaniciSgkNo] [nvarchar](20) NULL,
	[KullaniciIseBaslamaTarihi] [date] NOT NULL,
	[KullaniciSiparisIptalYetki] [bit] NOT NULL,
	[KullaniciUcretsizSatisYetki] [bit] NOT NULL,
	[KullaniciSabit] [bit] NOT NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici_Giris_Yetki]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici_Giris_Yetki](
	[KullaniciGirisYetkiKey] [int] NOT NULL,
	[KullaniciGirisYetkiMasaSiparisYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiPaketSiparisYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiRezervasyonYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiMusterilerYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiMutfakYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiKasaIslemleriYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiRaporlarYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiStokTakibiYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiAyarlarYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiTanimlamalarYetki] [bit] NOT NULL,
	[KullaniciGirisYetkiNotlarHatirlatmalarYetki] [bit] NOT NULL,
 CONSTRAINT [PK_Kullanici_Giris_Yetki] PRIMARY KEY CLUSTERED 
(
	[KullaniciGirisYetkiKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogIslemleri]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogIslemleri](
	[LogKey] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciKey] [int] NULL,
	[IslemTarih] [datetime] NOT NULL,
	[YapilanIslem] [char](1) NOT NULL,
	[IslemIcerik] [xml] NULL,
 CONSTRAINT [PK_LogIslemleri] PRIMARY KEY CLUSTERED 
(
	[LogKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Masa]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masa](
	[MasaKey] [int] IDENTITY(1,1) NOT NULL,
	[MasaKatBolgeKey] [int] NULL,
	[MasaNo] [nvarchar](10) NULL,
	[MasaKisi] [int] NOT NULL,
	[MasaAciklama] [nvarchar](100) NULL,
	[MasaAcik] [bit] NOT NULL,
	[MasaAktif] [bit] NOT NULL,
	[MasaSira] [tinyint] NOT NULL,
 CONSTRAINT [PK_Masa] PRIMARY KEY CLUSTERED 
(
	[MasaKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriKey] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAd] [nvarchar](50) NULL,
	[MusteriSoyad] [nvarchar](50) NULL,
	[MusteriUnvan] [nvarchar](50) NULL,
	[MusteriTarih] [date] NOT NULL,
	[MusteriTelefon] [nvarchar](20) NULL,
	[MusteriAciklama] [nvarchar](500) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezervasyon_Not_Hatirlatma]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervasyon_Not_Hatirlatma](
	[RezervasyonNotHatirlatmaKey] [int] IDENTITY(1,1) NOT NULL,
	[MasaKey] [int] NULL,
	[RezervasyonNotHatirlatmaTip] [bit] NOT NULL,
	[RezervasyonNotHatirlatmaTarihSaat] [datetime] NOT NULL,
	[RezervasyonNotHatirlatmaAciklama] [nvarchar](500) NULL,
 CONSTRAINT [PK_Rezervasyon] PRIMARY KEY CLUSTERED 
(
	[RezervasyonNotHatirlatmaKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[SiparisKey] [int] IDENTITY(1,1) NOT NULL,
	[MasaKey] [int] NULL,
	[SiparisiAlanKullaniciKey] [int] NULL,
	[MutfakOnayKullaniciKey] [int] NULL,
	[KasaOdemeKullaniciKey] [int] NULL,
	[MusteriKey] [int] NULL,
	[SiparisAlindiTarih] [datetime] NOT NULL,
	[SiparisMutfakOnayTarih] [datetime] NULL,
	[SiparisHesapKapatildiTarih] [datetime] NULL,
	[SiparisToplam] [decimal](18, 2) NOT NULL,
	[SiparisOdenen] [decimal](18, 2) NOT NULL,
	[SiparisAd] [nvarchar](50) NULL,
	[SiparisSoyad] [nvarchar](50) NULL,
	[SiparisTelefon] [nvarchar](20) NULL,
	[SiparisAdres] [nvarchar](100) NULL,
	[SiparisAciklama] [nvarchar](500) NULL,
	[SiparisYazildi] [bit] NOT NULL,
	[SiparisIptal] [bit] NOT NULL,
	[SiparisUcretsizKapatma] [bit] NOT NULL,
	[SiparisParcali] [bit] NOT NULL,
 CONSTRAINT [PK_Siparis_Satis] PRIMARY KEY CLUSTERED 
(
	[SiparisKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Kullanici_Tur]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Kullanici_Tur](
	[KullaniciTurKey] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciTurAd] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_KullaniciTur] PRIMARY KEY CLUSTERED 
(
	[KullaniciTurKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Masa_Kat_Bolge_Tur]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Masa_Kat_Bolge_Tur](
	[MasaKatBolgeKey] [int] IDENTITY(1,1) NOT NULL,
	[MasaKatBolgeAd] [nvarchar](20) NULL,
 CONSTRAINT [PK_Kat_Bolge] PRIMARY KEY CLUSTERED 
(
	[MasaKatBolgeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Urun_Kategori_Tur]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Urun_Kategori_Tur](
	[UrunKategoriTurKey] [int] IDENTITY(1,1) NOT NULL,
	[UrunKategoriTurAd] [nvarchar](20) NULL,
	[UrunKategoriResim] [image] NULL,
	[UrunKategoriTurSiralama] [int] NOT NULL,
 CONSTRAINT [PK_T_UrunTur] PRIMARY KEY CLUSTERED 
(
	[UrunKategoriTurKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Urun_Opsiyon_Tur]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Urun_Opsiyon_Tur](
	[UrunOpsiyonTurKey] [int] IDENTITY(1,1) NOT NULL,
	[UrunOpsiyonAd] [nvarchar](20) NULL,
 CONSTRAINT [PK_T_Urun_Opsiyon_Tur] PRIMARY KEY CLUSTERED 
(
	[UrunOpsiyonTurKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 13.07.2022 10:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[UrunKey] [int] IDENTITY(1,1) NOT NULL,
	[UrunKategoriTurKey] [int] NOT NULL,
	[KullaniciTurKey] [int] NULL,
	[UrunAd] [nvarchar](20) NULL,
	[UrunFiyat] [decimal](18, 2) NOT NULL,
	[UrunSiralama] [int] NOT NULL,
	[UrunAciklama] [nvarchar](100) NULL,
	[UrunAktif] [bit] NOT NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[UrunKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[A_Siparis_Opsiyon]  WITH CHECK ADD  CONSTRAINT [FK_A_Siparis_Opsiyon_Siparis] FOREIGN KEY([SiparisKey])
REFERENCES [dbo].[Siparis] ([SiparisKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Siparis_Opsiyon] CHECK CONSTRAINT [FK_A_Siparis_Opsiyon_Siparis]
GO
ALTER TABLE [dbo].[A_Siparis_Opsiyon]  WITH CHECK ADD  CONSTRAINT [FK_A_Siparis_Opsiyon_T_Urun_Opsiyon_Tur] FOREIGN KEY([UrunOpsiyonTurKey])
REFERENCES [dbo].[T_Urun_Opsiyon_Tur] ([UrunOpsiyonTurKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Siparis_Opsiyon] CHECK CONSTRAINT [FK_A_Siparis_Opsiyon_T_Urun_Opsiyon_Tur]
GO
ALTER TABLE [dbo].[A_Siparis_Urun]  WITH CHECK ADD  CONSTRAINT [FK_A_Siparis_Urun_Siparis] FOREIGN KEY([SiparisKey])
REFERENCES [dbo].[Siparis] ([SiparisKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Siparis_Urun] CHECK CONSTRAINT [FK_A_Siparis_Urun_Siparis]
GO
ALTER TABLE [dbo].[A_Siparis_Urun]  WITH CHECK ADD  CONSTRAINT [FK_A_Siparis_Urun_Urun] FOREIGN KEY([UrunKey])
REFERENCES [dbo].[Urun] ([UrunKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Siparis_Urun] CHECK CONSTRAINT [FK_A_Siparis_Urun_Urun]
GO
ALTER TABLE [dbo].[A_Urun_Opsiyon]  WITH CHECK ADD  CONSTRAINT [FK_A_Urun_Opsiyon_T_Urun_Opsiyon_Tur] FOREIGN KEY([OpsiyonKey])
REFERENCES [dbo].[T_Urun_Opsiyon_Tur] ([UrunOpsiyonTurKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Urun_Opsiyon] CHECK CONSTRAINT [FK_A_Urun_Opsiyon_T_Urun_Opsiyon_Tur]
GO
ALTER TABLE [dbo].[A_Urun_Opsiyon]  WITH CHECK ADD  CONSTRAINT [FK_A_Urun_Opsiyon_Urun] FOREIGN KEY([UrunKey])
REFERENCES [dbo].[Urun] ([UrunKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[A_Urun_Opsiyon] CHECK CONSTRAINT [FK_A_Urun_Opsiyon_Urun]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_T_Kullanici_Tur] FOREIGN KEY([KullaniciTurKey])
REFERENCES [dbo].[T_Kullanici_Tur] ([KullaniciTurKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_T_Kullanici_Tur]
GO
ALTER TABLE [dbo].[Kullanici_Giris_Yetki]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Giris_Yetki_Kullanici] FOREIGN KEY([KullaniciGirisYetkiKey])
REFERENCES [dbo].[Kullanici] ([KullaniciKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kullanici_Giris_Yetki] CHECK CONSTRAINT [FK_Kullanici_Giris_Yetki_Kullanici]
GO
ALTER TABLE [dbo].[Masa]  WITH CHECK ADD  CONSTRAINT [FK_Masa_T_Masa_Kat_Bolge_Tur] FOREIGN KEY([MasaKatBolgeKey])
REFERENCES [dbo].[T_Masa_Kat_Bolge_Tur] ([MasaKatBolgeKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Masa] CHECK CONSTRAINT [FK_Masa_T_Masa_Kat_Bolge_Tur]
GO
ALTER TABLE [dbo].[Rezervasyon_Not_Hatirlatma]  WITH CHECK ADD  CONSTRAINT [FK_Rezervasyon_Masa] FOREIGN KEY([MasaKey])
REFERENCES [dbo].[Masa] ([MasaKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rezervasyon_Not_Hatirlatma] CHECK CONSTRAINT [FK_Rezervasyon_Masa]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Kullanici] FOREIGN KEY([SiparisiAlanKullaniciKey])
REFERENCES [dbo].[Kullanici] ([KullaniciKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Kullanici]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Kullanici1] FOREIGN KEY([MutfakOnayKullaniciKey])
REFERENCES [dbo].[Kullanici] ([KullaniciKey])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Kullanici1]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Kullanici2] FOREIGN KEY([KasaOdemeKullaniciKey])
REFERENCES [dbo].[Kullanici] ([KullaniciKey])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Kullanici2]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Musteri] FOREIGN KEY([MusteriKey])
REFERENCES [dbo].[Musteri] ([MusteriKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Musteri]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Satis_Masa] FOREIGN KEY([MasaKey])
REFERENCES [dbo].[Masa] ([MasaKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Satis_Masa]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_T_Kullanici_Tur] FOREIGN KEY([KullaniciTurKey])
REFERENCES [dbo].[T_Kullanici_Tur] ([KullaniciTurKey])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_T_Kullanici_Tur]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_T_Urun_Kategori_Tur] FOREIGN KEY([UrunKategoriTurKey])
REFERENCES [dbo].[T_Urun_Kategori_Tur] ([UrunKategoriTurKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_T_Urun_Kategori_Tur]
GO
USE [master]
GO
ALTER DATABASE [ProCafeDB] SET  READ_WRITE 
GO
