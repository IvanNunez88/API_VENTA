CREATE TABLE [dbo].[PRODUCTO] (
    [IdProducto]  INT             IDENTITY (1, 1) NOT NULL,
    [Descrip]     VARCHAR (60)    NOT NULL,
    [SKU]         VARCHAR (4)     NULL,
    [CB]          VARCHAR (15)    NULL,
    [IdProveedor] INT             NOT NULL,
    [IVA]         DECIMAL (5, 2)  NOT NULL,
    [PVenta]      DECIMAL (12, 2) NULL,
    [IsActivo]    BIT             CONSTRAINT [DF_IsActivo_PRD] DEFAULT ((1)) NOT NULL,
    [FecAlta]     SMALLDATETIME   CONSTRAINT [DF_FecAlta_PRD] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_IdProducto_PRD] PRIMARY KEY CLUSTERED ([IdProducto] ASC),
    CONSTRAINT [FK_IdProveedor_PRD] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
);

