using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string SupplierId { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public int QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
