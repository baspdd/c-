using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Question
    {
        public int questionId { get; set; }
        public string keyId { get; set; } = null!;
        public string content { get; set; } = null!;
        public string answer { get; set; } = null!;
        public string rightAnswer { get; set; } = null!;

        public virtual Key key { get; set; } = null!;
    }
}
