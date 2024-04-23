using System.ComponentModel.DataAnnotations;
namespace AstronomiaEjercicio.Model
{
    public class Tipos_Objetos
    {
        [Key]
        public int Id_TiposObjetos { get; set; }
        public required string Nombre { get; set; }
    }
}
