using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class QuestionDTO
{
    public int QuestionId { get; set; }

    public string KeyId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Answer { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RightAnswer { get; set; } = null!;

    public int NumberRightAnswer { get; set; }

    //public virtual KeyDTO Key { get; set; } = null!;

    public virtual ICollection<QuestionAnswerDTO> listAnswer
        => Answer.Split('/').Select((answer, index) => new QuestionAnswerDTO { Id = ++index, Content = answer, Ticked = false }).ToList();
}
