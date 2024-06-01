using MODELS.VENTA_DETALLE.DTO;

namespace MODELS.VENTA.DTO;

public record DtoCarrito
{
    public decimal Pago { get; set; }
    public List<DtoCarritoDetalle> CarritoDetalles { get; set; }

}
