using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Course
    {
        public Course()
        {
            Keys = new HashSet<Key>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;

        public virtual ICollection<Key> Keys { get; set; }
    }
}
