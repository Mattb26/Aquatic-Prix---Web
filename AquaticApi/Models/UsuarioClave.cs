using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Models
{
    public class UsuarioClave:Usuario
    {
        [Required]
        [DataType(DataType.Password)]
        public string ClaveNueva { get; set; }
    }
}
