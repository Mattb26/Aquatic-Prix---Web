using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticAPIUsuario.Deal
{
    public class Persona: IPersonas
    {
        private readonly IPersonasData _personasData;
        private readonly IUsuariosDatos _usuariosDatos;
        private readonly IPersonaUsuario _personaUsuario;
        private readonly ILogger<Persona> _logger;
        public Persona(ILogger<Persona> logger, IPersonasData personasData, IUsuariosDatos usuariosDatos, IPersonaUsuario personaUsuario)
        {
            _personasData = personasData;
            _usuariosDatos = usuariosDatos;
            _personaUsuario = personaUsuario;
            _logger = logger;
        }

        public bool Agregar(PersonaUsuario personaUsuario)
        {
            ModelsSQL.Persona persona;
            ModelsSQL.Usuario usuario;
            ModelsSQL.PersonaUsuario persUsuario;

            try
            {
                persona = new ModelsSQL.Persona
                {
                    Apellido = personaUsuario.Apellido,
                    Nombre = personaUsuario.Nombre,
                    CorreoElectronico = personaUsuario.CorreoElectronico,
                    FechaNacimiento = personaUsuario.FechaNacimiento,
                    FechaAlta = DateTime.Now,
                    FechaBaja = null

                };

                usuario = new ModelsSQL.Usuario
                {
                    NombreUsuario = personaUsuario.Usuario.NombreUsuario,
                    Clave = personaUsuario.Usuario.Clave
                };

                if ((_personasData.Existe(persona) == 0) && (_usuariosDatos.Existe(usuario) == 0))
                {
                    if (_personasData.BajaExiste(persona) == 0)
                    {

                        persona.Id = _personasData.Agregar(persona);

                        usuario.IdUsuario = _usuariosDatos.Agregar(usuario);

                        persUsuario = new ModelsSQL.PersonaUsuario
                        {
                            IdPersona = persona.Id,
                            IdUsuario = usuario.IdUsuario,
                            FechaAlta = DateTime.Now,
                            FechaBaja = null
                        };

                        if (_personaUsuario.Agregar(persUsuario) > 0)
                        {
                            return true;
                        }
                        else 
                        {
                            return false;
                        }
                    }
                    else 
                    {
                        return false;
                    }
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public bool Existe(string usuario) 
        {
            try
            {
                if (_usuariosDatos.Existe(usuario) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public IEnumerable<Models.PersonaUsuario> Listado(int codPerfil, int op)
        {
            //IEnumerable<Models.PersonaUsuario> ilist;

            try
            {
                //ilist = new List<Models.PersonaUsuario>();

                //_usuariosDatos.ListadoAdministrador();


                if (op == 2)//Listado de los cliente que juegan el juego
                {
                    //return from list in ilist
                    //       where list.Usuario.Estado == 1
                    //       select list;

                    return _usuariosDatos.ListadoUsuario();
                }

                else if (codPerfil == 2)//Perfil Operador
                {
                    //return from list in ilist
                    //       where list.Usuario.Estado == 2
                    //       select list;
                    return _usuariosDatos.ListadoOperador();
                }
                else if (codPerfil == 3)//Perfil Administrador
                {
                    //return from list in ilist
                    //       where list.Usuario.Estado == 2 || list.Usuario.Estado == 3
                    //       select list;
                    return _usuariosDatos.ListadoAdministrador();
                }
                return null;



                //return ilist;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
    }
}
