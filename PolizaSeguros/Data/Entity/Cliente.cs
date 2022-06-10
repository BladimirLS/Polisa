using System;

namespace PolizaSeguros.Data.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
