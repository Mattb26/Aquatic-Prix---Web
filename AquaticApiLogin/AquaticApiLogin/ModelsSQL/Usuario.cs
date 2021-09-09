using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticApiLogin.ModelsSQL
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int Estado { get; set; }
    }
}
