using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Ruc { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
