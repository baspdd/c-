﻿using System;
using System.Collections.Generic;

namespace web.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string KeyId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public string RightAnswer { get; set; } = null!;

    public virtual Key Key { get; set; } = null!;

    public virtual ICollection<string> listAnswer { get; set; } = new List<string>();

    public List<string> GetAnswers(string answer) => answer.Split('/').ToList();


}
