using System;
using System.Collections.Generic;

namespace web.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public int Type { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
