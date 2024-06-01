CREATE TABLE [dbo].[VENTA] (
    [IdVenta]  INT             IDENTITY (1, 1) NOT NULL,
    [Pago]     DECIMAL (12, 2) NOT NULL,
    [Cambio]   DECIMAL (12, 2) NOT NULL,
    [FecVenta] DATETIME        CONSTRAINT [DF_FecVenta_VEN] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_IdVenta_VEN] PRIMARY KEY CLUSTERED ([IdVenta] ASC)
);

