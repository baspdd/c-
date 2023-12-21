using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ExamAnswerDTO
{
    public int ExamAnswer1 { get; set; }

    public int ExamId { get; set; }

    public string RightRightAnswer { get; set; } = null!;
 
}
