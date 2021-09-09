using AquaticApiLogin.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApiLogin.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            this._login = login;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Models.Usuario usuario) 
        {
            //Ver bcrypt
            //PBKDF2
            try
            {
                Models.PersonaUsuario personaUsuario = _login.ValidarUsuario(usuario);

                if (personaUsuario != null)
                {
                    return Ok(personaUsuario);
                }
                else 
                {
                    return BadRequest("Error en la solicitud");
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Models.UsuarioClave usuario)
        {
            //Ver bcrypt
            //PBKDF2
            try
            {
                 _login.CambioClave(usuario);

                return Ok();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
