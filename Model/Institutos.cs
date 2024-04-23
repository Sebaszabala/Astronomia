using System.ComponentModel.DataAnnotations;

namespace AstronomiaEjercicio.Model
{
    public class Institutos
    {
        [Key]
        public int Id_Instituto {  get; set; }
        public required string NombreInstituto { get; set; }
    }
}
