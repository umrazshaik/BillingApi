USE [BillingAppDB]
GO
/****** Object:  Table [dbo].[BILLING_INFO]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BILLING_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BILL_ID] [int] NULL,
	[QUANTITY] [int] NULL,
	[PRODUCT_ID] [int] NULL,
	[PRICE] [float] NULL,
	[TAX] [float] NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[UPDATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_BILLING_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BILLING_TAX_INFO]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BILLING_TAX_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BILL_ID] [int] NULL,
	[TAX_ID] [int] NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[UPDATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_BILLING_TAX_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BILLINGS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BILLINGS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BILL_NO] [bigint] NULL,
	[RETAIL_ID] [int] NOT NULL,
	[USER_ID] [int] NULL,
	[CUSTOMER_ID] [int] NULL,
	[PAID_AMOUNT] [float] NULL,
	[TAX_AMOUNT] [float] NULL,
	[ACTUAL_AMOUNT] [float] NULL,
	[BILLED_AMOUNT] [float] NULL,
	[PAYMENT_TYPE] [varchar](50) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[UPDATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_BILLINGS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BRANDS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BRANDS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RETAIL_ID] [int] NULL,
	[NAME] [varchar](100) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](100) NULL,
	[UPDATED_BY] [varchar](100) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_BRANDS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CART]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CART](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ITEM_ID] [int] NOT NULL,
	[RETAIL_ID] [int] NOT NULL,
	[USER_ID] [int] NULL,
	[QUANTITY] [int] NOT NULL,
	[STATUS] [bit] NULL,
 CONSTRAINT [PK_CART] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMERS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CUSTOMERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RETAIL_ID] [int] NULL,
	[NAME] [varchar](100) NULL,
	[MOBILE] [int] NULL,
	[EMAIL] [varchar](100) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](100) NULL,
	[UPDATED_BY] [varchar](100) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCT_TYPE]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCT_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RETAIL_ID] [int] NULL,
	[TYPE] [varchar](100) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](100) NULL,
	[UPDATED_BY] [varchar](100) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_PRODUCT_TYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCTS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](100) NULL,
	[DISPLAY_NAME] [varchar](200) NULL,
	[CODE] [varchar](100) NULL,
	[TYPE_ID] [int] NULL,
	[BRAND_ID] [int] NULL,
	[RETAIL_ID] [int] NULL,
	[SELLING_PRICE] [float] NULL,
	[ACTUAL_PRICE] [float] NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](100) NULL,
	[UPDATED_BY] [varchar](100) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
 CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RETAILERS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RETAILERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](100) NULL,
	[DISPLAY_NAME] [varchar](200) NULL,
	[ADDRESS] [varchar](1000) NULL,
	[MOBILE] [bigint] NULL,
	[ALTERNATE_MOB] [bigint] NULL,
	[PIN_CODE] [int] NULL,
	[CITY] [varchar](50) NULL,
	[DISTRICT] [varchar](50) NULL,
	[STATE] [varchar](50) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[UPDATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_RETAILERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAXES]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAXES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](100) NULL,
	[TAX_TYPE] [varchar](100) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](100) NULL,
	[UPDATED_BY] [varchar](100) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TAXES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 12/20/2019 10:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RETAIL_ID] [int] NULL,
	[NAME] [varchar](100) NULL,
	[DISPLAY_NAME] [varchar](200) NULL,
	[STATUS] [bit] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[UPDATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BRANDS] ON 

INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (4, 1, N'Mi3', 1, N'admin', N'admin', CAST(N'2019-12-20 20:12:25.127' AS DateTime), CAST(N'2019-12-20 20:25:51.650' AS DateTime))
INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (6, 1, N'Oppo', 1, N'admin', N'admin', CAST(N'2019-12-20 20:25:43.117' AS DateTime), CAST(N'2019-12-20 20:25:43.117' AS DateTime))
INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (8, 1, N'Realme', 1, N'admin', N'admin', CAST(N'2019-12-20 20:28:32.927' AS DateTime), CAST(N'2019-12-20 20:28:32.927' AS DateTime))
INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (9, 1, N'OnePlus', 1, N'admin', N'admin', CAST(N'2019-12-20 20:28:47.883' AS DateTime), CAST(N'2019-12-20 20:28:47.883' AS DateTime))
INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (11, 1, N'Samsung', 1, N'admin', N'admin', CAST(N'2019-12-20 21:23:26.430' AS DateTime), CAST(N'2019-12-20 21:23:26.430' AS DateTime))
INSERT [dbo].[BRANDS] ([ID], [RETAIL_ID], [NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (12, 1, N'Sony', 1, N'admin', N'admin', CAST(N'2019-12-20 21:48:01.943' AS DateTime), CAST(N'2019-12-20 21:48:01.943' AS DateTime))
SET IDENTITY_INSERT [dbo].[BRANDS] OFF
SET IDENTITY_INSERT [dbo].[CART] ON 

INSERT [dbo].[CART] ([ID], [ITEM_ID], [RETAIL_ID], [USER_ID], [QUANTITY], [STATUS]) VALUES (1, 1, 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[CART] OFF
SET IDENTITY_INSERT [dbo].[PRODUCT_TYPE] ON 

INSERT [dbo].[PRODUCT_TYPE] ([ID], [RETAIL_ID], [TYPE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (46, 1, N'Mobile', 1, N'admin', NULL, CAST(N'2019-12-20 19:22:09.847' AS DateTime), CAST(N'2019-12-20 19:22:09.847' AS DateTime))
INSERT [dbo].[PRODUCT_TYPE] ([ID], [RETAIL_ID], [TYPE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (47, 1, N'Laptops', 1, N'admin', NULL, CAST(N'2019-12-20 19:26:37.330' AS DateTime), CAST(N'2019-12-20 19:26:37.333' AS DateTime))
SET IDENTITY_INSERT [dbo].[PRODUCT_TYPE] OFF
SET IDENTITY_INSERT [dbo].[PRODUCTS] ON 

INSERT [dbo].[PRODUCTS] ([ID], [NAME], [DISPLAY_NAME], [CODE], [TYPE_ID], [BRAND_ID], [RETAIL_ID], [SELLING_PRICE], [ACTUAL_PRICE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATE_DATE]) VALUES (1, N'redmik20pro', N'redmi k20 pro', NULL, 46, 8, 1, 23000, 28000, 1, N'admin', NULL, CAST(N'2019-12-20 21:17:11.447' AS DateTime), CAST(N'2019-12-20 21:17:11.477' AS DateTime))
INSERT [dbo].[PRODUCTS] ([ID], [NAME], [DISPLAY_NAME], [CODE], [TYPE_ID], [BRAND_ID], [RETAIL_ID], [SELLING_PRICE], [ACTUAL_PRICE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATE_DATE]) VALUES (2, N'redmi', N'redmi', N'k20pro', 46, 8, 1, 23000, 28000, 1, N'admin', NULL, CAST(N'2019-12-20 21:26:36.150' AS DateTime), CAST(N'2019-12-20 21:26:36.150' AS DateTime))
INSERT [dbo].[PRODUCTS] ([ID], [NAME], [DISPLAY_NAME], [CODE], [TYPE_ID], [BRAND_ID], [RETAIL_ID], [SELLING_PRICE], [ACTUAL_PRICE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATE_DATE]) VALUES (3, N'redmi', N'redmi', N'k20pro', 46, 4, 1, 23000, 28000, 1, N'admin', NULL, CAST(N'2019-12-20 21:28:54.117' AS DateTime), CAST(N'2019-12-20 21:28:54.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[PRODUCTS] OFF
SET IDENTITY_INSERT [dbo].[RETAILERS] ON 

INSERT [dbo].[RETAILERS] ([ID], [NAME], [DISPLAY_NAME], [ADDRESS], [MOBILE], [ALTERNATE_MOB], [PIN_CODE], [CITY], [DISTRICT], [STATE], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (1, N'SALMANENTERPRISES', N'SALMAN ENTERPRISES', N'SHOP NO 18, PARIGI BUS STAND MUNICIPAL SHOPPING COMPLEX', 7013203801, 8247751908, 515201, N'Hindupur', N'Anantapur', N'Andhar Pradesh', 1, N'Umraz', N'Umraz', CAST(N'2019-12-17 00:00:00.000' AS DateTime), CAST(N'2019-12-19 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[RETAILERS] OFF
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([ID], [RETAIL_ID], [NAME], [DISPLAY_NAME], [STATUS], [CREATED_BY], [UPDATED_BY], [CREATED_DATE], [UPDATED_DATE]) VALUES (1, 1, N'admin', N'admin', 1, N'Umraz', N'Umraz', CAST(N'2019-12-17 00:00:00.000' AS DateTime), CAST(N'2019-12-17 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[USERS] OFF
ALTER TABLE [dbo].[BILLING_INFO]  WITH CHECK ADD  CONSTRAINT [FK_BILLING_INFO_BILLINGS] FOREIGN KEY([BILL_ID])
REFERENCES [dbo].[BILLINGS] ([ID])
GO
ALTER TABLE [dbo].[BILLING_INFO] CHECK CONSTRAINT [FK_BILLING_INFO_BILLINGS]
GO
ALTER TABLE [dbo].[BILLING_INFO]  WITH CHECK ADD  CONSTRAINT [FK_BILLING_INFO_PRODUCTS] FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[PRODUCTS] ([ID])
GO
ALTER TABLE [dbo].[BILLING_INFO] CHECK CONSTRAINT [FK_BILLING_INFO_PRODUCTS]
GO
ALTER TABLE [dbo].[BILLING_TAX_INFO]  WITH CHECK ADD  CONSTRAINT [FK_BILLING_TAX_INFO_BILLINGS] FOREIGN KEY([BILL_ID])
REFERENCES [dbo].[BILLINGS] ([ID])
GO
ALTER TABLE [dbo].[BILLING_TAX_INFO] CHECK CONSTRAINT [FK_BILLING_TAX_INFO_BILLINGS]
GO
ALTER TABLE [dbo].[BILLING_TAX_INFO]  WITH CHECK ADD  CONSTRAINT [FK_BILLING_TAX_INFO_TAXES] FOREIGN KEY([TAX_ID])
REFERENCES [dbo].[TAXES] ([ID])
GO
ALTER TABLE [dbo].[BILLING_TAX_INFO] CHECK CONSTRAINT [FK_BILLING_TAX_INFO_TAXES]
GO
ALTER TABLE [dbo].[BILLINGS]  WITH CHECK ADD  CONSTRAINT [FK_BILLINGS_CUSTOMERS] FOREIGN KEY([CUSTOMER_ID])
REFERENCES [dbo].[CUSTOMERS] ([ID])
GO
ALTER TABLE [dbo].[BILLINGS] CHECK CONSTRAINT [FK_BILLINGS_CUSTOMERS]
GO
ALTER TABLE [dbo].[BILLINGS]  WITH CHECK ADD  CONSTRAINT [FK_BILLINGS_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[BILLINGS] CHECK CONSTRAINT [FK_BILLINGS_RETAILERS]
GO
ALTER TABLE [dbo].[BRANDS]  WITH CHECK ADD  CONSTRAINT [FK_BRANDS_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[BRANDS] CHECK CONSTRAINT [FK_BRANDS_RETAILERS]
GO
ALTER TABLE [dbo].[CART]  WITH CHECK ADD  CONSTRAINT [FK_CART_PRODUCTS] FOREIGN KEY([ITEM_ID])
REFERENCES [dbo].[PRODUCTS] ([ID])
GO
ALTER TABLE [dbo].[CART] CHECK CONSTRAINT [FK_CART_PRODUCTS]
GO
ALTER TABLE [dbo].[CART]  WITH CHECK ADD  CONSTRAINT [FK_CART_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[CART] CHECK CONSTRAINT [FK_CART_RETAILERS]
GO
ALTER TABLE [dbo].[CART]  WITH CHECK ADD  CONSTRAINT [FK_CART_USERS] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[USERS] ([ID])
GO
ALTER TABLE [dbo].[CART] CHECK CONSTRAINT [FK_CART_USERS]
GO
ALTER TABLE [dbo].[CUSTOMERS]  WITH CHECK ADD  CONSTRAINT [FK_CUSTOMERS_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[CUSTOMERS] CHECK CONSTRAINT [FK_CUSTOMERS_RETAILERS]
GO
ALTER TABLE [dbo].[PRODUCT_TYPE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_TYPE_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[PRODUCT_TYPE] CHECK CONSTRAINT [FK_PRODUCT_TYPE_RETAILERS]
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTS_BRANDS] FOREIGN KEY([BRAND_ID])
REFERENCES [dbo].[BRANDS] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK_PRODUCTS_BRANDS]
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTS_PRODUCT_TYPE] FOREIGN KEY([TYPE_ID])
REFERENCES [dbo].[PRODUCT_TYPE] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK_PRODUCTS_PRODUCT_TYPE]
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTS_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK_PRODUCTS_RETAILERS]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_RETAILERS] FOREIGN KEY([RETAIL_ID])
REFERENCES [dbo].[RETAILERS] ([ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_RETAILERS]
GO
ALTER TABLE [dbo].[USERS]  WITH NOCHECK ADD  CONSTRAINT [FK_USERS_USERS] FOREIGN KEY([ID])
REFERENCES [dbo].[USERS] ([ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_USERS]
GO
