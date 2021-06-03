using System.ComponentModel.DataAnnotations;

namespace AquaticApi.Models
{
    public class Contacto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Asunto { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required]
        public int Mensaje { get; set; }
        

    }
}
