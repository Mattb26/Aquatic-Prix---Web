using AquaticAPIEstadistica.IServicios;
using System;
using System.Collections.Generic;

namespace AquaticAPIEstadistica.Deal
{
    public class Estadistica: IEstadisticaDeal
    {
        private readonly IEstadistica _estadistica;

        public Estadistica(IEstadistica estadistica)
        {
            _estadistica = estadistica;
        }

        public IEnumerable<Models.Estadisticas> Listado() 
        {
            try
            {
                return _estadistica.Listado();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Models.Estadisticas> Listado(Int32 idUsuario)
        {
            try
            {
                return _estadistica.Listado(idUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
