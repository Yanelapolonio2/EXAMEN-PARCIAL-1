using Microsoft.EntityFrameworkCore;
using EXAMEN_PARCIAL.Models; // Asegúrate de que este 'using' esté presente para usar los modelos Curso y Docente

namespace EXAMEN_PARCIAL.Data
{
    public class AppDbContext : DbContext
    {
        // DbSet para Curso
        public DbSet<Curso> Cursos { get; set; }

        // DbSet para Docente
        public DbSet<Docente> Docentes { get; set; }

        // Constructor que recibe opciones de configuración
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
