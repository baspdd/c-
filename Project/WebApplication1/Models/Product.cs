using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string getType()
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                Category category = new Category();
                category = context.Categories.FirstOrDefault(p => p.Id == Type);
                return category.Name;
            }
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int? IsSale { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }

        public virtual Category TypeNavigation { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
