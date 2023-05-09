using System;
using System.Collections.Generic;

namespace OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            //list.Add(new Student("1", "Nguyen Van A", 18));
            //list.Add(new Student("2", "Nguyen Van B", 18));
            //list.Add(new Student("3", "Nguyen Van C", 18));
            //list.Add(new Student("4", "Nguyen Van D", 18));
            //list.Add(new Student("5", "Nguyen Van E", 18));
            //list.Add(new Student("6", "Nguyen Van F", 18));
            IManager manage = new Manager(list);
            while (true)
            {
                Console.WriteLine("1.Add List");
                Console.WriteLine("2.Show List");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Remove");
                Console.WriteLine("5.Save to file");
                Console.WriteLine("6.Load from file");
                Console.WriteLine("7.Report");
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
                            manage.Add();
                            break;
                        }
                    case 2:
                        {
                            manage.showList();
                            break;
                        }
                    case 3:
                        {
                            manage.Update();
                            break;
                        }
                    case 4:
                        {
                            manage.Remove();
                            break;
                        }
                    case 5:
                        {
                            manage.SaveFile();
                            break;
                        }
                    case 6:
                        {
                            manage.loadFile();
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        
    }
}