using API_VENTAS.Context;
using BLL.PROVEEDOR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.PROVEEDOR.DTO;

namespace API_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController(DbContext _dbcontext) : ControllerBase
    {

        [HttpPost]
        [Route("AltaProveedor")]
        public async Task<IActionResult> AltaProveedor([FromBody] DtoAltaProveedor AltaProveedor)
        {
            IEnumerable<string> enuValidacion = await BL_PROVEEDOR.ValidarProveedor(AltaProveedor);
            Reponse<IEnumerable<string>> rsp = new();

            if (!enuValidacion.Any())
            {
                IEnumerable<string> enuDatos = await BL_PROVEEDOR.GuardarProveedor(_dbcontext.ConnectionSQL(), AltaProveedor);

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
        [Route("ConsultaProveedor")]
        public async Task<IActionResult> ConsultaProveedor()
        {
            IEnumerable<DtoConsuProveedor> enuConsulProveedor = await BL_PROVEEDOR.ConsultaProveedor(_dbcontext.ConnectionSQL());
            Reponse<IEnumerable<DtoConsuProveedor>> rsp = new();

            try
            {
                if (enuConsulProveedor.Any())
                {
                    rsp.Status = "00";
                    rsp.Value = enuConsulProveedor;
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
        [Route("ConsultaProveedorTexto/{Texto}")]
        public async Task<IActionResult> ConsultaProveedorTexto(string Texto)
        {
            IEnumerable<DtoConsulProveedorNombre> enuConsulProveedorNombre = await BL_PROVEEDOR.ConsultaProveedorTexto(_dbcontext.ConnectionSQL(), Texto);
            Reponse<IEnumerable<DtoConsulProveedorNombre>> rsp = new();

            try
            {
                if (enuConsulProveedorNombre.Any())
                {
                    rsp.Status = "00";
                    rsp.Value = enuConsulProveedorNombre;
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
        [Route("ModificarProveedor")]
        public async Task<IActionResult> ModificarProveedor([FromBody] DtoAltaProveedor AltaProveedor)
        {
            IEnumerable<string> enuValidacion = await BL_PROVEEDOR.ValidarProveedor(AltaProveedor);
            Reponse<IEnumerable<string>> rsp = new();

            if (!enuValidacion.Any())
            {
                IEnumerable<string> enuDatos = await BL_PROVEEDOR.ActualizarProveedor(_dbcontext.ConnectionSQL(), AltaProveedor);

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
