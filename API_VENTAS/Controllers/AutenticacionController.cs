using API_VENTAS.Context;
using BLL.AUTENTICACION;
using BLL.PROVEEDOR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MODELS;
using MODELS.AUTENTICACION.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController(DbContext _dbcontext, IConfiguration _config) : ControllerBase
    {

        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> Token([FromBody] DtoAutenticComponente Autenticacion)
        {
            IEnumerable<string> enuValidacion = await BL_AUTENTICACION.ValidaInfoComponente(_dbcontext.ConnectionSQL(), Autenticacion);
            Reponse<IEnumerable<string>> rsp = new();

            if (!enuValidacion.Any())
            {
                string? SecretKey = _config.GetSection("secretkey").ToString();

                var KeyByte = Encoding.ASCII.GetBytes(SecretKey);
                var Claims = new ClaimsIdentity();

                Claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Autenticacion.Usuario));

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = Claims,
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyByte), SecurityAlgorithms.HmacSha256Signature)
                };

                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenConfig = TokenHandler.CreateToken(tokenDescription);

                string Token = TokenHandler.WriteToken(TokenConfig);
                List<string> lstDatos = [Token];

                rsp.Status = "00";
                rsp.Value = lstDatos.AsEnumerable();

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
