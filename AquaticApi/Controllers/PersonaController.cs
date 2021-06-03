using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Models.PersonaUsuario personaUsuario)
        {
            //Deal.Persona persona;
            try
            {
                //persona = new Deal.Persona();

                //if (persona.Agregar(personas))
                //{
                return Ok();
                //}
                //else
                //{
                //    return BadRequest("Error al agregar los datos");
                //}


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
