using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Personas : IPersonasData
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<Personas> _logger;

        public Personas(ILogger<Personas> logger, AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public int Agregar(ModelsSQL.Persona persona)
        {
            try
            {
                _aquaticPrixContext.Personas.Add(persona);
                _aquaticPrixContext.SaveChanges();
                return persona.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }

        }

        public int BajaExiste(ModelsSQL.Persona persona)
        {
            try
            {
                var pers = _aquaticPrixContext.Personas.Where(x => x.Nombre == persona.Nombre &&
                                                                x.Apellido == persona.Apellido &&
                                                                x.FechaNacimiento == persona.FechaNacimiento && 
                                                                x.FechaBaja!=null).FirstOrDefault();

                if (pers != null)
                {
                    return pers.Id;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public int Existe(ModelsSQL.Persona persona)
        {
            try
            {
                var pers = _aquaticPrixContext.Personas.Where(x => x.Nombre == persona.Nombre && 
                                                                x.Apellido == persona.Apellido && 
                                                                x.FechaNacimiento == persona.FechaNacimiento &&
                                                                x.FechaBaja == null).FirstOrDefault();

                if (pers != null)
                {
                    return pers.Id;
                }
                else 
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
    }
}
