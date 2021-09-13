using System;

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
        bool Agregar(Models.PersonaUsuario personaUsuario);
        bool Existe(string usuario);
    }

}
