using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int ProId { get; set; }
        public int Amount { get; set; }

        public virtual Order OidNavigation { get; set; } = null!;
        public virtual Product Pro { get; set; } = null!;
    }
}
