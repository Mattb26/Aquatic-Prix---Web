using System;

namespace AquaticAPIUsuario.IServicios
{
    public interface IPersonaUsuario
    {
        Int32 Agregar(ModelsSQL.PersonaUsuario personaUsuario);
    }
}
