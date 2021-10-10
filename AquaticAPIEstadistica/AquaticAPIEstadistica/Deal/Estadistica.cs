using AquaticAPIEstadistica.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIEstadistica.Deal
{
    public class Estadistica: IEstadisticaDeal
    {
        private readonly IEstadistica _estadistica;

        public Estadistica(IEstadistica estadistica)
        {
            _estadistica = estadistica;
        }

        public void Listado() 
        {
            try
            {
                _estadistica.Listado();
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
                _estadistica.Listado();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
