using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class ObservacionesController : ControllerBase
    {
        private readonly IObservacionesService _observacionesService;

        public ObservacionesController(IObservacionesService observacionesService)
        {
            _observacionesService = observacionesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Observaciones>>> GetAll()
        {
            return Ok(await _observacionesService.GetAll());
        }
        [HttpGet("{Id_Observacion}")]

        public async Task<ActionResult<Observaciones>> GetObservaciones(int Id_Observacion)
        {
            var observacion = await _observacionesService.GetObservaciones(Id_Observacion);
            if (observacion == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(observacion);
        }

        [HttpPost]
        public async Task<ActionResult<Observaciones>> CreateObservaciones([FromBody] Observaciones observaciones)
        {
            if (observaciones == null)
            {
                return BadRequest("El objeto Observacio es nulo");
            }
            var newObservacion = await _observacionesService.CreateObservaciones (observaciones.Coordenadas, observaciones.Magnitud, observaciones.Fecha, observaciones.Id_Telescopio, observaciones.Id_TipoObjeto, observaciones.Id_Observador);
            return Ok(newObservacion);
        }

        [HttpPut("{Id_Observacion}")]
        public async Task<ActionResult<Observaciones>> UpdateObservaciones(int Id_Observacion, [FromBody] Observaciones UpdateObservaciones)
        {
            if (UpdateObservaciones == null || Id_Observacion <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Observacion");
            }
            var updateObservaciones = await _observacionesService.UpdateObservaciones (Id_Observacion, UpdateObservaciones.Coordenadas, UpdateObservaciones.Magnitud ,UpdateObservaciones.Fecha, UpdateObservaciones.Id_Telescopio , UpdateObservaciones.Id_TipoObjeto , UpdateObservaciones.Id_Observador);
            return Ok(updateObservaciones);
        }
        [HttpDelete("{Id_Observacion}")]
        public async Task<ActionResult<Observaciones>> DeleteObservaciones(int Id_Observacion)
        {
            if (Id_Observacion <= 0)
            {
                return BadRequest("Id_Observacion es invalido para eliminar");
            }
            var DeletedObservaciones = await _observacionesService.DeleteObservaciones(Id_Observacion);
            return Ok(DeletedObservaciones);
        }
    }


}