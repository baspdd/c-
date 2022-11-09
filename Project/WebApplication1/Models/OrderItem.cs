using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int ProId { get; set; }
        public int Amount { get; set; }

        public virtual Order OidNavigation { get; set; } = null!;
        public virtual Product Pro { get; set; } = null!;

        public Product get()
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                Product product = new Product();
                product = context.Products.FirstOrDefault(p => p.Id == ProId);
                return product;
            }
        }
    }
}
