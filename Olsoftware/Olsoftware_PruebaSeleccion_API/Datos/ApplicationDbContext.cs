using Microsoft.EntityFrameworkCore;
//using Olsoftware_Aspirante_API.Modelos;
using Olsoftware_PruebaSeleccion_API.Modelos;

namespace Olsoftware_PruebaSeleccion_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PruebaSeleccion> PruebaSeleccions { get; set; }

        

    }
}
