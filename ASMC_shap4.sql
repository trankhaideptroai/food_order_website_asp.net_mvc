USE [ASMC_shap4]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart_detail]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderStatus] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/18/2024 5:03:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Image] [nvarchar](255) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[CategoryId] [int] NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'combo')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'hamburger')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'khoaitaychien')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Nước')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Username], [Password], [Email], [FullName], [Role], [Address], [Phone]) VALUES (3, N'vu', N'123', N'vu@example.com', N'John Doe', N'Admin', N'123 Main St', N'1234567890')
INSERT [dbo].[Customers] ([Id], [Username], [Password], [Email], [FullName], [Role], [Address], [Phone]) VALUES (4, N'vu123', N'123', N'vutdhps40138@gmail.com', N'Trịnh Duy Hoàng Vũ', N'Customer', N'210phamvanhai', N'0866977335')
INSERT [dbo].[Customers] ([Id], [Username], [Password], [Email], [FullName], [Role], [Address], [Phone]) VALUES (5, N'vuu', N'123', N'vutdhps40138@gmail.com', N'Trịnh Duy Hoàng Vũ', N'Customer', N'210phamvanhai', N'0866977335')
INSERT [dbo].[Customers] ([Id], [Username], [Password], [Email], [FullName], [Role], [Address], [Phone]) VALUES (6, N'vub', N'123', N'vutdhps40138@gmail.com', N'Trịnh Duy Hoàng Vũ', N'Customer', N'210phamvanhai', N'0866977335')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 1, 4, 1, CAST(422.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 2, 5, 1, CAST(422.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (3, 2, 4, 1, CAST(422.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 2, 3, 1, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 3, 3, 1, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (6, 4, 3, 3, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (7, 4, 4, 3, CAST(422.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (8, 5, 5, 5, CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (9, 5, 6, 3, CAST(1300.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (10, 5, 9, 2, CAST(13200.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (1008, 1005, 5, 2, CAST(1200.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (1, 5, CAST(422.00 AS Decimal(18, 2)), CAST(N'2024-11-15T19:20:59.177' AS DateTime), N'Completed', N'210phamvanhai', N'0866977335')
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (2, 5, CAST(859.00 AS Decimal(18, 2)), CAST(N'2024-11-15T19:22:06.837' AS DateTime), N'Pending', N'210phamvanhai', N'0866977335')
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (3, 3, CAST(15.00 AS Decimal(18, 2)), CAST(N'2024-11-17T18:44:46.907' AS DateTime), N'Shipped', N'123 Main St', N'1234567890')
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (4, 3, CAST(1311.00 AS Decimal(18, 2)), CAST(N'2024-11-17T18:46:43.253' AS DateTime), N'Pending', N'123 Main St', N'1234567890')
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (5, 3, CAST(36300.00 AS Decimal(18, 2)), CAST(N'2024-11-17T22:11:50.680' AS DateTime), N'Shipped', N'123 Main St', N'1234567890')
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [OrderDate], [OrderStatus], [Address], [Phone]) VALUES (1005, 3, CAST(2400.00 AS Decimal(18, 2)), CAST(N'2024-11-18T16:49:07.163' AS DateTime), N'Pending', N'123 Main St', N'1234567890')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (5, N'hamburger a1', N'https://junger.vn/medias/jungerb/images/hamburger-thit-heo-nuong.jpg', CAST(1200.00 AS Decimal(10, 2)), 1, N'hamburger ko dầu')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (6, N'hamburger b2', N'https://superfoods.vn/wp-content/uploads/2023/07/banh-mi-hamburger-truyen-thong.jpeg', CAST(1300.00 AS Decimal(10, 2)), 1, N'hamburger béo ngậy')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (7, N'hamburger', N'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cheeseburger.jpg/800px-Cheeseburger.jpg', CAST(12222.00 AS Decimal(10, 2)), 1, N'supper thịt')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (8, N'hamburger c2', N'https://superfoods.vn/wp-content/uploads/2023/07/Hamburger-ga.jpg', CAST(5500.00 AS Decimal(10, 2)), 1, N'thập cẩm
')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (9, N'khoai tây chiên a1', N'https://cdn.tgdd.vn/Files/2015/03/01/615221/bi-quyet-lam-moi-khoai-tay-chien-cu-5-760x367.jpg', CAST(13200.00 AS Decimal(10, 2)), 2, N'100% khoai tây 200% bột')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (10, N'khoai tây chiên', N'https://getngo.vn/wp-content/uploads/2023/04/khoai-tay-chien-7.jpg', CAST(23220.00 AS Decimal(10, 2)), 2, N'full khoai tây')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (11, N'khoai tây chiên vc', N'https://www.lottemart.vn/media/catalog/product/cache/0x0/0/4/0400285530009-1.jpg.webp', CAST(1000.00 AS Decimal(10, 2)), 2, N'phần mang về')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (12, N'khoai tây chiên', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMdqKJU6_eNCdFRsglwcu7kS4dTAFw6Igo0w&s', CAST(12222.00 AS Decimal(10, 2)), 2, N'ăn kềm vs salat')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (13, N'combo double', N'https://png.pngtree.com/png-vector/20240308/ourlarge/pngtree-hamburger-fries-and-cola-png-image_11916327.png', CAST(5500.00 AS Decimal(10, 2)), 3, N'phần đủ cho 2 người ăn')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (14, N'combo2', N'https://png.pngtree.com/png-vector/20240206/ourlarge/pngtree-hamburger-fries-and-cola-png-image_11668169.png', CAST(25000.00 AS Decimal(10, 2)), 3, N'hamburger + nước + khoai tây')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (15, N'combo1', N'https://stockdep.net/files/images/35895009.jpg', CAST(30000.00 AS Decimal(10, 2)), 3, N'combo đong đầy')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (17, N'cocacola', N'https://www.coca-cola.com/content/dam/onexp/vn/home-image/coca-cola/Coca-Cola_OT%20320ml_VN-EX_Desktop.png', CAST(1500.00 AS Decimal(10, 2)), 4, N'nước')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (18, N'cocacola', N'https://cdn-images.kiotviet.vn/nhaphanphoidouongbachkhoa/53afdddca028419985fb851e22d465e4.jpg', CAST(12222.00 AS Decimal(10, 2)), 4, N'coca chai')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (19, N'pepsi', N'https://product.hstatic.net/200000407109/product/nuoc-ngot-pepsi-cola-330ml-202008131510316142_8307f014cca54f87883652601bca9600_1024x1024.jpg', CAST(1000.00 AS Decimal(10, 2)), 4, N'dvsbvbsd')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (20, N'pepsi', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtytX1iKLCF_98zeaDHFqTliqjaF2pq_oHTQ&s', CAST(15221.99 AS Decimal(10, 2)), 4, N'x2 5%')
INSERT [dbo].[Products] ([Id], [Name], [Image], [Price], [CategoryId], [Description]) VALUES (21, N'warior ', N'https://www.lottemart.vn/media/catalog/product/cache/0x0/8/8/8850228006733-1.jpg.webp', CAST(19.99 AS Decimal(10, 2)), 3, N'nu?c v? nho 250ml')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Cart_detail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
