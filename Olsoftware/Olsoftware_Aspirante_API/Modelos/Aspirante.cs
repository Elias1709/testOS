using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olsoftware_Aspirante_API.Modelos
{
    public class Aspirante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo identificacion es obligatorio.")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo nombres es obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo apellidos es obligatorio.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo email es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo celular es obligatorio.")]
        public string Celular { get; set; }

        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public string Clave { get; set; }

        public string EstadoPrueba { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "El campo calificacion es obligatorio.")]
        [Range(0, 100, ErrorMessage = "La calificación debe estar en el rango de 0 a 100.")]
        public decimal Calificacion { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
