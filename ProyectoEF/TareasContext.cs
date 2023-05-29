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

        }//Metodo para configurar los modelos en lugar de hacer con las tablas o modelos
        //Esto es fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Datos iniciales a la tabla categoria
            List<Categoria> categoriasInit=new List<Categoria>();
            categoriasInit.Add(new Categoria { CategoriaId= Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d746b"),Nombre="Actividades pendientes",Peso=20 });
            categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d7402"), Nombre = "Actividades personales", Peso = 50 });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                //Nombre de la tabla
                categoria.ToTable("Categoria");
                //llave primaria
                categoria.HasKey(p=>p.CategoriaId);
                //Poniendo validaciones
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion);

                categoria.Property(p => p.Peso);
                //Para insertar datos inciales a categoria, "semillas"
                categoria.HasData(categoriasInit);

            });
            List<Tarea> TareasInit = new List<Tarea>();
            TareasInit.Add(new Tarea { TareaId = Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d7410"),CategoriaId=Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d746b"),PrioridadTarea=Prioridad.Media,Titulo="Pago de servicios publicos",FechaCreacion=DateTime.Now });
            TareasInit.Add(new Tarea { TareaId = Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d7411"), CategoriaId = Guid.Parse("804d0754-53e7-498e-90d8-b7ccf34d7402"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar serie de Disney", FechaCreacion = DateTime.Now });
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                //foranea con categoria 1:n tarea 
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                //Para no mapear este campo
                tarea.Ignore(p => p.Resumen);

                tarea.HasData(TareasInit);
                
            });
        }

    }
}
