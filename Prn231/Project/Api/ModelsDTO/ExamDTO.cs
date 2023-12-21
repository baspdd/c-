using Api.Models;
using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ExamDTO
{
    public int ExamId { get; set; }

    public string AccountName { get; set; } = null!;

    public string? Score { get; set; }

}
