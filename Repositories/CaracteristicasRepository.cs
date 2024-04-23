using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface ICaracteristicasRepository 
    {
        Task<List<Caracteristicas>>GetAll();
        Task<Caracteristicas> GetCaracteristicas(int Id_Caracteristicas);
        Task<Caracteristicas> CreateCaracteristicas(string Caracteristica, int Id_TiposObjetos);
        Task<Caracteristicas> UpdateCaracteristicas(Caracteristicas caracteristicas);
        Task<bool> DeleteCaracteristicas(Caracteristicas caracteristicas);

    }
    public class CaracteristicasRepository : ICaracteristicasRepository
    {
        private readonly CaracteristicasDbContext _db;

        public CaracteristicasRepository(CaracteristicasDbContext db)
        {
            _db = db;
        }

        public async Task<Caracteristicas> CreateCaracteristicas(string caracteristica, int id_TiposObjetos)
        {

            Caracteristicas newCaracteristicas = new Caracteristicas
            {
                Caracteristica = caracteristica,
                Id_TiposObjetos = id_TiposObjetos,
            };
            
            await _db.Caracteristicas.AddAsync(newCaracteristicas);

            _db.SaveChanges();
            return newCaracteristicas;
        }

        public async Task<List <Caracteristicas>> GetAll()
        {
            return await _db.Caracteristicas.ToListAsync();
        }

        public async Task<Caracteristicas> GetCaracteristicas(int Id_Caracteristicas)
        {
            return await _db.Caracteristicas.FirstOrDefaultAsync(c => c.Id_Caracteristicas == Id_Caracteristicas);
        }

        public async Task<Caracteristicas> UpdateCaracteristicas(Caracteristicas caracteristicas)
        {
            Caracteristicas ConsultaUpdate = await _db.Caracteristicas.FirstOrDefaultAsync(c => c.Id_Caracteristicas == caracteristicas.Id_Caracteristicas);
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.Caracteristica = caracteristicas.Caracteristica;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }
        public async Task<bool> DeleteCaracteristicas(Caracteristicas caracteristicas)
        {
            _db.Caracteristicas.Remove(caracteristicas); 
            int affectedRows = await _db.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
