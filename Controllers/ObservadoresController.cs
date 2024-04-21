using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class ObservadoresController : ControllerBase
    {
        private readonly IObservadoresService _observadoresService;

        public ObservadoresController(IObservadoresService observadoresService)
        {
            _observadoresService = observadoresService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Observadores>>> GetAll()
        {
            return Ok(await _observadoresService.GetAll());
        }
        [HttpGet("{Id_Observador}")]

        public async Task<ActionResult<Observadores>> GetObservadores(int Id_Observador)
        {
            var observador = await _observadoresService.GetObservadores (Id_Observador);
            if (observador == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(observador);
        }

        [HttpPost]
        public async Task<ActionResult<Observadores>> CreateObservadores([FromBody] Observadores observadores)
        {
            if (observadores == null)
            {
                return BadRequest("El objeto observadores es nulo");
            }
            var newObservador = await _observadoresService.CreateObservadores(observadores.Nombre, observadores.Instituto , observadores.Correo , observadores.Id_Instituto );
            return Ok(newObservador);
        }

        [HttpPut("{Id_Observador}")]
        public async Task<ActionResult<Observadores>> UpdateObservadores(int Id_Observador, [FromBody] Observadores UpdateObservadores)
        {
            if (UpdateObservadores == null || Id_Observador <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Observacion");
            }
            var updateObservadores = await _observadoresService.UpdateObservadores (Id_Observador, UpdateObservadores.Nombre, UpdateObservadores.Instituto, UpdateObservadores.Correo, UpdateObservadores.Id_Instituto);
            return Ok(updateObservadores);
        }
        [HttpDelete("{Id_Observador}")]
        public async Task<ActionResult<Observadores>> DeleteObservadores(int Id_Observador)
        {
            if (Id_Observador <= 0)
            {
                return BadRequest("Id_Observacion es invalido para eliminar");
            }
            var DeletedObservador = await _observadoresService.DeleteObservadores(Id_Observador);
            return Ok(DeletedObservador);
        }
    }


}
