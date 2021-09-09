using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticApiLogin.ModelsSQL
{
    public partial class PersonaUsuario
    {
        public int IdUsuarioPersona { get; set; }
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
