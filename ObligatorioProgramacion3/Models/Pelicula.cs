using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProgramacion3.Models
{
    [Table("Peliculas")]
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre de la pelicula")]
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        [StringLength(150)]
        public string? Sinopsis { get; set; }
        public List<Proyeccion>? Proyecciones { get; set; }

    }
}
