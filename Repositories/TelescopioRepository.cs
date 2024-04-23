using AstronomiaEjercicio.Context;
using AstronomiaEjercicio.Model;
using AstronomiaEjercicio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AstronomiaEjercicio.Repositories
{
    public interface ITelescopioRepository
    {
        Task<List<Telescopio>> GetAll();
        Task<Telescopio> GetTelescopio(int Id_telescopio);
        Task<Telescopio> CreateTelescopio(string NombreTelescopio, string Ubicacion, string Diametro);
        Task<Telescopio> UpdateTelescopio(Telescopio telescopio);
        Task<bool> DeleteTelescopio(Telescopio telescopio);
    }
}
public class TelescopioRepository : ITelescopioRepository
{
    private readonly CaracteristicasDbContext _db;

    public TelescopioRepository(CaracteristicasDbContext db)
    {
        _db = db;
    }

    public async Task<Telescopio> CreateTelescopio(string nombretelescopio, string ubicacion, string diametro)
    {

        Telescopio newTelescopio = new Telescopio
        {
            NombreTelescopio = nombretelescopio,
            Ubicacion = ubicacion,
            Diametro = diametro,
        };

        await _db.Telescopios.AddAsync(newTelescopio);

        _db.SaveChanges();
        return newTelescopio;
    }

    public async Task<List<Telescopio>> GetAll()
    {
        return await _db.Telescopios.ToListAsync();
    }

    public async Task<Telescopio> GetTelescopio(int Id_telescopio)
    {
        return await _db.Telescopios.FirstOrDefaultAsync(c => c.Id_telescopio == Id_telescopio);
    }

    public async Task<Telescopio> UpdateTelescopio(Telescopio telescopio)
    {
        Telescopio ConsultaUpdate = await _db.Telescopios.Where(t => t.Id_telescopio == telescopio.Id_telescopio).FirstOrDefaultAsync();
        if (ConsultaUpdate != null)
        {
            ConsultaUpdate.NombreTelescopio = telescopio.NombreTelescopio;
            ConsultaUpdate.Ubicacion = telescopio.Ubicacion;
            ConsultaUpdate.Diametro = telescopio.Diametro;
            await _db.SaveChangesAsync();
        }
        return ConsultaUpdate;
    }
    public async Task<bool> DeleteTelescopio(Telescopio telescopio)
    {
        _db.Telescopios.Remove(telescopio);
        int affectedRows = await _db.SaveChangesAsync();
        return affectedRows > 0;
    }

}
