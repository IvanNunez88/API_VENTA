using FluentValidation;
using MODELS.PRODUCTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PRODUCTO.Validator
{
    public class ValidacionAltaProducto : AbstractValidator<DtoAltaProducto>
    {
        public ValidacionAltaProducto()
        {
            RuleFor(x => x.Descrip).NotEmpty().WithMessage("Debe escribir un producto")
                                   .MinimumLength(2).WithMessage("La descripción del producto no es valido");
            RuleFor(x => x.IdProveedor).GreaterThan(0).WithMessage("Debe indicar un Proveedor");
            RuleFor(x => x.IVA).GreaterThan(0).WithMessage("Ingrese un IVA mayor a 0");
            RuleFor(x => x.PVenta).GreaterThan(0).WithMessage("El precio de venta debe ser mayor a 0");
        }


    }
}
