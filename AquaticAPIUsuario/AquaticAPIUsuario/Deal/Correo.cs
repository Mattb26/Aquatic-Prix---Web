using AquaticAPIUsuario.IServicios;
using Microsoft.Extensions.Logging;
using System;

namespace AquaticAPIUsuario.Deal
{
    public class Correo : IMail
    {
        private readonly ILogger<Correo> _logger;
        private readonly IMailDato _mailDato;

        public Correo(ILogger<Correo> logger, IMailDato mailDato)
        {
            _logger = logger;
            _mailDato = mailDato;
        }

        public bool Existe(string correo)
        {
            try
            {
                return _mailDato.Existe(correo);
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
    }
}
