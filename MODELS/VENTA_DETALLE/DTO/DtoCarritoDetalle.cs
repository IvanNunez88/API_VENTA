namespace MODELS.VENTA_DETALLE.DTO;

public record DtoCarritoDetalle(
    int IdProducto,
    int Cantidad,
    decimal PVenta,
    decimal IVA
    );

