using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticAPIToken.ModelsSQL
{
    public partial class UsuarioEstadistica
    {
        public int Id { get; set; }
        public int Idusuario { get; set; }
        public int Idestadistica { get; set; }
        public DateTime Fechaalta { get; set; }
    }
}
