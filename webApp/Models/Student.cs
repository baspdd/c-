namespace webApp.Models
{
    public class Student
    {
        public string code { get; set; }
        public string name { get; set; }
        public int mark { get; set; }

        public Student(string code, string name, int mark)
        {
            this.code = code;
            this.name = name;
            this.mark = mark;
        }

        public Student()
        {
        }

        public override string? ToString()
        {
            return code + '\t'+name+"\t"+ mark;
        }
    }
}
