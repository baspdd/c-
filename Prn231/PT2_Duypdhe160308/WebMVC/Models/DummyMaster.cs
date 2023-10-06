using System;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public partial class DummyMaster
    {
        public int masterId { get; set; }
        public string masterName { get; set; } = null!;

        public virtual ICollection<DummyDetail> dummyDetails { get; set; }
    }
}
