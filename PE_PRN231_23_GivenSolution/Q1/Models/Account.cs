using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Account
    {
        public Account()
        {
            Exams = new HashSet<Exam>();
        }

        public string AccountId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FullName { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
