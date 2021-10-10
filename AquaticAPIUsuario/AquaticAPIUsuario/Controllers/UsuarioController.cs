using AquaticAPIUsuario.IServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            bool resultado;

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

        [HttpGet("perfil/{codPerfil}/opcion/{op}")]
        public IActionResult Get([Required] int codPerfil, [Required] int op) 
        {
            

            try
            {
                if (codPerfil == 2 || codPerfil == 3)
                {
                    IEnumerable<Models.PersonaUsuario> list = _personas.Listado(codPerfil, op);
                    if (list != null)
                    {
                        return Ok(list);
                    }
                    else 
                    {
                        return BadRequest("Sin registros");
                    }

                }
                else
                {
                    return BadRequest("El código de perfil ingresado no existe");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
    }
}
