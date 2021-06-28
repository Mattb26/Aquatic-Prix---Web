using System;

namespace AquaticApi.Models
{
    public class Estadistica
    {
        public Int32 idUsuario { get; set; }
        public int IdEstadistica { get; set; }
        public int Posicion { get; set; }
        public int Perdido { get; set; }
        public int PromedioPerdidas { get; set; }
        public int Baja { get; set; }
        public int Caidas { get; set; }
        public int PromedioBaja { get; set; }
        public int PromedioCaidas { get; set; }
        public DateTime Fecha { get; set; }
    }
}
