using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;

namespace AstronomiaEjercicio.Services
{
    public interface ITipos_ObjetosService
    {
        Task<List<Tipos_Objetos>> GetAll();
        Task<Tipos_Objetos> GetTipos_Objetos(int Id_TiposObjetos);
        Task<Tipos_Objetos> CreateTipos_Objetos(string Nombre);
        Task<Tipos_Objetos> UpdateTipos_Objetos(int Id_TiposObjetos, string? Nombre = null);
        Task<string> DeleteTipos_Objetos(int Id_TiposObjetos);
    }
    public class Tipos_ObjetosService : ITipos_ObjetosService
    {
        private readonly ITipos_ObjetosRepository _tipos_objetosRepository;

        public Tipos_ObjetosService(ITipos_ObjetosRepository tipos_objetosRepository)
        {
            _tipos_objetosRepository = tipos_objetosRepository;
        }

        public async Task<Tipos_Objetos> CreateTipos_Objetos(string nombre)
        {
            return await _tipos_objetosRepository.CreateTipos_Objetos(nombre);
        }
        public async Task<List<Tipos_Objetos>> GetAll()
        {
            return await _tipos_objetosRepository.GetAll();
        }

        public async Task<Tipos_Objetos> GetTipos_Objetos(int Id_TiposObjetos)
        {
            return await _tipos_objetosRepository.GetTipos_Objetos(Id_TiposObjetos);
        }
        public async Task<Tipos_Objetos> UpdateTipos_Objetos(int Id_TiposObjetos, string? Nombre = null)
        {
            Tipos_Objetos newTipos_Objetos = await _tipos_objetosRepository.GetTipos_Objetos(Id_TiposObjetos);
            if (newTipos_Objetos != null)
            {
                if (Nombre != null)
                {
                    newTipos_Objetos.Nombre = Nombre;
                }
                return await _tipos_objetosRepository.UpdateTipos_Objetos(newTipos_Objetos);
            }
            throw new NotImplementedException();
        }
        public async Task<string> DeleteTipos_Objetos(int Id_TiposObjetos)
        {
            try
            {
                Tipos_Objetos tipos_Objetos = await _tipos_objetosRepository.GetTipos_Objetos(Id_TiposObjetos);
                if (tipos_Objetos == null)
                {
                    return "No se encontro el registro";
                }
                await _tipos_objetosRepository.DeleteTipos_Objetos(tipos_Objetos);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error";
            }
        }
    }
}
