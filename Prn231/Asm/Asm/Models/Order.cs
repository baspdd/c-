using System;
using System.Collections.Generic;

namespace Asm.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
