using System;
using System.Collections.Generic;

namespace web.Models;

public partial class ExamAnswer
{
    public int ExamAnswer1 { get; set; }

    public int ExamId { get; set; }

    public string RightRightAnswer { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;
}
