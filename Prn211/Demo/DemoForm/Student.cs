using System.ComponentModel.DataAnnotations;

namespace OOP
{
    public class Student
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "String can not empty")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "String can not empty")]
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "String can not empty")]
        public String Subject { get; set; }
        [Range(0, 10)]
        public int Mark { get; set; }
        public Student() { }

        public Student(string code, string name, string subject, int mark)
        {
            Code = code;
            Name = name;
            Subject = subject;
            Mark = mark;
        }

        public override string? ToString()
        {
            return Code+"\t"+Name+"\t"+Subject+"\t"+Mark;   
        }
    }
}