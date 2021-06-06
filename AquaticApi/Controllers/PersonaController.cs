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
    }
}
