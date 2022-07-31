using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Trabajador
    {
        public Trabajador()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Edad { get; set; }
        public int? Dni { get; set; }
        public int? IdRestaurant { get; set; }
        public int? IdCargo { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual Restaurant? IdRestaurantNavigation { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
