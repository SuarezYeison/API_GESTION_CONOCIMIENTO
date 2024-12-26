using System.ComponentModel.DataAnnotations;

namespace API_GESTION_CONOCIMIENTO.Models
{
    public class Medicamento
    {
        [Key]
        public int IdMedicamento { get; set; }
        public string NombreM { get; set; }
    }
}
