using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProgramacion3.Models
{
    [Table("Proyecciones")]
    public class Proyeccion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar la fecha de la pelicula")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Debe ingresar la hora de la pelicula")]
        public TimeSpan Hora { get; set; }
        [ForeignKey("Pelicula")]
        public int IdPelicula { get; set; }
        public Pelicula? Pelicula { get; set; }
        [ForeignKey("Sala")]
        public int IdSala { get; set; }
        public Sala? Sala { get; set; }
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

    } 
}
