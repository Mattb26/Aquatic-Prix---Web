using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticAPIToken.ModelsSQL
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Asunto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
