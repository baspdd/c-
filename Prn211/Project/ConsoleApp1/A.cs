using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal record A
    {
        public int x { get; set; } = 1;
        public int y { get; set; } = 2;
        public void Print() => Console.Write($"{x},{y}");
       

    }
}
