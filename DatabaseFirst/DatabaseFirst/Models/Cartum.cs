using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class Cartum
    {
        public int Id { get; set; }
        public int? IdRestaurant { get; set; }
        public string? Descripccion { get; set; }

        public virtual Restaurant? IdRestaurantNavigation { get; set; }
    }
}
