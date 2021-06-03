using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Models
{
    public class Contacto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(500)]
        public string Mensaje { get; set; }
        

    }
}
