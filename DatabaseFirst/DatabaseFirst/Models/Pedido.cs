using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Idproveedor { get; set; }
        public int? Idrestaurant { get; set; }

        public virtual Proveedor? IdproveedorNavigation { get; set; }
        public virtual Restaurant? IdrestaurantNavigation { get; set; }
    }
}
