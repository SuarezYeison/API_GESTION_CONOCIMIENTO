using API_GESTION_CONOCIMIENTO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_GESTION_CONOCIMIENTO.Data
{
    public class GestionConocimientoDbContext : DbContext
    {
        public GestionConocimientoDbContext(DbContextOptions<GestionConocimientoDbContext> options) : base(options)
        {

        }

        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
    }
}
