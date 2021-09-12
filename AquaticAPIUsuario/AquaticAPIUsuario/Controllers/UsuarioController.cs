using AquaticAPIUsuario.IServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IPersonas _personas;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IPersonas personas, ILogger<UsuarioController> logger)
        {
            this._personas = personas;
            _logger = logger;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Models.PersonaUsuario personaUsuario)
        {

            try
            {
                if (_personas.Agregar(personaUsuario))
                {
                    return Ok();
                }
                else 
                {
                    return BadRequest("Por favor verifique sus datos");
                }
                

            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }

        }
        [HttpGet("existe")]
        public IActionResult Get([Required] string usuario)
        {
            bool resultado = false;

            try
            {
                resultado = _personas.Existe(usuario);

                return Ok(resultado);


            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);

                throw;
            }

        }
    }
}
