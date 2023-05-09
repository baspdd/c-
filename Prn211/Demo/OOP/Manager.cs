using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP
{
    public class Manager : IManager
    {
        public bool V { get; }
        public List<Student> List { get; }

        public Manager()
        {
        }


        public Manager(List<Student> list)
        {
            List = list;
        }

        public void SaveFile()
        {
            try
            {
                String fileName = @"..\\..\\..\\Data.txt";
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var item in List)
                    {
                        sw.WriteLine(item);
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Save file error :" + e.Message);
            }
        }
        public void Update()
        {
            String code = Console.ReadLine();
            Student student = find(code);
            if (student != null)
            {
                Console.WriteLine("input info");
                String name = Console.ReadLine();
                int age = Convert.ToInt32(Console.ReadLine());
                student.Name = name;
                student.Age = age;
                showList();
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        private Student find(string? code)
        {
            foreach (var item in List)
            {
                if (item.Code.Equals(code))
                {
                    return item;
                }
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            String code = Console.ReadLine().ToUpper();
            while (checkDup(code))
            {
                Console.WriteLine("re input code");
                code = Console.ReadLine().ToUpper();
            }
            String name = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            List.Add(new Student(code, name, age));
        }

        private bool checkDup(string code)
        {
            foreach (var item in List)
            {
                if (item.Code.Equals(code))
                {
                    return true;
                }
            }
            return false;
        }

        public void showList()
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }

        public void loadFile()
        {
            List.Clear();
            try
            {
                String fileName = @"..\\..\\..\\Data.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    String s = sr.ReadLine().Trim();
                    while (s != null)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            String[] a = s.Split('\t');
                            if (a.Length == 3 && Regex.Match(a[2], "[0-9]").Success && !checkDup(a[0]))
                            {
                                String code = a[0];
                                String name = a[1];
                                int age = Convert.ToInt32(a[2]);
                                List.Add((Student)new Student(code, name, age));
                            }

                        }
                        s = sr.ReadLine();
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine("load file error :" + e.Message);
            }
        }
    }
}