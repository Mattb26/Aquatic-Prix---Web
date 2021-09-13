using AquaticApiLogin.ModelsSQL;
using AquaticApiLogin.Servicios;
using System;
using System.Linq;

namespace AquaticApiLogin.DataAccess
{
    public class Login: ILoginData
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        public Login(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public ModelsSQL.Usuario ValidarUsuario(string usuario, string clave) 
        {
            try
            {
                 return _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario && x.Clave == clave).FirstOrDefault();
             }
            catch (Exception)
            {

                throw;
            }
        }

        public ModelsSQL.PersonaUsuario PersonaUsuario(Int32 idUsuario)
        {
            try
            {
                return _aquaticPrixContext.PersonaUsuarios.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ModelsSQL.Persona Persona(Int32 idPersona)
        {
            try
            {
                return _aquaticPrixContext.Personas.Where(x => x.Id == idPersona).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CambioClave(ModelsSQL.Usuario usuario )
        {
            try
            {
                 _aquaticPrixContext.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Console.WriteLine(_aquaticPrixContext.ChangeTracker.DebugView.LongView);
                _aquaticPrixContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
