using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;

namespace AstronomiaEjercicio.Services
{
    public interface IObservacionesService
    {
        Task<List<Observaciones>> GetAll();
        Task<Observaciones> GetObservaciones(int Id_Observacion);
        Task<Observaciones> CreateObservaciones(string Coordenadas, string Magnitud, DateTime Fecha, int Id_Telescopio, int Id_TipoObjeto, int Id_Observador);
        Task<Observaciones> UpdateObservaciones(int Id_Observacion, string? Coordenadas = null, string? Magnitud = null, DateTime? Fecha = null, int? Id_Telescopio = null, int? Id_TipoObjeto = null, int? Id_Observador = null);
        Task<string> DeleteObservaciones(int Id_Observacion);
    }
    public class ObservacionesService : IObservacionesService
    {
        private readonly IObservacionesRepository _observacionesRepository;

        public ObservacionesService(IObservacionesRepository observacionesRepository)
        {
            _observacionesRepository = observacionesRepository;
        }

        public async Task<Observaciones> CreateObservaciones(string coordenadas, string magnitud, DateTime fecha, int id_telescopio, int id_tipoObjeto, int id_observador)
        {
            return await _observacionesRepository.CreateObservaciones(coordenadas, magnitud, fecha, id_telescopio, id_tipoObjeto, id_observador);
        }
        public async Task<List<Observaciones>> GetAll()
        {
            return await _observacionesRepository.GetAll();
        }

        public async Task<Observaciones> GetObservaciones(int Id_Observacion)
        {
            return await _observacionesRepository.GetObservaciones(Id_Observacion);
        }
        public async Task<Observaciones> UpdateObservaciones(int Id_Observacion, string? Coordenadas = null, string? Magnitud = null, DateTime? Fecha = null, int? Id_Telescopio = null, int? Id_TipoObjeto = null, int? Id_Observador = null)
        {
            Observaciones newObservacion = await _observacionesRepository.GetObservaciones(Id_Observacion);
            if (newObservacion != null)
            {
                if (Coordenadas != null)
                {
                    newObservacion.Coordenadas = Coordenadas;
                }
                if (Magnitud != null)
                {
                    newObservacion.Magnitud = Magnitud;
                }
                if (Fecha != null)
                {
                    newObservacion.Fecha = (DateTime)Fecha;
                }
                if (Id_Telescopio != null)
                {
                    newObservacion.Id_Telescopio = (int)Id_Telescopio;
                }
                if (Id_TipoObjeto != null)
                {
                    newObservacion.Id_TipoObjeto = (int)Id_TipoObjeto;
                }
                if (Id_Observador != null)
                {
                    newObservacion.Id_Observador = (int)Id_Observador;
                }
                return await _observacionesRepository.UpdateObservaciones(newObservacion);
            }
            throw new NotImplementedException();
        }
        public async Task<string> DeleteObservaciones(int Id_Observacion)
        {
            try
            {
                Observaciones observaciones = await _observacionesRepository.GetObservaciones(Id_Observacion);
                if (observaciones == null)
                {
                    return "No se encontro el registro";
                }
                await _observacionesRepository.DeleteObservaciones(observaciones);
                return "Registro eliminado";
            }
            catch (Exception ex)
            {
                return "Se produjo un error";
            }
        }
    }
}
