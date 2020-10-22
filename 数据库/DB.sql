USE [master]
GO
/****** Object:  Database [Wx_Mg]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Sys_logEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Sys_MenuEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_EvenMessageEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_MaterialEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_MenuEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_MessageEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_PushListEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_PushTemplateEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
/****** Object:  Table [dbo].[Wx_UserEntity]    Script Date: 2020/10/22 15:37:41 ******/
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
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (15, N'62210d9e-3374-4a5c-81f5-899aa8f590b5', N'菜单编辑', 1, N'{"Id":0,"GuId":"ed13e028-c027-4f88-a153-e1b03c88e3d9","Name":"微信其他管理","Number":"wxother","SuperiorId":"0","Address":null,"IsDel":0,"Sort":3,"Type":"expand","CreateTime":"2020-10-11 15:28:12","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:28:12', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (16, N'89a6ed87-87c0-4df9-95e4-f43e1c0377ae', N'菜单编辑', 2, N'{"Id":47,"GuId":"ed13e028-c027-4f88-a153-e1b03c88e3d9","Name":"微信其他管理","Number":"wxother","SuperiorId":"1","Address":null,"IsDel":0,"Sort":3,"Type":"expand","CreateTime":"2020-10-11 15:28:12","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:28:23', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (17, N'ba68fa3c-64dc-43b4-b4c6-300a1082e466', N'菜单编辑', 2, N'{"Id":7,"GuId":"0A40EC40-BF93-47CC-ABA7-8A807D44AB7A","Name":"Token/JsapiTicket","Number":"WToken","SuperiorId":"47","Address":"Mg_WXConfig/Token.html","IsDel":0,"Sort":0,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:28:35', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (18, N'a1e76a19-f53e-4458-a549-8d602427e35a', N'菜单编辑', 2, N'{"Id":46,"GuId":"157ea435-26a3-4e66-8c25-e52404c64d9b","Name":"用户管理","Number":"wxuserlist","SuperiorId":"1","Address":null,"IsDel":0,"Sort":1,"Type":"expand","CreateTime":"2020-10-11 15:26:33","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:28:54', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (19, N'b0b50430-4d57-48b8-9f7f-490ed9fe0c6e', N'菜单编辑', 2, N'{"Id":3,"GuId":"914F5733-83C9-4C93-9BD0-2BCD8C994F4F","Name":"菜单配置","Number":"WMenu","SuperiorId":"45","Address":"Mg_WXConfig/Menu.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:29:00', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (20, N'92dcb87b-6573-4bf0-8c53-b33ffb97bee6', N'菜单编辑', 2, N'{"Id":4,"GuId":"B8AF1779-2754-41EA-A4B5-A6AEB673C78B","Name":"关注用户","Number":"WUser","SuperiorId":"46","Address":"Mg_WXConfig/User.html","IsDel":0,"Sort":2,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:29:06', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (21, N'f4fe71a2-88c9-4eb2-b712-b62c13604bef', N'菜单编辑', 2, N'{"Id":11,"GuId":"D9223636-EDC2-4B3B-9DB6-9182318C8D20","Name":"推送","Number":"WPush","SuperiorId":"46","Address":"Mg_WXConfig/WXPush.html","IsDel":0,"Sort":1,"Type":"iframe","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:29:10', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (22, N'ae3b0f58-8d42-4a67-8f4f-638302a3a4db', N'菜单编辑', 2, N'{"Id":47,"GuId":"ed13e028-c027-4f88-a153-e1b03c88e3d9","Name":"其他管理","Number":"wxother","SuperiorId":"1","Address":null,"IsDel":0,"Sort":3,"Type":"expand","CreateTime":"2020-10-11 15:28:12","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:29:15', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (23, N'48355a3f-8719-4520-b8d4-fe56d45399d0', N'菜单编辑', 2, N'{"Id":6,"GuId":"2B855D72-8CAA-4133-8128-C89FAED41C18","Name":"素材管理","Number":"WXcommon","SuperiorId":"1","Address":null,"IsDel":0,"Sort":4,"Type":"expand","CreateTime":"2020-09-27 9:50:00","buttons":null,"PSysMenu":[]}', N'2020-10-11 15:29:22', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (24, N'418a77cf-3547-41de-8b23-0fb35df08505', N'菜单编辑', 1, N'{"Id":0,"GuId":"499cca62-112a-4ab4-bfec-3cc1d22247d0","Name":"模板维护","Number":"wxtemp","SuperiorId":"46","Address":"Mg_WXConfig/WXPushTemp.html","IsDel":0,"Sort":0,"Type":"iframe","CreateTime":"2020-10-11 17:06:46","buttons":null,"PSysMenu":[]}', N'2020-10-11 17:06:46', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (25, N'52774c05-38aa-4047-8dd3-29d9319499f6', N'菜单编辑', 1, N'{"Id":0,"GuId":"a6d2b32b-4705-46bc-8e0d-773819bdc252","Name":"推送记录","Number":"pushRo","SuperiorId":"46","Address":"Mg_WXConfig/WXPushRecord.html","IsDel":0,"Sort":0,"Type":"iframe","CreateTime":"2020-10-14 16:47:05","buttons":null,"PSysMenu":[]}', N'2020-10-14 16:47:05', N'Sys_Menu/SaveFrom')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1025, N'19e03ae1-de6b-4e1f-b7f6-8f005a295596', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjB-jXAGr4IN9JaWvYHYhjvb8\",\"url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/IuaZfurZ4Wfx1Gib3QmGhHI5hEv26Y70m3TdSdNQuWZicOD0bUH2fTXlYu7r9siaN1F5xn1Pic5HbdhMHdR453e5MQ\\/0?wx_fmt=png\",\"item\":[]}"]', N'2020-10-21 11:09:53', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1026, N'0231e6b0-64b4-4550-a900-409c18dc07ff', N'微信素材操作', 3, N'"{\"errcode\":0,\"errmsg\":\"ok\"}"', N'2020-10-21 13:04:40', N'Wx_Data/DeleteSC')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1027, N'21be7d94-30cd-4371-92a8-2fc7e128aa4b', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjB9VT9SFB2I1ignKFfFCQ7G0\",\"url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/IuaZfurZ4Wfx1Gib3QmGhHI5hEv26Y70m3TdSdNQuWZicOD0bUH2fTXlYu7r9siaN1F5xn1Pic5HbdhMHdR453e5MQ\\/0?wx_fmt=png\",\"item\":[]}"]', N'2020-10-21 13:23:12', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1028, N'4d6cb9f2-826b-4f78-99dc-aa28f6665ed2', N'微信素材操作', 3, N'"{\"errcode\":0,\"errmsg\":\"ok\"}"', N'2020-10-21 14:40:49', N'Wx_Data/DeleteSC')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1029, N'05cb2ed6-f98f-4d26-96d5-a201f2436525', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjB5ieGI_vd8XUmzNI0UBK2eE\",\"url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/IuaZfurZ4WecFCufeFO2tQPJEFariaxXv1n7b3luCObFSAwVsNKnDRwtwaZtNFmPU19hFnyyNyGNXvnJgdCbU0A\\/0?wx_fmt=png\",\"item\":[]}","{\"media_id\":\"wy9-6ie4coVTcM-hUKfjBwgenjUe8cWQrzoQXG9wAQs\",\"url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/IuaZfurZ4WecFCufeFO2tQPJEFariaxXvzn8W1zl03PemCDRalHg2ufbX6zfaXB8mj9heeInW9u2RFYVEzVdV1w\\/0?wx_fmt=png\",\"item\":[]}"]', N'2020-10-22 09:56:25', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1030, N'c17802ed-d784-46c0-bbb6-4ae26cc86f09', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjByasjUvCRxybuUQxAc-CBeI\",\"item\":[]}"]', N'2020-10-22 10:35:46', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1031, N'aba55665-555e-4ad9-9d7b-fbfd7033fda2', N'微信素材操作', 1, N'["{\"errcode\":40007,\"errmsg\":\"invalid media_id hint: [bGoQca0272d228] rid: 5f90f468-4cc7fedf-3a18ed76\"}"]', N'2020-10-22 10:54:34', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1032, N'4a153020-4a31-4bb2-bcb6-5f62aae17e2a', N'微信素材操作', 1, N'["{\"errcode\":40007,\"errmsg\":\"invalid media_id hint: [XEKyba03108236] rid: 5f90f48e-005bbfb1-12c79165\"}"]', N'2020-10-22 10:55:27', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1033, N'10c062d5-fe66-4ebc-bbea-b569584dc02f', N'微信素材操作', 1, N'["{\"errcode\":40007,\"errmsg\":\"invalid media_id hint: [J5ugMA04322217] rid: 5f90f508-4d2d343f-5804a6ec\"}"]', N'2020-10-22 10:57:14', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1034, N'c8275c0a-f5e8-4b3f-866e-3114cd0fcdfc', N'微信素材操作', 1, N'["{\"media_id\":\"wy9-6ie4coVTcM-hUKfjB_yFj6XjSODF5mw4z8wc5d8\",\"item\":[]}"]', N'2020-10-22 11:17:25', N'Wx_Data/AddMaterialList')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1035, N'e87aba2c-5823-41ba-bc48-2ce8999611d1', N'微信素材操作', 3, N'"{\"errcode\":0,\"errmsg\":\"ok\"}"', N'2020-10-22 15:00:30', N'Wx_Data/DeleteSC')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1036, N'd121c8a6-88e5-4dc8-a0bf-53a28d6f78f5', N'微信素材操作', 3, N'"{\"errcode\":0,\"errmsg\":\"ok\"}"', N'2020-10-22 15:00:34', N'Wx_Data/DeleteSC')
INSERT [dbo].[Sys_logEntity] ([Id], [GuId], [Name], [Type], [Content], [CreateTime], [Action]) VALUES (1037, N'753118be-3d12-49ec-9173-b4681e8fb1a4', N'微信素材操作', 3, N'"{\"errcode\":0,\"errmsg\":\"ok\"}"', N'2020-10-22 15:00:39', N'Wx_Data/DeleteSC')
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
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (16, N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', N'系统菜单', N'sysMenu', N'0', N'Mg_Sys/Sys_Menu.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (38, N'4F262545-8D8B-4BB1-AF5A-96BEB498B053', N'微信日志', N'wx_log', N'12', N'Mg_Log/Wx_Log/index.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (45, N'58606827-e11d-4fde-8dd5-709952e26878', N'配置管理', N'wxconfig', N'1', NULL, 0, 0, N'expand', N'2020-10-11 15:25:21')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (46, N'157ea435-26a3-4e66-8c25-e52404c64d9b', N'用户管理', N'wxuserlist', N'1', NULL, 0, 1, N'expand', N'2020-10-11 15:26:33')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (47, N'ed13e028-c027-4f88-a153-e1b03c88e3d9', N'其他管理', N'wxother', N'1', NULL, 0, 3, N'expand', N'2020-10-11 15:28:12')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (48, N'499cca62-112a-4ab4-bfec-3cc1d22247d0', N'模板维护', N'wxtemp', N'46', N'Mg_WXConfig/WXPushTemp.html', 0, 0, N'iframe', N'2020-10-11 17:06:46')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (49, N'a6d2b32b-4705-46bc-8e0d-773819bdc252', N'推送记录', N'pushRo', N'46', N'Mg_WXConfig/WXPushRecord.html', 0, 0, N'iframe', N'2020-10-14 16:47:05')
SET IDENTITY_INSERT [dbo].[Sys_MenuEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_MaterialEntity] ON 

INSERT [dbo].[Wx_MaterialEntity] ([Id], [GuId], [Type], [Content], [Media_Id], [Introduction], [Url], [PathUrl], [CreateTime], [WxAppId]) VALUES (6, N'fbf8a42a-667e-45dd-b30a-856b76e92ba5', N'news', N'{"articles":[{"title":"测试","thumb_media_id":"wy9-6ie4coVTcM-hUKfjB5ieGI_vd8XUmzNI0UBK2eE","author":"测试","digest":"测试","show_cover_pic":0,"content":"测试","content_source_url":"https://www.baidu.com/","need_open_comment":0,"only_fans_can_comment":1}]}', N'wy9-6ie4coVTcM-hUKfjB_yFj6XjSODF5mw4z8wc5d8', N'', N'', N'', N'2020-10-22 11:17:24', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_MaterialEntity] OFF
SET IDENTITY_INSERT [dbo].[Wx_MenuEntity] ON 

INSERT [dbo].[Wx_MenuEntity] ([Id], [GuId], [WxAppId], [Content], [CreateTime]) VALUES (2, N'29fd4097-c21c-47d3-8898-82e8f1248a83', N'wxf4d49d7ee1a463be', N'{"menu":{"button":[{"name":"baid ","sub_button":[{"type":"view","name":"110","url":"http:\/\/www.baidu.com","sub_button":[]},{"type":"view","name":"0000","url":"http:\/\/www.baidu.com","sub_button":[]},{"type":"view","name":"ces","url":"http:\/\/www.baidu.com","sub_button":[]}]},{"type":"pic_sysphoto","name":"扫一扫","key":"tup","sub_button":[]},{"name":"扫码","sub_button":[{"type":"location_select","name":"当前位置","key":"loc","sub_button":[]},{"type":"scancode_waitmsg","name":"扫码","key":"q","sub_button":[]}]}]}}', N'2020-10-11 14:57:31')
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

INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1007, N'b5cf02b7-dd56-487f-99ba-92a264d74f8b', N'oF6zUwrLBSHhn_EsWuUnnzBXJe_4', N'lzf', N'中国江苏', N'http://thirdwx.qlogo.cn/mmopen/Q3auHgzwzM7KuWyYqJUEKB1prexWz7icsRFcOW7x44icjfaia0fkBickxmUkIK6MzxrIh5SFuAflDIayF10yic679VWuVJEjLgOrIGdQezRgDBC4/132', 1, N'1597219940', N'2020-10-22 09:28:46', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1008, N'c240ec78-2a80-4777-b30d-997705474e48', N'oF6zUwh918mV1b16D630Cr3pHIA4', N'ERROI', N'中国江苏苏州', N'http://thirdwx.qlogo.cn/mmopen/HLIibDmaSEVMOCDkhlTZiciaCRdianI0yP4nK63vCfiaddMZRQ00nK7euEKH6yI0hvmp8LE9wg8fVrYU3Bz8z74v7N63qPXWPG6lT/132', 1, N'1597713323', N'2020-10-22 09:28:46', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1009, N'4db6c95d-2c17-4884-bade-a975eafa2b32', N'oF6zUwjD4kuYfHYkBpogsNx_YtkQ', N'+7', N'比利时', N'http://thirdwx.qlogo.cn/mmopen/EtUakuZ0XRLPXpTBbyxEzNuckek31nEibaG5zUQ8mWqwk57ndia48tYkqAl9T5bza7oQFPP3EsEdbeGBnTNaeAK72JmBWGxN7J/132', 2, N'1602559726', N'2020-10-22 09:28:46', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1010, N'b36e39ca-4733-4eda-bc14-c97f7ec3b484', N'oF6zUwgqaPqHnNcRoaU3aA8wYv1U', N'包子', N'中国江苏苏州', N'http://thirdwx.qlogo.cn/mmopen/cFEsMsQm6lGkoabVicNhov9LXfYlBqkdGRYGaLBU5Sjm7dh9zZHz1y7Fe4ZY0TuDtHBSEGypVyCfJK3Wgub4lEYJaV0iaEk3or/132', 1, N'1597556619', N'2020-10-22 09:28:46', N'wxf4d49d7ee1a463be')
INSERT [dbo].[Wx_UserEntity] ([Id], [GuId], [Openid], [Nickname], [Address], [Headimgurl], [Sex], [SubscribeTime], [CreateTime], [WxAppId]) VALUES (1011, N'eeacc30f-2edb-4573-badb-0d320cd03c4c', N'oF6zUwucqESM98AMjzgYck_gtCHo', N'张岩', N'中国江苏徐州', N'http://thirdwx.qlogo.cn/mmopen/HLIibDmaSEVMOCDkhlTZiciaBThAclrxjHTQ2BzHvFOVQbHibtXc7Nn2ichujIygqE1zSd6Xc3m1ylib2X6KYyr7wQZbOeyRicia7PR3/132', 1, N'1603330121', N'2020-10-22 09:28:46', N'wxf4d49d7ee1a463be')
SET IDENTITY_INSERT [dbo].[Wx_UserEntity] OFF
USE [master]
GO
ALTER DATABASE [Wx_Mg] SET  READ_WRITE 
GO
