using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi1.Models;

namespace MyApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // list
        public static List<Student> listStudents = new List<Student>()
        {
            new Student(1,"Trieu Dinh Quang",21),
            new Student(2,"Vu Manh Hung",20),
            new Student(3,"Trieu  Quang",19),
        };
        //Get: api/Student/
        [HttpGet]
        public IActionResult GetStudent() => Ok(listStudents);

        //Get: api/Student/1
        [HttpGet("id")]
        public IActionResult SearchStudent(int code)
        {
            var stu = listStudents.Find(s => s.Code == code);
            if (stu == null) return NotFound();
            return Ok(stu);
        }

        //Post:api/Student
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var fin = listStudents.Find(s => s.Code == student.Code);
            if (fin != null) return BadRequest();
            listStudents.Add(student);
            return Ok(listStudents);
        }

        //Put:api/Student
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            var fin = listStudents.Find(s => s.Code == student.Code);
            if (fin == null) return NotFound();
            fin.Name = student.Name;
            fin.Age = student.Age;
            return Ok(listStudents);
        }
    }
}
