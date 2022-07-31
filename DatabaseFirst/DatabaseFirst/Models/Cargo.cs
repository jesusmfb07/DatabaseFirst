using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Trabajadors = new HashSet<Trabajador>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal? Salario { get; set; }

        public virtual ICollection<Trabajador> Trabajadors { get; set; }
    }
}
