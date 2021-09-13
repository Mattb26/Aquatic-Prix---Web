using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Mail: IMailDato
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<Mail> _logger;

        public Mail(AquaticPrixContext aquaticPrixContext, ILogger<Mail> logger)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public bool Existe(string correo)
        {
            try
            {
                var correoExiste = _aquaticPrixContext.Personas.Where(x => x.CorreoElectronico == correo).FirstOrDefault();

                if (correoExiste != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("",ex);
                throw;
            }
        }
    }
}
