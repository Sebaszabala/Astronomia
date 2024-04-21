using System.ComponentModel.DataAnnotations;

namespace AstronomiaEjercicio.Model
{
    public class Observadores
    {
        [Key]
        public int Id_Observador { get; set; }
        public required string Nombre { get; set; }
        public required string Instituto { get; set; }
        public required string Correo { get; set; }
        public required int Id_Instituto { get; set; }
        public Institutos? Institutos {  get; set; }
    }
}
