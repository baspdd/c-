using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Startdate { get; set; }

        public Course()
        {
            
        }
        public Course(int id , string title , DateTime startdate)
        {
            ID = id;
            Title = title;
            Startdate = startdate;
        }

        public override string? ToString()
        {
            return ID.ToString() +' '+ Title +' '+ Startdate.ToString();
        }
    }
}
