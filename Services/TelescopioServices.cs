using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;

namespace AstronomiaEjercicio.Services
{
    public interface ITelescopioService
    {
        Task<List<Telescopio>> GetAll();
        Task<Telescopio> GetTelescopio(int Id_telescopio);
        Task<Telescopio> CreateTelescopio(string NombreTelescopio, string Ubicacion, string Diametro);
        Task<Telescopio> UpdateTelescopio(int Id_telescopio, string? NombreTelescopio = null, string? Ubicacion = null, string? Diametro = null);
        Task<string> DeleteTelescopio(int Id_telescopio);
    }
    public class TelescopioService : ITelescopioService
    {
        private readonly ITelescopioRepository _telescopioRepository;

        public TelescopioService(ITelescopioRepository telescopioRepository)
        {
            _telescopioRepository = telescopioRepository;
        }

        public async Task<Telescopio> CreateTelescopio(string nombretelescopio, string ubicacion, string diametro)
        {
            return await _telescopioRepository.CreateTelescopio(nombretelescopio, ubicacion, diametro);
        }
        public async Task<List<Telescopio>> GetAll()
        {
            return await _telescopioRepository.GetAll();
        }

        public async Task<Telescopio> GetTelescopio(int Id_telescopio)
        {
            return await _telescopioRepository.GetTelescopio(Id_telescopio);
        }
        public async Task<Telescopio> UpdateTelescopio(int Id_telescopio, string? NombreTelescopio = null, string? Ubicacion = null, string? Diametro = null)
        {
            Telescopio newTelescopio = await _telescopioRepository.GetTelescopio(Id_telescopio);
            if (newTelescopio != null)
            {
                if (NombreTelescopio != null)
                {
                    newTelescopio.NombreTelescopio = NombreTelescopio;
                }
                if (Ubicacion != null)
                {
                    newTelescopio.Ubicacion = Ubicacion;
                }
                if (Diametro != null)
                {
                    newTelescopio.Diametro = Diametro;
                }
                return await _telescopioRepository.UpdateTelescopio(newTelescopio);
            }
            throw new NotImplementedException();
        }
        public async Task<string> DeleteTelescopio(int Id_telescopio)
        {
            try
            {
                Telescopio telescopio = await _telescopioRepository.GetTelescopio(Id_telescopio);
                if (telescopio == null)
                {
                    return "No se encontro el registro";
                }
                await _telescopioRepository.DeleteTelescopio(telescopio);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error";
            }
        }
    }
}
