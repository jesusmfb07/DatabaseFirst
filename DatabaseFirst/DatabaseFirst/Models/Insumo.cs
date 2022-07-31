using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Insumo
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Proveedor? IdProveedorNavigation { get; set; }
    }
}
