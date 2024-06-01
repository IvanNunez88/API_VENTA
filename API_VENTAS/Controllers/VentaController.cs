using API_VENTAS.Context;
using BLL.VENTA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.VENTA.DTO;

namespace API_VENTAS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentaController(DbContext _dbcontext) : ControllerBase
{

    [HttpPost]
    [Route("Venta")]
    public async Task<IActionResult> Venta([FromBody] DtoCarrito Carrito)
    {

        IEnumerable<string> enuValidacion = await BL_VENTA.ValidaCarrito(Carrito);
        Reponse<IEnumerable<string>> rsp = new();

        if (!enuValidacion.Any())
        {
            IEnumerable<string> enuDatos = await BL_VENTA.Venta(_dbcontext.ConnectionSQL(), Carrito);

            if (enuDatos.ToList()[0] == "00")
            {
                rsp.Status = enuDatos.ToList()[0];
                rsp.Value = enuDatos;
            }
            else
            {
                rsp.Status = enuDatos.ToList()[0];
                rsp.Msg = (IEnumerable<string>)enuDatos.ToList()[1].AsEnumerable();
            }

        }
        else
        {
            rsp.Status = "14";
            rsp.Msg = enuValidacion;
        }

        return Ok(rsp);

    }

}
