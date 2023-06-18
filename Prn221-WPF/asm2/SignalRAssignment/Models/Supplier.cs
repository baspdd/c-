using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public string SupplierId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
