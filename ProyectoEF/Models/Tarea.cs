using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoEF.Models
{
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }
        //Para agregar la foranea
        [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; } //foranea de categoria
        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }
        //Evitar que este campo se mapee
        [NotMapped]
        public string Resumen { get; set; }

        //Para hacer los saltos con las foraneas y traer la informacion de categoria, osea Categorita 1:n Tarea, con ello obtengo la categoria a la que esta enlazada esta tarea
         
        public virtual Categoria Categoria { get; set; }

        
    }

    public enum Prioridad {
     Baja,Media,Alta
    
    }
}
