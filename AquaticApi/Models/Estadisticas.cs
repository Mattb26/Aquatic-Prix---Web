using System;

namespace AquaticApi.Models
{
    public class Estadisticas
    {
        public string NombreUsuario { get; set; }
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
