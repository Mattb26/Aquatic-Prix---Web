using AquaticAPIUsuario.IServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private readonly IMail _mail;

        public MailController(ILogger<MailController> logger, IMail mail)
        {
            _logger = logger;
            _mail = mail;
        }

        [HttpGet("existe")]
        public IActionResult Get([Required][DataType(DataType.EmailAddress)][StringLength(100)] string mail) 
        {
            bool resultado;
            try
            {
                resultado = _mail.Existe(mail);

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
