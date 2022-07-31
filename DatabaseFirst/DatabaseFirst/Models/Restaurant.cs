using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Carta = new HashSet<Cartum>();
            Pedidos = new HashSet<Pedido>();
            Proveedors = new HashSet<Proveedor>();
            Trabajadors = new HashSet<Trabajador>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Cartum> Carta { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        public virtual ICollection<Trabajador> Trabajadors { get; set; }
    }
}
