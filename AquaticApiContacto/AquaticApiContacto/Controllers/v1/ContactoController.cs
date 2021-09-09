using AquaticApiContacto.IServicios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AquaticApiContacto.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContacto _contacto;

        public ContactoController(IContacto contacto)
        {
            _contacto = contacto;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Models.Contacto contacto) 
        {
            try
            {
                if (_contacto.Agregar(contacto))
                {
                    return Ok("Operación exitosa");
                }
                else 
                {
                    return BadRequest();
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var listado = _contacto.Listado();
                if (listado.Count>0)
                {
                    return Ok(listado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
