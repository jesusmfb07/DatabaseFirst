using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class ProductoVentum
    {
        public ProductoVentum()
        {
            Comprobantedetalles = new HashSet<Comprobantedetalle>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string? Receta { get; set; }

        public virtual ICollection<Comprobantedetalle> Comprobantedetalles { get; set; }
    }
}
