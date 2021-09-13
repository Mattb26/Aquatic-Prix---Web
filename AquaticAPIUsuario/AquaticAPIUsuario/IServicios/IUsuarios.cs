using System;

namespace AquaticAPIUsuario.IServicios
{
    public interface IUsuariosDatos
    {
        Int32 Agregar(ModelsSQL.Usuario usuario);
        Int32 Existe(ModelsSQL.Usuario usuario);
        Int32 BajaExiste(ModelsSQL.Usuario usuario);
        Int32 Existe(string usuario);
    }
    public interface IUsuarios
    {
    }
}
