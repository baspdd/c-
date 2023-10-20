using System;
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

    public virtual ICollection<QuestionAnswer> listAnswer { get; set; } = new List<QuestionAnswer>();

    public int numberRightAnswer { get; set; }

    public List<QuestionAnswer> GetAnswers(string answer)
    {
        List<QuestionAnswer> answerList = new List<QuestionAnswer>();
        var list = answer.Split('/').ToList();
        list.ForEach(answer => answerList.Add(new QuestionAnswer() { Content = answer }));
        return answerList;
    }

    public int GetNumberAnswers(string right) => right.Split('/').ToList().Count();
}
