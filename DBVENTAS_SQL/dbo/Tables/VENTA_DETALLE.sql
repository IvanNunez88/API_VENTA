CREATE TABLE [dbo].[VENTA_DETALLE] (
    [IdVenta]    INT             NOT NULL,
    [IdProducto] INT             NOT NULL,
    [Cantidad]   INT             NOT NULL,
    [PVenta]     DECIMAL (12, 2) NULL,
    [IVA]        DECIMAL (5, 2)  NOT NULL,
    CONSTRAINT [FK_IdProducto_VED] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTO] ([IdProducto]),
    CONSTRAINT [FK_IdVenta_VED] FOREIGN KEY ([IdVenta]) REFERENCES [dbo].[VENTA] ([IdVenta])
);

