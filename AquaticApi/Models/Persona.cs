using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Models
{
    public class Persona
    {
        public Int32 IdPersona { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}
