using AquaticAPIEstadistica.IServicios;
using AquaticAPIEstadistica.ModelsSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIEstadistica.DataAccess
{
    public class Estadistica: IEstadistica
    {
        private readonly AquaticPrixContext _aquaticPrixContext;

        public Estadistica(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public void Listado() 
        {
            try
            {
                var result = _aquaticPrixContext.UsuarioEstadisticas.Join(_aquaticPrixContext.Usuarios,
                                                                         usuarioEstadistica => usuarioEstadistica.Idusuario,
                                                                         usuario => usuario.IdUsuario,
                                                                         (usuarioEstadistica, usuario) => new
                                                                         {
                                                                             usuario.IdUsuario,
                                                                             usuario.NombreUsuario,
                                                                             usuarioEstadistica.Idestadistica
                                                                         }).Join(_aquaticPrixContext.Estadisticas,
                                                                                     usuario => usuario.Idestadistica,
                                                                                     estadistica => estadistica.IdEstadistica,
                                                                                     (usuario, estadistica) => new
                                                                                     {
                                                                                         usuario.IdUsuario,
                                                                                         usuario.NombreUsuario,
                                                                                         estadistica.Perdido,
                                                                                         estadistica.Posicion,
                                                                                         estadistica.Promediobaja,
                                                                                         estadistica.PromedioCaidas,
                                                                                         estadistica.PromedioPartidas
                                                                                     }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Listado(Int32 idUsuario)
        {
            try
            {
                var result = _aquaticPrixContext.UsuarioEstadisticas.Join(_aquaticPrixContext.Usuarios,
                                                                            usuarioEstadistica => usuarioEstadistica.Idusuario,
                                                                            usuario => usuario.IdUsuario,
                                                                            (usuarioEstadistica, usuario) => new
                                                                            {
                                                                                usuario.IdUsuario,
                                                                                usuario.NombreUsuario,
                                                                                usuarioEstadistica.Idestadistica
                                                                            }).Join(_aquaticPrixContext.Estadisticas,
                                                                                        usuario => usuario.Idestadistica,
                                                                                        estadistica => estadistica.IdEstadistica,
                                                                                        (usuario, estadistica) => new
                                                                                        {
                                                                                            usuario.IdUsuario,
                                                                                            usuario.NombreUsuario,
                                                                                            estadistica.Perdido,
                                                                                            estadistica.Posicion,
                                                                                            estadistica.Promediobaja,
                                                                                            estadistica.PromedioCaidas,
                                                                                            estadistica.PromedioPartidas
                                                                                        }).Where(x => x.IdUsuario == idUsuario).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
