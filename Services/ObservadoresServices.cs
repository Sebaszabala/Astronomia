using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;

namespace AstronomiaEjercicio.Services
{
    public interface IObservadoresService
    {
        Task<List<Observadores>> GetAll();
        Task<Observadores> GetObservadores(int Id_Observador);
        Task<Observadores> CreateObservadores(string Nombre, string Instituto, string Correo, int Id_Instituto);
        Task<Observadores> UpdateObservadores(int Id_Observador, string? Nombre = null, string? Instituto = null, string? Correo = null, int? Id_Instituto = null);
        Task<string> DeleteObservadores(int Id_Observador);
    }
    public class ObservadoresService : IObservadoresService
    {
        private readonly IObservadoresRepository _observadoresRepository;

        public ObservadoresService(IObservadoresRepository observadoresRepository)
        {
            _observadoresRepository = observadoresRepository;
        }

        public async Task<Observadores> CreateObservadores(string nombre, string instituto, string correo, int id_instituto)
        {
            return await _observadoresRepository.CreateObservadores(nombre, instituto, correo, id_instituto);
        }
        public async Task<List<Observadores>> GetAll()
        {
            return await _observadoresRepository.GetAll();
        }

        public async Task<Observadores> GetObservadores(int Id_Observador)
        {
            return await _observadoresRepository.GetObservadores(Id_Observador);
        }
        public async Task<Observadores> UpdateObservadores(int Id_Observador, string? Nombre = null, string? Instituto = null, string? Correo = null, int? Id_Instituto = null)
        {
            Observadores newObservador = await _observadoresRepository.GetObservadores(Id_Observador);
            if (newObservador != null)
            {
                if (Nombre != null)
                {
                    newObservador.Nombre = Nombre;
                }
                if (Instituto != null)
                {
                    newObservador.Instituto = Instituto;
                }
                if (Correo != null)
                {
                    newObservador.Correo = Correo;
                }
                if (Id_Instituto != null)
                {
                    newObservador.Id_Instituto = (int)Id_Instituto;
                }
                return await _observadoresRepository.UpdateObservadores(newObservador);
            }
            throw new NotImplementedException();
        }
        public async Task<string> DeleteObservadores(int Id_Observador)
        {
            try
            {
                Observadores observadores = await _observadoresRepository.GetObservadores(Id_Observador);
                if (observadores == null)
                {
                    return "No se encontro el registro";
                }
                await _observadoresRepository.DeleteObservadores(observadores);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error";
            }
        }
    }
}
