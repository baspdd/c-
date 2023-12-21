using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class QuestionAnswerDTO
{
    public int Id { get; set; }
    public string Content { get; set; }

    public bool Ticked { get; set; } = false;

}
