using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;

namespace AquaticAPIUsuario.DataAcces
{
    public class PersonaUsuario : IPersonaUsuario
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<PersonaUsuario> _logger;

        public PersonaUsuario(ILogger<PersonaUsuario> logger, AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public int Agregar(ModelsSQL.PersonaUsuario personaUsuario)
        {
            try
            {
                _aquaticPrixContext.PersonaUsuarios.Add(personaUsuario);
                _aquaticPrixContext.SaveChanges();

                return personaUsuario.IdPersona;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
    }
}
