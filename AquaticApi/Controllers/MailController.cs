using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        [HttpGet("existe")]
        public IActionResult Get([Required][DataType(DataType.EmailAddress)][StringLength(100)] string mail)
        {
            Deal.Mail _mail;
            try
            {
                _mail = new Deal.Mail();


                if (_mail.ExisteMail(mail))
                {

                    return BadRequest("La cuenta " + _mail + ", ya existe, por favor aguregue otra cuenta");
                }
                else
                {
                    return Ok("Cuenta disponible");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
