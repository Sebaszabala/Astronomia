using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface IInstitutosRepository
    {
        Task<List<Institutos>> GetAll();
        Task<Institutos> GetInstitutos(int Id_Instituto);
        Task<Institutos> CreateInstitutos(string NombreInstituto);
        Task<Institutos> UpdateInstitutos(Institutos institutos);
        Task<bool> DeleteInstitutos(Institutos intitutos);
    }
    public class InstitutosRepository : IInstitutosRepository
    {
        private readonly CaracteristicasDbContext _db;

        public InstitutosRepository(CaracteristicasDbContext db)
        {
            _db = db;
        }

        public async Task<Institutos> CreateInstitutos(string nombreinstituto)
        {
            Institutos newInstitutos = new Institutos
            {
                NombreInstituto = nombreinstituto,
            };

            await _db.Instituto.AddAsync(newInstitutos);

            _db.SaveChanges();
            return newInstitutos;
        }
        public async Task<List <Institutos>> GetAll()
        {
            return await _db.Instituto.ToListAsync();
        }

        public async Task<Institutos> GetInstitutos(int Id_Instituto)
        {
            return await _db.Instituto.FirstOrDefaultAsync(i => i.Id_Instituto == Id_Instituto);
        }

        public async Task<Institutos> UpdateInstitutos(Institutos institutos)
        {
            Institutos ConsultaUpdate = await _db.Instituto.FirstOrDefaultAsync(i => i.Id_Instituto == institutos.Id_Instituto);
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.NombreInstituto = institutos.NombreInstituto;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }
        public async Task<bool> DeleteInstitutos(Institutos institutos)
        {
            _db.Instituto.Remove(institutos);
            int affectedRows = await _db.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}

