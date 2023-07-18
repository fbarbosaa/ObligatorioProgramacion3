using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProgramacion3.Models
{
    [Table("Proyecciones")]
    public class Proyeccion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre de la pelicula")]
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        [StringLength(150)]
        public string? Sinopsis { get; set; }
        [ForeignKey("Pelicula")]
        public int PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
