using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public DateTime? Send { get; set; }
        public DateTime? Received { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }

        public string getSta()
        {
            string ret = "";
            switch (Status)
            {
                case 0: ret=  "On process";break;
                case 1: ret = "Check out"; break;
                case 2: ret = "Received"; break;
                default:
                    break;
            }
            return ret;
        }
        public virtual User UidNavigation { get; set; } = null!;
    }
}
