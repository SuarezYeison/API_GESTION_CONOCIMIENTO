using System.ComponentModel.DataAnnotations;

namespace API_GESTION_CONOCIMIENTO.Models
{
    public class Tratamiento
    {
        [Key]
        public int IdTratamiento { get; set; }
        public string NombreT { get; set; }
    }
}
