using System;

namespace AquaticApi.Deal
{
    public class Persona
    {
        public bool Agregar(Models.PersonaUsuario pers)
        {
            DataAccess.Persona persona;
            
            try
            {
                persona = new DataAccess.Persona();
                return persona.Agregar(pers);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.PersonaUsuario Login(Models.Usuario usuario)
        {
            DataAccess.Persona persona;

            try
            {
                persona = new DataAccess.Persona();
                return persona.Login(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteUsuario(string usuario)
        {
            DataAccess.Persona persona;

            try
            {
                persona = new DataAccess.Persona();
                return persona.ExisteUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
