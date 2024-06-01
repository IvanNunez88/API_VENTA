namespace MODELS.PRODUCTO.DTO;

public sealed record DtoConsulProducto(
    int IdProducto,
    string? Nombre,
    string? SKU,
    string? CB,
    string? Proveedor,
    decimal IVA,
    decimal PVenta,
    string? Estatus,
    string? FecAlta
    );

