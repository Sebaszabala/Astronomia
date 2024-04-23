using System.ComponentModel.DataAnnotations;

namespace AstronomiaEjercicio.Model
{
    public class Telescopio
    {
        [Key]
        public int Id_telescopio { get; set; }
        public required string NombreTelescopio {  get; set; }
        public required string Ubicacion {  get; set; }
        public required string Diametro {  get; set; }
    }
}
