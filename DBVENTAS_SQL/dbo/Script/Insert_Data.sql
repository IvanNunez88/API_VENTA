USE [DBVENTAS]
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR] ON 
GO
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [RFC], [Contacto], [IsActivo], [FecAlta]) VALUES (1000, N'Manuel Fernandez Prueba', N'aaaaaaaaaaaa', N'Juan Valdez Prueba', 0, CAST(N'2024-05-25T09:33:00' AS SmallDateTime))
GO
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [RFC], [Contacto], [IsActivo], [FecAlta]) VALUES (1001, N'Vanesa Perez Ayala', N'bbbbbbbbbbbb', N'Juan Luis Martinez', 1, CAST(N'2024-05-25T09:35:00' AS SmallDateTime))
GO
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [RFC], [Contacto], [IsActivo], [FecAlta]) VALUES (1002, N'Mario Quiroz Muñoz', N'cccccccccccc', N'Jessica Alvarado Madero', 1, CAST(N'2024-05-25T09:35:00' AS SmallDateTime))
GO
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [RFC], [Contacto], [IsActivo], [FecAlta]) VALUES (1003, N'Juan Perez Perez', N'dddddddddddd', N'Juan Carlos Muñoz Ayala', 1, CAST(N'2024-05-25T10:23:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 
GO
INSERT [dbo].[PRODUCTO] ([IdProducto], [Descrip], [SKU], [CB], [IdProveedor], [IVA], [PVenta], [IsActivo], [FecAlta]) VALUES (2, N'Marcador para pizarrón Azul', NULL, N'7501811272387', 1000, CAST(16.00 AS Decimal(5, 2)), CAST(25.60 AS Decimal(12, 2)), 1, CAST(N'2024-05-25T10:58:00' AS SmallDateTime))
GO
INSERT [dbo].[PRODUCTO] ([IdProducto], [Descrip], [SKU], [CB], [IdProveedor], [IVA], [PVenta], [IsActivo], [FecAlta]) VALUES (4, N'Prueba', NULL, N'7501159551014', 1001, CAST(16.00 AS Decimal(5, 2)), CAST(300.50 AS Decimal(12, 2)), 1, CAST(N'2024-05-25T11:23:00' AS SmallDateTime))
GO
INSERT [dbo].[PRODUCTO] ([IdProducto], [Descrip], [SKU], [CB], [IdProveedor], [IVA], [PVenta], [IsActivo], [FecAlta]) VALUES (5, N'a Prueba', N'1450', NULL, 1002, CAST(16.00 AS Decimal(5, 2)), CAST(26.60 AS Decimal(12, 2)), 1, CAST(N'2024-05-25T11:47:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
SET IDENTITY_INSERT [dbo].[VENTA] ON 
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (1, CAST(1500.00 AS Decimal(12, 2)), CAST(357.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:05:38.390' AS DateTime))
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (2, CAST(1600.00 AS Decimal(12, 2)), CAST(457.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:07:11.787' AS DateTime))
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (3, CAST(1800.00 AS Decimal(12, 2)), CAST(657.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:13:23.450' AS DateTime))
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (4, CAST(1800.00 AS Decimal(12, 2)), CAST(657.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:16:02.467' AS DateTime))
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (5, CAST(1800.00 AS Decimal(12, 2)), CAST(657.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:17:58.067' AS DateTime))
GO
INSERT [dbo].[VENTA] ([IdVenta], [Pago], [Cambio], [FecVenta]) VALUES (6, CAST(2000.00 AS Decimal(12, 2)), CAST(857.40 AS Decimal(12, 2)), CAST(N'2024-06-01T10:19:27.197' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VENTA] OFF
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (2, 2, 15, CAST(25.60 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (2, 4, 2, CAST(300.50 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (5, 2, 15, CAST(25.60 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (5, 4, 2, CAST(300.50 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (6, 2, 15, CAST(25.60 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[VENTA_DETALLE] ([IdVenta], [IdProducto], [Cantidad], [PVenta], [IVA]) VALUES (6, 4, 2, CAST(300.50 AS Decimal(12, 2)), CAST(16.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[COMPONENTE] ON 
GO
INSERT [dbo].[COMPONENTE] ([IdComponente], [Descrip], [Usuario], [Contra], [GUID], [FecRegistro]) VALUES (100, N'app web Angular', N'angular123', N'angular124', N'29EF0DC9-BF48-4ACE-BDA7-864D77DF6B15', CAST(N'2024-06-01T10:41:49.117' AS DateTime))
GO
INSERT [dbo].[COMPONENTE] ([IdComponente], [Descrip], [Usuario], [Contra], [GUID], [FecRegistro]) VALUES (101, N'app mobile Android', N'android123', N'android123', N'716B7101-309B-4414-9DD5-1EB9827F6BAE', CAST(N'2024-06-01T10:41:49.120' AS DateTime))
GO
INSERT [dbo].[COMPONENTE] ([IdComponente], [Descrip], [Usuario], [Contra], [GUID], [FecRegistro]) VALUES (102, N'app mobile IOS', N'ios123', N'ios123', N'7F8C5F13-0F1A-4E29-9161-F51B657FFEA0', CAST(N'2024-06-01T10:41:49.120' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[COMPONENTE] OFF
GO
