using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Insumos = new HashSet<Insumo>();
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Idrestaurant { get; set; }

        public virtual Restaurant? IdrestaurantNavigation { get; set; }
        public virtual ICollection<Insumo> Insumos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
