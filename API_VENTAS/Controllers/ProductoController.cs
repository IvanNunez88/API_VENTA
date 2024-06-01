using API_VENTAS.Context;
using BLL.PROVEEDOR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.PROVEEDOR.DTO;
using MODELS;
using MODELS.PRODUCTO.DTO;
using BLL.PRODUCTO;

namespace API_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController(DbContext _dbcontext) : ControllerBase
    {

        [HttpPost]
        [Route("AltaProducto")]
        public async Task<IActionResult> AltaProducto([FromBody] DtoAltaProducto AltaProducto)
        {
            IEnumerable<string> enuValidacion = await BL_PRODUCTO.ValidarProducto(AltaProducto);
            Reponse<IEnumerable<string>> rsp = new();

            if (!enuValidacion.Any())
            {
                IEnumerable<string> enuDatos = await BL_PRODUCTO.GuardarProducto(_dbcontext.ConnectionSQL(), AltaProducto);

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

        [HttpGet]
        [Route("ConsultaProducto")]
        public async Task<IActionResult> ConsultaProducto()
        {
            IEnumerable<DtoConsulProducto> enuConsulProducto = await BL_PRODUCTO.ConsultaProducto(_dbcontext.ConnectionSQL());
            Reponse<IEnumerable<DtoConsulProducto>> rsp = new();

            try
            {
                if (enuConsulProducto.Any())
                {
                    rsp.Status = "00";
                    rsp.Value = enuConsulProducto;
                }
                else
                {
                    rsp.Status = "14";
                    rsp.Msg = (IEnumerable<string>)"No se encontro información".AsEnumerable();
                }

            }
            catch (Exception ex)
            {
                rsp.Status = "14";
                rsp.Msg = (IEnumerable<string>)ex.Message.AsEnumerable();

            }

            return Ok(rsp);

        }

        [HttpGet]
        [Route("ConsultaProductoTexto/{Texto}")]
        public async Task<IActionResult> ConsultaProducto(string Texto)
        {
            IEnumerable<DtoConsulProducto> enuConsulProducto = await BL_PRODUCTO.ConsultaProductoTexto(_dbcontext.ConnectionSQL(), Texto);
            Reponse<IEnumerable<DtoConsulProducto>> rsp = new();

            try
            {
                if (enuConsulProducto.Any())
                {
                    rsp.Status = "00";
                    rsp.Value = enuConsulProducto;
                }
                else
                {
                    rsp.Status = "14";
                    rsp.Msg = (IEnumerable<string>)"No se encontro información".AsEnumerable();
                }

            }
            catch (Exception ex)
            {
                rsp.Status = "14";
                rsp.Msg = (IEnumerable<string>)ex.Message.AsEnumerable();

            }

            return Ok(rsp);

        }


        [HttpPut]
        [Route("ModificarProducto")]
        public async Task<IActionResult> ModificarProducto([FromBody] DtoAltaProducto AltaProducto)
        {
            IEnumerable<string> enuValidacion = await BL_PRODUCTO.ValidarProducto(AltaProducto);
            Reponse<IEnumerable<string>> rsp = new();

            if (!enuValidacion.Any())
            {
                IEnumerable<string> enuDatos = await BL_PRODUCTO.ActualizarProducto(_dbcontext.ConnectionSQL(), AltaProducto);

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
}
