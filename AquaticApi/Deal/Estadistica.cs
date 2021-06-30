using System;
using System.Collections.Generic;
using System.Linq;


namespace AquaticApi.Deal
{
    public class Estadistica
    {
        public IEnumerable<Models.Estadisticas> Listado()
        {
            DataAccess.Estadisticas estadisticas;

            try
            {
                estadisticas = new DataAccess.Estadisticas();
                return estadisticas.Listado();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<Models.Estadisticas> Listado(Int32 idUsuario)
        {
            DataAccess.Estadisticas estadisticas;
            IEnumerable<Models.Estadisticas> listEstadistica;

            try
            {
                estadisticas = new DataAccess.Estadisticas();



                listEstadistica = estadisticas.Listado();

                return from list in listEstadistica
                       where list.idUsuario == idUsuario
                       select list;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
