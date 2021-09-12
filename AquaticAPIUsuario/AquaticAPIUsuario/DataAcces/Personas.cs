using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using System;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Personas : IPersonasData
    {
        private readonly AquaticPrixContext _aquaticPrixContext;

        public Personas(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public int Agregar(ModelsSQL.Persona persona)
        {
            try
            {
                _aquaticPrixContext.Personas.Add(persona);
                _aquaticPrixContext.SaveChanges();
                return persona.Id;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int BajaExiste(ModelsSQL.Persona persona)
        {
            try
            {
                return _aquaticPrixContext.Personas.Where(x => x.Nombre == persona.Nombre &&
                                                                x.Apellido == persona.Apellido &&
                                                                x.FechaNacimiento == persona.FechaNacimiento && 
                                                                x.FechaBaja!=null).FirstOrDefault().Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Existe(ModelsSQL.Persona persona)
        {
            try
            {
                return _aquaticPrixContext.Personas.Where(x => x.Nombre == persona.Nombre && 
                                                                x.Apellido == persona.Apellido && 
                                                                x.FechaNacimiento == persona.FechaNacimiento &&
                                                                x.FechaBaja == null).FirstOrDefault().Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
