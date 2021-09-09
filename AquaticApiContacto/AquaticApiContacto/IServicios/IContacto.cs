using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApiContacto.IServicios
{
    public interface IContacto
    {
        bool Agregar(Models.Contacto contacto);
        List<ModelsSQL.Contacto> Listado();
    }

    public interface IContactoData
    {
        bool Agregar(ModelsSQL.Contacto contacto);
        List<ModelsSQL.Contacto> Listado();
    }
}
