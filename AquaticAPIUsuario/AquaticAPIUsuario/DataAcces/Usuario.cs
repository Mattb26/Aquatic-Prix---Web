using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticAPIUsuario.DataAcces
{
    public class Usuario : IUsuariosDatos
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        private readonly ILogger<Usuario> _logger;

        public Usuario(ILogger<Usuario> logger, AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
            _logger = logger;
        }

        public int Agregar(ModelsSQL.Usuario usuario)
        {
            try
            {
                _aquaticPrixContext.Usuarios.Add(usuario);
                _aquaticPrixContext.SaveChanges();
                return usuario.IdUsuario;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
            throw new NotImplementedException();
        }

        public int BajaExiste(ModelsSQL.Usuario usuario)
        {
            try
            {
                return _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave).FirstOrDefault().IdUsuario;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public int Existe(ModelsSQL.Usuario usuario)
        {
            try
            {
                var user = _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave).FirstOrDefault();

                if (user != null)
                {
                    return user.IdUsuario;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
        public int Existe(string usuario)
        {
            try
            {
                var user = _aquaticPrixContext.Usuarios.Where(x => x.NombreUsuario == usuario).FirstOrDefault();

                if (user != null)
                {
                    return user.IdUsuario;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public IEnumerable<Models.PersonaUsuario> ListadoAdministrador()
        {
            List<Models.PersonaUsuario> person;

            try
            {
                var listado = _aquaticPrixContext.Personas.Join(_aquaticPrixContext.PersonaUsuarios,
                               pers => pers.Id,
                               persUsu => persUsu.IdPersona,
                               (pers, persUsu) => new { pers, persUsu }).Join
                               (_aquaticPrixContext.Usuarios, perPerUsu => perPerUsu.persUsu.IdUsuario, user => user.IdUsuario
                               , (perPerUsu, user) => new { perPerUsu, user }).
                               Select(x => new
                               {
                                   x.perPerUsu.persUsu.IdPersona,
                                   x.perPerUsu.pers.Nombre,
                                   x.perPerUsu.pers.Apellido,
                                   x.perPerUsu.pers.CorreoElectronico,
                                   x.perPerUsu.pers.FechaNacimiento,
                                   x.perPerUsu.persUsu.IdUsuario,
                                   x.user.NombreUsuario,
                                   x.user.Estado
                               }).Where(x => x.Estado.Equals(2) || x.Estado.Equals(3)).ToList();

                person = new List<Models.PersonaUsuario>();

                foreach (var item in listado)
                {
                    Models.PersonaUsuario personaUsuario = new Models.PersonaUsuario
                    {
                        Apellido = item.Apellido,
                        Nombre = item.Nombre,
                        CorreoElectronico = item.CorreoElectronico,
                        FechaNacimiento = item.FechaNacimiento,
                        IdPersona = item.IdPersona,
                        Usuario = new Models.Usuario
                        {
                            IdUsuario = item.IdUsuario,
                            NombreUsuario = item.NombreUsuario
                        }
                    };

                    person.Add(personaUsuario);
                }

                return person;


            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public IEnumerable<Models.PersonaUsuario> ListadoOperador() 
        {
            List<Models.PersonaUsuario> person;
            try
            {
                var listado = _aquaticPrixContext.Personas.Join(_aquaticPrixContext.PersonaUsuarios,
                        pers => pers.Id,
                        persUsu => persUsu.IdPersona,
                        (pers, persUsu) => new { pers, persUsu }).Join
                        (_aquaticPrixContext.Usuarios,
                            perPerUsu => perPerUsu.persUsu.IdUsuario,
                            user => user.IdUsuario
                        , (perPerUsu, user) => new { perPerUsu, user }).
                        Select(x => new
                        {
                            x.perPerUsu.persUsu.IdPersona,
                            x.perPerUsu.pers.Nombre,
                            x.perPerUsu.pers.Apellido,
                            x.perPerUsu.pers.CorreoElectronico,
                            x.perPerUsu.pers.FechaNacimiento,
                            x.perPerUsu.persUsu.IdUsuario,
                            x.user.NombreUsuario,
                            x.user.Estado
                        }).Where(x => x.Estado.Equals(2)).ToList();

                person = new List<Models.PersonaUsuario>();

                foreach (var item in listado)
                {
                    Models.PersonaUsuario personaUsuario = new Models.PersonaUsuario
                    {
                        Apellido = item.Apellido,
                        Nombre = item.Nombre,
                        CorreoElectronico = item.CorreoElectronico,
                        FechaNacimiento = item.FechaNacimiento,
                        IdPersona = item.IdPersona,
                        Usuario = new Models.Usuario
                        {
                            IdUsuario = item.IdUsuario,
                            NombreUsuario = item.NombreUsuario
                        }
                    };

                    person.Add(personaUsuario);
                }

                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }

        public IEnumerable<Models.PersonaUsuario> ListadoUsuario()
        {
            List<Models.PersonaUsuario> person;
            try
            {
                var listado = _aquaticPrixContext.Personas.Join(_aquaticPrixContext.PersonaUsuarios,
                        pers => pers.Id,
                        persUsu => persUsu.IdPersona,
                        (pers, persUsu) => new { pers, persUsu }).Join
                        (_aquaticPrixContext.Usuarios,
                            perPerUsu => perPerUsu.persUsu.IdUsuario,
                            user => user.IdUsuario
                        , (perPerUsu, user) => new { perPerUsu, user }).
                        Select(x => new
                        {
                            x.perPerUsu.persUsu.IdPersona,
                            x.perPerUsu.pers.Nombre,
                            x.perPerUsu.pers.Apellido,
                            x.perPerUsu.pers.CorreoElectronico,
                            x.perPerUsu.pers.FechaNacimiento,
                            x.perPerUsu.persUsu.IdUsuario,
                            x.user.NombreUsuario,
                            x.user.Estado
                        }).Where(x => x.Estado.Equals(1)).ToList();

                person = new List<Models.PersonaUsuario>();

                foreach (var item in listado)
                {
                    Models.PersonaUsuario personaUsuario = new Models.PersonaUsuario
                    {
                        Apellido = item.Apellido,
                        Nombre = item.Nombre,
                        CorreoElectronico = item.CorreoElectronico,
                        FechaNacimiento = item.FechaNacimiento,
                        IdPersona = item.IdPersona,
                        Usuario = new Models.Usuario
                        {
                            IdUsuario = item.IdUsuario,
                            NombreUsuario = item.NombreUsuario,
                            Estado = item.Estado
                        }
                    };

                    person.Add(personaUsuario);
                }

                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }
        }
        
    }
}
