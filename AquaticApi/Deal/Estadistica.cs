using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApi.Deal
{
    public class Estadistica
    {
        public IList<Models.Estadisticas> Listado()
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
    }
}
