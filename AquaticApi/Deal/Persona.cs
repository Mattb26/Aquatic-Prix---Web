using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticApi.Deal
{
    public class Persona
    {
        public bool Agregar(Models.PersonaUsuario pers)
        {
            DataAccess.Persona persona;
            
            try
            {
                persona = new DataAccess.Persona();
                return persona.Agregar(pers);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.PersonaUsuario Login(Models.Usuario usuario)
        {
            DataAccess.Persona persona;

            try
            {
                persona = new DataAccess.Persona();
                return persona.Login(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteUsuario(string usuario)
        {
            DataAccess.Persona persona;

            try
            {
                persona = new DataAccess.Persona();
                return persona.ExisteUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Models.PersonaUsuario> PersonaUsuariosListado(int codPerfil, int op) 
        {
            DataAccess.Persona persona;
            IEnumerable<Models.PersonaUsuario> ilist;

            try
            {
                persona = new DataAccess.Persona();
                ilist = persona.PersonaUsuarioListado(op);

                if (op == 2)//Listado de los cliente que juegan el juego
                {
                    return from list in ilist
                           where list.Usuario.Estado == 1
                           select list;
                }

                else if (codPerfil == 2)//Perfil Operador
                {
                    return from list in ilist
                           where list.Usuario.Estado == 2
                           select list; 
                }
                else if (codPerfil == 3)//Perfil Administrador
                {
                     return from list in ilist
                            where list.Usuario.Estado == 2 || list.Usuario.Estado == 3
                            select list;

                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
