using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIUsuario.IServicios
{
    public interface IPersonasData
    {
        Int32 Agregar(ModelsSQL.Persona persona);
        Int32 Existe(ModelsSQL.Persona persona);
        Int32 BajaExiste(ModelsSQL.Persona persona);
    }
    public interface IPersonas
    {

    }
}
