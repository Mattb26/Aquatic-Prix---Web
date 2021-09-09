using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticApiLogin.Models
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
