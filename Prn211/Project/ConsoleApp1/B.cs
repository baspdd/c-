using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal record B:A
    {
        public B()
        {
            x++;
            y++;
        }

        public void Print() => Console.Write(".c");

    }
}
