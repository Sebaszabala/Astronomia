using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface ITipos_ObjetosRepository
    {
        Task<List<Tipos_Objetos>> GetAll();
        Task<Tipos_Objetos> GetTipos_Objetos(int Id_TiposObjetos);
        Task<Tipos_Objetos> CreateTipos_Objetos(string Nombre);
        Task<Tipos_Objetos> UpdateTipos_Objetos(Tipos_Objetos tipos_Objetos);
        Task<bool> DeleteTipos_Objetos(Tipos_Objetos tipos_Objetos);
    }
    public class Tipos_ObjetosRepository : ITipos_ObjetosRepository
    {
        private readonly CaracteristicasDbContext _db;

        public Tipos_ObjetosRepository(CaracteristicasDbContext db)
        {
            _db = db;
        }

        public async Task<Tipos_Objetos> CreateTipos_Objetos(string nombre)
        {
            Tipos_Objetos newTipos_Objetos = new Tipos_Objetos
            {
                Nombre = nombre,
            };

            await _db.Tipo_Objeto.AddAsync(newTipos_Objetos);

            _db.SaveChanges();
            return newTipos_Objetos;
        }

        public async Task<List<Tipos_Objetos>> GetAll()
        {
            return await _db.Tipo_Objeto.ToListAsync();
        }

        public async Task<Tipos_Objetos> GetTipos_Objetos(int Id_TiposObjetos)
        {
            return await _db.Tipo_Objeto.FirstOrDefaultAsync(c => c.Id_TiposObjetos == Id_TiposObjetos);
        }

        public async Task<Tipos_Objetos> UpdateTipos_Objetos(Tipos_Objetos tipos_Objetos)
        {
            Tipos_Objetos ConsultaUpdate = await _db.Tipo_Objeto.Where(T => T.Id_TiposObjetos == tipos_Objetos.Id_TiposObjetos).FirstOrDefaultAsync();
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.Nombre = tipos_Objetos.Nombre;

                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }
        public async Task<bool> DeleteTipos_Objetos(Tipos_Objetos tipos_Objetos)
        {
            _db.Tipo_Objeto.Remove(tipos_Objetos);
            int affectedRows = await _db.SaveChangesAsync();
            return affectedRows > 0;
        }

    }
}
