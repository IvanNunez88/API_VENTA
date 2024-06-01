namespace MODELS.PROVEEDOR.DTO;

public record DtoConsuProveedor(
    int IdProveedor,
    string? Nombre, 
    string? RFC, 
    string? Contacto, 
    string? Estatus, 
    string? FecAlta);