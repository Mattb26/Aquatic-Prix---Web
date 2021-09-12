using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticAPIUsuario.Models
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        public int Estado { get; set; }
    }
}
