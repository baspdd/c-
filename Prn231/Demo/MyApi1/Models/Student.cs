namespace MyApi1.Models
{
    public class Student
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student()
        {

        }

        public Student(int code, string name, int age)
        {
            Code = code;
            Name = name;
            Age = age;
        }
    }
}
