using System;
using System.Collections.Generic;

namespace web.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<Key> Keys { get; set; } = new List<Key>();
}
