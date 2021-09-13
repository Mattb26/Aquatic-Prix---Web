using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Estadisticas: IEstadisticasDatos
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<Estadisticas> _logger;

        public Estadisticas(AquaticPrixContext aquaticPrixContext, ILogger<Estadisticas> logger)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public void ListadoGeneral()
        {
            try
            {
                var result = _aquaticPrixContext.UsuarioEstadisticas.Join(_aquaticPrixContext.Usuarios, 
                                                                            usuarioEstadistica => usuarioEstadistica.Idusuario, 
                                                                            usuario=> usuario.IdUsuario,
                                                                            (usuarioEstadistica, usuario)=> new
                                                                            {
                                                                                usuario.IdUsuario,
                                                                                usuario.NombreUsuario,
                                                                                usuarioEstadistica.Idestadistica
                                                                            }).Join(_aquaticPrixContext.Estadisticas, 
                                                                                        usuario=> usuario.Idestadistica, 
                                                                                        estadistica=> estadistica.IdEstadistica,
                                                                                        (usuario, estadistica)=> new 
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
                                                                                        }).Where(x=> x.IdUsuario == idUsuario).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
