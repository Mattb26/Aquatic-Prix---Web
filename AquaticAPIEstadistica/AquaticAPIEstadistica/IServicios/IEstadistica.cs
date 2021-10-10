using System;

namespace AquaticAPIEstadistica.IServicios
{
    public interface IEstadistica
    {
        void Listado();
        void Listado(Int32 idUsuario);

    }
    public interface IEstadisticaDeal
    {
        void Listado();
        void Listado(Int32 idUsuario);

    }
}
