using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class Student
    {
        [Required(AllowEmptyStrings = false,ErrorMessage ="String is not empty")]
        public string code { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "String is not empty")]
        public string name { get; set; }
        [Range(0,10)]
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
