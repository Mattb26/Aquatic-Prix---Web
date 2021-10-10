using AquaticAPIEstadistica.IServicios;
using AquaticAPIEstadistica.ModelsSQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticAPIEstadistica.DataAccess
{
    public class Estadistica: IEstadistica
    {
        private readonly AquaticPrixContext _aquaticPrixContext;

        public Estadistica(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public IEnumerable<Models.Estadisticas> Listado() 
        {
            List<Models.Estadisticas> estadisticas; 
            try
            {
                var result = _aquaticPrixContext.UsuarioEstadisticas.Join(_aquaticPrixContext.Usuarios,
                                                                         usuarioEstadistica => usuarioEstadistica.Idusuario,
                                                                         usuario => usuario.IdUsuario,
                                                                         (usuarioEstadistica, usuario) => new
                                                                         {
                                                                             usuarioEstadistica,
                                                                             usuario
                                                                         }).Join(_aquaticPrixContext.Estadisticas,
                                                                                     usuarioestadisticas => usuarioestadisticas.usuarioEstadistica.Idestadistica,
                                                                                     estadistica => estadistica.IdEstadistica,
                                                                                     (usuario, estadistica) => new
                                                                                     {
                                                                                         usuario,
                                                                                         estadistica
                                                                                     }).Select(x=> new
                                                                                     {
                                                                                         x.usuario.usuario.IdUsuario,
                                                                                         x.usuario.usuario.NombreUsuario,
                                                                                         x.estadistica.Posicion,
                                                                                         x.estadistica.Perdido,
                                                                                         x.estadistica.PromedioPartidas,
                                                                                         x.estadistica.Bajas,
                                                                                         x.estadistica.Caidas,
                                                                                         x.estadistica.Promediobaja,
                                                                                         x.estadistica.PromedioCaidas,
                                                                                         x.estadistica.Fecha
                                                                                     }
                                                                                     ).ToList();
      
                estadisticas = new List<Models.Estadisticas>();

                foreach (var item in result)
                {
                    estadisticas.Add(new Models.Estadisticas
                    {
                        idUsuario = item.IdUsuario,
                        NombreUsuario = item.NombreUsuario,
                        Posicion = item.Posicion,
                        Perdido = item.Perdido,
                        PromedioPartidas = item.PromedioPartidas,
                        Bajas = item.Bajas,
                        Caidas = item.Caidas,
                        Promediobaja = item.Promediobaja,
                        PromedioCaidas = item.PromedioCaidas,
                        Fecha = item.Fecha
                    });
                }

                return estadisticas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Models.Estadisticas> Listado(Int32 idUsuario)
        {
            List<Models.Estadisticas> estadisticas;
            try
            {
                var result = _aquaticPrixContext.UsuarioEstadisticas.Join(_aquaticPrixContext.Usuarios,
                                                                         usuarioEstadistica => usuarioEstadistica.Idusuario,
                                                                         usuario => usuario.IdUsuario,
                                                                         (usuarioEstadistica, usuario) => new
                                                                         {
                                                                             usuarioEstadistica,
                                                                             usuario
                                                                         }).Join(_aquaticPrixContext.Estadisticas,
                                                                                     usuarioestadisticas => usuarioestadisticas.usuarioEstadistica.Idestadistica,
                                                                                     estadistica => estadistica.IdEstadistica,
                                                                                     (usuario, estadistica) => new
                                                                                     {
                                                                                         usuario,
                                                                                         estadistica
                                                                                     }).Select(x => new
                                                                                     {
                                                                                         x.usuario.usuario.IdUsuario,
                                                                                         x.usuario.usuario.NombreUsuario,
                                                                                         x.estadistica.Posicion,
                                                                                         x.estadistica.Perdido,
                                                                                         x.estadistica.PromedioPartidas,
                                                                                         x.estadistica.Bajas,
                                                                                         x.estadistica.Caidas,
                                                                                         x.estadistica.Promediobaja,
                                                                                         x.estadistica.PromedioCaidas,
                                                                                         x.estadistica.Fecha
                                                                                     }
                                                                                     ).Where(x=> x.IdUsuario == idUsuario).ToList();

                estadisticas = new List<Models.Estadisticas>();

                foreach (var item in result)
                {
                    estadisticas.Add(new Models.Estadisticas
                    {
                        idUsuario = item.IdUsuario,
                        NombreUsuario = item.NombreUsuario,
                        Posicion = item.Posicion,
                        Perdido = item.Perdido,
                        PromedioPartidas = item.PromedioPartidas,
                        Bajas = item.Bajas,
                        Caidas = item.Caidas,
                        Promediobaja = item.Promediobaja,
                        PromedioCaidas = item.PromedioCaidas,
                        Fecha = item.Fecha
                    });
                }

                return estadisticas;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
