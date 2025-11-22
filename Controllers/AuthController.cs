using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using _686DP_BE;
using _686DP_BLL;
using _686DP_SERVICIOS;
using Microsoft.AspNetCore.Identity.Data;
using AseguraYA_Back.Models;


namespace AseguraYA_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] logRequest request)
        {
            try
            {
                int DNI = request.DNI;

                _686DP_BLLUsuario bllusr = new _686DP_BLLUsuario();

                string usuario = bllusr._686DPTraerUsuario(DNI);

                if (usuario == null)
                    return BadRequest(new { mensaje = "UsuarioIncorrecto" });

                return Ok(new { mensaje = "UsuarioEncontrado", usuario });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

    }
}
