using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticApiLogin.ModelsSQL
{
    public partial class UsuarioEstadistica
    {
        public int Id { get; set; }
        public int Idusuario { get; set; }
        public int Idestadistica { get; set; }
        public DateTime Fechaalta { get; set; }
    }
}
