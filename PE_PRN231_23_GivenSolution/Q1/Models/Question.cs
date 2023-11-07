using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string KeyId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public string RightAnswer { get; set; } = null!;

        public virtual Key Key { get; set; } = null!;
    }
}
