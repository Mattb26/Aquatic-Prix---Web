using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using System;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Usuario : IUsuariosDatos
    {
        private readonly AquaticPrixContext _aquaticPrixContext;

        public Usuario(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public int Agregar(ModelsSQL.Usuario usuario)
        {
            try
            {
                _aquaticPrixContext.Usuarios.Add(usuario);
                _aquaticPrixContext.SaveChanges();
                return usuario.IdUsuario;
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public int BajaExiste(ModelsSQL.Usuario usuario)
        {
            try
            {
                return _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave).FirstOrDefault().IdUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Existe(ModelsSQL.Usuario usuario)
        {
            try
            {
                return _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave).FirstOrDefault().IdUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
