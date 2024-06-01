namespace MODELS.PROVEEDOR.DTO
{
    public record DtoAltaProveedor
    {
        public int IdProveedor { get; set; } = 0; 
        public string Nombre { get; init; } = string.Empty;
        public string RFC { get; init; } = string.Empty;
        public string Contacto { get; init; } = string.Empty;
        public bool IsActivo { get; set; } = false;
    }
}
