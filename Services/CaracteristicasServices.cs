using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;

namespace AstronomiaEjercicio.Services
{
    public interface ICaracteristicasService
    {
        Task<List<Caracteristicas>> GetAll();
        Task<Caracteristicas> GetCaracteristicas(int Id_Caracteristicas);
        Task<Caracteristicas> CreateCaracteristicas(string Caracteristica, int Id_TipoObjeto);
        Task<Caracteristicas> UpdateCaracteristicas(int Id_Caracteristicas, string? Caracteristica = null, int? Id_TiposObjetos = null);
        Task<string> DeleteCaracteristicas(int Id_Caracteristicas);
    }
    public class CaracteristicasService : ICaracteristicasService
    {
        private readonly ICaracteristicasRepository _caracteristicasRepository;

        public CaracteristicasService(ICaracteristicasRepository caracteristicasRepository)
        {
            _caracteristicasRepository = caracteristicasRepository;
        }

        public async Task<Caracteristicas> CreateCaracteristicas(string caracteristica, int id_TipoObjeto)
        {
            return await _caracteristicasRepository.CreateCaracteristicas(caracteristica, id_TipoObjeto);
        }
        public async Task<List<Caracteristicas>> GetAll()
        {
            return await _caracteristicasRepository.GetAll();
        }

        public async Task<Caracteristicas> GetCaracteristicas(int Id_Caracteristicas)
        {
            return await _caracteristicasRepository.GetCaracteristicas(Id_Caracteristicas);
        }
        public async Task<Caracteristicas> UpdateCaracteristicas(int IdCaracteristica, string? Caracteristica = null, int? Id_TiposObjetos = null)
        {
            Caracteristicas newCaracteristica = await _caracteristicasRepository.GetCaracteristicas(IdCaracteristica);
            if (newCaracteristica != null)
            {
                if(Caracteristica != null)
                {
                    newCaracteristica.Caracteristica = Caracteristica;
                }
                if(Id_TiposObjetos != null)
                {
                    newCaracteristica.Id_TiposObjetos = (int)Id_TiposObjetos;
                }
                return await _caracteristicasRepository.UpdateCaracteristicas(newCaracteristica);
            }
            throw new NotImplementedException();
        }
        public async Task<string> DeleteCaracteristicas(int Id_Caracteristica)
        {
            try
            {
                Caracteristicas caracteristicas = await _caracteristicasRepository.GetCaracteristicas(Id_Caracteristica);
                if (caracteristicas == null)
                {
                    return "No se encontro el registro";
                }
                await _caracteristicasRepository.DeleteCaracteristicas(caracteristicas);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error"; 
            }
        }

    }
}
