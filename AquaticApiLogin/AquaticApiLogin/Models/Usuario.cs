using System;
using System.ComponentModel.DataAnnotations;

namespace AquaticApiLogin.Models
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string Clave { get; set; }
        public int Estado { get; set; }
    }
}
