using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class Tipos_ObjetosController : ControllerBase
    {
        private readonly ITipos_ObjetosService _tipos_ObjetosService;

        public Tipos_ObjetosController(ITipos_ObjetosService tipos_ObjetosService)
        {
            _tipos_ObjetosService = tipos_ObjetosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tipos_Objetos>>> GetAll()
        {
            return Ok(await _tipos_ObjetosService.GetAll());
        }
        [HttpGet("{Id_TiposObjetos}")]

        public async Task<ActionResult<Tipos_Objetos>> GetTipos_Objetos(int Id_TiposObjetos)
        {
            var tipos_Obje = await _tipos_ObjetosService.GetTipos_Objetos(Id_TiposObjetos);
            if (tipos_Obje == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(tipos_Obje);
        }

        [HttpPost]
        public async Task<ActionResult<Tipos_Objetos>> CreateTipos_Objetos([FromBody] Tipos_Objetos tipos_Objeto)
        {
            if (tipos_Objeto == null)
            {
                return BadRequest("El objeto tipos_Objeto es nulo");
            }
            var newTipo_objeto = await _tipos_ObjetosService.CreateTipos_Objetos(tipos_Objeto.Nombre);
            return Ok(newTipo_objeto);
        }

        [HttpPut("{Id_TiposObjetos}")]
        public async Task<ActionResult<Tipos_Objetos>> UpdateTelescopio(int Id_TiposObjetos, [FromBody] Tipos_Objetos UpdateTipos_Objetos)
        {
            if (UpdateTipos_Objetos == null || Id_TiposObjetos <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Telescopio");
            }
            var updateTipos_Objetos = await _tipos_ObjetosService.UpdateTipos_Objetos(Id_TiposObjetos, UpdateTipos_Objetos.Nombre);
            return Ok(updateTipos_Objetos);
        }

        [HttpDelete("{Id_TiposObjetos}")]
        public async Task<ActionResult<Tipos_Objetos>> DeleteTipo_Objetos(int Id_TiposObjetos)
            {
                if (Id_TiposObjetos <= 0)
                {
                    return BadRequest("Id_telescopio es invalido para eliminar");
                }
                var DeletedTelescopio = await _tipos_ObjetosService.DeleteTipos_Objetos(Id_TiposObjetos);
                return Ok(DeletedTelescopio);
        }
    }
}