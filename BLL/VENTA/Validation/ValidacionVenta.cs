using FluentValidation;
using MODELS.VENTA.DTO;

namespace BLL.VENTA.Validation
{
    public class ValidacionVenta : AbstractValidator<DtoCarrito>
    {

        public ValidacionVenta()
        {
            RuleFor(x => x.Pago).GreaterThanOrEqualTo(1).WithMessage("revise que el monto del pago sea mayor a 0");
            RuleFor(x => x.CarritoDetalles).NotEmpty().WithMessage("Debe mandar un detalle de venta");
        }


    }
}
