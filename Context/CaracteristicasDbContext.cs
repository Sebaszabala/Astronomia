using Microsoft.EntityFrameworkCore;
using AstronomiaEjercicio.Model;
using System.ComponentModel.DataAnnotations;

namespace AstronomiaEjercicio.Context
{
    public class CaracteristicasDbContext : DbContext
    {
        public CaracteristicasDbContext(DbContextOptions<CaracteristicasDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         /*   modelBuilder.Entity<Caracteristicas>()
                .HasKey(Caracteristicas => Caracteristicas.Id_Caracteristicas);
            /*modelBuilder.Entity<Observadores>()
                .HasKey(Observadores => Observadores.Id_Observador);

            modelBuilder.Entity<Institutos>()
                .HasKey(Institutos => Institutos.Id_Instituto);
            modelBuilder.Entity<Caracteristicas>()
                .HasKey(Caracteristicas => Caracteristicas.Id_Caracteristicas);

            modelBuilder.Entity<Observaciones>()
                .HasKey(Observaciones => Observaciones.Id_Observacion);

            modelBuilder.Entity<Telescopio>()
                .HasKey(Telescopio => Telescopio.Id_telescopio);

            modelBuilder.Entity<Tipos_Objetos>()
                .HasKey(Tipos_Objetos => Tipos_Objetos.Id_TiposObjetos);*/
        }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Institutos> Instituto { get; set; }
        public DbSet<Observaciones> Observacion { get; set; }
        public DbSet<Observadores> Observador { get; set;}
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Tipos_Objetos> Tipo_Objeto { get; set; }
    }
}
