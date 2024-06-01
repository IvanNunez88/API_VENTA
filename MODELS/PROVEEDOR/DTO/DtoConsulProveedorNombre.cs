namespace MODELS.PROVEEDOR.DTO
{
    public record DtoConsulProveedorNombre
    {
        public int IdProveedor { get; init; } = 0;
        public string? Nombre { get; init; } = string.Empty;
        public string? RFC { get; init; } = string.Empty;
        public string? Contacto { get; init; } = string.Empty;
        public string? Estatus { get; init; } = string.Empty;
        public string? FecAlta { get; init; } = string.Empty;
    }

}
