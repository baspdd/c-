using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class CourseDTO
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<KeyDTO> Keys { get; set; } = new List<KeyDTO>();
}
