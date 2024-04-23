using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Services;

namespace AstronomiaEjercicio.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class InstituosController : ControllerBase
    {
        private readonly IInstitutosServices _institutosServices;

        public InstituosController(IInstitutosServices institutosServices)
        {
            _institutosServices = institutosServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Institutos>>> GetAll()
        {
            return Ok(await _institutosServices.GetAll());
        }
        [HttpGet("{Id_Instituto}")]

        public async Task<ActionResult<Institutos>> GetInstitutos(int Id_Instituto)
        {
            var institut = await _institutosServices.GetInstitutos(Id_Instituto);
            if (institut == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(institut);
        }

        [HttpPost]
        public async Task<ActionResult<Institutos>> CreateInstitutos([FromBody] Institutos institutos)
        {
            if (institutos == null)
            {
                return BadRequest("El objeto instituto es nulo");
            }
            var newInstitutos = await _institutosServices.CreateInstitutos(institutos.NombreInstituto);
            return Ok(newInstitutos);
        }

        [HttpPut("{Id_Instituto}")]
        public async Task<ActionResult<Institutos>> UpdateInstitutos(int Id_Instituto, [FromBody] Institutos UpdateInstitutos)
        {
            if (UpdateInstitutos == null || Id_Instituto <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Instituto");
            }
            var updateInstitutos = await _institutosServices.UpdateInstitutos(Id_Instituto, UpdateInstitutos.NombreInstituto);
            return Ok(updateInstitutos);
        }
        [HttpDelete("{Id_Instituto}")]
        public async Task<ActionResult<Institutos>> DeleteInstitutos(int Id_Instituto)
        {
            if (Id_Instituto <= 0)
            {
                return BadRequest("Id_Instituto es invalido para eliminar");
            }
            var DeletedInstitutos = await _institutosServices.DeleteInstitutos(Id_Instituto);
            return Ok(DeletedInstitutos);
        }
    }


}
