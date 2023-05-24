using Microsoft.EntityFrameworkCore;
using ProyectoEF.Models;

namespace ProyectoEF
{
    public class TareasContext:DbContext
    {
        //Para crear la tabla en la bd
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        //Crear el metodo base del contructor de entity framework
        public TareasContext(DbContextOptions<TareasContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            
        }

    }
}
