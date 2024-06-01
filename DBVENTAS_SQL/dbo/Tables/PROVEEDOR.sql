CREATE TABLE [dbo].[PROVEEDOR] (
    [IdProveedor] INT           IDENTITY (1000, 1) NOT NULL,
    [Nombre]      VARCHAR (120) NOT NULL,
    [RFC]         VARCHAR (13)  NOT NULL,
    [Contacto]    VARCHAR (80)  NULL,
    [IsActivo]    BIT           CONSTRAINT [DF_IsActivo_PRO] DEFAULT ((1)) NOT NULL,
    [FecAlta]     SMALLDATETIME CONSTRAINT [DF_FecAlta_PRO] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_IdProveedor_PRO] PRIMARY KEY CLUSTERED ([IdProveedor] ASC)
);

