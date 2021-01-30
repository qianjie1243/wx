USE [master]
GO
/****** Object:  Database [Wx_Mg]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Sys_logEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Sys_MenuEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Sys_RoleAuthorizationEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Sys_UserEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_EvenMessageEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_MaterialEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_MenuEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_MessageEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_PushListEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_PushTemplateEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
/****** Object:  Table [dbo].[Wx_UserEntity]    Script Date: 2021/1/31 0:13:51 ******/
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
SET IDENTITY_INSERT [dbo].[Sys_logEntity] ON 

INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (7, N'2c737e68-f3e9-4489-91d6-33dd550253bc', N'菜单编辑', 1, N'{"Id":0,"GuId":"58606827-e11d-4fde-8dd5-709952e26878","Name":"配置管理","Number":"wxconfig","SuperiorId":"1","Address":null,"IsDel":0,"Sort":0,"Type":"expand","CreateTime":"2020-10-11 15:25:21","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:25:21', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (8, N'2e414235-c7fe-4fa7-b013-ecf00ea6356f', N'菜单编辑', 2, N'{"Id":2,"GuId":"63246CA4-766A-4691-8019-D0697BE198E5","Name":"基本配置","Number":"WXConfig","SuperiorId":"45","Address":"Mg_WXConfig/index.html","IsDel":0,"Sort":0,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:25:41', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (9, N'ddbd3cf4-35ee-4acd-9e16-50bfbabb5c1f', N'菜单编辑', 2, N'{"Id":3,"GuId":"914F5733-83C9-4C93-9BD0-2BCD8C994F4F","Name":"微信菜单配置","Number":"WMenu","SuperiorId":"45","Address":"Mg_WXConfig/Menu.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:25:49', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (10, N'cd307a51-295f-4a2b-bb3b-f52eaa93cb8a', N'菜单编辑', 1, N'{"Id":0,"GuId":"157ea435-26a3-4e66-8c25-e52404c64d9b","Name":"微信用户管理","Number":"wxuserlist","SuperiorId":"1","Address":null,"IsDel":0,"Sort":1,"Type":"expand","CreateTime":"2020-10-11 15:26:33","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:26:33', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (11, N'5d3fd768-5b77-4273-8e8b-49e0bbbe0195', N'菜单编辑', 2, N'{"Id":4,"GuId":"B8AF1779-2754-41EA-A4B5-A6AEB673C78B","Name":"微信关注用户","Number":"WUser","SuperiorId":"46","Address":"Mg_WXConfig/User.html","IsDel":0,"Sort":2,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:26:43', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (12, N'6215d353-7879-4718-ba73-d72353a90d6e', N'菜单编辑', 2, N'{"Id":5,"GuId":"4AEB51EF-489A-495D-BA7A-DD7D05FA17A2","Name":"自动回复","Number":"WReply","SuperiorId":"46","Address":"Mg_TokenConfig/WReply.html","IsDel":0,"Sort":3,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:26:50', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (13, N'bb1d2efa-92a8-4fff-9ecb-4122e14b8647', N'菜单编辑', 2, N'{"Id":11,"GuId":"D9223636-EDC2-4B3B-9DB6-9182318C8D20","Name":"微信推送","Number":"WPush","SuperiorId":"46","Address":"Mg_WXConfig/WXPush.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:27:04', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (14, N'e4cb5ec6-7a8b-4afe-8dc8-c0a582a1af1a', N'菜单编辑', 2, N'{"Id":6,"GuId":"2B855D72-8CAA-4133-8128-C89FAED41C18","Name":"微信素材管理","Number":"WXcommon","SuperiorId":"1","Address":null,"IsDel":0,"Sort":4,"Type":"expand","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:27:21', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1038, N'aa520ade-2d67-470e-ae66-d9bc831596cb', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjB5wtbqUvVvUa-jpoCn7AxJs\",\"url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/IuaZfurZ4WfdzIuqkbJH6CcDic5ic4Dmoq9XKCZicSlGIUt5PuK5jQPMQhy7uBjyxicjL5MgnGUAEZjthSVSshLR3A\\/0?wx_fmt=png\",\"item\":[]}"]', N'2020-11-22 17:37:24', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1039, N'5e6f3f9c-9967-45e6-ae27-010d1dd1de86', N'菜单编辑', 1, N'{"Id":0,"GuId":"266400bf-6875-4665-af14-397ef6b6e6a9","Name":"系统管理","Number":"system","SuperiorId":"0","Address":null,"IsDel":0,"Sort":99,"Type":"expand","CreateTime":"2020-12-21 15:27:26","buttons":null,"PSysMenu":[]}', N'2020-12-21 15:27:27', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1040, N'f506246d-8f5c-435e-af53-7759b8b064f1', N'菜单编辑', 2, N'{"Id":16,"GuId":"4F262545-8D8B-4BB1-AF5A-96BEB498B015","Name":"系统菜单","Number":"sysMenu","SuperiorId":"1049","Address":"Mg_Sys/Sys_Menu.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-12-21 15:27:44', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1041, N'ed66cc3d-d5ae-4d21-b1cd-e1f923010b1a', N'菜单编辑', 1, N'{"Id":0,"GuId":"a00de834-1534-47c0-a26b-971cc85d152b","Name":"数据库","Number":"table","SuperiorId":"1049","Address":null,"IsDel":0,"Sort":2,"Type":"expand","CreateTime":"2020-12-21 15:28:29","buttons":null,"PSysMenu":[]}', N'2020-12-21 15:28:29', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1042, N'7d4e69b9-8f8a-4847-91e7-32fa4785a0de', N'菜单编辑', 2, N'{"Id":1050,"GuId":"a00de834-1534-47c0-a26b-971cc85d152b","Name":"数据库","Number":"Systable","SuperiorId":"1049","Address":"Mg_Table/Tableindex.html","IsDel":0,"Sort":2,"Type":"iframe","CreateTime":"2020-12-21 15:28:29","buttons":null,"PSysMenu":[]}', N'2020-12-21 15:29:35', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1043, N'e0a32063-4852-4b77-a2b5-6b56a1cc5ab3', N'菜单编辑', 1, N'{"Id":0,"GuId":"55a66651-a2aa-4afb-83d1-31ad20141b07","Name":"用户管理","Number":"sys_user","SuperiorId":"1049","Address":"Mg_Sys/Sys_User.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2021-01-30 18:56:01","buttons":null,"PSysMenu":[]}', N'2021-01-30 18:56:02', N'Sys_Menu/SaveFrom')
SET IDENTITY_INSERT [dbo].[Sys_logEntity] OFF
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

INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (34, N'9d093686-49bd-4756-8961-a5c0ae0739c9', N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', N'ca134f8a-a010-49d1-b844-96bf325954c5', N'', N'2021-01-31 00:11:07')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (35, N'469d53fb-6f86-480b-8f44-ff8d85a0d9d2', N'266400bf-6875-4665-af14-397ef6b6e6a9', N'ca134f8a-a010-49d1-b844-96bf325954c5', N'', N'2021-01-31 00:11:07')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (36, N'0f3022e5-f925-4cd6-b5fc-a40ec932cd97', N'55a66651-a2aa-4afb-83d1-31ad20141b07', N'ca134f8a-a010-49d1-b844-96bf325954c5', N'', N'2021-01-31 00:11:07')
INSERT [dbo].[Sys_RoleAuthorizationEntity] ([Id], [GuId], [MenuGid], [UserGid], [ButtonLis], [CreateTime]) VALUES (37, N'02da6943-805e-4d3a-ab1d-29486d0e6352', N'a00de834-1534-47c0-a26b-971cc85d152b', N'ca134f8a-a010-49d1-b844-96bf325954c5', N'', N'2021-01-31 00:11:07')
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
SET IDENTITY_INSERT [dbo].[Wx_PushListEntity] ON 

INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (1, N'1afcf35e-7913-48e8-bfa6-ccf68060322e', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'oF6zUwgqaPqHnNcRoaU3aA8wYv1U', N'[{"Name":"title","values":{"value":"测试","color":"#0000ff"}},{"Name":"keyword1","values":{"value":"测试","color":"#0000a0"}},{"Name":"keyword2","values":{"value":"测试","color":"#00c040"}},{"Name":"keyword3","values":{"value":"测试","color":"#202020"}},{"Name":"remark","values":{"value":"测试","color":"#202060"}}]', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-13 10:50:31', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (2, N'5ab41b76-94f7-47be-b526-d2432690f0a1', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'oF6zUwjD4kuYfHYkBpogsNx_YtkQ', N'[{"Name":"title","values":{"value":"防守打法","color":"#002060"}},{"Name":"keyword1","values":{"value":"防守打法","color":"#002060"}},{"Name":"keyword2","values":{"value":"防守打法","color":"#200080"}},{"Name":"keyword3","values":{"value":"防守打法","color":"#4000ff"}},{"Name":"remark","values":{"value":"防守打法","color":"#4000a0"}}]', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-13 11:29:59', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (3, N'5d913d27-5014-47c7-b8d7-18923d148522', N'文本推送', N'oF6zUwgqaPqHnNcRoaU3aA8wYv1U', N'大声道', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-14 18:10:56', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (4, N'6443b7a6-d853-495a-8316-27d67dc69c59', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测试', N'{"errcode":"45015","errmsg":"response out of time limit or subscription is canceled rid: 5f892e70-074c8bfb-030bf89f"}', N'2020-10-16 13:24:01', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (5, N'a097ebe6-1450-4b14-b77d-d14804ae1683', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'[{"Name":"title","values":{"value":"测","color":"#000080"}},{"Name":"keyword1","values":{"value":"测测","color":"#00c080"}},{"Name":"keyword2","values":{"value":"测测测","color":"#00a0a0"}},{"Name":"keyword3","values":{"value":"测测测","color":"#204080"}},{"Name":"remark","values":{"value":"测测测测测","color":"#20c060"}}]', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-16 13:24:32', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (6, N'4cb12a40-a307-4a7c-b6dd-fca9c6183fbd', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测测测测测测测测测测测测', N'{"errcode":"45015","errmsg":"response out of time limit or subscription is canceled rid: 5f892ecf-4ed722b8-314f76a5"}', N'2020-10-16 13:25:35', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (7, N'848145ba-78ef-4d88-9501-52f09a8a1e96', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测测测测测测测测测测测测', N'{"errcode":"45015","errmsg":"response out of time limit or subscription is canceled rid: 5f892ef1-4d03aa68-4922e893"}', N'2020-10-16 13:26:09', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (8, N'ff0c4566-f959-46e3-8dd1-0117e50b3ec3', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测测测测测测测测测测测测', N'{"errcode":"45015","errmsg":"response out of time limit or subscription is canceled rid: 5f892efb-56b565c0-480d568f"}', N'2020-10-16 13:26:19', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (9, N'c309e137-182c-4887-ad4e-1b58c851fbe1', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测测测测测测测测测测测测', N'{"errcode":"45015","errmsg":"response out of time limit or subscription is canceled rid: 5f892f07-1d1b9820-460a0ec9"}', N'2020-10-16 13:26:31', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (10, N'21ac4143-cc4c-4334-b128-344143f8a752', N'文本推送', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'测测测测测测测测测测测测', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-16 13:26:40', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_PushListEntity] ([Id], [GuId], [TempId], [Oppid], [Content], [ResContent], [CreateTime], [WxAppId]) VALUES (1002, N'20631f8b-1098-46d3-a62a-967f6caa00d6', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'oF6zUwucqESM98AMjzgYck_gtCHo', N'[{"Name":"title","values":{"value":"传","color":"#0020a0"}},{"Name":"keyword1","values":{"value":"测试","color":"#0000c0"}},{"Name":"keyword2","values":{"value":"测试","color":"#204060"}},{"Name":"keyword3","values":{"value":"测试","color":"#406020"}},{"Name":"remark","values":{"value":"测试","color":"#4020a0"}}]', N'{"errcode":"0","errmsg":"ok"}', N'2020-10-22 09:29:27', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_PushListEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_PushTemplateEntity] ON 

INSERT [dbo].[Wx_PushTemplateEntity] ([Id], [GuId], [TempId], [Name], [Content], [CreateTime], [WxAppId]) VALUES (1, N'7a8a1030-5173-4e92-9fdd-796335684c43', N'zJPCnfXRETA3kO2thmNbG9r2rN_SnKqsGobkXlSdBVc', N'测试', N' {{title.DATA}}
 测试：{{keyword1.DATA}}
 测试：{{keyword2.DATA}} 
测试：{{keyword3.DATA}} 
备注：{{remark.DATA}}
', N'2020-10-11 17:14:09', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_PushTemplateEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_UserEntity] ON 

INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1012, N'3fbdfcab-75f3-46a5-8c93-a4225c167934', N'oF6zUwhScOTb8T_kk-djEtZXVxSI', N'乔高梁', N'奥地利布尔根兰', N'http://thirdwx.qlogo.cn/mmopen/PfcVOSsxrliav7HtZF623YOVYnWpUJ0TqTjyVwSJjicfnbzCFqP5SGS5zPXkEeqFQpxQibiasZQ0K93aPwNeEBYQTeCortYLjQqY/132', 1, N'1604562391', N'2021-01-02 15:53:14', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1013, N'3ca31bfa-f391-49c9-a4ec-d1e7338cb8da', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'lzf', N'中国江苏', N'http://thirdwx.qlogo.cn/mmopen/Q3auHgzwzM7KuWyYqJUEKB1prexWz7icsRFcOW7x44icjfaia0fkBickxmUkIK6MzxrIh5SFuAflDIayF10yic679VWuVJEjLgOrIGdQezRgDBC4/132', 1, N'1597219940', N'2021-01-02 15:53:14', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1014, N'3a4db300-8915-4ff7-96e4-d50f1ce046ff', N'oF6zUwh918mV1b16D630Cr3pHIA4', N'ERROI', N'中国江苏苏州', N'http://thirdwx.qlogo.cn/mmopen/EtUakuZ0XRLPXpTBbyxEzHemsg77OXfCfmmhmudxrxOJL5Nt0lsBwHDtgbAibibcnAWKM33yDQ9ib1DrKXp27Kd6UqBfBpKXkVw/132', 1, N'1597713323', N'2021-01-02 15:53:14', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1015, N'5ba7776b-f4ff-46d2-9978-9c249605bccf', N'oF6zUwjD4kuYfHYkBpogsNx_YtkQ', N'+7', N'比利时', N'http://thirdwx.qlogo.cn/mmopen/EtUakuZ0XRLPXpTBbyxEzNuckek31nEibaG5zUQ8mWqwk57ndia48tYkqAl9T5bza7oQFPP3EsEdbeGBnTNaeAK72JmBWGxN7J/132', 2, N'1602559726', N'2021-01-02 15:53:14', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1016, N'a3f5da52-4be9-4923-b45a-28c53fc0c231', N'oF6zUwgqaPqHnNcRoaU3aA8wYv1U', N'包子', N'中国江苏苏州', N'http://thirdwx.qlogo.cn/mmopen/cFEsMsQm6lGkoabVicNhov9LXfYlBqkdGRYGaLBU5Sjm7dh9zZHz1y7Fe4ZY0TuDtHBSEGypVyCfJK3Wgub4lEYJaV0iaEk3or/132', 1, N'1597556619', N'2021-01-02 15:53:14', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_UserEntity] OFF
USE [master]
GO
ALTER DATABASE [Wx_Mg] SET  READ_WRITE 
GO
