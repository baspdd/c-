using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    internal class Service
    {
        public List<Course> Courses = new List<Course>();

        public void Default() {
            DateTime date1 = new DateTime(2015, 12, 25);
            Courses.Add(new Course(1, "Java", date1));
            Courses.Add(new Course(2, "Javsa", date1));
            Courses.Add(new Course(3, "Javccca", date1));
        }
        public void Add()
        {
            while (true)
            {
                Console.WriteLine("Enter course  information");

                Course course = new Course();
                Console.Write("Enter course ID: ");
                course.ID = Int32.Parse(Console.ReadLine());
                Console.Write("Enter course title: ");
                course.Title = Console.ReadLine();
                Console.Write("Enter course start date: ");
                course.Startdate = DateTime.Parse(Console.ReadLine());
                Courses.Add(course);

                Console.Write("Do you want to enter the next course information(Y/N)?");
                if (Console.ReadLine().Equals("Y"))
                {
                    continue;
                }
                break;
            }
        }

        public void ShowList()
        {
            Show(Courses);
        }
        private void Show(List<Course> Courses)
        {
            Courses.ForEach((course) => Console.WriteLine(course.ToString()));
        }

        public void FindCoursesBetweenDate()
        {
            Console.Write("Enter course start date: ");
            DateTime start = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter course start date: ");
            DateTime end = DateTime.Parse(Console.ReadLine());
            List<Course> verifiedCourses = Courses.FindAll(course => course.Startdate >= start && course.Startdate <= end).ToList();
            Show(verifiedCourses);
        }

        public void SortCourses()
        {
            List<Course> verifiedCourses = Courses.OrderBy(c => c.Title).ToList();
            Show(verifiedCourses);
        }

    }
}
