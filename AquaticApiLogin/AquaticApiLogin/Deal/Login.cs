using AquaticApiLogin.Servicios;

namespace AquaticApiLogin.Deal
{
    public class Login : ILogin
    {
        private readonly ILoginData _loginData;

        public Login(ILoginData loginData)
        {
            this._loginData = loginData;
        }

        public Models.PersonaUsuario ValidarUsuario(Models.Usuario usuario)
        {
            Models.PersonaUsuario personaUsuario = new Models.PersonaUsuario();
             
            ModelsSQL.Usuario user = _loginData.ValidarUsuario(usuario.NombreUsuario, usuario.Clave);

            if (user != null) 
            {
                //Ahora obtengo el id de la tabla PersonaUsuario
                ModelsSQL.PersonaUsuario personaUsua = _loginData.PersonaUsuario(user.IdUsuario);

                if (personaUsua != null) 
                {
                    ModelsSQL.Persona persona = _loginData.Persona(personaUsua.IdPersona);

                    personaUsuario.Nombre = persona.Nombre;
                    personaUsuario.Apellido = persona.Apellido;
                    personaUsuario.IdPersona = persona.Id;
                    personaUsuario.FechaNacimiento = persona.FechaNacimiento;
                    personaUsuario.CorreoElectronico = persona.CorreoElectronico;

                    personaUsuario.Usuario = new Models.Usuario() 
                    {
                        IdUsuario = user.IdUsuario,
                        Estado = user.Estado,
                        NombreUsuario = user.NombreUsuario
                    };

                }
            }

            return personaUsuario;
        }

        public bool CambioClave(Models.UsuarioClave usuario)
        {

            ModelsSQL.Usuario user = _loginData.ValidarUsuario(usuario.NombreUsuario, usuario.Clave);

            if (user != null)
            {
                user.Clave = usuario.NuevaClave;
                _loginData.CambioClave(user);
            }

            return true;
        }

    }
}
