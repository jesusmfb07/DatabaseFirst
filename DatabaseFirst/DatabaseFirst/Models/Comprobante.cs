using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            Comprobantedetalles = new HashSet<Comprobantedetalle>();
        }

        public int Id { get; set; }
        public DateTime? Fechas { get; set; }
        public int? Idcliente { get; set; }
        public int? MedioDePago { get; set; }
        public int? Tipo { get; set; }
        public int? VentaTotal { get; set; }
        public int? IdTrabajador { get; set; }

        public virtual Trabajador? IdTrabajadorNavigation { get; set; }
        public virtual Cliente? IdclienteNavigation { get; set; }
        public virtual ICollection<Comprobantedetalle> Comprobantedetalles { get; set; }
    }
}
