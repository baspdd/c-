using test1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            service.Default();

            while (true)
            {
                Console.WriteLine("1.Add List");
                Console.WriteLine("2.Show List");
                Console.WriteLine("3.Filter");
                Console.WriteLine("4.Sort");
                Console.WriteLine("0.Exit");
                
                int option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            service.Add();
                            break;
                        }
                    case 2:
                        {
                            service.ShowList();
                            break;
                        }
                    case 3:
                        {
                           service.FindCoursesBetweenDate();
                            break;
                        }
                    case 4:
                        {
                            service.SortCourses();
                            break;
                        }
                    default:
                        break;
                }
            }
        }


    }
}