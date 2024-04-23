using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface IObservacionesRepository
    {
        Task<List<Observaciones>> GetAll();
        Task<Observaciones> GetObservaciones(int Id_Observacion);
        Task<Observaciones> CreateObservaciones(string Coordenadas, string Magnitud, DateTime Fecha, int Id_Telescopio, int Id_TipoObjeto, int Id_Observador);
        Task<Observaciones> UpdateObservaciones(Observaciones observaciones);
        Task<bool> DeleteObservaciones(Observaciones observaciones);
    }
    public class ObservacionesRepository : IObservacionesRepository
    {
        private readonly CaracteristicasDbContext _db;

        public ObservacionesRepository(CaracteristicasDbContext db)
        {
            _db = db;
        }

        public async Task<Observaciones> CreateObservaciones(string coordenadas, string magnitud, DateTime fecha, int id_telescopio, int id_tipoObjeto, int id_observador)
        {

            Observaciones newObservaciones = new Observaciones
            {
                Coordenadas = coordenadas,
                Magnitud = magnitud,
                Fecha = fecha,
                Id_Telescopio = id_telescopio,
                Id_TipoObjeto = id_tipoObjeto,
                Id_Observador = id_observador,
            };

            await _db.Observacion.AddAsync(newObservaciones);

            _db.SaveChanges();
            return newObservaciones;
        }

        public async Task<List<Observaciones>> GetAll()
        {
            return await _db.Observacion.ToListAsync();
        }

        public async Task<Observaciones> GetObservaciones(int Id_Observacion)
        {
            return await _db.Observacion.FirstOrDefaultAsync(c => c.Id_Observacion == Id_Observacion);
        }

        public async Task<Observaciones> UpdateObservaciones(Observaciones observaciones)
        {
            Observaciones ConsultaUpdate = await _db.Observacion.Where(o => o.Id_Observacion == observaciones.Id_Observador).FirstOrDefaultAsync();
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.Coordenadas = observaciones.Coordenadas;
                ConsultaUpdate.Magnitud = observaciones.Magnitud;
                ConsultaUpdate.Fecha = observaciones.Fecha;
                ConsultaUpdate.Id_Telescopio = observaciones.Id_Telescopio;
                ConsultaUpdate.Id_TipoObjeto = observaciones.Id_TipoObjeto;
                ConsultaUpdate.Id_Observador = observaciones.Id_Observador;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }
        public async Task<bool> DeleteObservaciones(Observaciones observaciones)
        {
            _db.Observacion.Remove(observaciones);
            int affectedRows = await _db.SaveChangesAsync();
            return affectedRows > 0;
        }

    }
}
