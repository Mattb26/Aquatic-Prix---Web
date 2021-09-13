using System.ComponentModel.DataAnnotations;

namespace AquaticApiLogin.Models
{
    public class UsuarioClave: Usuario
    {
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string NuevaClave { get; set; }
    }
}
