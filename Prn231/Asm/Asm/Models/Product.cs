using System;
using System.Collections.Generic;

namespace Asm.Models
{
    public partial class Product
    {
        public Product()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public double? Weight { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
