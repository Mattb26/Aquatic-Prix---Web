using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIUsuario.IServicios
{
    public interface IUsuariosDatos
    {
        Int32 Agregar(ModelsSQL.Usuario usuario);
        Int32 Existe(ModelsSQL.Usuario usuario);
        Int32 BajaExiste(ModelsSQL.Usuario usuario);
    }
    public interface IUsuarios
    {
    }
}
