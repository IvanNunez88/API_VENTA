CREATE PROC [dbo].[spVenta]
(@P_Accion TINYINT,
 @P_Pago decimal (12,2) = NULL,
 @P_Cambio decimal (12,2) = NULL,
 @P_IdVenta INT = NULL ,
 @P_IdProducto INT = NULL,
 @P_Cantidad INT = NULL,
 @P_PVenta DECIMAL(12,2) = NULL,
 @P_IVA DECIMAL(5,2) = NULL)
AS
BEGIN
	SET NOCOUNT ON

	IF @P_Accion =1
	BEGIN
		--VENTA ENCABEZO
		DECLARE @V_IdVenta int

		INSERT INTO VENTA (Pago,Cambio) VALUES (@P_Pago, @P_Cambio)

		SET @V_IdVenta = SCOPE_IDENTITY()

		SELECT @V_IdVenta AS Id

	END

	ELSE IF @P_Accion =2
	BEGIN

		INSERT INTO VENTA_DETALLE (IdVenta,IdProducto,Cantidad,PVenta,IVA) 
						   VALUES (@P_IdVenta, @P_IdProducto, @P_Cantidad, @P_PVenta, @P_IVA)

	END

	SET NOCOUNT OFF
END