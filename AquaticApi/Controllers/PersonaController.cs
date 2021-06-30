using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Models.PersonaUsuario personaUsuario)
        {
            Deal.Persona persona;
            try
            {
                persona = new Deal.Persona();

                if (persona.Agregar(personaUsuario))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error al agregar los datos");
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] Models.Usuario usuario) 
        {
            Deal.Persona persona;
            Models.PersonaUsuario personaUsuario; 
            try
            {
                persona = new Deal.Persona();
                personaUsuario = persona.Login(usuario);

                if (personaUsuario != null)
                {
                    return Ok(personaUsuario);
                }
                else
                {
                    return BadRequest("Error al agregar los datos");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("existe")]
        public IActionResult Get([Required] string usuario)
        {
            Deal.Persona persona;
            try
            {
                persona = new Deal.Persona();
                

                if (persona.ExisteUsuario(usuario))
                {
                   
                    return BadRequest("El usuario " + usuario + ", ya existe, por favor aguregue otro usuario");
                }
                else
                {
                    return Ok("Usuario disponible");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{idUsuario}/estadisticas")]
        public IActionResult Get([Required] Int32 idUsuario)
        {
            Deal.Estadistica estadistica;
            try
            {
                estadistica = new Deal.Estadistica();

                return Ok(estadistica.Listado(idUsuario));

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("estadisticas")]
        public IActionResult Get()
        {
            Deal.Estadistica estadistica;
            try
            {
                estadistica = new Deal.Estadistica();

                return Ok(estadistica.Listado());

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("perfil/{codPerfil}/opcion/{op}")]
        public IActionResult Get([Required] int codPerfil, [Required] int op)
        {
            Deal.Persona persona;
            try
            {
                if (codPerfil == 2 || codPerfil == 3)
                {
                    persona = new Deal.Persona();

                    return Ok(persona.PersonaUsuariosListado(codPerfil, op));
                }
                else 
                {
                    return BadRequest("El código de perfil ingresado no existe");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("clave")]
        public IActionResult Put([Required] Models.UsuarioClave usuarioClave)
        {
            Deal.Persona persona;

            try
            {
                persona = new Deal.Persona();

                if (persona.CambioClave(usuarioClave))
                {
                    return Ok("Se realizó correctamente el cambio de clave");
                }
                else 
                {
                    return BadRequest("Error al realizar el cambio de clave");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
