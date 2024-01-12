using Microsoft.EntityFrameworkCore;
using Olsoftware_Aspirante_API.Modelos;

namespace Olsoftware_Aspirante_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Aspirante> Aspirantes { get; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspirante>().HasData(
            new Aspirante()
            {
                Id = 1,
                Identificacion = "789654",
                Nombres = "Ana Maria",
                Apellidos = "Paz Mena",
                Email = "ana@gmail.com",
                Celular = "1223345",
                Direccion = "Calle Luna",
                Clave = "123uju",
                EstadoPrueba = "Proceso",
                Calificacion = 74,
                Usuario = "ana@gmail.com",
                FechaActualizacion = DateTime.Now

            }
            );
        }
    }
}
