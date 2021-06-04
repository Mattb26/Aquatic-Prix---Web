using System;

namespace AquaticApi.Deal
{
    public class Persona
    {
        public bool Agregar(Models.Persona pers)
        {
            DataAccess.Persona persona;
            Models.PersonaUsuario personaUsuario;
            
            try
            {

                personaUsuario = new Models.PersonaUsuario();
                personaUsuario.Nombre = pers.Nombre;
                personaUsuario.Apellido = pers.Apellido;
                personaUsuario.CorreoElectronico = pers.CorreoElectronico;
                personaUsuario.FechaNacimiento = pers.FechaNacimiento;

                persona = new DataAccess.Persona();
                return persona.Agregar(personaUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
