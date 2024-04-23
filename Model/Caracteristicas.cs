using System.ComponentModel.DataAnnotations;
namespace AstronomiaEjercicio.Model
{
    public class Caracteristicas
    {
        [Key]
        public int Id_Caracteristicas { get; set; }
        public required string Caracteristica{ get; set; }
        public required int Id_TiposObjetos { get; set; }
        public Tipos_Objetos? Tipos_Objetos { get; set; }

    }
}
