using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface IObservadoresRepository
    {
        Task<List<Observadores>> GetAll();
        Task<Observadores> GetObservadores(int Id_Observador);
        Task<Observadores> CreateObservadores(string Nombre, string Instituto, string Correo, int Id_Instituto);
        Task<Observadores> UpdateObservadores(Observadores observadores);
        Task<bool> DeleteObservadores(Observadores observadores);
    }
    public class ObservadoresRepository : IObservadoresRepository
    {
        private readonly CaracteristicasDbContext _db;

        public ObservadoresRepository(CaracteristicasDbContext db)
        {
            _db = db;
        }

        public async Task<Observadores> CreateObservadores(string nombre, string instituto, string correo, int id_instituto)
        {

            Observadores newObservadores = new Observadores
            {
                Nombre = nombre,
                Instituto = instituto,
                Correo = correo,
                Id_Instituto = id_instituto,
            };

            await _db.Observador.AddAsync(newObservadores);

            _db.SaveChanges();
            return newObservadores;
        }

        public async Task<List<Observadores>> GetAll()
        {
            return await _db.Observador.ToListAsync();
        }

        public async Task<Observadores> GetObservadores(int Id_Observador)
        {
            return await _db.Observador.FirstOrDefaultAsync(c => c.Id_Observador == Id_Observador);
        }

        public async Task<Observadores> UpdateObservadores(Observadores observadores)
        {
            Observadores ConsultaUpdate = await _db.Observador.Where(o => o.Id_Observador == observadores.Id_Observador).FirstOrDefaultAsync();
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.Nombre = observadores.Nombre;
                ConsultaUpdate.Instituto = observadores.Instituto;
                ConsultaUpdate.Correo = observadores.Correo;
                ConsultaUpdate.Id_Instituto = observadores.Id_Instituto;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }
        public async Task<bool> DeleteObservadores(Observadores observadores)
        {
            _db.Observador.Remove(observadores);
            int affectedRows = await _db.SaveChangesAsync();
            return affectedRows > 0;
        }

    }
}
