using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticAPIEstadistica.ModelsSQL
{
    public partial class Persona
    {
        public string CorreoElectronico { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
