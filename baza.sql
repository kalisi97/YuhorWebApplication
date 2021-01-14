USE [master]
GO
/****** Object:  Database [Yuhor]    Script Date: 1/14/2021 3:59:20 PM ******/
CREATE DATABASE [Yuhor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Yuhor', FILENAME = N'C:\Users\user\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\Yuhor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Yuhor_log', FILENAME = N'C:\Users\user\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\Yuhor.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Yuhor] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Yuhor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Yuhor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Yuhor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Yuhor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Yuhor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Yuhor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Yuhor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Yuhor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Yuhor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Yuhor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Yuhor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Yuhor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Yuhor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Yuhor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Yuhor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Yuhor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Yuhor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Yuhor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Yuhor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Yuhor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Yuhor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Yuhor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Yuhor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Yuhor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Yuhor] SET  MULTI_USER 
GO
ALTER DATABASE [Yuhor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Yuhor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Yuhor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Yuhor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Yuhor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Yuhor] SET QUERY_STORE = OFF
GO
USE [Yuhor]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Yuhor]
GO
/****** Object:  SqlAssembly [ArtikalProcenti]    Script Date: 1/14/2021 3:59:20 PM ******/
CREATE ASSEMBLY [ArtikalProcenti]
FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C010300FC5B9C850000000000000000E00022200B013000000E00000006000000000000362D0000002000000040000000000010002000000002000004000000000000000600000000000000008000000002000000000000030060850000100000100000000010000010000000000000100000000000000000000000E32C00004F000000004000004803000000000000000000000000000000000000006000000C000000382C0000380000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E746578740000003C0D000000200000000E000000020000000000000000000000000000200000602E7273726300000048030000004000000004000000100000000000000000000000000000400000402E72656C6F6300000C0000000060000000020000001400000000000000000000000000004000004200000000000000000000000000000000172D000000000000480000000200050080220000B80900000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000133001000C0000000100001100027B010000040A2B00062A133002001700000002000011001200FE15020000021200177D01000004060B2B00072A00133001000C0000000300001100027B020000040A2B00062A13300200300000000400001100027B020000040A02037D0200000402280700000616FE010B072C130002067D020000047201000070731100000A7A2A133001000C0000000300001100027B030000040A2B00062A13300200300000000400001100027B030000040A02037D0300000402280700000616FE010B072C130002067D030000047201000070731100000A7A2A13300200310000000500001100027B0200000422000000003712027B030000042200000000FE0516FE012B01160A062C0500170B2B0500160B2B00072A000000133003002600000006000011007239000070027B020000048C18000001027B030000048C18000001281200000A0A2B00062A0000133005007200000007000011000F00281300000A0A062C0C1201FE1502000002070C2B58001203FE1502000002028C15000001281400000A13041104178D1C00000125161F2C9D6F1500000A130512031105169A281600000A6B7D0200000412031105179A281600000A6B7D030000041203167D01000004090C2B00082A0000133002004B00000008000011000228010000060A062C0872610000700B2B3600731700000A0C08027B020000046F1800000A2608726B0000706F1900000A2608027B030000046F1800000A26086F1A00000A0B2B00072A0042534A4201000100000000000C00000076342E302E33303331390000000005006C00000068030000237E0000D40300008C03000023537472696E677300000000600700007000000023555300D0070000100000002347554944000000E0070000D801000023426C6F6200000000000000020000015717A2010900000000FA013300160000010000001C00000002000000030000000A00000003000000010000001A000000110000000800000001000000040000000600000001000000020000000000330201000000000006006501F0020600D201F00206007D00BE020F00100300000600A5005E02060048015E02060029015E020600B9015E02060085015E0206009E015E020600D8005E0206009100D10206005C00D10206000C015E020600F300F6010A004E039D020A00BC009D020600430057020A0032001F030A006A009D020A0010021F0306008F026A0306007002570206003C00570206001C02570206005503570206006203570206008A0257020000000009000000000001000100092110002302120049000100010001003B028600010086038900010048038900502000000000E6094C0251000100682000000000960843028C0001008C20000000008608760391000100A4200000000086087E0395000100E020000000008608340391000200F8200000000086083E039500020034210000000081005300510003007421000000008600820279000300A8210000000096004D009A000300282200000000C6001A027900040000000100F00100000100F00100000100320302004D000900B80201001100B80206001900B8020A002900B80210003100B80210003900B80210004100B80210004900B80210005100B80210005900B80210006100B80215006900B80210007100B80210007900B80210008900B8021A00A100B8020600B900B8021000C9004E033D00A9004C025100D9001A025500C9005C035A00D90001006100B100B8020600B1002B006D00B1002B007300D1001A0279002E000B00AE002E001300B7002E001B00D6002E002300DF002E002B00E8002E003300E8002E003B00E8002E004300DF002E004B00EE002E005300E8002E005B00E8002E00630006012E006B0030012E0073003D0143007B009E01000183008B01200183008B01200024002B002F0034003900440066000200010000005002A10000005202A50000008203AA0000004203AA00020001000300020002000500020003000700010004000700020005000900010006000900048000000100000000000000000000000000120000000400000000000000000000007D002200000000000400000000000000000000007D00160000000000000000546F496E743332003C4D6F64756C653E004B44540053797374656D2E44617461006D73636F726C696200417070656E6400494E756C6C61626C650053696E676C650056616C7565547970650050617273650056616C696461746500477569644174747269627574650053716C4D6574686F644174747269627574650044656275676761626C6541747472696275746500436F6D56697369626C6541747472696275746500417373656D626C795469746C654174747269627574650053716C55736572446566696E65645479706541747472696275746500417373656D626C7954726164656D61726B417474726962757465005461726765744672616D65776F726B41747472696275746500417373656D626C7946696C6556657273696F6E41747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C794465736372697074696F6E41747472696275746500436F6D70696C6174696F6E52656C61786174696F6E7341747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C79436F6D70616E794174747269627574650052756E74696D65436F6D7061746962696C6974794174747269627574650076616C75650053797374656D2E52756E74696D652E56657273696F6E696E670053716C537472696E6700546F537472696E6700417274696B616C50726F63656E7469004B44542E646C6C0069735F4E756C6C006765745F4E756C6C006765745F49734E756C6C0053797374656D0053797374656D2E5265666C656374696F6E00417267756D656E74457863657074696F6E0053706F6A656E6F004368617200537472696E674275696C646572004D6963726F736F66742E53716C5365727665722E536572766572002E63746F720053797374656D2E446961676E6F73746963730053797374656D2E52756E74696D652E496E7465726F7053657276696365730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300446562756767696E674D6F6465730053797374656D2E446174612E53716C5479706573006765745F5261626174007365745F526162617400726162617400466F726D6174004F626A6563740053706C697400436F6E766572740053797374656D2E54657874006765745F506476007365745F50647600706476000000003749006E00760061006C006900640020005800200063006F006F007200640069006E006100740065002000760061006C00750065002E0000275000640076003A0020007B0030007D000A00520061006200610074003A0020007B0031007D0000094E0055004C004C0000032C00000013C451F53CBCAA43AA68461B6DE97B4600042001010803200001052001011111042001010E042001010205200101114103070102060702110811080307010C0407020C0204070202020307010E0600030E0E1C1C0C0706021108110811080E1D0E032000020400010E1C0620011D0E1D03040001080E060703020E125905200112590C05200112590E0320000E08B77A5C561934E08902060202060C04000011080320000C042001010C060001110811550328000204080011080328000C0801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F777301080100070100000000080100034B4454000005010000000017010012436F7079726967687420C2A920203230323000002901002464356135616230652D323034392D343537662D613237662D39636265666364653461623200000C010007312E302E302E3000004D01001C2E4E45544672616D65776F726B2C56657273696F6E3D76342E362E310100540E144672616D65776F726B446973706C61794E616D65142E4E4554204672616D65776F726B20342E362E31120100010054020A4F6E4E756C6C43616C6C0039010001000000020054020D4973427974654F72646572656401540E1456616C69646174696F6E4D6574686F644E616D650856616C69646174650000000039B9189A000000000200000073000000702C0000700E0000000000000000000000000000100000000000000000000000000000005253445399BA1D50DDDC5A44AE988D9D5504EC4501000000433A5C55736572735C416E61205374616E69635C4465736B746F705C6D61737465725C42617A6520325C616E612070726F6A656B61745C5975686F7250726F6A656B61745C4B44545C6F626A5C44656275675C4B44542E706462000B2D00000000000000000000252D0000002000000000000000000000000000000000000000000000172D0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C000000000000FF25002000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100100000001800008000000000000000000000000000000100010000003000008000000000000000000000000000000100000000004800000058400000EC0200000000000000000000EC0234000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000001000000000000000100000000003F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B0044C020000010053007400720069006E006700460069006C00650049006E0066006F0000002802000001003000300030003000300034006200300000001A000100010043006F006D006D0065006E007400730000000000000022000100010043006F006D00700061006E0079004E0061006D0065000000000000000000300004000100460069006C0065004400650073006300720069007000740069006F006E00000000004B00440054000000300008000100460069006C006500560065007200730069006F006E000000000031002E0030002E0030002E003000000030000800010049006E007400650072006E0061006C004E0061006D00650000004B00440054002E0064006C006C0000004800120001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A90020002000320030003200300000002A00010001004C006500670061006C00540072006100640065006D00610072006B00730000000000000000003800080001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000004B00440054002E0064006C006C000000280004000100500072006F0064007500630074004E0061006D006500000000004B00440054000000340008000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0030002E003000000038000800010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0030002E00300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000383D00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
WITH PERMISSION_SET = SAFE
GO
/****** Object:  UserDefinedDataType [dbo].[PIB]    Script Date: 1/14/2021 3:59:20 PM ******/
CREATE TYPE [dbo].[PIB] FROM [varchar](9) NULL
GO
/****** Object:  UserDefinedType [dbo].[ArtikalProcenti]    Script Date: 1/14/2021 3:59:20 PM ******/
CREATE TYPE [dbo].[ArtikalProcenti]
EXTERNAL NAME [ArtikalProcenti].[KDT.ArtikalProcenti]
GO
/****** Object:  Table [dbo].[Adresa]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresa](
	[mestoID] [int] NOT NULL,
	[adresaID] [int] NOT NULL,
	[ulica] [varchar](50) NULL,
	[brojZgrade] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[adresaID] ASC,
	[mestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alternativa]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alternativa](
	[jmID] [int] NOT NULL,
	[artikalID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[jmID] ASC,
	[artikalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artikal]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artikal](
	[artikalID] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NULL,
	[pdv] [float] NULL,
	[rabat] [float] NULL,
	[artikalProcenti] [dbo].[ArtikalProcenti] NULL,
	[aktuelnaCena] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[artikalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cena]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cena](
	[datumOd] [datetime2](7) NOT NULL,
	[iznos] [float] NULL,
	[artikalID] [int] NULL,
 CONSTRAINT [PK_Cena] PRIMARY KEY CLUSTERED 
(
	[datumOd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faktura]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faktura](
	[brojFakture] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime] NULL,
	[datumOtpreme] [datetime] NULL,
	[datumPrometa] [datetime] NULL,
	[datumIzdavanja] [datetime] NULL,
	[rokPlacnja] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[brojFakture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JedinicaMere]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JedinicaMere](
	[jmID] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NULL,
	[oznaka] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[jmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kupac]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kupac](
	[kupacID] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NULL,
	[tr] [varchar](50) NULL,
	[mb] [varchar](50) NULL,
	[pib] [dbo].[PIB] NOT NULL,
 CONSTRAINT [PK_Kupac2] PRIMARY KEY CLUSTERED 
(
	[kupacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesto]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesto](
	[mestoID] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NULL,
 CONSTRAINT [PK_Mesto] PRIMARY KEY CLUSTERED 
(
	[mestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzbenica]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzbenica](
	[narudzbenicaID] [int] IDENTITY(1,1) NOT NULL,
	[datumPrijema] [datetime] NULL,
	[datumNarucivanja] [datetime] NULL,
	[profakturaID] [int] NULL,
	[brojPonude] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[narudzbenicaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ponuda]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ponuda](
	[brojPonude] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime] NULL,
	[valutaDospeca] [varchar](4) NULL,
	[datumIzdavanja] [datetime] NULL,
	[napomena] [varchar](50) NULL,
	[zaposleniID] [int] NULL,
	[kupacID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[brojPonude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profaktura]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profaktura](
	[profakturaID] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime] NULL,
	[datumPrometa] [datetime] NULL,
	[datumIzdavanja] [datetime] NULL,
	[rokPlacanja] [datetime] NULL,
	[zaposleniID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[profakturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reklamacija]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reklamacija](
	[brojReklamacije] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime2](7) NULL,
	[razlog] [varchar](50) NULL,
	[kupacID] [int] NULL,
	[naziv] [varchar](50) NULL,
	[ukupno] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[brojReklamacije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaFakture]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaFakture](
	[brojFakture] [int] NOT NULL,
	[rb] [int] NOT NULL,
	[kolicina] [int] NULL,
	[artikalID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[brojFakture] ASC,
	[rb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaNarudzbenice]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaNarudzbenice](
	[narudzbenicaID] [int] NOT NULL,
	[stavkaID] [int] NOT NULL,
	[kolicina] [int] NULL,
	[artikalID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[narudzbenicaID] ASC,
	[stavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaPonude]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaPonude](
	[brojPonude] [int] NOT NULL,
	[rb] [int] NOT NULL,
	[kolicina] [int] NULL,
	[artikalID] [int] NOT NULL,
 CONSTRAINT [PK_StavkaPonude] PRIMARY KEY CLUSTERED 
(
	[brojPonude] ASC,
	[rb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaProfakture]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaProfakture](
	[profakturaID] [int] NOT NULL,
	[stavkaID] [int] NOT NULL,
	[kolicinaID] [int] NULL,
	[artikalID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[profakturaID] ASC,
	[stavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaReklamacije]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaReklamacije](
	[brojReklamacije] [int] NOT NULL,
	[rb] [int] IDENTITY(1,1) NOT NULL,
	[kolicina] [int] NULL,
	[artikalID] [int] NULL,
	[razlog] [varchar](50) NULL,
 CONSTRAINT [PK_StavkaReklamacije] PRIMARY KEY CLUSTERED 
(
	[brojReklamacije] ASC,
	[rb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zaposleni]    Script Date: 1/14/2021 3:59:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zaposleni](
	[zaposleniID] [int] IDENTITY(1,1) NOT NULL,
	[imePrezime] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[zaposleniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Adresa] ([mestoID], [adresaID], [ulica], [brojZgrade]) VALUES (1, 1, N'Vojvode Stepe', N'21')
GO
INSERT [dbo].[Alternativa] ([jmID], [artikalID]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Artikal] ON 

INSERT [dbo].[Artikal] ([artikalID], [naziv], [pdv], [rabat], [artikalProcenti], [aktuelnaCena]) VALUES (25, N'Artikal2', 20, 200, 0x00C1A00000C3480000, 20)
INSERT [dbo].[Artikal] ([artikalID], [naziv], [pdv], [rabat], [artikalProcenti], [aktuelnaCena]) VALUES (33, N'Artikal2 izmenjen 2', 50, 500, 0x00C2480000C3FA0000, 25)
INSERT [dbo].[Artikal] ([artikalID], [naziv], [pdv], [rabat], [artikalProcenti], [aktuelnaCena]) VALUES (1037, N'Artikal novi sada ', 10, 10, 0x00C1200000C1200000, 10)
SET IDENTITY_INSERT [dbo].[Artikal] OFF
GO
INSERT [dbo].[Cena] ([datumOd], [iznos], [artikalID]) VALUES (CAST(N'2021-01-12T18:32:40.9043974' AS DateTime2), 10, 33)
INSERT [dbo].[Cena] ([datumOd], [iznos], [artikalID]) VALUES (CAST(N'2021-01-14T15:31:00.0000000' AS DateTime2), 20, 25)
INSERT [dbo].[Cena] ([datumOd], [iznos], [artikalID]) VALUES (CAST(N'2021-01-29T11:45:40.9320000' AS DateTime2), 10, 1037)
GO
SET IDENTITY_INSERT [dbo].[Faktura] ON 

INSERT [dbo].[Faktura] ([brojFakture], [datum], [datumOtpreme], [datumPrometa], [datumIzdavanja], [rokPlacnja]) VALUES (1, CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-05-31T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Faktura] OFF
GO
SET IDENTITY_INSERT [dbo].[JedinicaMere] ON 

INSERT [dbo].[JedinicaMere] ([jmID], [naziv], [oznaka]) VALUES (1, N'kilogram', N'kg')
INSERT [dbo].[JedinicaMere] ([jmID], [naziv], [oznaka]) VALUES (2, N'tona', N't')
SET IDENTITY_INSERT [dbo].[JedinicaMere] OFF
GO
SET IDENTITY_INSERT [dbo].[Kupac] ON 

INSERT [dbo].[Kupac] ([kupacID], [naziv], [tr], [mb], [pib]) VALUES (1, N'Dis', N'46', N'131', N'31321')
INSERT [dbo].[Kupac] ([kupacID], [naziv], [tr], [mb], [pib]) VALUES (2, N'Aman', N'73', N'94', N'065')
SET IDENTITY_INSERT [dbo].[Kupac] OFF
GO
SET IDENTITY_INSERT [dbo].[Mesto] ON 

INSERT [dbo].[Mesto] ([mestoID], [naziv]) VALUES (1, N'Zemun, Beograd')
INSERT [dbo].[Mesto] ([mestoID], [naziv]) VALUES (2, N'Vozdovac, Beograd')
INSERT [dbo].[Mesto] ([mestoID], [naziv]) VALUES (3, N'Novi Beograd, Beograd')
SET IDENTITY_INSERT [dbo].[Mesto] OFF
GO
SET IDENTITY_INSERT [dbo].[Narudzbenica] ON 

INSERT [dbo].[Narudzbenica] ([narudzbenicaID], [datumPrijema], [datumNarucivanja], [profakturaID], [brojPonude]) VALUES (1, CAST(N'2020-04-29T00:00:00.000' AS DateTime), CAST(N'2020-04-27T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Narudzbenica] OFF
GO
SET IDENTITY_INSERT [dbo].[Ponuda] ON 

INSERT [dbo].[Ponuda] ([brojPonude], [datum], [valutaDospeca], [datumIzdavanja], [napomena], [zaposleniID], [kupacID]) VALUES (1, CAST(N'2020-03-27T00:00:00.000' AS DateTime), N'DIN', CAST(N'2020-03-27T00:00:00.000' AS DateTime), N'x', 1, 1)
SET IDENTITY_INSERT [dbo].[Ponuda] OFF
GO
SET IDENTITY_INSERT [dbo].[Profaktura] ON 

INSERT [dbo].[Profaktura] ([profakturaID], [datum], [datumPrometa], [datumIzdavanja], [rokPlacanja], [zaposleniID]) VALUES (1, CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-04-27T00:00:00.000' AS DateTime), CAST(N'2020-05-31T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Profaktura] OFF
GO
SET IDENTITY_INSERT [dbo].[Reklamacija] ON 

INSERT [dbo].[Reklamacija] ([brojReklamacije], [datum], [razlog], [kupacID], [naziv], [ukupno]) VALUES (1, CAST(N'2020-06-27T00:00:00.0000000' AS DateTime2), N'raz3 izmenjen', 1, N'tempo1', 2355)
INSERT [dbo].[Reklamacija] ([brojReklamacije], [datum], [razlog], [kupacID], [naziv], [ukupno]) VALUES (18, CAST(N'2021-01-12T23:19:21.3261527' AS DateTime2), N'dodato', 1, N'kaca', 1110)
INSERT [dbo].[Reklamacija] ([brojReklamacije], [datum], [razlog], [kupacID], [naziv], [ukupno]) VALUES (1019, CAST(N'2021-01-14T15:14:46.4570000' AS DateTime2), N'x', 1, N'x', 20)
INSERT [dbo].[Reklamacija] ([brojReklamacije], [datum], [razlog], [kupacID], [naziv], [ukupno]) VALUES (1020, CAST(N'2021-01-14T15:16:11.1500000' AS DateTime2), N'y', 2, N'y', 20)
SET IDENTITY_INSERT [dbo].[Reklamacija] OFF
GO
INSERT [dbo].[StavkaFakture] ([brojFakture], [rb], [kolicina], [artikalID]) VALUES (1, 1, 2, 1)
INSERT [dbo].[StavkaFakture] ([brojFakture], [rb], [kolicina], [artikalID]) VALUES (1, 2, 2, 2)
GO
INSERT [dbo].[StavkaNarudzbenice] ([narudzbenicaID], [stavkaID], [kolicina], [artikalID]) VALUES (1, 1, 2, 1)
INSERT [dbo].[StavkaNarudzbenice] ([narudzbenicaID], [stavkaID], [kolicina], [artikalID]) VALUES (1, 2, 2, 2)
GO
INSERT [dbo].[StavkaPonude] ([brojPonude], [rb], [kolicina], [artikalID]) VALUES (1, 1, 2, 1)
INSERT [dbo].[StavkaPonude] ([brojPonude], [rb], [kolicina], [artikalID]) VALUES (1, 2, 2, 2)
GO
INSERT [dbo].[StavkaProfakture] ([profakturaID], [stavkaID], [kolicinaID], [artikalID]) VALUES (1, 1, 2, 1)
INSERT [dbo].[StavkaProfakture] ([profakturaID], [stavkaID], [kolicinaID], [artikalID]) VALUES (1, 2, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[StavkaReklamacije] ON 

INSERT [dbo].[StavkaReklamacije] ([brojReklamacije], [rb], [kolicina], [artikalID], [razlog]) VALUES (1, 1, 1, 25, N'raz3')
INSERT [dbo].[StavkaReklamacije] ([brojReklamacije], [rb], [kolicina], [artikalID], [razlog]) VALUES (1, 3, 2, 33, N'raz3')
INSERT [dbo].[StavkaReklamacije] ([brojReklamacije], [rb], [kolicina], [artikalID], [razlog]) VALUES (18, 1008, 2, 25, N'budi Bog s nama ')
INSERT [dbo].[StavkaReklamacije] ([brojReklamacije], [rb], [kolicina], [artikalID], [razlog]) VALUES (1019, 4009, 1, 25, N'xx')
INSERT [dbo].[StavkaReklamacije] ([brojReklamacije], [rb], [kolicina], [artikalID], [razlog]) VALUES (1020, 4010, 2, 1037, N'yy')
SET IDENTITY_INSERT [dbo].[StavkaReklamacije] OFF
GO
SET IDENTITY_INSERT [dbo].[Zaposleni] ON 

INSERT [dbo].[Zaposleni] ([zaposleniID], [imePrezime]) VALUES (1, N'Zaposleni1')
INSERT [dbo].[Zaposleni] ([zaposleniID], [imePrezime]) VALUES (2, N'Zaposleni2')
SET IDENTITY_INSERT [dbo].[Zaposleni] OFF
GO
ALTER TABLE [dbo].[Adresa]  WITH CHECK ADD  CONSTRAINT [FK_Adresa_ToTable] FOREIGN KEY([mestoID])
REFERENCES [dbo].[Mesto] ([mestoID])
GO
ALTER TABLE [dbo].[Adresa] CHECK CONSTRAINT [FK_Adresa_ToTable]
GO
ALTER TABLE [dbo].[Alternativa]  WITH CHECK ADD  CONSTRAINT [FK_Table_Jml] FOREIGN KEY([jmID])
REFERENCES [dbo].[JedinicaMere] ([jmID])
GO
ALTER TABLE [dbo].[Alternativa] CHECK CONSTRAINT [FK_Table_Jml]
GO
ALTER TABLE [dbo].[Cena]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTable] FOREIGN KEY([artikalID])
REFERENCES [dbo].[Artikal] ([artikalID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cena] CHECK CONSTRAINT [FK_Table_ToTable]
GO
ALTER TABLE [dbo].[Narudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Narudzbenica_ToTable] FOREIGN KEY([profakturaID])
REFERENCES [dbo].[Profaktura] ([profakturaID])
GO
ALTER TABLE [dbo].[Narudzbenica] CHECK CONSTRAINT [FK_Narudzbenica_ToTable]
GO
ALTER TABLE [dbo].[Narudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Narudzbenica_ToTable_1] FOREIGN KEY([brojPonude])
REFERENCES [dbo].[Ponuda] ([brojPonude])
GO
ALTER TABLE [dbo].[Narudzbenica] CHECK CONSTRAINT [FK_Narudzbenica_ToTable_1]
GO
ALTER TABLE [dbo].[Ponuda]  WITH CHECK ADD  CONSTRAINT [FK_Ponuda_ToTable] FOREIGN KEY([zaposleniID])
REFERENCES [dbo].[Zaposleni] ([zaposleniID])
GO
ALTER TABLE [dbo].[Ponuda] CHECK CONSTRAINT [FK_Ponuda_ToTable]
GO
ALTER TABLE [dbo].[Profaktura]  WITH CHECK ADD  CONSTRAINT [FK_Profaktura_ToTable] FOREIGN KEY([zaposleniID])
REFERENCES [dbo].[Zaposleni] ([zaposleniID])
GO
ALTER TABLE [dbo].[Profaktura] CHECK CONSTRAINT [FK_Profaktura_ToTable]
GO
ALTER TABLE [dbo].[StavkaFakture]  WITH CHECK ADD  CONSTRAINT [FK_StavkaFakture_ToTable] FOREIGN KEY([brojFakture])
REFERENCES [dbo].[Faktura] ([brojFakture])
GO
ALTER TABLE [dbo].[StavkaFakture] CHECK CONSTRAINT [FK_StavkaFakture_ToTable]
GO
ALTER TABLE [dbo].[StavkaNarudzbenice]  WITH CHECK ADD  CONSTRAINT [FK_StavkaNarudzbenice_ToTable] FOREIGN KEY([narudzbenicaID])
REFERENCES [dbo].[Narudzbenica] ([narudzbenicaID])
GO
ALTER TABLE [dbo].[StavkaNarudzbenice] CHECK CONSTRAINT [FK_StavkaNarudzbenice_ToTable]
GO
ALTER TABLE [dbo].[StavkaPonude]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPonude_ToTable] FOREIGN KEY([brojPonude])
REFERENCES [dbo].[Ponuda] ([brojPonude])
GO
ALTER TABLE [dbo].[StavkaPonude] CHECK CONSTRAINT [FK_StavkaPonude_ToTable]
GO
ALTER TABLE [dbo].[StavkaProfakture]  WITH CHECK ADD  CONSTRAINT [FK_StavkaProfakture_ToTable] FOREIGN KEY([profakturaID])
REFERENCES [dbo].[Profaktura] ([profakturaID])
GO
ALTER TABLE [dbo].[StavkaProfakture] CHECK CONSTRAINT [FK_StavkaProfakture_ToTable]
GO
ALTER TABLE [dbo].[StavkaReklamacije]  WITH CHECK ADD  CONSTRAINT [FK_StavkaReklamacije_ToTable] FOREIGN KEY([brojReklamacije])
REFERENCES [dbo].[Reklamacija] ([brojReklamacije])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkaReklamacije] CHECK CONSTRAINT [FK_StavkaReklamacije_ToTable]
GO
/****** Object:  StoredProcedure [dbo].[IZRACUNAJUKUPNO]    Script Date: 1/14/2021 3:59:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IZRACUNAJUKUPNO]
@brojReklamacije INT = 1020
AS
BEGIN
SET NOCOUNT ON;
DECLARE @ukupno FLOAT;
SELECT @ukupno =
SUM(A.aktuelnaCena*SR.kolicina)
FROM Artikal A INNER JOIN StavkaReklamacije SR ON A.artikalID=SR.artikalID
WHERE brojReklamacije=@brojReklamacije;
UPDATE Reklamacija
SET ukupno = @ukupno
WHERE brojReklamacije = @brojReklamacije
END
GO
/****** Object:  StoredProcedure [dbo].[ODREDJIVANJEAKTUELNECENE]    Script Date: 1/14/2021 3:59:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ODREDJIVANJEAKTUELNECENE]
@ARTIKALID INT = 1019
AS
BEGIN
SET NOCOUNT ON;
DECLARE @AKTUELNACENA FLOAT;
SELECT @AKTUELNACENA = iznos FROM Cena
WHERE artikalID=@ARTIKALID AND datumOd=(SELECT MAX(datumOd) FROM Cena WHERE
artikalID=@ARTIKALID);
UPDATE Artikal
SET aktuelnaCena = @AKTUELNACENA
WHERE artikalID=@ARTIKALID;
END
GO
USE [master]
GO
ALTER DATABASE [Yuhor] SET  READ_WRITE 
GO
