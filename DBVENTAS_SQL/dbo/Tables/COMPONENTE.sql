CREATE TABLE [dbo].[COMPONENTE] (
    [IdComponente] TINYINT       IDENTITY (100, 1) NOT NULL,
    [Descrip]      VARCHAR (150) NOT NULL,
    [Usuario]      VARCHAR (25)  NOT NULL,
    [Contra]       VARCHAR (25)  NOT NULL,
    [GUID]         VARCHAR (40)  CONSTRAINT [DF_GUID_COM] DEFAULT (newid()) NOT NULL,
    [FecRegistro]  DATETIME      CONSTRAINT [DF_FecRegistro_COM] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_IdComponente_COM] PRIMARY KEY CLUSTERED ([IdComponente] ASC)
);

