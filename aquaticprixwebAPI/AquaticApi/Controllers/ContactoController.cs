using Microsoft.AspNetCore.Mvc;
using System;

namespace AquaticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Post([FromBody]Models.Contacto contacto)
        {
            Deal.Contacto contac;
            try
            {
                contac = new Deal.Contacto();

                if (contac.Agregar(contacto))
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
    }
}
