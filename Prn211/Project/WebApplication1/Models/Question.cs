﻿namespace WebApplication1.Models
{
    public class Question
    {
        public Question(int index,string question, string answer1, string answer2, string answer3, string answer4, int correct)
        {
            this.index = index;
            this.question = question;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.correct = correct;
        }
        public int index { get; set; }
        public string question { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }

        public int correct { get; set; }
    }
}
