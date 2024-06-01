using FluentValidation;
using MODELS.PROVEEDOR.DTO;

namespace BLL.PROVEEDOR.Validator
{
    public class ValidacionAltaProveedor : AbstractValidator<DtoAltaProveedor>
    {

        public ValidacionAltaProveedor()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Debe escribir un nombre")
                                  .MinimumLength(2).WithMessage("El nombre no es valido")
                                  .Must(IsNumero).WithMessage("El nombre del proveedor no puede contener números o caracteres especiales");
            RuleFor(x => x.RFC).NotEmpty().WithMessage("Debe escribir un RFC")
                               .MinimumLength(12).WithMessage("El RFC debe contener por lo menos 12 caracteres")
                               .MaximumLength(13).WithMessage("El RFC no debe contener más de 13 caracteres");
            RuleFor(x => x.Contacto).NotEmpty().WithMessage("Debe escribir un nombre de contacto")
                                   .MinimumLength(2).WithMessage("El nombre de contacto no es valido")
                                   .Must(IsNumero).WithMessage("El nombre del contacto no puede contener números o caracteres especiales");
        }


        private bool IsNumero(string Texto)
        {
            bool Validacion = true;

            foreach (char Letra in Texto.Replace(" ", ""))
            {
                if (!char.IsLetter(Letra))
                {
                    Validacion = false;
                    break;
                }
            }
            return Validacion;
        }

    }
}
