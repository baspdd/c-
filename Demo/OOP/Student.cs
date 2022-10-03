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
        [Range(18, 30)]
        public int Age { get; set; }
        public Student() { }
        public Student(string code, string name, int age)
        {
            Code = code;
            Name = name;
            Age = age;
        }

        public override string? ToString()
        {
            return Code +"\t" + Name + "\t" + Age;
        }
    }
}