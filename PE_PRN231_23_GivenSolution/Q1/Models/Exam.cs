using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamAnswers = new HashSet<ExamAnswer>();
        }

        public int ExamId { get; set; }
        public string AccountId { get; set; } = null!;
        public string KeyId { get; set; } = null!;
        public string? Score { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Key Key { get; set; } = null!;
        public virtual ICollection<ExamAnswer> ExamAnswers { get; set; }
    }
}
