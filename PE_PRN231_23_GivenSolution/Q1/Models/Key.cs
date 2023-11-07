using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Key
    {
        public Key()
        {
            Exams = new HashSet<Exam>();
            Questions = new HashSet<Question>();
        }

        public string KeyId { get; set; } = null!;
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
