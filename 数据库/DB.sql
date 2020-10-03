USE [Wx_Mg]
GO
/****** Object:  Table [dbo].[Sys_logEntity]    Script Date: 2020/10/3 17:52:21 ******/
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
/****** Object:  Table [dbo].[Sys_MenuEntity]    Script Date: 2020/10/3 17:52:21 ******/
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
/****** Object:  Table [dbo].[Wx_EvenMessageEntity]    Script Date: 2020/10/3 17:52:21 ******/
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
/****** Object:  Table [dbo].[Wx_MenuEntity]    Script Date: 2020/10/3 17:52:21 ******/
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
/****** Object:  Table [dbo].[Wx_MessageEntity]    Script Date: 2020/10/3 17:52:21 ******/
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
SET IDENTITY_INSERT [dbo].[Sys_MenuEntity] ON 

INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (1, N'08080707-2116-46B2-9904-97C86DDDB577', N'微信管理', N'WX', N'0', N'', 0, 0, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (2, N'63246CA4-766A-4691-8019-D0697BE198E5', N'基本配置', N'WXConfig', N'1', N'Mg_WXConfig/index.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (3, N'914F5733-83C9-4C93-9BD0-2BCD8C994F4F', N'微信菜单配置', N'WMenu', N'1', N'Mg_WXConfig/Menu.html', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (4, N'B8AF1779-2754-41EA-A4B5-A6AEB673C78B', N'微信关注用户', N'WUser', N'1', N'Mg_WXConfig/User.html', 0, 2, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (5, N'4AEB51EF-489A-495D-BA7A-DD7D05FA17A2', N'自动回复', N'WReply', N'1', N'Mg_TokenConfig/WReply.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (6, N'2B855D72-8CAA-4133-8128-C89FAED41C18', N'微信基本操作类', N'WXcommon', N'1', NULL, 0, 4, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (7, N'0A40EC40-BF93-47CC-ABA7-8A807D44AB7A', N'Token/JsapiTicket', N'WToken', N'6', N'Mg_WXConfig/Token.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (8, N'33EB4F97-0196-4C2F-B9D1-E552B7923D42', N'素材总数', N'WMaterial', N'6', N'Mg_WXMaterial/Material.html', 0, 4, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (9, N'7E8518DC-8364-47D8-822E-C95E254E3190', N'获取永久素材', N'WMaterialList', N'6', N'Mg_WXMaterial/MaterialList.html', 0, 2, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (10, N'BFF8E440-CDF8-4669-8C9A-1E729C69D302', N'上传素材', N'WAddMaterial', N'6', N'Mg_WXMaterial/AddMaterial.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (11, N'D9223636-EDC2-4B3B-9DB6-9182318C8D20', N'微信推送', N'WPush', N'6', N'Mg_WXConfig/WXPush.html', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (12, N'039F7ACE-A6FB-4943-93E0-BFDB6F452E11', N'日志管理', N'Log', N'0', N'', 0, 2, N'expand', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (14, N'4F262545-8D8B-4BB1-AF5A-96BEB498B012', N'系统日志', N'syslog', N'12', N'Mg_Log/Sys_Log', 0, 1, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (16, N'4F262545-8D8B-4BB1-AF5A-96BEB498B015', N'系统菜单', N'sysMenu', N'0', N'Mg_Sys/Sys_Menu.html', 0, 3, N'iframe', N'2020-09-27 9:50:00')
INSERT [dbo].[Sys_MenuEntity] ([Id], [GuId], [Name], [Number], [SuperiorId], [Address], [IsDel], [Sort], [Type], [CreateTime]) VALUES (38, N'4F262545-8D8B-4BB1-AF5A-96BEB498B053', N'微信日志', N'wx_log', N'12', N'Mg_Log/Wx_Log/index.html', 0, 0, N'iframe', N'2020-09-27 9:50:00')
SET IDENTITY_INSERT [dbo].[Sys_MenuEntity] OFF
