using System;
using System.Collections.Generic;

namespace MyApi2.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; } = null!;
        public bool Display { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
