using System;
using System.Collections.Generic;

namespace AquaticAPIUsuario.IServicios
{
    public interface IUsuariosDatos
    {
        Int32 Agregar(ModelsSQL.Usuario usuario);
        Int32 Existe(ModelsSQL.Usuario usuario);
        Int32 BajaExiste(ModelsSQL.Usuario usuario);
        Int32 Existe(string usuario);
        IEnumerable<Models.PersonaUsuario> ListadoAdministrador();
        IEnumerable<Models.PersonaUsuario> ListadoOperador();
        IEnumerable<Models.PersonaUsuario> ListadoUsuario();
    }
    public interface IUsuarios
    {
    }
}
