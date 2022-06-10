using System.ComponentModel.DataAnnotations;

namespace PolizaSeguros.Models
{
    public class PlanModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public double Dues { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public SeguroModels Seguro { get; set; }
    }
}
