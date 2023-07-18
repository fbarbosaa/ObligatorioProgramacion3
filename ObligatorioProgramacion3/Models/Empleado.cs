using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProgramacion3.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre del empleado")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar el apellido del empleado")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar el cargo del empleado")]
        public string? Cargo { get; set; }
        public List<Proyeccion>? Proyecciones { get; set; }
    }
}
