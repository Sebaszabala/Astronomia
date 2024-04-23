using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class CaracteriticasController : ControllerBase
    {
        private readonly ICaracteristicasService _caracteristicasservice;

        public CaracteriticasController(ICaracteristicasService caracteristicasService)
        {
            _caracteristicasservice = caracteristicasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Caracteristicas>>> GetAll()
        {
            return Ok(await _caracteristicasservice.GetAll());
        }
        [HttpGet("{Id_Caracteristicas}")]

        public async Task<ActionResult<Caracteristicas>> GetCaracteriticas(int Id_Caracteristicas)
        {
            var Caracteristic = await _caracteristicasservice.GetCaracteristicas(Id_Caracteristicas);
            if (Caracteristic == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(Caracteristic);
        }

        [HttpPost]
        public async Task<ActionResult<Caracteristicas>> CreateCaracteristicas([FromBody] Caracteristicas caracteristicas)
        {
            if (caracteristicas == null)
            {
                return BadRequest("El objeto Crops es nulo");
            }
            var newcarateriticas = await _caracteristicasservice.CreateCaracteristicas(caracteristicas.Caracteristica , caracteristicas.Id_Caracteristicas);
            return Ok(newcarateriticas);
        }

        [HttpPut("{Id_Caracteristicas}")]
        public async Task<ActionResult<Caracteristicas>> UpdateCaracteristicas(int Id_Caracteristicas, [FromBody] Caracteristicas UpdateCaracteristicas)
        {
            if (UpdateCaracteristicas == null || Id_Caracteristicas <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Crops");
            }
            var updateCaracteristicas = await _caracteristicasservice.UpdateCaracteristicas(Id_Caracteristicas, UpdateCaracteristicas.Caracteristica);
            return Ok(updateCaracteristicas);
        }
        [HttpDelete("{Id_Caracteristicas}")]
        public async Task<ActionResult<Caracteristicas>> DeleteCaracteristicas(int Id_Caracteristicas)
        {
            if (Id_Caracteristicas <= 0)
            {
                return BadRequest("Id_Caracteristicas es invalido para eliminar");
            }
            var DeletedCaracteristicas = await _caracteristicasservice.DeleteCaracteristicas(Id_Caracteristicas);
            return Ok(DeletedCaracteristicas);
        }
    }


}