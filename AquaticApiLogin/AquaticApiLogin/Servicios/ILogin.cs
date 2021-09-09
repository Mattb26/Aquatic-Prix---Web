using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApiLogin.Servicios
{
    public interface ILogin
    {
        Models.PersonaUsuario ValidarUsuario(Models.Usuario usuario);
        bool CambioClave(Models.UsuarioClave usuario);
    }

    public interface ILoginData
    {
        ModelsSQL.Usuario ValidarUsuario(string usuario, string clave);
        ModelsSQL.PersonaUsuario PersonaUsuario(Int32 idUsuario);
        ModelsSQL.Persona Persona(Int32 idPersona);
        bool CambioClave(ModelsSQL.Usuario usuario);
    }
}
