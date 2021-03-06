USE [master]
GO
/****** Object:  Database [Wx_Mg]    Script Date: 2021/2/9 17:46:22 ******/
CREATE DATABASE [Wx_Mg]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WX_MG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WX_MG.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WX_MG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WX_MG_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Wx_Mg] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Wx_Mg].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Wx_Mg] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Wx_Mg] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Wx_Mg] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Wx_Mg] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Wx_Mg] SET ARITHABORT OFF 
GO
ALTER DATABASE [Wx_Mg] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Wx_Mg] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Wx_Mg] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Wx_Mg] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Wx_Mg] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Wx_Mg] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Wx_Mg] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Wx_Mg] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Wx_Mg] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Wx_Mg] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Wx_Mg] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Wx_Mg] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Wx_Mg] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Wx_Mg] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Wx_Mg] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Wx_Mg] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Wx_Mg] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Wx_Mg] SET RECOVERY FULL 
GO
ALTER DATABASE [Wx_Mg] SET  MULTI_USER 
GO
ALTER DATABASE [Wx_Mg] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Wx_Mg] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Wx_Mg] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Wx_Mg] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Wx_Mg] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Wx_Mg', N'ON'
GO
USE [Wx_Mg]
GO
/****** Object:  Table [dbo].[Sys_ButtonEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_ButtonEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [varchar](50) NULL,
	[Number] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[CreateTime] [varchar](50) NULL,
	[MenuId] [varchar](50) NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_logEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_logEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Type] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[CreateTime] [varchar](200) NULL,
	[Action] [nvarchar](100) NULL,
 CONSTRAINT [PK__Sys_logE__3214EC078A8C2911] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_MenuEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_MenuEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Number] [varchar](50) NULL,
	[SuperiorId] [varchar](50) NULL,
	[Address] [varchar](200) NULL,
	[IsDel] [int] NULL,
	[Sort] [int] NULL,
	[Type] [varchar](200) NULL,
	[CreateTime] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_RoleAuthorizationEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_RoleAuthorizationEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [varchar](50) NULL,
	[MenuGid] [varchar](50) NULL,
	[UserGid] [varchar](50) NULL,
	[ButtonLis] [varchar](max) NULL,
	[CreateTime] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_UserEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_UserEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [varchar](50) NULL,
	[Name] [nvarchar](20) NULL,
	[NickName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Pwd] [nvarchar](50) NULL,
	[key] [varchar](20) NULL,
	[EncryPwd] [nvarchar](100) NULL,
	[CreateTime] [nvarchar](20) NULL,
	[IsDel] [int] NULL,
 CONSTRAINT [PK__Sys_User__3214EC07D22ED70D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wx_EvenMessageEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_EvenMessageEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[WxAppId] [nvarchar](50) NULL,
	[EventKey] [nvarchar](50) NULL,
	[EventType] [nvarchar](50) NULL,
	[CreateTime] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_MaterialEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_MaterialEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NULL,
	[Media_Id] [nvarchar](50) NULL,
	[Introduction] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NULL,
	[PathUrl] [nvarchar](500) NULL,
	[CreateTime] [nvarchar](50) NULL,
	[WxAppId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_MenuEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_MenuEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[WxAppId] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NULL,
	[CreateTime] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_MessageEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_MessageEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[WxAppId] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Key] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[Content] [nvarchar](max) NULL,
	[MatchingWay] [int] NULL,
	[CreateTime] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_PushListEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_PushListEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[TempId] [nvarchar](50) NULL,
	[Oppid] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NULL,
	[ResContent] [nvarchar](max) NULL,
	[CreateTime] [nvarchar](50) NULL,
	[WxAppId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_PushTemplateEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wx_PushTemplateEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[TempId] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NULL,
	[CreateTime] [nvarchar](30) NULL,
	[WxAppId] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wx_UserEntity]    Script Date: 2021/2/9 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wx_UserEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuId] [nvarchar](50) NULL,
	[Openid] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Headimgurl] [varchar](500) NULL,
	[Sex] [int] NULL,
	[SubscribeTime] [varchar](30) NULL,
	[CreateTime] [nvarchar](30) NULL,
	[WxAppId] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sys_ButtonEntity] ON 

INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (4, N'8d47f0a0-2793-43b6-a68d-1d5d88630c8b', N'add', N'新增', N'2021-02-09 09:25:55', N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (8, N'2dff7b40-e333-48be-891c-01db9c3d9d3a', N'add', N'新增', N'2021-02-09 09:33:43', N'55a66651-a2aa-4afb-83d1-31ad20141b07', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (9, N'41487c20-3fc2-42e0-a021-31dd7be2d132', N'edit', N'编辑', N'2021-02-09 09:33:43', N'55a66651-a2aa-4afb-83d1-31ad20141b07', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (10, N'a12e4c63-c3e7-46ef-9a72-ffa2147ef446', N'del', N'禁用', N'2021-02-09 09:33:43', N'55a66651-a2aa-4afb-83d1-31ad20141b07', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (11, N'a30e207c-851d-4058-85d3-2510b16163a3', N'unlock', N'正常', N'2021-02-09 09:35:16', N'55a66651-a2aa-4afb-83d1-31ad20141b07', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (12, N'2493acd0-5a72-446e-8c84-457a93737871', N'authorization', N'编辑权限', N'2021-02-09 09:35:16', N'55a66651-a2aa-4afb-83d1-31ad20141b07', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (13, N'fedbedb7-7c1d-40de-888e-bfc2dd95d008', N'edit', N'查看', N'2021-02-09 15:30:00', N'4F262545-8D8B-4BB1-AF5A-96BEB498B012', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (14, N'56451636-dc28-4297-8e05-b84cc5eb619f', N'edit', N'查看', N'2021-02-09 15:38:28', N'4F262545-8D8B-4BB1-AF5A-96BEB498B053', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (15, N'cd148a48-18a6-4c25-a733-eb377ba680fe', N'edit', N'查看', N'2021-02-09 15:46:06', N'a00de834-1534-47c0-a26b-971cc85d152b', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (16, N'c7fab5cd-bc60-4636-93ba-4d61e96a4518', N'pull', N'拉取', N'2021-02-09 16:07:21', N'914F5733-83C9-4C93-9BD0-2BCD8C994F4F', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (17, N'3f81a595-f9dd-48a5-90b0-c320a489eb90', N'submit', N'保存', N'2021-02-09 16:07:21', N'914F5733-83C9-4C93-9BD0-2BCD8C994F4F', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (18, N'7aed953a-eb8c-423e-805e-9f6c009d7109', N'pull', N'拉取数据', N'2021-02-09 16:11:31', N'B8AF1779-2754-41EA-A4B5-A6AEB673C78B', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (19, N'6bcde953-6cf9-4bbd-af51-9905cf02520e', N'submit', N'保存', N'2021-02-09 16:12:48', N'4AEB51EF-489A-495D-BA7A-DD7D05FA17A2', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (20, N'ad111607-e8b4-4764-9c37-98911fa2fd58', N'edit', N'查看', N'2021-02-09 16:23:23', N'a6d2b32b-4705-46bc-8e0d-773819bdc252', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (21, N'936a47a2-cd4e-4cda-af01-7ab9684e2693', N'add', N'新增', N'2021-02-09 16:32:47', N'499cca62-112a-4ab4-bfec-3cc1d22247d0', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (22, N'1e6fe52c-4fab-4cd7-a957-1a2be8b9256b', N'edit', N'编辑', N'2021-02-09 16:32:47', N'499cca62-112a-4ab4-bfec-3cc1d22247d0', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (23, N'5a7e702a-ab7e-4659-ba2b-e53d8ab34bd1', N'del', N'删除', N'2021-02-09 16:32:47', N'499cca62-112a-4ab4-bfec-3cc1d22247d0', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (24, N'7a744fc1-4349-4af7-b403-62d30bdd75f0', N'pull', N'拉取数据', N'2021-02-09 16:47:54', N'0A40EC40-BF93-47CC-ABA7-8A807D44AB7A', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (25, N'45f8cc94-4fae-48e5-9f28-b45996d5e66b', N'pull', N'拉取数据', N'2021-02-09 16:56:26', N'33EB4F97-0196-4C2F-B9D1-E552B7923D42', 0)
INSERT [dbo].[Sys_ButtonEntity] ([Id], [GuId], [Number], [Name], [CreateTime], [MenuId], [IsDel]) VALUES (26, N'c0c30fc9-12d9-48d9-aeec-2fba21a07cc8', N'submit', N'上传保存', N'2021-02-09 17:42:58', N'BFF8E440-CDF8-4669-8C9A-1E729C69D302', 0)
SET IDENTITY_INSERT [dbo].[Sys_ButtonEntity] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuEntity] ON 

INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (1, N'08080707-2116-46B2-9904-97C86DDDB577', N'微信管理', N'WX', N'0', N'', 0, 0, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (2, N'63246CA4-766A-4691-8019-D0697BE198E5', N'基本配置', N'WXConfig', N'45', N'Mg_WXConfig/index.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (3, N'914F5733-83C9-4C93-9BD0-2BCD8C994F4F', N'菜单配置', N'WMenu', N'45', N'Mg_WXConfig/Menu.html', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (4, N'B8AF1779-2754-41EA-A4B5-A6AEB673C78B', N'关注用户', N'WUser', N'46', N'Mg_WXConfig/User.html', 0, 2, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (5, N'4AEB51EF-489A-495D-BA7A-DD7D05FA17A2', N'自动回复', N'WReply', N'46', N'Mg_TokenConfig/WReply.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (6, N'2B855D72-8CAA-4133-8128-C89FAED41C18', N'素材管理', N'WXcommon', N'1', NULL, 0, 4, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (7, N'0A40EC40-BF93-47CC-ABA7-8A807D44AB7A', N'Token/JsapiTicket', N'WToken', N'47', N'Mg_WXConfig/Token.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (8, N'33EB4F97-0196-4C2F-B9D1-E552B7923D42', N'素材总数', N'WMaterial', N'6', N'Mg_WXMaterial/Material.html', 0, 4, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (9, N'7E8518DC-8364-47D8-822E-C95E254E3190', N'获取永久素材', N'WMaterialList', N'6', N'Mg_WXMaterial/MaterialList.html', 0, 2, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (10, N'BFF8E440-CDF8-4669-8C9A-1E729C69D302', N'上传素材', N'WAddMaterial', N'6', N'Mg_WXMaterial/AddMaterial.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (11, N'D9223636-EDC2-4B3B-9DB6-9182318C8D20', N'推送', N'WPush', N'46', N'Mg_WXConfig/WXPush.html', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (12, N'039F7ACE-A6FB-4943-93E0-BFDB6F452E11', N'日志管理', N'Log', N'0', N'', 0, 2, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (14, N'4F262545-8D8B-4BB1-AF5A-96BEB498B012', N'系统日志', N'syslog', N'12', N'Mg_Log/Sys_Log', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (16, N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', N'系统菜单', N'sysMenu', N'1049', N'Mg_Sys/Sys_Menu.html', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (38, N'4F262545-8D8B-4BB1-AF5A-96BEB498B053', N'微信日志', N'wx_log', N'12', N'Mg_Log/Wx_Log/index.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (45, N'58606827-e11d-4fde-8dd5-709952e26878', N'配置管理', N'wxconfig', N'1', NULL, 0, 0, N'expand', N'2020-10-11 15:25:21')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (46, N'157ea435-26a3-4e66-8c25-e52404c64d9b', N'用户管理', N'wxuserlist', N'1', NULL, 0, 1, N'expand', N'2020-10-11 15:26:33')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (47, N'ed13e028-c027-4f88-a153-e1b03c88e3d9', N'其他管理', N'wxother', N'1', NULL, 0, 3, N'expand', N'2020-10-11 15:28:12')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (48, N'499cca62-112a-4ab4-bfec-3cc1d22247d0', N'模板维护', N'wxtemp', N'46', N'Mg_WXConfig/WXPushTemp.html', 0, 0, N'iframe', N'2020-10-11 17:06:46')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (49, N'a6d2b32b-4705-46bc-8e0d-773819bdc252', N'推送记录', N'pushRo', N'46', N'Mg_WXConfig/WXPushRecord.html', 0, 0, N'iframe', N'2020-10-14 16:47:05')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (1049, N'266400bf-6875-4665-af14-397ef6b6e6a9', N'系统管理', N'system', N'0', NULL, 0, 99, N'expand', N'2020-12-21 15:27:26')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (1050, N'a00de834-1534-47c0-a26b-971cc85d152b', N'数据库', N'Systable', N'1049', N'Mg_Table/Tableindex.html', 0, 2, N'iframe', N'2020-12-21 15:28:29')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (1051, N'55a66651-a2aa-4afb-83d1-31ad20141b07', N'用户管理', N'sys_user', N'1049', N'Mg_Sys/Sys_User.html', 0, 1, N'iframe', N'2021-01-30 18:56:01')
SET IDENTITY_INSERT [dbo].[Sys_MenuEntity] OFF
SET IDENTITY_INSERT [dbo].[Sys_RoleAuthorizationEntity] ON 

INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (66, N'f679bedc-3133-4fd8-8987-98215640ea87', N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', N'2133797b-0a87-4b02-b023-a3a61da581e3', N'[]', N'2021-02-09 15:15:45')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (67, N'0f9df992-dd54-41a0-85af-6cd03bca1788', N'266400bf-6875-4665-af14-397ef6b6e6a9', N'2133797b-0a87-4b02-b023-a3a61da581e3', N'[]', N'2021-02-09 15:15:45')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (68, N'b658d981-b8f7-4e62-aedf-0770a29f0fac', N'a00de834-1534-47c0-a26b-971cc85d152b', N'2133797b-0a87-4b02-b023-a3a61da581e3', N'[]', N'2021-02-09 15:15:45')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (69, N'6b992f73-2929-451e-9258-c09545601003', N'55a66651-a2aa-4afb-83d1-31ad20141b07', N'2133797b-0a87-4b02-b023-a3a61da581e3', N'[]', N'2021-02-09 15:15:45')
SET IDENTITY_INSERT [dbo].[Sys_RoleAuthorizationEntity] OFF
SET IDENTITY_INSERT [dbo].[Sys_UserEntity] ON 

INSERT [dbo].[Sys_UserEntity] ([Id], [GuId], [Name], [NickName], [UserName], [Phone], [Pwd], [key], [EncryPwd], [CreateTime], [IsDel]) VALUES (1, N'37918052-F5C9-4A6D-B5B7-D752D976E9A8', N'system', N'system', N'system', NULL, N'123456', N'system_username', N'D04C1A90B2218F47', N'2021-01-29 15:26:23:', -1)
INSERT [dbo].[Sys_UserEntity] ([Id], [GuId], [Name], [NickName], [UserName], [Phone], [Pwd], [key], [EncryPwd], [CreateTime], [IsDel]) VALUES (4, N'2133797b-0a87-4b02-b023-a3a61da581e3', N'1234', N'123', N'admin', NULL, N'123456', N'bqiB5ki0kob2G0k', N'05687C7805CAF6A1', N'2021-01-30 21:43:38', 0)
INSERT [dbo].[Sys_UserEntity] ([Id], [GuId], [Name], [NickName], [UserName], [Phone], [Pwd], [key], [EncryPwd], [CreateTime], [IsDel]) VALUES (5, N'ca134f8a-a010-49d1-b844-96bf325954c5', N'测试', N'我是谁', N'ces', NULL, N'123456', N'3aGA2ndpkp8g186', N'3007490284EF21F8', N'2021-01-30 21:50:00', 0)
SET IDENTITY_INSERT [dbo].[Sys_UserEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_MaterialEntity] ON 

INSERT [dbo].[Wx_MaterialEntity] ([Id], [GuId], [Type], [Content], [Media_Id], [Introduction], [Url], [PathUrl], [CreateTime], [WxAppId]) VALUES (6, N'fbf8a42a-667e-45dd-b30a-856b76e92ba5', N'news', N'{"articles":[{"title":"测试","thumb_media_id":"wy9-6ie4coVTcM-hUKfjB5ieGI_vd8XUmzNI0UBK2eE","author":"测试","digest":"测试","show_cover_pic":0,"content":"测试","content_source_url":"https://www.baidu.com/","need_open_comment":0,"only_fans_can_comment":1}]}', N'wy9-6ie4coVTcM-hUKfjB_yFj6XjSODF5mw4z8wc5d8', N'', N'', N'', N'2020-10-22 11:17:24', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_MaterialEntity] ([Id], [GuId], [Type], [Content], [Media_Id], [Introduction], [Url], [PathUrl], [CreateTime], [WxAppId]) VALUES (7, N'1602684e-09d4-4d52-b463-3d1448dd34a8', N'image', N'', N'wy9-6ie4coVTcM-hUKfjB5wtbqUvVvUa-jpoCn7AxJs', N'', N'http://mmbiz.qpic.cn/mmbiz_png/IuaZfurZ4WfdzIuqkbJH6CcDic5ic4Dmoq9XKCZicSlGIUt5PuK5jQPMQhy7uBjyxicjL5MgnGUAEZjthSVSshLR3A/0?wx_fmt=png', N'/file/media/images/20201122/202011221737222678K1.jpg', N'2020-11-22 17:37:23', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_MaterialEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_MenuEntity] ON 

INSERT [dbo].[Wx_MenuEntity] ([Id], [GuId], [WxAppId], [Content], [CreateTime]) VALUES (2, N'29fd4097-c21c-47d3-8898-82e8f1248a83', N'wxf4d49d7ee1a463be', N'{
  "button": [
    {
      "type": "view",
      "name": "测试功能",
      "url": "http://qianjie.fit/v1.1_Mobile/index.html",
      "sub_button": []
    },
    {
      "type": "scancode_push",
      "name": "扫一扫1",
      "key": "sao",
      "sub_button": []
    }
  ]
}', N'2020-10-11 14:57:31')
SET IDENTITY_INSERT [dbo].[Wx_MenuEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_MessageEntity] ON 

INSERT [dbo].[Wx_MessageEntity] ([Id], [GuId], [WxAppId], [Type], [Key], [Name], [Content], [MatchingWay], [CreateTime]) VALUES (7, N'114b762f-0433-49d2-be38-0d24a75841d7', N'wxf4d49d7ee1a463be', 1, 2, N'2', N'[{"PicUrl_Title":"图片链接","PicUrl":"","Title_Title":"标题","Title":"Title","Description_Title":"摘要","Description":"Description","Url_Title":"跳转链接","Url":"http://www.baidu.com"}]', 0, N'2020-10-14 18:07:49')
INSERT [dbo].[Wx_MessageEntity] ([Id], [GuId], [WxAppId], [Type], [Key], [Name], [Content], [MatchingWay], [CreateTime]) VALUES (8, N'b263da7a-b416-4a36-a7e9-a625797cd731', N'wxf4d49d7ee1a463be', 1, 1, N'测试', N'[{"Content_Title":"详情","Content":"测试"}]', 0, N'2020-10-14 18:07:49')
INSERT [dbo].[Wx_MessageEntity] ([Id], [GuId], [WxAppId], [Type], [Key], [Name], [Content], [MatchingWay], [CreateTime]) VALUES (9, N'9cabafdd-108b-4d43-b68c-fadf56ef06bc', N'wxf4d49d7ee1a463be', 1, 1, N'1', N'[{"Content_Title":"详情","Content":"3123123123213123123123123"}]', 0, N'2020-10-14 18:07:49')
INSERT [dbo].[Wx_MessageEntity] ([Id], [GuId], [WxAppId], [Type], [Key], [Name], [Content], [MatchingWay], [CreateTime]) VALUES (10, N'e4fc2ad7-2dc5-4879-b05d-8e2fdb8b8dea', N'wxf4d49d7ee1a463be', 2, 1, NULL, N'[{"Content_Title":"详情","Content":"谢谢你的关注"}]', 0, N'2020-10-14 18:07:49')
SET IDENTITY_INSERT [dbo].[Wx_MessageEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_PushTemplateEntity] ON 

INSERT [dbo].[Wx_PushTemplateEntity] ([Id], [GuId], [TempId], [Name], [Content], [CreateTime], [WxAppId]) VALUES (1, N'7a8a1030-5173-4e92-9fdd-796335684c43', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'测试', N' {{title.DATA}}
 测试：{{keyword1.DATA}}
 测试：{{keyword2.DATA}} 
测试：{{keyword3.DATA}} 
备注：{{remark.DATA}}
', N'2020-10-11 17:14:09', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_PushTemplateEntity] OFF
USE [master]
GO
ALTER DATABASE [Wx_Mg] SET  READ_WRITE 
GO
