using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebMVC.Models
{
    public partial class DummyDetail
    {
        public int detailId { get; set; }
        public string detailName { get; set; } = null!;
        public int masterId { get; set; }

        public virtual DummyMaster master { get; set; } = null!;

        public override bool Equals(object obj)
        {
            if (obj is DummyDetail other)
            {
                return detailId == other.detailId &&
                       detailName == other.detailName &&
                       masterId == other.masterId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(detailId, detailName, masterId);
        }
    }
}
