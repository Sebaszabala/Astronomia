using System.ComponentModel.DataAnnotations;

namespace AstronomiaEjercicio.Model
{
    public class Observaciones
    {
        [Key]
        public int Id_Observacion {  get; set; }
        public required string Coordenadas { get; set; }
        public required string Magnitud { get; set; }
        public required DateTime Fecha { get; set; }
        public required int Id_Telescopio { get; set; }
        public Telescopio? Telescopio {  get; set; }
        public required int Id_TipoObjeto { get; set; }
        public Tipos_Objetos? Tipos_Objetos { get; set; }
        public required int Id_Observador { get; set; }
        public Observadores? Observadores { get; set; }
    }
}
