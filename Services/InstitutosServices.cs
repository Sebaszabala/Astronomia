using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;
using System.Runtime.CompilerServices;

namespace AstronomiaEjercicio.Services
{
    public interface IInstitutosServices
    {
        Task<List<Institutos>> GetAll();
        Task<Institutos> GetInstitutos(int Id_Instituto);
        Task<Institutos> CreateInstitutos(string NombreInstituto);
        Task<Institutos> UpdateInstitutos(int Id_Instituto, string? NombreInstituto = null);
        Task<String> DeleteInstitutos(int Id_Instituto);
    }
    public class InstitutosService : IInstitutosServices
    {
        private readonly IInstitutosRepository _institutosRepository;
        public InstitutosService(IInstitutosRepository institutosRepository)
        {
            _institutosRepository = institutosRepository;
        }
        public async Task<Institutos> CreateInstitutos(string NombreInstituto)
        {
            return await _institutosRepository.CreateInstitutos(NombreInstituto);
        }
        public async Task<List<Institutos>> GetAll()
        {
            return await _institutosRepository.GetAll();
        }
        public async Task<Institutos> GetInstitutos(int Id_Instituto)
        {
            return await _institutosRepository.GetInstitutos(Id_Instituto);
        }
        public async Task<Institutos> UpdateInstitutos(int Id_Instituto, string? NombreInstituto = null)
        {
            Institutos newInstituto = await _institutosRepository.GetInstitutos(Id_Instituto);
            if (newInstituto != null) 
            {
                if(NombreInstituto != null)
                {
                    newInstituto.NombreInstituto = NombreInstituto;
                }
                return await _institutosRepository.UpdateInstitutos(newInstituto);
            }
            throw new NotImplementedException();  
        }
        public async Task<string> DeleteInstitutos(int Id_Instituto)
        {
            try
            {
                Institutos institutos = await _institutosRepository.GetInstitutos(Id_Instituto);
                if (institutos == null)
                {
                    return "No se encontro el registro";
                }
                await _institutosRepository.DeleteInstitutos(institutos);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error";
            }
        }
    }
}
