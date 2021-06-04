using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
