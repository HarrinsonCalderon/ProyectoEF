using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace ProyectoEF.Models
{
    public class Categoria
    {
        //Llave primaria,
        [Key]
        public Guid CategoriaId { get; set; }
        //Requerido
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
         

        //Para hacer los saltos con las foraneas y traer la informacion de las Tareas, osea Categorita 1:n Tarea, con ello obtengo las tareas a la que esta enlazada esta categoria

        public int Peso { get; set; }

        //al momento que traiga los datos no traiga la coleccion de tareas cuando se haga el include con tareas y categoria
        [JsonIgnore]

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
