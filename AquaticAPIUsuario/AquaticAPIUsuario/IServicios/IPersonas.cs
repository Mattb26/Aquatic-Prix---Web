using System;
using System.Collections.Generic;

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
        IEnumerable<Models.PersonaUsuario> Listado(int codPerfil, int op);
    }

}
