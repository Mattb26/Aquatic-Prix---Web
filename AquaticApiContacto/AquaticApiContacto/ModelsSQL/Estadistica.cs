using System;
using System.Collections.Generic;

#nullable disable

namespace AquaticApiContacto.ModelsSQL
{
    public partial class Estadistica
    {
        public int IdEstadistica { get; set; }
        public int Posicion { get; set; }
        public int Perdido { get; set; }
        public int PromedioPartidas { get; set; }
        public int Bajas { get; set; }
        public int Caidas { get; set; }
        public int Promediobaja { get; set; }
        public int PromedioCaidas { get; set; }
        public DateTime Fecha { get; set; }
    }
}
