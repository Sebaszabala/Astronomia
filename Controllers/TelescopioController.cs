using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class TelescopioController : ControllerBase
    {
        private readonly ITelescopioService _telescopioService;

        public TelescopioController(ITelescopioService telescopioService)
        {
            _telescopioService = telescopioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Telescopio>>> GetAll()
        {
            return Ok(await _telescopioService.GetAll());
        }
        [HttpGet("{Id_telescopio}")]

        public async Task<ActionResult<Telescopio>> GetTelescopio(int Id_telescopio)
        {
            var telescop = await _telescopioService.GetTelescopio(Id_telescopio);
            if (telescop == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(telescop);
        }

        [HttpPost]
        public async Task<ActionResult<Telescopio>> CreateTelescopio([FromBody] Telescopio telescopio)
        {
            if (telescopio == null)
            {
                return BadRequest("El objeto telescopio es nulo");
            }
            var newtelescopio = await _telescopioService.CreateTelescopio (telescopio.NombreTelescopio, telescopio.Ubicacion, telescopio.Diametro);
            return Ok(newtelescopio);
        }

        [HttpPut("{Id_telescopio}")]
        public async Task<ActionResult<Telescopio>> UpdateTelescopio(int Id_telescopio, [FromBody] Telescopio UpdateTelescopio)
        {
            if (UpdateTelescopio == null || Id_telescopio <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Telescopio");
            }
            var updateTelescopio = await _telescopioService.UpdateTelescopio (Id_telescopio, UpdateTelescopio.NombreTelescopio , UpdateTelescopio.Ubicacion , UpdateTelescopio.Diametro);
            return Ok(updateTelescopio);
        }
        [HttpDelete("{Id_telescopio}")]
        public async Task<ActionResult<Telescopio>> DeleteTelescopio(int Id_telescopio)
        {
            if (Id_telescopio <= 0)
            {
                return BadRequest("Id_telescopio es invalido para eliminar");
            }
            var DeletedTelescopio = await _telescopioService.DeleteTelescopio(Id_telescopio);
            return Ok(DeletedTelescopio);
        }
    }


}
