using Olsoftware_Aspirante_API.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olsoftware_PruebaSeleccion_API.Modelos.Dto
{
    public class PruebaSeleccionDto
    {
        [Key]
        public int Id { get; set; }

        public string NombrePrueba { get; set; }

        [Required]
        public int AspiranteId { get; set; }
        [ForeignKey("AspiranteId")]
        public Aspirante Aspirante { get; set; }

        [Required(ErrorMessage = "El campo fecha de inicio es obligatorio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo fecha de finalizacion es obligatorio.")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El campo tipo de prueba es obligatorio.")]
        public string TipoPrueba { get; set; }

        [Required(ErrorMessage = "El campo lenguaje de programacion es obligatorio.")]
        public string LenguajeProgramacion { get; set; }

        [Required(ErrorMessage = "El campo cantidad de preguntas es obligatorio.")]
        [Range(1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero")]
        public int CantidadPreguntas { get; set; }

        [Required(ErrorMessage = "El campo nivel de prueba es obligatorio.")]
        public string NivelPrueba { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
