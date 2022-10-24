using Microsoft.AspNetCore.Mvc;
using webApp.Models;
namespace webApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Student student)
        {
            // truyền dữ liệu
            //C1 - viewData
            ViewData["message"] = "Đây là cách sử dụng viewdata";
            ViewData["data"] = new Student
            {
                code = "sv1",
                name = "hehe",
                mark = 5
            };

            //C2 - viewBag
            ViewBag.MSG = "Đây là cách sử dụng viewBag";
            ViewBag.Data2 = new Student("sv2","hihi",6);

            // C3 - Model
            return View(student);
        }
        public IActionResult Add()
        {
            return View();
        }
        static List<Student> list = new List<Student>();
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)//Tạo model thành công
            {
                list.Add(student);
                ViewBag.Data = list;
                return View("ListStudent",student);
            }
            return View();
        }
        public IActionResult Detail(string code)
        {
           Student student = list.FirstOrDefault(item=>item.code == code);
            return RedirectToAction("Index",student);
        }
        public IActionResult Delete(string code)
        {
            Student student = list.FirstOrDefault(item => item.code == code);
            list.Remove(student);   
            ViewBag.Data = list;
            return View("ListStudent",student);
        }

        public IActionResult Update(string code)
        {
            Student student = list.FirstOrDefault(item => item.code == code);
            return View("Update", student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)//Tạo model thành công
            {
                Student stu = list.FirstOrDefault(item => item.code == student.code);
                stu.name = student.name;
                stu.mark = student.mark;
                ViewBag.Data = list;
                return View("ListStudent", student);
            }
            return View();
        }
    }
}
