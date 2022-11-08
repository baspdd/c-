using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ASM.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int? IsSale { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }

        public virtual Category TypeNavigation { get; set; } = null!;
        public string getType()
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                Category category = new Category();
                category = context.Categories.FirstOrDefault(p => p.Id == Type);
                return category.Name;
            }
        }
    }
}
