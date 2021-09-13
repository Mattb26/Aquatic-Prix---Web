using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Usuario : IUsuariosDatos
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<Usuario> _logger;

        public Usuario(ILogger<Usuario> logger,AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public int Agregar(ModelsSQL.Usuario usuario)
        {
            try
            {
                _aquaticPrixContext.Usuarios.Add(usuario);
                _aquaticPrixContext.SaveChanges();
                return usuario.IdUsuario;
            }
            catch (Exception ex)
            {
                _logger.LogError("",ex);
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
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public int Existe(ModelsSQL.Usuario usuario)
        {
            try
            {
                var user =  _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave).FirstOrDefault();

                if (user != null) 
                {
                    return user.IdUsuario;
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
        public int Existe(string usuario)
        {
            try
            {
                var user = _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario).FirstOrDefault();

                if (user != null)
                {
                    return user.IdUsuario;
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
