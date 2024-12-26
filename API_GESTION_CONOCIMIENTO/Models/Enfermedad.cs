using System.ComponentModel.DataAnnotations;

namespace API_GESTION_CONOCIMIENTO.Models
{
    public class Enfermedad
    {
        [Key]
        public int IdEnfermedad { get; set; }
        public string NombreE { get; set; }
    }
}
