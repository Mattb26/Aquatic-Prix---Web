using System;
using System.Collections.Generic;

namespace AquaticAPIEstadistica.IServicios
{
    public interface IEstadistica
    {
        IEnumerable<Models.Estadisticas> Listado();
        IEnumerable<Models.Estadisticas> Listado(Int32 idUsuario);

    }
    public interface IEstadisticaDeal
    {
        IEnumerable<Models.Estadisticas> Listado();
        IEnumerable<Models.Estadisticas> Listado(Int32 idUsuario);

    }
}
