using System;
using System.Collections.Generic;

namespace web.Models;

public partial class QuestionAnswer
{
    public string Content { get; set; }

    public bool Ticked { get; set; } = false;

}
