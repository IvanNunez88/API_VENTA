namespace MODELS.PRODUCTO.DTO;

public class DtoAltaProducto
{
    public int IdProducto { get; set; } = 0;
    public string? Descrip { get; set; } = string.Empty;
    public string? SKU { get; set; } = null;
    public string? CB { get; set; } = null;
    public int IdProveedor { get; set; } = 0;
    public decimal IVA { get; set; } = decimal.Zero;
    public decimal PVenta { get; set; } = decimal.Zero;
    public bool IsActivo { get; set; } = true;

}
