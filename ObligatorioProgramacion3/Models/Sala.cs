using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProgramacion3.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre de la sala")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar la cantidad de asientos")]
        public int Asientos { get; set; }
        public List<Proyeccion>? Proyecciones { get; set; }
    }
}
