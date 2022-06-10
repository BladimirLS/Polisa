using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolizaSeguros.Models
{
    public class ClienteModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        public PlanModels Plan { get; set; }

    }
}
