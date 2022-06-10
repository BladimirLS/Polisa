using System.ComponentModel.DataAnnotations;

namespace PolizaSeguros.Models
{
    public class SeguroModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public MetodoPago MetodoPago { get; }
    }
}
