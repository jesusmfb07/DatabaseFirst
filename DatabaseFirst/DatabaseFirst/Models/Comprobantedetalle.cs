using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Comprobantedetalle
    {
        public int IdComprobante { get; set; }
        public int IdProductoVenta { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Subtotal { get; set; }

        public virtual Comprobante IdComprobanteNavigation { get; set; } = null!;
        public virtual ProductoVentum IdProductoVentaNavigation { get; set; } = null!;
    }
}
