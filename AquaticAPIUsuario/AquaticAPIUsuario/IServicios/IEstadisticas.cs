using System;

namespace AquaticAPIUsuario.IServicios
{
    public interface IEstadisticasDatos
    {
        void ListadoGeneral();
        void Listado(Int32 idUsuario);
    }

    public interface IEstadisticas
    {
        void ListadoGeneral();
        void Listado(Int32 idUsuario);
    }
}
